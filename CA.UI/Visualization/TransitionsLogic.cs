using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using CA.Modes;
using Tao.Sdl;

namespace CA.UI
{
    public delegate void DelTesting();
    public partial class CellFieldUI : Form
    {
        private int _autoTransitionsMinInterval = 10;
        private int _autoTranstionsMaxInterval = 1000;
        private bool _autoTransitionsOn;

        public int AutoTransitionsInterval
        {
            get { return TimerForAutoTransitions.Interval; }
            set
            {
                bool timerWasActive = false;
                timerWasActive = TimerForAutoTransitions.Enabled;
                TimerForAutoTransitions.Stop();
                TimerForAutoTransitions.Interval = value;
                btnSlowDown.Enabled = TimerForAutoTransitions.Interval < _autoTranstionsMaxInterval;
                btnAccelerate.Enabled = TimerForAutoTransitions.Interval > _autoTransitionsMinInterval;
                if(timerWasActive)
                {
                    TimerForAutoTransitions.Start();
                }
            }
        }

        private void выходClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void новоеПолеClick(object sender, EventArgs e)
        {
            ClearAllMatrices(this, e);
        }

        #region -- Автоматична зміна поколінь --

        private void ChangeAutomaticTransitionMode(object sender, EventArgs e)
        {
            TimerForAutoTransitions.Enabled = !TimerForAutoTransitions.Enabled;
            _autoTransitionsOn = TimerForAutoTransitions.Enabled;
            btnStart.Text = TimerForAutoTransitions.Enabled ? Localization.Locales.Resources.CellFieldUI_btnStart_Stop_Text : Localization.Locales.Resources.CellFieldUI_btnStart_Text;
        }

        private void StopAutoTransitions()
        {
            TimerForAutoTransitions.Enabled = false;
            _autoTransitionsOn = false;
            btnStart.Text = Localization.Locales.Resources.CellFieldUI_btnStart_Text;
        }

        private void TimerForAutoTransitions_Tick(object sender, EventArgs e)
        {
            //todo check how to do this later...
            //if (_Dim0.Length == 0)
            //{
            //    TimerForAutoTransitions.Enabled = false;
            //    _autoTransitionsOn = TimerForAutoTransitions.Enabled;
            //}
            GoToNextGeneration(this, null);
        }

        private void AccelerateTheSpeed(object sender, EventArgs e)
        {
            bool timerWasActive = TimerForAutoTransitions.Enabled;
            TimerForAutoTransitions.Stop();
            if (TimerForAutoTransitions.Interval > 100)
            {
                TimerForAutoTransitions.Interval -= 100;
                btnAccelerate.Enabled = true;
            }
            else if (TimerForAutoTransitions.Interval > _autoTransitionsMinInterval)
            {
                TimerForAutoTransitions.Interval -= 10;
                btnAccelerate.Enabled = TimerForAutoTransitions.Interval > _autoTransitionsMinInterval;
            }
            btnSlowDown.Enabled = true;
            if (timerWasActive)
            {
                TimerForAutoTransitions.Start();
            }
            //pictureBox1.Invalidate();
        }

        private void SlowDownTheSpeed(object sender, EventArgs e)
        {
            bool timerWasActive = TimerForAutoTransitions.Enabled;
            TimerForAutoTransitions.Stop();
            if (TimerForAutoTransitions.Interval < 100)
            {
                TimerForAutoTransitions.Interval += 10;
                btnSlowDown.Enabled = true;
            }
            else if (TimerForAutoTransitions.Interval + 90 < 1000)
            {
                TimerForAutoTransitions.Interval += 100;
                btnSlowDown.Enabled = TimerForAutoTransitions.Interval < _autoTranstionsMaxInterval;
            }
            if (timerWasActive)
            {
                TimerForAutoTransitions.Start();
            }
            btnAccelerate.Enabled = true;
            //pictureBox1.Invalidate();
        }
        # endregion

        # region -- Запуск перерахунку --

        private void перейтиНаХХХПоколіньClick(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text.Length > 0 && 
                int.TryParse(toolStripTextBox1.Text, NumberStyles.Integer, CultureInfo.CurrentCulture, out amountOfTransitions))
            {
                _autoTransitionsOn = true;
                DoTransition(amountOfTransitions);
            }
        }

        private void DoTransition(int iter)
        {
            DelTesting DT = Testing;
            TimerForAutoTransitions.Enabled = false;
            toolStrip1.Enabled = false;
            pictureBox1.Enabled = false;
            tabControl1.Enabled = false;
            IAsyncResult IR = DT.BeginInvoke(AllComplite, iter);
            //pictureBox1.Invalidate();
        }

        private void GoToNextGeneration(object sender, EventArgs e)
        {
            amountOfTransitions = 1;
            Testing();
        }

        private void Testing()
        {
            //TODO: Check whether I need to lock the surface in any case. Need to investigate for the reason of surface locking
            //bool surfaceLocked = false;
            //if (Sdl.SDL_MUSTLOCK(_m_SdlSurface)>0)
            //{
            //    Sdl.SDL_LockSurface(_m_SdlSurface);
            //    surfaceLocked = true;
            //    Console.WriteLine(surfaceLocked);
            //}
            CurrAlgorithmConfiguration.CurrentAlgorithm.Test(ref _Dim0, ref _Dim1, ref _Dim2, ref _Dim3, ref _Dim4, ref _Dim5, ref _Dim6, ref _Dim7, ref _Dim8, ref _Dim9, ref _Dim10,
                amountOfTransitions, currAmountOfCellsVertical, currAmountOfCellsGorizomtal, _SdlScreenPixelBuffer, userColorPalette.ArrayPointer);
            //Sdl.SDL_UnlockSurface(_m_SdlSurface);
            SdlPushBufferContentToScreen();
            //if(surfaceLocked)
            //{
            //    Sdl.SDL_UnlockSurface(_m_SdlSurface);
            //}
        }

        private void AllComplite(IAsyncResult ir)
        {
            SetEnabledState(toolStrip1, true);
            SetEnabledState(pictureBox1, true);
            SetEnabledState(tabControl1, true);

            MessageBox.Show(Localization.Locales.Resources.CellFieldUI_AllCompliteBox_Text,
                Localization.Locales.Resources.CellFieldUI_AllCompliteBox_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            _autoTransitionsOn = false;
        }

        public delegate void SetEnabledStateCallBack(Control control, bool enabled);
        public static void SetEnabledState(Control control, bool enabled)
        {
            if (control.InvokeRequired)
            {
                SetEnabledStateCallBack d = SetEnabledState;
                control.Invoke(d, new object[] { control, enabled });
            }
            else
            {
                control.Enabled = enabled;
            }
        }
        # endregion
    }
}
