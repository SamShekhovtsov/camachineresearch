using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.Sdl;

namespace CA.UI
{
    unsafe partial class CellFieldUI : Form
    {
        #region -- Native Win32 Functions --
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr SetParent(IntPtr child, IntPtr newParent);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr handle, ShowWindowCommand command);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetWindowPos(IntPtr handle, IntPtr handleAfter, int x, int y, int cx, int cy, SetWindowPosFlags flags);

        private enum ShowWindowCommand : int
        {
            SW_HIDE = 0,
            SW_SHOW = 5,
            SW_SHOWNA = 8,
            SW_SHOWNORMAL = 1,
            SW_SHOWMAXIMIZED = 3
        }

        private enum SetWindowPosFlags : uint
        {
            SWP_SHOWWINDOW = 0x0400,
            SWP_NOSIZE = 0x0001
        }
        #endregion

        #region -- Configuration for custom cells size --

        private IntPtr _backgroundImageSdlSurface;
        private IntPtr _workingBufferSdlSurface;
        private Dictionary<UInt32, IntPtr> _imagesForCustomCellSize;
        Sdl.SDL_Rect _coloredCellRect;
        Sdl.SDL_Rect _fullScreenSpaceRect;
        #endregion

        private IntPtr _m_SdlWindowHandle;
        private IntPtr _m_SdlSurface;
        private Panel _m_SdlPanel;
        private IntPtr _SdlScreenPixelBuffer;
        private IntPtr _SdlScreenPixelFormat;
        private Sdl.SDL_Event _sdlEvent;

        private int pos = 0;
        private bool appIsRunned = true;

        private void InitializeSdlComponents()
        {
            // Create the Panel which will hold the SDL Window
            _m_SdlPanel = new Panel();
            _m_SdlPanel.Size = new Size(700, 700);
            _m_SdlPanel.Location = new Point(218, 78);

            // Add the Controls
            this.Controls.Add(_m_SdlPanel);

            // Create the SDL WIndow
            CreateSdlWindow();
            RunSdlEventHandlingMechanism();
            /*
            IntPtr processWindowHandle = FindWindow( null, "Untitled - Notepad" );
            SetParent( processWindowHandle, panel.Handle );
            ShowWindow( processWindowHandle, ShowWindowCommand.SW_SHOWMAXIMIZED );
            */
        }

        private void RunSdlEventHandlingMechanism()
        {
            Thread eventReceiver = new Thread(CatchSdlEvents);
            eventReceiver.Priority = ThreadPriority.Lowest;
            eventReceiver.TrySetApartmentState(ApartmentState.MTA);
            eventReceiver.IsBackground = true;
            eventReceiver.Start();
        }

        private void CatchSdlEvents()
        {
            while (appIsRunned)
            {
                Thread.Sleep(5);
                if (Sdl.SDL_PollEvent(out _sdlEvent) != 0)
                {
                    switch (_sdlEvent.type)
                    {
                        case Sdl.SDL_MOUSEBUTTONDOWN:
                            {
                                // right button is not handled by design
                                if (_sdlEvent.button.button == Sdl.SDL_BUTTON_LEFT)
                                {
                                    _mouseLeftBtnIsDown = true;
                                    _moseMoving = false;
                                }
                                break;
                            }
                        case Sdl.SDL_MOUSEBUTTONUP:
                            {
                                // right button is not handled by design
                                if (_sdlEvent.button.button == Sdl.SDL_BUTTON_LEFT)
                                {
                                    MouseButtons pressedButton = MouseButtons.Left;
                                    ThreadPool.QueueUserWorkItem(delegate
                                    {
                                        uiField_MouseClick(_m_SdlPanel,
                                                        new MouseEventArgs(
                                                            pressedButton, 1,
                                                            _sdlEvent.button
                                                                .x,
                                                            _sdlEvent.button
                                                                .y, -1));
                                    });
                                    //Task.Factory.StartNew(() => );
                                    _moseMoving = false;
                                    _mouseLeftBtnIsDown = false;
                                } 
                                else if (_sdlEvent.button.button == Sdl.SDL_BUTTON_RIGHT)
                                {
                                    MouseButtons pressedButton = MouseButtons.Right;
                                    ThreadPool.QueueUserWorkItem(delegate
                                    {
                                        uiField_MouseClick(_m_SdlPanel,
                                                           new MouseEventArgs(
                                                               pressedButton, 1,
                                                               _sdlEvent.button
                                                                   .x,
                                                               _sdlEvent.button
                                                                   .y, -1));
                                    });
                                    //Task.Factory.StartNew(() => );
                                    _moseMoving = false;
                                    _mouseLeftBtnIsDown = false;
                                }
                                break;
                            }
                        case Sdl.SDL_MOUSEMOTION:
                            {
                                if (_mouseLeftBtnIsDown)
                                {
                                    ThreadPool.QueueUserWorkItem(delegate
                                                                     {
                                                                         uiField_MouseMove(_m_SdlPanel,
                                                                                           new MouseEventArgs(
                                                                                               MouseButtons.Left, 1,
                                                                                               _sdlEvent.button.x,
                                                                                               _sdlEvent.button.y,
                                                                                               -1));
                                                                     });
                                    //Task.Factory.StartNew(() => );
                                    _moseMoving = true;
                                }
                                else
                                {
                                    ThreadPool.QueueUserWorkItem(delegate
                                    {
                                        uiField_MouseMoveOnly(_m_SdlPanel,
                                                          new MouseEventArgs(
                                                              MouseButtons.Left, 1,
                                                              _sdlEvent.button.x,
                                                              _sdlEvent.button.y,
                                                              -1));
                                    });
                                }
                                break;
                            }
                    }
                }
                Thread.Sleep(5);
            }
        }

        private void CreateSdlWindow()
        {
            // Initialize SDL
            Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
            //TODO Sam: check that doublebuf is not needed for laptops (integrated video cards)
            //| Sdl.SDL_DOUBLEBUF 
            int flags = (Sdl.SDL_HWSURFACE | Sdl.SDL_ANYFORMAT | Sdl.SDL_NOFRAME);
            _m_SdlSurface = Sdl.SDL_SetVideoMode(_m_SdlPanel.Size.Width, _m_SdlPanel.Size.Height, 32, flags);

            // Retrieve the Handle to the SDL Window
            Sdl.SDL_SysWMinfo_Windows wmInfo;
            Sdl.SDL_GetWMInfo(out wmInfo);
            _m_SdlWindowHandle = new IntPtr(wmInfo.window);

            // Set the Window Position to 0/0
            SetWindowPos(_m_SdlWindowHandle, this.Handle, 0, 0, 0, 0, (SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_SHOWWINDOW));

            // Make the SDL Window the child of our Panel
            SetParent(_m_SdlWindowHandle, _m_SdlPanel.Handle);
            ShowWindow(_m_SdlWindowHandle, ShowWindowCommand.SW_SHOWNORMAL);

            Sdl.SDL_Rect rectangle = new Sdl.SDL_Rect(0, 0, (short)_m_SdlPanel.Size.Width, (short)_m_SdlPanel.Size.Height);
            Sdl.SDL_Surface sdlSurface = (Sdl.SDL_Surface)Marshal.PtrToStructure(_m_SdlSurface, typeof(Sdl.SDL_Surface));
            _SdlScreenPixelBuffer = sdlSurface.pixels;
            _SdlScreenPixelFormat = sdlSurface.format;
            //int clearColor = Sdl.SDL_MapRGBA(sdlSurface.format, 210, 180, 140, 0); //Color.Tan;Color.Tan.ToArgb()
            Sdl.SDL_FillRect(_m_SdlSurface, ref rectangle, Color.Tan.ToArgb());
            Sdl.SDL_Flip(_m_SdlSurface);
        }

        private void SdlPushBufferContentToScreen()
        {
            if (CurrentCellSize > 1)
            {
                int i_numberOfCellsGorizomtal_j = 0;
                //UInt32 purpurleColor = (UInt32)Color.Purple.ToArgb();
                //UInt32 darkOrchidColor = (UInt32)Color.DarkOrchid.ToArgb();
                //UInt32 blackColor = (UInt32)Color.Black.ToArgb();
                //UInt32 midnightBlueColor = (UInt32)Color.MidnightBlue.ToArgb();
                //UInt32 redColor = (UInt32)Color.Red.ToArgb();
                //UInt32 blueColor = (UInt32)Color.Blue.ToArgb();
                //UInt32 tanColor = (UInt32)Color.Tan.ToArgb();
                Sdl.SDL_Rect cellPosOnTheScreenRect = new Sdl.SDL_Rect();
                Sdl.SDL_BlitSurface(_backgroundImageSdlSurface, ref _fullScreenSpaceRect, _workingBufferSdlSurface, ref _fullScreenSpaceRect);
                for (int j = 0; j < currAmountOfCellsGorizomtal; j++)
                {
                    for (int k = 0; k < currAmountOfCellsVertical; k++)
                    {
                        i_numberOfCellsGorizomtal_j = j * currAmountOfCellsGorizomtal + k;
                        cellPosOnTheScreenRect = new Sdl.SDL_Rect((short)(k * CurrentCellSize), (short)(j * CurrentCellSize), CurrentCellSize, CurrentCellSize);
                        DrawShapeOnBufferSurface(cellPosOnTheScreenRect, *((UInt32*)_SdlScreenPixelBuffer + i_numberOfCellsGorizomtal_j));
                    }
                }

                Sdl.SDL_BlitSurface(_workingBufferSdlSurface, ref _fullScreenSpaceRect, _m_SdlSurface, ref _fullScreenSpaceRect);
            }

            Sdl.SDL_Flip(_m_SdlSurface);
        }

        private void DisplaySelectedMatricesContent(bool dispMat0, bool dispMat1, bool dispMat2, bool dispMat3, bool dispMat4, bool dispMat5, bool dispMat6,
            bool dispMat7, bool dispMat8, bool dispMat9, bool dispMat10)
        {
            int i_numberOfCellsGorizomtal_j = 0;

            if (CurrentCellSize > 1)
            {
                //clear the screen to default Tan color
                Sdl.SDL_BlitSurface(_backgroundImageSdlSurface, ref _fullScreenSpaceRect, _workingBufferSdlSurface,
                                    ref _fullScreenSpaceRect);
            }
            bool cellIsFilled = false;

            for (int i = 0; i < currAmountOfCellsGorizomtal; i++)
                for (int j = 0; j < currAmountOfCellsVertical; j++)
                {
                    cellIsFilled = false;
                    i_numberOfCellsGorizomtal_j = i * currAmountOfCellsGorizomtal + j;
                    if (*((short*)_Dim0 + i_numberOfCellsGorizomtal_j) != 0 && dispMat0)
                    {
                        SetPointToSdlScreenBuffer(i, j, 0);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim1 + i_numberOfCellsGorizomtal_j) != 0 && dispMat1)
                    {
                        SetPointToSdlScreenBuffer(i, j, 1);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim2 + i_numberOfCellsGorizomtal_j) != 0 && dispMat2)
                    {
                        SetPointToSdlScreenBuffer(i, j, 2);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim3 + i_numberOfCellsGorizomtal_j) != 0 && dispMat3)
                    {
                        SetPointToSdlScreenBuffer(i, j, 3);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim4 + i_numberOfCellsGorizomtal_j) != 0 && dispMat4)
                    {
                        SetPointToSdlScreenBuffer(i, j, 4);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim5 + i_numberOfCellsGorizomtal_j) != 0 && dispMat5)
                    {
                        SetPointToSdlScreenBuffer(i, j, 5);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim6 + i_numberOfCellsGorizomtal_j) != 0 && dispMat6)
                    {
                        SetPointToSdlScreenBuffer(i, j, 6);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim7 + i_numberOfCellsGorizomtal_j) != 0 && dispMat7)
                    {
                        SetPointToSdlScreenBuffer(i, j, 7);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim8 + i_numberOfCellsGorizomtal_j) != 0 && dispMat8)
                    {
                        SetPointToSdlScreenBuffer(i, j, 8);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim9 + i_numberOfCellsGorizomtal_j) != 0 && dispMat9)
                    {
                        SetPointToSdlScreenBuffer(i, j, 9);
                        cellIsFilled = true;
                    }
                    if (*((short*)_Dim10 + i_numberOfCellsGorizomtal_j) != 0 && dispMat10)
                    {
                        SetPointToSdlScreenBuffer(i, j, 10);
                        cellIsFilled = true;
                    }
                    if (!cellIsFilled && (CurrentCellSize == 1))
                    {
                        SetPointToSdlScreenBuffer(i, j, 11);
                    }
                }

            if (CurrentCellSize > 1)
            {
                Sdl.SDL_BlitSurface(_workingBufferSdlSurface, ref _fullScreenSpaceRect, _m_SdlSurface,
                                    ref _fullScreenSpaceRect);
            }
            Sdl.SDL_Flip(_m_SdlSurface);
        }

        private void DrawShapeOnBufferSurface(Sdl.SDL_Rect cellPosOnTheScreenRect, UInt32 colorValue)
        {
            switch (colorValue)
            {
                case 4286578816:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4288230092:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4278190080:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4279834992:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4294919424:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4294901760:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4278190335:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4278215680:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4292664540:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4294606962:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[colorValue], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
                case 4291998860: // for Tan color just break!!!
                    {
                        break;
                    }
                default:
                    {
                        Sdl.SDL_BlitSurface(_imagesForCustomCellSize[0], ref _coloredCellRect, _workingBufferSdlSurface,
                                            ref cellPosOnTheScreenRect);
                        break;
                    }
            }
        }

        private void SetPointToSdlScreenBuffer(int i, int j, int colorOffset)
        {
            //Sdl.SDL_LockSurface(_m_SdlSurface);
            Sdl.SDL_Rect cellPosOnTheScreenRect = new Sdl.SDL_Rect();
            if (CurrentCellSize > 1)
            {
                cellPosOnTheScreenRect = new Sdl.SDL_Rect((short)(j * CurrentCellSize), (short)(i * CurrentCellSize), CurrentCellSize, CurrentCellSize);
                DrawShapeOnBufferSurface(cellPosOnTheScreenRect, *((UInt32*)userColorPalette.ArrayPointer + colorOffset));
            }
            else
            {
                *((UInt32*)_SdlScreenPixelBuffer + i * currAmountOfCellsGorizomtal + j) = *((UInt32*)userColorPalette.ArrayPointer + colorOffset);
            }
            //Sdl.SDL_UnlockSurface(_m_SdlSurface);
        }

        private void SetPointToScreen(int i, int j, int colorOffset)
        {
            //Sdl.SDL_LockSurface(_m_SdlSurface);
            if (CurrentCellSize > 1)
            {
                Sdl.SDL_Rect cellPosOnTheScreenRect = new Sdl.SDL_Rect((short)(j * CurrentCellSize), (short)(i * CurrentCellSize), CurrentCellSize, CurrentCellSize);
                DrawShapeOnBufferSurface(cellPosOnTheScreenRect, *((UInt32*)userColorPalette.ArrayPointer + colorOffset));

                Sdl.SDL_BlitSurface(_workingBufferSdlSurface, ref _fullScreenSpaceRect, _m_SdlSurface, ref _fullScreenSpaceRect);
            }
            else
            {
                *((UInt32*)_SdlScreenPixelBuffer + i * currAmountOfCellsGorizomtal + j) = *((UInt32*)userColorPalette.ArrayPointer + colorOffset);
            }
            //Sdl.SDL_UnlockSurface(_m_SdlSurface);
            Sdl.SDL_Flip(_m_SdlSurface);
        }

        private void InitImagesForCustomSellSize()
        {
            _coloredCellRect = new Sdl.SDL_Rect(0, 0, CurrentCellSize, CurrentCellSize);
            _fullScreenSpaceRect = new Sdl.SDL_Rect(0, 0, (short)numberOfCellsGorizomtal, (short)numberOfCellsVertical);
            FileInfo currentAssemblyInfo = new FileInfo(Assembly.GetExecutingAssembly().Location);
            IntPtr preloadedBackground = SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\backgroundTan.bmp"));
            _backgroundImageSdlSurface = Sdl.SDL_DisplayFormat(preloadedBackground);

            IntPtr preloadedBackgroundx = SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\backgroundTan.bmp"));
            _workingBufferSdlSurface = Sdl.SDL_DisplayFormat(preloadedBackgroundx);

            _imagesForCustomCellSize = new Dictionary<uint, IntPtr>();

            IntPtr preLoadedPurple =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Purple.png"));
            _imagesForCustomCellSize.Add(4286578816, Sdl.SDL_DisplayFormatAlpha(preLoadedPurple));

            IntPtr preLoadedDarkOrchid =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8DarkOrchid.png"));
            _imagesForCustomCellSize.Add(4288230092, Sdl.SDL_DisplayFormatAlpha(preLoadedDarkOrchid));

            IntPtr preLoadedBlack =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Black.png"));
            _imagesForCustomCellSize.Add(4278190080, Sdl.SDL_DisplayFormatAlpha(preLoadedBlack));

            IntPtr preLoadedMidnightBlue =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8MidnightBlue.png"));
            _imagesForCustomCellSize.Add(4279834992, Sdl.SDL_DisplayFormatAlpha(preLoadedMidnightBlue));

            IntPtr preLoadedOrangeRed =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8OrangeRed.png"));
            _imagesForCustomCellSize.Add(4294919424, Sdl.SDL_DisplayFormatAlpha(preLoadedOrangeRed));

            IntPtr preLoadedRed =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Red.png"));
            _imagesForCustomCellSize.Add(4294901760, Sdl.SDL_DisplayFormatAlpha(preLoadedRed));

            IntPtr preLoadedBlue =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Blue.png"));
            _imagesForCustomCellSize.Add(4278190335, Sdl.SDL_DisplayFormatAlpha(preLoadedBlue));

            IntPtr preLoadedDarkGreen =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8DarkGreen.png"));
            _imagesForCustomCellSize.Add(4278215680, Sdl.SDL_DisplayFormatAlpha(preLoadedDarkGreen));

            IntPtr preLoadedGainsboro =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Gainsboro.png"));
            _imagesForCustomCellSize.Add(4292664540, Sdl.SDL_DisplayFormatAlpha(preLoadedGainsboro));

            IntPtr preLoadedMaroon =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Maroon.png"));
            _imagesForCustomCellSize.Add(4286578688, Sdl.SDL_DisplayFormatAlpha(preLoadedMaroon));

            IntPtr preLoadedSalmon =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8Salmon.png"));
            _imagesForCustomCellSize.Add(4294606962, Sdl.SDL_DisplayFormatAlpha(preLoadedSalmon));

            IntPtr preLoadedGenImage =
                    SdlImage.IMG_Load(Path.Combine(currentAssemblyInfo.DirectoryName, @"Images\8x8-old.circle.png"));
            _imagesForCustomCellSize.Add(0, Sdl.SDL_DisplayFormatAlpha(preLoadedGenImage));

            //try
            //{
            //    string errorMessage = SdlImage.IMG_GetError();
            //    if (!string.IsNullOrEmpty(errorMessage))
            //    {
            //        throw new ExternalException("SDL image loading failed!");
            //    }
            //}
            //catch
            //{
            //}
        }

        private void TryToUpdateScreen()
        {
            if (!_autoTransitionsOn)
            {
                SdlPushBufferContentToScreen();
            }
        }

        private void ButtonClickHandler(object sender, EventArgs e)
        {
            // Draw a rectangle to our surface
            IntPtr videoInfoPtr = Sdl.SDL_GetVideoInfo();
            Sdl.SDL_VideoInfo videoInfo = (Sdl.SDL_VideoInfo)Marshal.PtrToStructure(videoInfoPtr, typeof(Sdl.SDL_VideoInfo));

            int red = Sdl.SDL_MapRGB(videoInfo.vfmt, 255, 0, 0);
            Sdl.SDL_Rect rect = new Sdl.SDL_Rect((short)pos, (short)pos, 20, 20);
            Sdl.SDL_FillRect(_m_SdlSurface, ref rect, red);

            Sdl.SDL_UpdateRect(_m_SdlSurface, 0, 0, _m_SdlPanel.Size.Width, _m_SdlPanel.Size.Height);

            pos += 10;
        }

        //IntPtr sdlBuffer;	 //to be displayed buffer
        //IntPtr surfacePtr;
        //int[] pixelBuffer;  //offscreen emulated buffer
        //int bpp = 32;
        ////int width = 320;
        ////int height = 224;
        //int width = 600;
        //int height = 600;
        //int resultFlip;

        //public void CellFieldUI1()
        //{
        //    //Initialize the SDL frontend
        //    int init, flags, j;

        //    init = Sdl.SDL_Init(Sdl.SDL_INIT_VIDEO);
        //    flags = (Sdl.SDL_SWSURFACE | Sdl.SDL_DOUBLEBUF | Sdl.SDL_ANYFORMAT);
        //    surfacePtr = Sdl.SDL_SetVideoMode(
        //        width,
        //        height,
        //        bpp,
        //        flags);

        //    Sdl.SDL_Surface surface =
        //        (Sdl.SDL_Surface)Marshal.PtrToStructure(surfacePtr, typeof(Sdl.SDL_Surface));
        //    sdlBuffer = surface.pixels;
        //    //END Initialize the SDL frontend

        //    //Initialize the offscreen buffer
        //    pixelBuffer = new int[width * height];
        //    FillBuffer(255);
        //    //END Initialize the offscreen buffer
        //}

        //public void BlitScreen()
        //{
        //    int j, f;
        //    for (j = 0; j < 1000; j++)
        //    {
        //        int myPixelColor;
        //        unsafe
        //        {
        //            int* p = (int*)sdlBuffer;
        //            int maxlength = width * height;

        //            Sdl.SDL_LockSurface(surfacePtr);
        //            for (f = 0; f < maxlength; f++)
        //            {
        //                //myPixelColor = pixelBuffer[f];
        //                myPixelColor = j + f;
        //                p[f] = myPixelColor;
        //            }
        //            Sdl.SDL_UnlockSurface(surfacePtr);
        //        }
        //        resultFlip = Sdl.SDL_Flip(surfacePtr);
        //        //FillBuffer(j % 255);
        //    }
        //}

        //public void FillBuffer(int pixelColor)
        //{
        //    int j;
        //    for (j = 0; j < (width * height); j++)
        //    {
        //        pixelBuffer[j] = pixelColor;
        //    }
        //}

        ~CellFieldUI()
        {
        }

        private void CellFieldUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            appIsRunned = false;
            userColorPalette.FreePinnedObjects();
            _gcHandles.ForEach(gh => gh.Free());
            Sdl.SDL_FreeSurface(_m_SdlSurface);
        }
    }
}
