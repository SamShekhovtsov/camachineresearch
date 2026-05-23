using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using CA.Modes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using CA.UI.Properties;
using Tao.Sdl;

namespace CA.UI
{
    public unsafe partial class CellFieldUI : Form
    {
        # region -- Діалоги та кольори --
        public Pen linePen = new Pen(Brushes.MediumSeaGreen, 1);
        public string InitialDirectory = @"c:\Projects\WindowsFormsApplication24_1\MyBase\";
        public Pen bufLinePen = new Pen(Brushes.MediumSeaGreen, 1);
        public Brush CellBrush = new SolidBrush(Color.Purple);
        public Brush PaletteBrush = new SolidBrush(Color.Tan);
        public OpenFileDialog OpenfileDlg = new OpenFileDialog();
        public SaveFileDialog SaveFileDlg = new SaveFileDialog();
        # endregion

        #region -- Fields --

        private string _restoreFilePath;
        private bool _restoreStateAfterLoad;

        internal short CurrentCellSize = -1;
        int displacementX = 0;
        int displacementY = 0;
        internal int NumberOfDimensions = 11;
        internal FieldOptions CurrentFieldOptions;
        internal AlgorithmConfiguration CurrAlgorithmConfiguration;
        UserColorPalette userColorPalette;
        bool _mouseLeftBtnIsDown, _moseMoving;
        int currAmountOfCellsGorizomtal;
        int currAmountOfCellsVertical;
        internal int numberOfCellsGorizomtal = 700;
        internal int numberOfCellsVertical = 700;
        internal ColorDialog userColorDialog = new ColorDialog();
        internal int amountOfTransitions;
        private List<GCHandle> _gcHandles = new List<GCHandle>();
        private bool _imagesForCustomCellSizeInitialized = false;
        private string _locationInfo = string.Empty;
        private int? _catchedXPos = null;
        private int? _catchedYPos = null;
        private bool _newCoordinatesSelected = false;

        private IntPtr _Dim0;
        private IntPtr _Dim1;
        private IntPtr _Dim2;
        private IntPtr _Dim3;
        private IntPtr _Dim4;
        private IntPtr _Dim5;
        private IntPtr _Dim6;
        private IntPtr _Dim7;
        private IntPtr _Dim8;
        private IntPtr _Dim9;
        private IntPtr _Dim10;

        private short[] _t_Dim0;
        private short[] _t_Dim1;
        private short[] _t_Dim2;
        private short[] _t_Dim3;
        private short[] _t_Dim4;
        private short[] _t_Dim5;
        private short[] _t_Dim6;
        private short[] _t_Dim7;
        private short[] _t_Dim8;
        private short[] _t_Dim9;
        private short[] _t_Dim10;

        #endregion

        public CellFieldUI()
        {
            InitializeComponent();
            InitializeSdlComponents();
        }

        public CellFieldUI(string moduleLocation)
        {
            _restoreStateAfterLoad = !string.IsNullOrEmpty(moduleLocation);
            _restoreFilePath = moduleLocation;

            InitializeComponent();
            InitializeSdlComponents();
            cbxLayer.SelectedIndex = 0;
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int WM_RESTORESTATE = 0x4A;
            const int SC_MOVE = 0xF010;
            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
                case WM_RESTORESTATE:
                    COPYDATASTRUCT CD = (COPYDATASTRUCT)message.GetLParam(typeof(COPYDATASTRUCT));
                    byte[] B = new byte[CD.cbData];
                    IntPtr lpData = new IntPtr(CD.lpData);
                    Marshal.Copy(lpData, B, 0, CD.cbData);
                    SaveRestoreHelper.RestoreMachineState(this, Encoding.Default.GetString(B));
                    Activate();
                    break;
            }
            base.WndProc(ref message);
        }

        private void CellFieldUI_Load(object sender, EventArgs e)
        {
            try
            {
                Localize();
                AllocateMemoryForMatrices();
                InitSystemWithDefaultValues();

                if (_restoreStateAfterLoad)
                {
                    SaveRestoreHelper.RestoreMachineState(this, _restoreFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitSystemWithDefaultValues()
        {
            userColorPalette = new UserColorPalette(new Color[] { Color.Purple, Color.DarkOrchid, Color.Black, Color.MidnightBlue, Color.Red, Color.Blue, Color.OrangeRed, Color.Maroon, Color.DarkGreen, Color.Salmon, Color.Gainsboro, Color.Tan });
            // default algorithm and field configuration
            CurrAlgorithmConfiguration = new AlgorithmConfiguration("2, 3", "3");
            cbxCellSize.SelectedIndex = 1;
            toolStripStatusLabel1.Text = Localization.Locales.Resources.SelectedRules + CurrAlgorithmConfiguration.CurrRule;

            // TODO Sam implement logic for partially displaying the field
            //currAmountOfCellsGorizomtal = CurrentFieldOptions.SizeOfCell;//(pictureBox1.Width - 1) / 
            //currAmountOfCellsVertical = CurrentFieldOptions.SizeOfCell;//(pictureBox1.Height - 1) / 
            rbPlane0.Checked = true;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //currAmountOfCellsGorizomtal = (pictureBox1.Width - 1) / currFieldOptions.sizeOfCell;
            //currAmountOfCellsVertical = (pictureBox1.Height - 1) / currFieldOptions.sizeOfCell;
            //e.Graphics.FillRectangle(PaletteBrush, 0, 0, currAmountOfCellsGorizomtal * currFieldOptions.sizeOfCell,
            //    currAmountOfCellsVertical * currFieldOptions.sizeOfCell);

            //# region  -- Малювання сітки --
            //if (!currFieldOptions.vizNet)
            //{
            //    for (int i = 0; i <= currAmountOfCellsVertical; i++)
            //        e.Graphics.DrawLine(linePen, 0, currFieldOptions.sizeOfCell * i,
            //                      currAmountOfCellsGorizomtal * currFieldOptions.sizeOfCell, currFieldOptions.sizeOfCell * i);
            //    for (int i = 0; i <= currAmountOfCellsGorizomtal; i++)
            //        e.Graphics.DrawLine(linePen, currFieldOptions.sizeOfCell * i, 0,
            //                      currFieldOptions.sizeOfCell * i, currAmountOfCellsVertical * currFieldOptions.sizeOfCell);
            //}
            //# endregion

            //# region -- Опції відображення масивів даних --
            //if (currFieldOptions.sizeOfCell > 1)
            //{
            //    // this logic is only applied for cases when size of the cell is larger than 1 pixel
            //    // it's not a usual behavior
            //    for (int i = 0; i < currAmountOfCellsGorizomtal; i++)
            //        for (int j = 0; j < currAmountOfCellsVertical; j++)
            //        {
            //            if (bitmapOnPictureBox1.GetPixel(i, j) != Color.Tan)
            //                e.Graphics.FillRectangle(new SolidBrush(bitmapOnPictureBox1.GetPixel(i, j)),
            //                                         i*currFieldOptions.sizeOfCell,
            //                                         j*currFieldOptions.sizeOfCell, currFieldOptions.sizeOfCell,
            //                                         currFieldOptions.sizeOfCell);
            //        }
            //}
            //else e.Graphics.DrawImage(bitmapOnPictureBox1, 0, 0);
            //# endregion
        }

        # region -- Заповнення мишкою --

        private void uiField_MouseClick(object sender, MouseEventArgs e)
        {
            if (!_moseMoving && e.X < currAmountOfCellsGorizomtal * CurrentCellSize && e.Y < currAmountOfCellsVertical * CurrentCellSize)
            {
                int x = e.X / CurrentCellSize;
                int y = e.Y / CurrentCellSize;
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    _catchedXPos = x;
                    _catchedYPos = y;
                    _newCoordinatesSelected = true;
                }
                else if (e.Button == System.Windows.Forms.MouseButtons.Left)
                {
                    if (rbPlane0.Checked)
                    {
                        if (*((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) == 0)
                        {
                            *((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) = 1;
                        }
                        else
                        {
                            *((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) = 0;
                        }
                    }
                    else if (rbPlane1.Checked)
                    {
                        if (*((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) == 0)
                        {
                            *((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) = 1;
                        }
                        else
                        {
                            *((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) = 0;
                        }
                    }
                    else if (rbPlane2.Checked)
                    {
                        if (*((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) == 0)
                        {
                            *((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) = 1;
                        }
                        else
                        {
                            *((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) = 0;
                        }
                    }
                    else if (rbPlane3.Checked)
                    {
                        if (*((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) == 0)
                        {
                            *((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) = 1;
                        }
                        else
                        {
                            *((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) = 0;
                        }
                    }

                    else if (rbPlane8.Checked)
                    {
                        if (*((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) == 0)
                        {
                            *((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) = 1;
                        }
                        else
                        {
                            *((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) = 0;
                        }
                    }

                    if (_autoTransitionsOn)
                    {
                        return;
                    }

                    if (*((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) == 1)
                        SetPointToScreen(y, x, 0);

                    if (*((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) == 1)
                        SetPointToScreen(y, x, 1);

                    if (*((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) == 1)
                        SetPointToScreen(y, x, 2);

                    if (*((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) == 1)
                        SetPointToScreen(y, x, 3);

                    if (*((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) == 1)
                        SetPointToScreen(y, x, 8);

                    //TryToUpdateScreen();
                }
            }
        }

        private void uiField_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X < currAmountOfCellsGorizomtal * CurrentCellSize && e.Y < currAmountOfCellsVertical * CurrentCellSize
                          && e.X >= 0 && e.Y >= 0)
            {
                int x = e.X / CurrentCellSize;
                int y = e.Y / CurrentCellSize;
                if (rbPlane0.Checked &&
                    *((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) == 0)
                {
                    *((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) = 1;
                }
                else if (rbPlane1.Checked &&
                    *((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) == 0)
                {
                    *((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) = 1;
                }
                else if (rbPlane2.Checked &&
                    *((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) == 0)
                {
                    *((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) = 1;
                }
                else if (rbPlane3.Checked &&
                    *((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) == 0)
                {
                    *((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) = 1;
                }

                else if (rbPlane8.Checked &&
                    *((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) == 0)
                {
                    *((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) = 1;
                }

                if (_autoTransitionsOn)
                {
                    return;
                }

                if (*((short*)_Dim0 + y * currAmountOfCellsGorizomtal + x) == 1)
                    SetPointToScreen(y, x, 0);

                if (*((short*)_Dim1 + y * currAmountOfCellsGorizomtal + x) == 1)
                    SetPointToScreen(y, x, 1);

                if (*((short*)_Dim2 + y * currAmountOfCellsGorizomtal + x) == 1)
                    SetPointToScreen(y, x, 2);

                if (*((short*)_Dim3 + y * currAmountOfCellsGorizomtal + x) == 1)
                    SetPointToScreen(y, x, 3);

                if (*((short*)_Dim8 + y * currAmountOfCellsGorizomtal + x) == 1)
                    SetPointToScreen(y, x, 8);

                //TryToUpdateScreen();
                _locationInfo = string.Format(Localization.Locales.Resources.lblMouseCurrentPosition_Text, "X: " + x + "Y: " + y);
            }

        }

        private void uiField_MouseMoveOnly(Panel _m_SdlPanel, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.X < currAmountOfCellsGorizomtal * CurrentCellSize && mouseEventArgs.Y < currAmountOfCellsVertical * CurrentCellSize
                            && mouseEventArgs.X >= 0 && mouseEventArgs.Y >= 0)
            {
                int x = mouseEventArgs.X / CurrentCellSize;
                int y = mouseEventArgs.Y / CurrentCellSize;
                //Console.WriteLine("Coordinate X: " + x + "  Coordinate Y: " + y);
                _locationInfo = string.Format(Localization.Locales.Resources.lblMouseCurrentPosition_Text, "X: " + x + " Y: " + y);
            }
        }

        # endregion

        # region -- Опції налаштування программи --

        private void checkNewVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VersionChecker.CheckForUpdates();
        }

        private void tsmiViewHelpClick(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "help.chm");
        }

        private void DefaultConfigurationsClick(object sender, EventArgs e)
        {
            CurrentFieldOptions.ShowMatrixBorders = true;
            CurrentCellSize = 4;
            tbCellSize.Value = 4;
            Invalidate();
        }

        private void UserIsNotified(object sender, EventArgs e)
        {
            gbMessage.Visible = false;
            //pictureBox1.Visible = true;
        }

        private void exitProgram(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ClearAllMatrices(object sender, EventArgs e)
        {
            try
            {
                InitAllMatricesWithZero();
                TimerForAutoTransitions.Enabled = false;
                btnStart.Text = Localization.Locales.Resources.CellFieldUI_btnStart_Text;

                DisplaySelectedMatricesContent(rbPlane0.Checked, rbPlane1.Checked, rbPlane2.Checked, rbPlane3.Checked, false,
                false, false, false, rbPlane8.Checked, false, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SizeOfCellBeenChanged(object sender, EventArgs e)
        {
            // todo rework this code
            //btnStart.Text = Localization.Locales.Resources.CellFieldUI_btnStart_Text;
            //TimerForAutoTransitions.Enabled = false;
            //CurrentFieldOptions.SizeOfCell = tbCellSize.Value;
            //pictureBox1.Invalidate();
        }

        private void toRepresentTheGraph(object sender, EventArgs e)
        {
            if (CurrAlgorithmConfiguration.CurrentAlgorithm is IDiagramme)
            {
                Diagramme d = new Diagramme(((IDiagramme)CurrAlgorithmConfiguration.CurrentAlgorithm).Demografia);
                d.Show();
            }
        }

        # region -- Робота з масивами --

        private void toExchangePlanes(object sender, EventArgs e)
        {
            IntPtr tempArray = _Dim0;
            _Dim0 = _Dim1;
            _Dim1 = tempArray;
            tempArray = _Dim2;
            _Dim2 = _Dim3;
            _Dim3 = tempArray;
        }

        private void DisplayContenOfTheSelectedMatrices(object sender, EventArgs e)
        {
            // TODO !!!! after cell size made changable, replace 'numberOfCells' with 'currEmountOfCells'
            // TODO Optimise this code somehow... (later) probably replace cbxMatrix--.Checked property... just a guess
            if (_autoTransitionsOn)
            {
                StopAutoTransitions();
            }
            DisplaySelectedMatricesContent(cbxMatrix0.Checked, cbxMatrix1.Checked, cbxMatrix2.Checked, cbxMatrix3.Checked, cbxMatrix4.Checked
                , cbxMatrix5.Checked, cbxMatrix6.Checked, cbxMatrix7.Checked, cbxMatrix8.Checked, cbxMatrix9.Checked, cbxMatrix10.Checked);
            //TryToUpdateScreen();
        }

        private void KvadroReshotka()
        {
            for (int i = 0; i < currAmountOfCellsGorizomtal; i++)
                for (int j = 0; j < currAmountOfCellsVertical; j++)
                    if (i % 2 == 0 && j % 2 == 0)
                        //_Dim2[i * numberOfCellsGorizomtal + j] = 0;
                        *((short*)_Dim2 + i * currAmountOfCellsGorizomtal + j) = 0;
                    else if (i % 2 == 0 && j % 2 != 0)
                        //_Dim2[i * numberOfCellsGorizomtal + j] = 1;
                        *((short*)_Dim2 + i * currAmountOfCellsGorizomtal + j) = 1;
                    else if (i % 2 != 0 && j % 2 == 0)
                        //_Dim2[i * numberOfCellsGorizomtal + j] = 2;
                        *((short*)_Dim2 + i * currAmountOfCellsGorizomtal + j) = 2;
                    else if (i % 2 != 0 && j % 2 != 0)
                        //_Dim2[i * numberOfCellsGorizomtal + j] = 3;
                        *((short*)_Dim2 + i * currAmountOfCellsGorizomtal + j) = 3;
        }

        private void BinarReshotca()
        {
            int temp = 1;
            for (int i = 0; i < currAmountOfCellsGorizomtal; i++, temp = 1)
                for (int j = 0; j < currAmountOfCellsVertical; j++)
                {
                    temp = temp == 0 ? (byte)1 : (byte)0;
                    //_Dim2[i * numberOfCellsGorizomtal + j] = (byte)temp;
                    *((short*)_Dim2 + i * currAmountOfCellsGorizomtal + j) = (byte)temp;
                }
        }

        private void InitAllMatricesWithZero()
        {
            //todo Sam: implement initializtion logic
            InitMatrixWithZero(_Dim0);
            InitMatrixWithZero(_Dim1);
            InitMatrixWithZero(_Dim2);
            InitMatrixWithZero(_Dim3);
            InitMatrixWithZero(_Dim4);
            InitMatrixWithZero(_Dim5);
            InitMatrixWithZero(_Dim6);
            InitMatrixWithZero(_Dim7);
            InitMatrixWithZero(_Dim8);
            InitMatrixWithZero(_Dim9);
            InitMatrixWithZero(_Dim10);
        }

        private void InitMatrixWithZero(IntPtr matrix)
        {
            //todo Sam: implement initializtion logic
            for (int i = 0; i < numberOfCellsGorizomtal * numberOfCellsVertical; i++)
            {
                *((short*)matrix + i) = 0;
            }
        }

        private void AllocateMemoryForMatrices()
        {
            _t_Dim0 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h0 = GCHandle.Alloc(_t_Dim0, GCHandleType.Pinned);
            _Dim0 = h0.AddrOfPinnedObject();
            _gcHandles.Add(h0);

            _t_Dim1 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h1 = GCHandle.Alloc(_t_Dim1, GCHandleType.Pinned);
            _Dim1 = h1.AddrOfPinnedObject();
            _gcHandles.Add(h1);

            _t_Dim2 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h2 = GCHandle.Alloc(_t_Dim2, GCHandleType.Pinned);
            _Dim2 = h2.AddrOfPinnedObject();
            _gcHandles.Add(h2);

            _t_Dim3 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h3 = GCHandle.Alloc(_t_Dim3, GCHandleType.Pinned);
            _Dim3 = h3.AddrOfPinnedObject();
            _gcHandles.Add(h3);

            _t_Dim4 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h4 = GCHandle.Alloc(_t_Dim4, GCHandleType.Pinned);
            _Dim4 = h4.AddrOfPinnedObject();
            _gcHandles.Add(h4);

            _t_Dim5 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h5 = GCHandle.Alloc(_t_Dim5, GCHandleType.Pinned);
            _Dim5 = h5.AddrOfPinnedObject();
            _gcHandles.Add(h5);

            _t_Dim6 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h6 = GCHandle.Alloc(_t_Dim6, GCHandleType.Pinned);
            _Dim6 = h6.AddrOfPinnedObject();
            _gcHandles.Add(h6);

            _t_Dim7 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h7 = GCHandle.Alloc(_t_Dim7, GCHandleType.Pinned);
            _Dim7 = h7.AddrOfPinnedObject();
            _gcHandles.Add(h7);

            _t_Dim8 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h8 = GCHandle.Alloc(_t_Dim8, GCHandleType.Pinned);
            _Dim8 = h8.AddrOfPinnedObject();
            _gcHandles.Add(h8);

            _t_Dim9 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h9 = GCHandle.Alloc(_t_Dim9, GCHandleType.Pinned);
            _Dim9 = h9.AddrOfPinnedObject();
            _gcHandles.Add(h9);

            _t_Dim10 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
            GCHandle h10 = GCHandle.Alloc(_t_Dim10, GCHandleType.Pinned);
            _Dim10 = h10.AddrOfPinnedObject();
            _gcHandles.Add(h10);

            //_Dim0 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim0, GCHandleType.Pinned));
            //_Dim1 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim1, GCHandleType.Pinned));
            //_Dim2 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim2, GCHandleType.Pinned));
            //_Dim3 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim3, GCHandleType.Pinned));
            //_Dim4 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim4, GCHandleType.Pinned));
            //_Dim5 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim5, GCHandleType.Pinned));
            //_Dim6 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim6, GCHandleType.Pinned));
            //_Dim7 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim7, GCHandleType.Pinned));
            //_Dim8 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim8, GCHandleType.Pinned));
            //_Dim9 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim9, GCHandleType.Pinned));
            //_Dim10 = Marshal.AllocHGlobal(numberOfCellsVertical * numberOfCellsGorizomtal);
            //_gcHandles.Add(GCHandle.Alloc(_Dim10, GCHandleType.Pinned));
        }
        # endregion

        private void ClearSelectedPlane_Click(object sender, EventArgs e)
        {
            if (rbPlane0.Checked)
            {
                InitMatrixWithZero(_Dim0);
                InitMatrixWithZero(_Dim4);
            }
            else if (rbPlane1.Checked)
            {
                InitMatrixWithZero(_Dim1);
                InitMatrixWithZero(_Dim5);
            }
            else if (rbPlane2.Checked)
            {
                InitMatrixWithZero(_Dim2);
                InitMatrixWithZero(_Dim6);
            }
            else if (rbPlane3.Checked)
            {
                InitMatrixWithZero(_Dim3);
                InitMatrixWithZero(_Dim7);
            }

            else if (rbPlane8.Checked)
            {
                InitMatrixWithZero(_Dim8);
                InitMatrixWithZero(_Dim9);
            }
            //todo it needs to clean the SDL_Screen buffer!!!
            //bitmapOnPictureBox1 = new Bitmap(numberOfCellsGorizomtal, numberOfCellsVertical);

            //todo check this out later...
            DisplaySelectedMatricesContent(rbPlane0.Checked, rbPlane1.Checked, rbPlane2.Checked, rbPlane3.Checked, false,
                false, false, false, rbPlane8.Checked, false, false);
        }

        private void ApplyTuning(object sender, EventArgs e)
        {
            ILead UserLead = (ILead)CurrAlgorithmConfiguration.CurrentAlgorithm;
            UserLead.LiveHerbivorous = (int)numericUpDown4.Value;
            UserLead.LivePredator = (int)numericUpDown3.Value;
            UserLead.ReproductionHerbivorousus = (int)numericUpDown1.Value;
            UserLead.ReproductionPredators = (int)numericUpDown2.Value;
            UserLead.hunderDeath = (int)numericUpDown5.Value;
        }

        private void SetAPoint_1(object sender, EventArgs e)
        {
            if (CurrAlgorithmConfiguration.CurrentAlgorithm is IDiagramme)
            {
                List<long>[] l = new List<long>[2];
                l[0] = new List<long>();
                l[1] = new List<long>();
                ((IDiagramme)CurrAlgorithmConfiguration.CurrentAlgorithm).Demografia = l;
            }
        }

        # region -- ToolStrip підменю --

        private void Save(object sender, EventArgs e)
        {
            сохранитьВФайлClick(sender, e);
        }

        private void ChooseRules1(object sender, EventArgs e)
        {
            SetRules(sender, e);
        }

        private void SetAPoint(object sender, EventArgs e)
        {
            SetAPoint_1(sender, e);
        }

        private void CleanCurrentPlane(object sender, EventArgs e)
        {
            ClearSelectedPlane_Click(sender, e);
        }

        private void ExecuteTransition(object sender, EventArgs e)
        {
            if (toolStripTextBox2.Text.Length > 0 &&
                int.TryParse(toolStripTextBox2.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out amountOfTransitions))
            {
                DoTransition(amountOfTransitions);
            }
        }
        # endregion

        private void RepresentTheHistogram(object sender, EventArgs e)
        {
            try
            {
                //todo Implement this later, according to the new architecture
                //string str = "";
                //short[][] ToGistogramma = new short[3][];
                //ToGistogramma[1] = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //ToGistogramma[2] = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //ToGistogramma[0] = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //if (radioButton1.Checked)
                //{ ToGistogramma[0] = (short[])_Dim0.Clone(); str = ": \nплощина 0. Правила: "; }
                //else if (radioButton2.Checked)
                //{ ToGistogramma[0] = (short[])_Dim1.Clone(); str = ": \nплощина 1. Правила: "; }
                //else if (radioButton3.Checked)
                //{ ToGistogramma[0] = (short[])_Dim2.Clone(); str = ": \nплощина 2. Правила: "; }
                //else if (radioButton4.Checked)
                //{ ToGistogramma[0] = (short[])_Dim3.Clone(); str = ": \nплощина 3. Правила: "; }
                //else if (radioButton5.Checked)
                //{ ToGistogramma[0] = (short[])_Dim8.Clone(); str = ": \nплощина 4. Правила: "; }
                //Gistogramma Gist = new Gistogramma();
                //amountOfTransitions = 1;
                //GistogrammaOfCurrPlane WinGist = new GistogrammaOfCurrPlane();
                //WinGist.rozm = numberOfCellsGorizomtal;
                //WinGist.str = str;
                //WinGist.b = new Bitmap(1, 1);
                //WinGist.Width = numberOfCellsGorizomtal + 200;
                //WinGist.Height = numberOfCellsGorizomtal + 200;
                //Gist.Test(amountOfTransitions, numberOfCellsVertical, numberOfCellsGorizomtal);
                //WinGist.ShowDialog();
                //pictureBox1.Invalidate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void проПрограмуClick(object sender, EventArgs e)
        {
            AppVersionInfo kl = new AppVersionInfo();
            kl.ShowDialog();
        }

        private void toRepresentTheHistogrаm_1(object sender, EventArgs e)
        {
            RepresentTheHistogram(sender, e);
        }

        private void RepresentGrаph_1(object sender, EventArgs e)
        {
            toRepresentTheGraph(sender, e);
        }

        private void acceptDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ExecuteTransition(sender, e);
        }
        # endregion

        #region -- Зміна параметрів поля --

        private void cbxCellSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigureForCellSize((short.Parse(((string)cbxCellSize.SelectedItem).Substring(0, 1))));
            //if (((ComboBox)sender).SelectedIndex == 0 && CurrentCellSize != 1)
            //{
            //    CurrentCellSize = 1;
            //    CurrentFieldOptions = new FieldOptions(true, numberOfCellsGorizomtal);
            //    currAmountOfCellsGorizomtal = 700;
            //    currAmountOfCellsVertical = 700;
            //}
            //else if (((ComboBox)sender).SelectedIndex ==1 && CurrentCellSize != 8)
            //{
            //    CurrentCellSize = 8;
            //    CurrentFieldOptions = new FieldOptions(true, numberOfCellsGorizomtal);
            //    currAmountOfCellsGorizomtal = 90;
            //    currAmountOfCellsVertical = 90;

            //    InitImagesForCustomSellSize();
            //}
        }

        internal void ConfigureForCellSize(short sizeOfACell)
        {
            // TODO check this is correct...
            if (sizeOfACell == CurrentCellSize)
            {
                return;
            }
            CurrentCellSize = sizeOfACell;
            if (CurrentCellSize == 1)
            {
                CurrentCellSize = 1;
                CurrentFieldOptions = new FieldOptions(true, numberOfCellsGorizomtal);
                currAmountOfCellsGorizomtal = 700;
                currAmountOfCellsVertical = 700;
                cbxCellSize.SelectedIndex = 0;
            }else if (CurrentCellSize == 4)
            {
                CurrentCellSize = 4;
                CurrentFieldOptions = new FieldOptions(true, numberOfCellsGorizomtal);
                currAmountOfCellsGorizomtal = 175;
                currAmountOfCellsVertical = 175;
                cbxCellSize.SelectedIndex = 1;

                if (!_imagesForCustomCellSizeInitialized)
                {
                    InitImagesForCustomSellSize();
                    _imagesForCustomCellSizeInitialized = true;
                }
            }
            else if (CurrentCellSize == 8)
            {
                CurrentCellSize = 8;
                CurrentFieldOptions = new FieldOptions(true, numberOfCellsGorizomtal);
                currAmountOfCellsGorizomtal = 90;
                currAmountOfCellsVertical = 90;
                cbxCellSize.SelectedIndex = 2;

                if (!_imagesForCustomCellSizeInitialized)
                {
                    InitImagesForCustomSellSize();
                    _imagesForCustomCellSizeInitialized = true;
                }
            }
            ClearAllMatrices(this, EventArgs.Empty);
        }

        private void ChooseParametersOfTheField(object sender, EventArgs e)
        {
            try
            {
                TuningOfTheField f2 = new TuningOfTheField();
                f2.set(CurrentCellSize, CurrentFieldOptions.ShowMatrixBorders, CurrentFieldOptions.SizeOfField);
                f2.ShowDialog();
                //CurrentCellSize = (short)f2.retStruct().SizeOfCell;
                //tbCellSize.Value = f2.retStruct().SizeOfCell;
                CurrentFieldOptions.ShowMatrixBorders = f2.retStruct().ShowMatrixBorders;

                //NOTE according to new architecture, field size should not be changed 
                //if (f2.retStruct().sizeOfField != currFieldOptions.sizeOfField)
                //{
                //    currFieldOptions.sizeOfField = f2.retStruct().sizeOfField;
                //    numberOfCellsGorizomtal = currFieldOptions.sizeOfField;
                //    numberOfCellsVertical = currFieldOptions.sizeOfField;
                //    pictureBox1.Height = currFieldOptions.sizeOfField;
                //    pictureBox1.Width = currFieldOptions.sizeOfField;
                //    _Dim1 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim2 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim0 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim3 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim4 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim5 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim6 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim7 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim8 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim9 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    _Dim10 = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //    bitmapOnPictureBox1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //    pictureBox1.Invalidate();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (CurrentFieldOptions.ShowMatrixBorders)
                bufLinePen = linePen;
            else linePen = bufLinePen;
        }

        internal void ConfigureField(FieldOptions fieldOptions)
        {
            // todo Sam - implement this
            this.CurrentFieldOptions = fieldOptions;
            //tbCellSize.Value = this.CurrentFieldOptions.SizeOfCell;
            // todo Sam - update field size
            // SizeOfTheField
            // SizeOfACell
            // etc.
        }
        #endregion

        # region -- Задання правил --

        private void SetRules(object sender, EventArgs e)
        {
            SelectRules f3 = new SelectRules();
            f3.UserAlgorithmConfiguration = CurrAlgorithmConfiguration;
            //tabControl2.Visible = false;
            f3.ShowDialog();
            ConfigureSystemForAlgorithm(f3.UserAlgorithmConfiguration);
        }

        internal void ConfigureSystemForAlgorithm(AlgorithmConfiguration config)
        {
            LoadAlgorithm(config);

            if (CurrAlgorithmConfiguration.CurrentAlgorithm is GM_GAS || CurrAlgorithmConfiguration.CurrentAlgorithm is TM_GAS || CurrAlgorithmConfiguration.CurrentAlgorithm is Dendrit || CurrAlgorithmConfiguration.CurrentAlgorithm is Naiv_Deffusion)
                KvadroReshotka();
            else if (CurrAlgorithmConfiguration.CurrentAlgorithm is Primitiv_Deffusion)
                BinarReshotca();
            else if (CurrAlgorithmConfiguration.CurrentAlgorithm is Demographiya)
            {
                tabControl2.Visible = true;
                KvadroReshotka();
                numericUpDown1.Value = 100;
                numericUpDown2.Value = 100;
                numericUpDown3.Value = 100;
                numericUpDown4.Value = 100;
                numericUpDown5.Value = 100;
                ApplyTuning(this, EventArgs.Empty);
            }
        }

        internal void LoadAlgorithm(AlgorithmConfiguration config)
        {
            CurrAlgorithmConfiguration = config;
            toolStripStatusLabel1.Text = Localization.Locales.Resources.SelectedRules + CurrAlgorithmConfiguration.CurrentAlgorithm.Name;
        }
        # endregion

        #region -- Генерація початкового покоління --

        private void GenerateRandomPattern(object sender, EventArgs e)
        {
            _timerForAutoGeneration.Enabled = !_timerForAutoGeneration.Enabled;
            btnStartGenerateRandomPattern.Text = _timerForAutoGeneration.Enabled ?
                Localization.Locales.Resources.CellFieldUI_btnStartGenerateRandomPattern_Stop :
                Localization.Locales.Resources.CellFieldUI_btnStartGenerateRandomPattern_Start;
        }

        private void SetRandomValueToSelectedMatrix(object sender, EventArgs e)
        {
            Random ran = new Random();
            int x = ran.Next(0, currAmountOfCellsGorizomtal), y = ran.Next(0, currAmountOfCellsVertical);
            if (rbPlane0.Checked == true)
            {
                SetPixelToMatrixAndToScreen(_Dim0, x, y, 0);
            }
            else if (rbPlane1.Checked == true)
            {
                SetPixelToMatrixAndToScreen(_Dim1, x, y, 1);
            }
            else if (rbPlane2.Checked == true)
            {
                SetPixelToMatrixAndToScreen(_Dim2, x, y, 2);
            }
            else if (rbPlane3.Checked == true)
            {
                SetPixelToMatrixAndToScreen(_Dim3, x, y, 3);
            }
            else if (rbPlane8.Checked == true)
            {
                SetPixelToMatrixAndToScreen(_Dim8, x, y, 4);
            }

            //TryToUpdateScreen();
        }

        private void SetPixelToMatrixAndToScreen(IntPtr dimension, int x, int y, int colorOffset)
        {
            //Sdl.SDL_LockSurface(_m_SdlSurface);
            *((short*)dimension + y * currAmountOfCellsGorizomtal + x) = 1;
            //if (!_autoTransitionsOn)
            //{
                SetPointToScreen(y, x, colorOffset);
            //}
            //Sdl.SDL_UnlockSurface(_m_SdlSurface);
        }

        private void стопToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _timerForAutoGeneration.Enabled = false;
        }
        # endregion

        #region -- Завантажити / Зберегти --

        private void сохранитьВФайлClick(object sender, EventArgs e)
        {
            try
            {
                SaveFileDlg.Filter = Localization.Locales.Resources.SaveFileDlg_Filter;
                SaveFileDlg.InitialDirectory = InitialDirectory;
                SaveFileDlg.FileName = "*.camodel";
                SaveFileDlg.FilterIndex = 1;
                SaveFileDlg.RestoreDirectory = true;
                if (SaveFileDlg.ShowDialog() != DialogResult.Cancel)
                {
                    SaveRestoreHelper.SaveCAMachineState(this, SaveFileDlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void загрузитьИзФайлаClick(object sender, EventArgs e)
        {
            OpenfileDlg = new OpenFileDialog();
            OpenfileDlg.InitialDirectory = InitialDirectory;
            OpenfileDlg.Filter = Localization.Locales.Resources.SaveFileDlg_Filter;
            OpenfileDlg.FilterIndex = 1;
            OpenfileDlg.RestoreDirectory = true;
            try
            {
                if (OpenfileDlg.ShowDialog() != DialogResult.Cancel)
                {
                    SaveRestoreHelper.RestoreMachineState(this, OpenfileDlg.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void SaveFieldsDataToStream(Stream str)
        {
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim0 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim0 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim1 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim1 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim2 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim2 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim3 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim3 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim4 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim4 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim5 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim5 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim6 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim6 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim7 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim7 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim8 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim8 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim9 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim9 + i) >> 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                str.WriteByte((byte)(*((short*)_Dim10 + i) >> 8));
                str.WriteByte((byte)(*((short*)_Dim10 + i) >> 0));
            }
        }

        internal void InitDimensionsFromStream(Stream str)
        {
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim0 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim1 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim2 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim3 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim4 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim5 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim6 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim7 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim8 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim9 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
            for (int i = 0; i < currAmountOfCellsGorizomtal * currAmountOfCellsVertical; i++)
            {
                *((short*)_Dim10 + i) = (short)((str.ReadByte() << 8) | (str.ReadByte() << 0));
            }
        }

        internal void DisplaySystemState()
        {
            //Sdl.SDL_LockSurface(_m_SdlSurface);
            CurrAlgorithmConfiguration.CurrentAlgorithm.Show(ref _Dim0, ref _Dim1, ref _Dim2, ref _Dim3, ref _Dim4, ref _Dim5, ref _Dim6, ref _Dim7, ref _Dim8, ref _Dim9, ref _Dim10,
                currAmountOfCellsVertical, currAmountOfCellsGorizomtal, _SdlScreenPixelBuffer, userColorPalette.ArrayPointer);
            //Sdl.SDL_UnlockSurface(_m_SdlSurface);
            SdlPushBufferContentToScreen();
        }
        #endregion

        #region -- Керування положенням поля --

        private void button8_Click(object sender, EventArgs e)
        {
            displacementX = 0;
            displacementY = -1;
            moove();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            displacementX = 0;
            displacementY = 1;
            moove();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            displacementX = -1;
            displacementY = 0;
            moove();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            displacementX = 1;
            displacementY = 0;
            moove();
        }

        private void button11_MouseDown(object sender, MouseEventArgs e)
        {
            displacementX = 1;
            displacementY = 0;
            timer3.Enabled = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            moove();
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            displacementX = -1;
            displacementY = 0;
            timer3.Enabled = true;
        }

        private void button8_MouseDown(object sender, MouseEventArgs e)
        {
            displacementX = 0;
            displacementY = -1;
            timer3.Enabled = true;
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            displacementX = 0;
            displacementY = 1;
            timer3.Enabled = true;
        }

        private void button11_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
        }

        private void button10_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
        }

        private void button8_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Enabled = false;
        }

        private void moove()
        {
            try
            {
                //todo implement this functionality later, according to the new architecture
                //TimerForAutoTransitions.Enabled = false;
                //int offsetX = 0;
                //int offsetY = 0;
                //short[] temp = new short[numberOfCellsGorizomtal * numberOfCellsVertical];
                //for (int i = 0; i < numberOfCellsGorizomtal; i++)
                //    for (int j = 0; j < numberOfCellsVertical; j++)
                //    {
                //        if (i == numberOfCellsGorizomtal - 1 && displacementX < 0) { offsetX = i + displacementX; }
                //        else if (i == 0 && displacementX < 0) { offsetX = numberOfCellsGorizomtal - 1 + displacementX; }
                //        else if (i == numberOfCellsGorizomtal - 1 && displacementX > 0) { offsetX = displacementX; }
                //        else offsetX = displacementX + i;
                //        if (j == numberOfCellsVertical - 1 && displacementY < 0) { offsetY = j + displacementY; }
                //        else if (j == 0 && displacementY < 0) { offsetY = numberOfCellsVertical - 1 + displacementY; }
                //        else if (j == numberOfCellsVertical - 1 && displacementY > 0) { offsetY = displacementY; }
                //        else offsetY = displacementY + j;
                //        temp[i * numberOfCellsGorizomtal + j] = _Dim0[offsetX * numberOfCellsGorizomtal + offsetY];
                //    }
                //_Dim0 = (short[])temp.Clone();
                //pictureBox1.Invalidate();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        # endregion

        #region -- Локалізація --

        private void Localize()
        {
            this.btnGoToNextGeneration.Text = Localization.Locales.Resources.CellFieldUI_btnGoToNextGeneration_Text;
            this.btnStart.Text = Localization.Locales.Resources.CellFieldUI_btnStart_Text;
            this.gpbAutoTransitions.Text = Localization.Locales.Resources.CellFieldUI_gpbAutoTransitions_Text;
            this.lblSpeed.Text = Localization.Locales.Resources.CellFieldUI_lblSpeed_Text;
            this.btnAccelerate.Text = Localization.Locales.Resources.CellFieldUI_btnAccelerate_Text;
            this.btnSlowDown.Text = Localization.Locales.Resources.CellFieldUI_btnSlowDown_Text;
            this.файлToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_файлToolStripMenuItem_Text;
            this.новоеПолеToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_новоеПолеToolStripMenuItem_Text;
            this.загрузитьИзФайлаToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_загрузитьИзФайлаToolStripMenuItem_Text;
            this.сохранитьВФайлToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_сохранитьВФайлToolStripMenuItem_Text;
            this.выходToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_выходToolStripMenuItem_Text;
            this.tsmiExec.Text = Localization.Locales.Resources.CellFieldUI_tsmiExec_Text;
            this.перейтиНаХХХПоколіньToolStripMenuItem.Text = Localization.Locales.Resources.CellFieldUI_перейтиНаХХХПоколіньToolStripMenuItem_Text;
            this.tsmiCreateGraph.Text = Localization.Locales.Resources.CellFieldUI_tsmiCreateGraph_Text;
            this.tsmiBuildHistogram.Text = Localization.Locales.Resources.CellFieldUI_tsmiBuildHistogram_Text;
            this.camOptions.Text = Localization.Locales.Resources.CellFieldUI_camOptions_Text;
            this.tsmiAdditionalFieldOptions.Text = Localization.Locales.Resources.CellFieldUI_tsmiAdditionalFieldOptions_Text;
            this.tsmiSetRules.Text = Localization.Locales.Resources.CellFieldUI_tsmiSetRules_Text;
            this.tsmiDefaultConfigurations.Text = Localization.Locales.Resources.CellFieldUI_tsmiDefaultConfigurations_Text;
            this.tsmiCheckNewVersion.Text = Localization.Locales.Resources.CellFieldUI_tsmiCheckNewVersion_Text;
            this.tsmiHelpCategory.Text = Localization.Locales.Resources.CellFieldUI_tsmiHelpCategory_Text;
            this.tsmiViewHelp.Text = Localization.Locales.Resources.CellFieldUI_tsmiViewHelp_Text;
            this.tsmiAboutApp.Text = Localization.Locales.Resources.CellFieldUI_tsmiAboutApp_Text;
            this.btnClearAllMatrices.Text = Localization.Locales.Resources.CellFieldUI_btnClearAllMatrices_Text;
            this.tsslTransitionStatus.Text = Localization.Locales.Resources.CellFieldUI_tsslTransitionStatus_Text;
            this.btnExit.Text = Localization.Locales.Resources.CellFieldUI_btnExit_Text;
            this.gbCellSize.Text = Localization.Locales.Resources.CellFieldUI_gbCellsSize_Text;
            this.gbMessage.Text = Localization.Locales.Resources.CellFieldUI_gbMessage_Text;
            this.btmGbMessageOK.Text = Localization.Locales.Resources.CellFieldUI_ok_Text;
            this.gbFieldLocation.Text = Localization.Locales.Resources.CellFieldUI_gbFieldLocation_Text;
            this.tpMainControlBox.Text = Localization.Locales.Resources.CellFieldUI_tpMainControlBox_Text;
            this.tpFieldOptions.Text = Localization.Locales.Resources.CellFieldUI_tpFieldOptions_Text;
            this.gbGenerateRandomPattern.Text = Localization.Locales.Resources.CellFieldUI_gbGenerateRandomPattern_Text;
            this.btnStartGenerateRandomPattern.Text = Localization.Locales.Resources.CellFieldUI_btnStartGenerateRandomPattern_Text;
            this.btnClearSelectedPlane.Text = Localization.Locales.Resources.CellFieldUI_btnClearSelectedPlane_Text;
            this.btnSwapMatrices.Text = Localization.Locales.Resources.CellFieldUI_btnSwapMatrices_Text;
            this.gbSelectPlane.Text = Localization.Locales.Resources.CellFieldUI_gbSelectPlane_Text;
            this.rbPlane8.Text = Localization.Locales.Resources.CellFieldUI_rbPlane8_Text;
            this.rbPlane3.Text = Localization.Locales.Resources.CellFieldUI_rbPlane3_Text;
            this.rbPlane2.Text = Localization.Locales.Resources.CellFieldUI_rbPlane2_Text;
            this.rbPlane1.Text = Localization.Locales.Resources.CellFieldUI_rbPlane1_Text;
            this.rbPlane0.Text = Localization.Locales.Resources.CellFieldUI_rbPlane0_Text;
            this.tpAnalytics.Text = Localization.Locales.Resources.CellFieldUI_tpAnalytics_Text;
            this.gbGraphs.Text = Localization.Locales.Resources.CellFieldUI_gbGraphs_Text;
            this.btnMakeGistogramma.Text = Localization.Locales.Resources.CellFieldUI_btnMakeGistogramma_Text;
            this.btnShowGraph.Text = Localization.Locales.Resources.CellFieldUI_btnShowGraph_Text;
            this.btnStartPoint.Text = Localization.Locales.Resources.CellFieldUI_btnStartPoint_Text;
            this.tpDemography.Text = Localization.Locales.Resources.CellFieldUI_tpDemography_Text;
            this.gbPredatorsConf.Text = Localization.Locales.Resources.CellFieldUI_gbPredatorsConf_Text;
            this.gbIntervalForBirth.Text = Localization.Locales.Resources.CellFieldUI_gbIntervalForBirth_Text;
            this.lblPredators.Text = Localization.Locales.Resources.CellFieldUI_lblPredators_Text;
            this.lblHerbivorous.Text = Localization.Locales.Resources.CellFieldUI_lblHerbivorous_Text;
            this.lblEmulatorConfiguration.Text = Localization.Locales.Resources.CellFieldUI_lblEmulatorConfiguration_Text;
            this.btnApplyemulatorRules.Text = Localization.Locales.Resources.CellFieldUI_btnApplyemulatorRules_Text;
            this.gbLifeDuration.Text = Localization.Locales.Resources.CellFieldUI_gbLifeDuration_Text;
            this.label6.Text = Localization.Locales.Resources.CellFieldUI_lblPredators_Text;
            this.label7.Text = Localization.Locales.Resources.CellFieldUI_lblHerbivorous_Text;
            this.tsbsaveResultsToFile.Text = Localization.Locales.Resources.CellFieldUI_tsbsaveResultsToFile_Text;
            this.tsbsaveResultsToFile.ToolTipText = Localization.Locales.Resources.CellFieldUI_tsbsaveResultsToFile_ToolTipText;
            this.tsbSelectRules.Text = Localization.Locales.Resources.CellFieldUI_tsbSelectRules_Text;
            this.tsbSelectRules.ToolTipText = Localization.Locales.Resources.CellFieldUI_tsbSelectRules_ToolTipText;
            this.tsbSetstartPoint.Text = Localization.Locales.Resources.CellFieldUI_tsbSetStartPoint_Text;
            this.tsbSetstartPoint.ToolTipText = Localization.Locales.Resources.CellFieldUI_tsbSetStartPoint_ToolTipText;
            this.tsbClearSelectedPlane.Text = Localization.Locales.Resources.CellFieldUI_tsbClearSelectedPlane_Text;
            this.tsbClearSelectedPlane.ToolTipText = Localization.Locales.Resources.CellFieldUI_tsbClearSelectedPlane_ToolTipText;
            this.tsbDoTransition.Text = Localization.Locales.Resources.CellFieldUI_tsbDoTransition_Text;
            this.tsbDoTransition.ToolTipText = Localization.Locales.Resources.CellFieldUI_tsbDoTransition_ToolTipText;
            this.btnDisplayMatrContent.Text = Localization.Locales.Resources.CellFieldUI_btnDisplayContent_Text;
            this.gbPlanesToShow.Text = Localization.Locales.Resources.CellFieldUI_gbPlanesToShow_Text;
            this.Text = Localization.Locales.Resources.CellFieldUI_Text;
            this.lblCellValDesc.Text = Localization.Locales.Resources.CellFieldUI_CellValue;
            this.lblCellValue.Text = Localization.Locales.Resources.lblCellValue;
            this.btnGetCell.Text = Localization.Locales.Resources.btnGetCell_Text;
            this.btnSetCell.Text = Localization.Locales.Resources.btnSetCell_Text;
        }
        #endregion

        private void btnGetCell_Click(object sender, EventArgs e)
        {
            LoadSelectedCellValue();
        }

        private void LoadSelectedCellValue()
        {
            int xCoordinate = int.Parse(txbXAxes.Text);
            int yCoordinate = int.Parse(txbYAxes.Text);
            if (xCoordinate > currAmountOfCellsGorizomtal * CurrentCellSize && yCoordinate > currAmountOfCellsVertical * CurrentCellSize)
            {
                MessageBox.Show(Localization.Locales.Resources.LoadCellValueCoordinatesAreNotCorrect);
                return;
            }

            short requestedVal = 0;
            bool valueFound = true;
            switch (cbxLayer.Text)
            {
                case "0":
                    {
                        requestedVal = *((short*)_Dim0 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "1":
                    {
                        requestedVal = *((short*)_Dim1 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "2":
                    {
                        requestedVal = *((short*)_Dim2 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "3":
                    {
                        requestedVal = *((short*)_Dim3 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "4":
                    {
                        requestedVal = *((short*)_Dim4 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "5":
                    {
                        requestedVal = *((short*)_Dim5 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "6":
                    {
                        requestedVal = *((short*)_Dim6 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "7":
                    {
                        requestedVal = *((short*)_Dim7 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "8":
                    {
                        requestedVal = *((short*)_Dim8 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "9":
                    {
                        requestedVal = *((short*)_Dim9 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                case "10":
                    {
                        requestedVal = *((short*)_Dim10 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate);
                        break;
                    }
                default:
                    {
                        valueFound = false;
                        break;
                    }
            }
            if (!valueFound)
            {
                // Notify user that value was not found
                MessageBox.Show(Localization.Locales.Resources.LoadCellValueNotFound);
                return;
            }

            txbCellValue.Text = requestedVal.ToString();
        }

        private void btnSetCell_Click(object sender, EventArgs e)
        {
            int xCoordinate = int.Parse(txbXAxes.Text);
            int yCoordinate = int.Parse(txbYAxes.Text);
            if (xCoordinate > currAmountOfCellsGorizomtal * CurrentCellSize && yCoordinate > currAmountOfCellsVertical * CurrentCellSize)
            {
                MessageBox.Show(Localization.Locales.Resources.LoadCellValueCoordinatesAreNotCorrect);
                return;
            }

            short targetVal = Convert.ToInt16(txbCellValue.Text);
            bool valueWasSet = true;
            switch (cbxLayer.Text)
            {
                case "0":
                    {
                        *((short*)_Dim0 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 0);
                        break;
                    }
                case "1":
                    {
                        *((short*)_Dim1 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 1);
                        break;
                    }
                case "2":
                    {
                        *((short*)_Dim2 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 2);
                        break;
                    }
                case "3":
                    {
                        *((short*)_Dim3 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 3);
                        break;
                    }
                case "4":
                    {
                        *((short*)_Dim4 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 4);
                        break;
                    }
                case "5":
                    {
                        *((short*)_Dim5 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 5);
                        break;
                    }
                case "6":
                    {
                        *((short*)_Dim6 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 6);
                        break;
                    }
                case "7":
                    {
                        *((short*)_Dim7 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 7);
                        break;
                    }
                case "8":
                    {
                        *((short*)_Dim8 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 8);
                        break;
                    }
                case "9":
                    {
                        *((short*)_Dim9 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 9);
                        break;
                    }
                case "10":
                    {
                        *((short*)_Dim10 + yCoordinate * currAmountOfCellsGorizomtal + xCoordinate) = targetVal;
                        SetPointToScreen(yCoordinate, xCoordinate, 10);
                        break;
                    }
                default:
                    {
                        valueWasSet = false;
                        break;
                    }
            }
            if (!valueWasSet)
            {
                // Notify user that value was not found
                MessageBox.Show(Localization.Locales.Resources.LoadCellValueNotFound);
                return;
            }
        }

        private void tmrMouseLocation_Tick(object sender, EventArgs e)
        {
            lblMouseCurrentPosition.Text = _locationInfo;

            if (_catchedXPos.HasValue && _catchedYPos.HasValue && _newCoordinatesSelected)
            {
                RadioButton selectedRadioButton = gbSelectPlane.Controls.OfType<RadioButton>().Where(rb => rb.Checked).FirstOrDefault();
                // 7 is index of the 'rbPlane' string
                //cbxLayer.SelectedIndex = int.Parse(selectedRadioButton.Name.Substring(7));
                txbXAxes.Text = _catchedXPos.Value.ToString();
                txbYAxes.Text = _catchedYPos.Value.ToString();
                LoadSelectedCellValue();
                _newCoordinatesSelected = false;
            }
        }
    }
}