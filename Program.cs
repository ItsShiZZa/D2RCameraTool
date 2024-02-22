using Memory;
using System.Diagnostics;

namespace D2RCameraTool
{
    internal static class Program
    {
        public static Mem MemLib;

        public static bool ProgramEnabled = true;
        public static bool ProcessFound;
        public static bool IsAngleScanning;
        public static bool IsZoomScanning;
        public static bool ValuesFound;
        public static bool ZoomFound;

        public static MainForm MainFormInstance;

        public static FloatValue PitchValue;
        public static FloatValue CamHeightValue;
        public static FloatValue CamPanValue;
        public static FloatValue RollValue;
        public static FloatValue ZoomValue;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            MainFormInstance = new MainForm();
            if (MainFormInstance == null) {
                Application.Exit();
            }
            Application.Run(MainFormInstance);
        }

        public static void EnableChecked() {
            ProgramEnabled = true;
        }

        public static void EnableUnchecked() {
            ProgramEnabled = false;
        }

        public static void FormShown_Callback() {
            Init();
        }

        private static void InitTimers() {
            GlobalTimers.Reset();
        }

        private static void Init() {



            MemLib = new Mem();

            if (MemLib == null) {
                MessageBox.Show("Failed to initialize Memory.dll. Check Windows Defender or other antivirus software for false positive detection. Please see:\nhttps://github.com/erfg12/memory.dll/", "Error", MessageBoxButtons.OK);
                Application.Exit();
            }
            InitValues();
            InitTimers();
        }

        private static void InitValues() {
            PitchValue = new FloatValue(new byte[] { 0x44, 0x74, 0x64, 0xBF });
            CamHeightValue = new FloatValue(new byte[] { 0x3F, 0xDB, 0x74, 0x3E });
            CamPanValue = new FloatValue(new byte[] { 0xF4, 0x41, 0xBD, 0x3E });
            RollValue = new FloatValue(new byte[] { 0x81, 0xD8, 0xCA, 0x3D });
            ZoomValue = new FloatValue(new byte[] { 0x00, 0x00, 0x00, 0x00 });
        }

        public static void Idle_Tick(object sender, EventArgs e) {

        }

        public static void ProcessScan_Tick() {
            if (!ProgramEnabled || ProcessFound)
                return;

            string process = MainFormInstance.ProcessName_Text.Text;
            if (string.IsNullOrWhiteSpace(process))
                return;

            if (MemLib.OpenProcess(process)) {
                ProcessFound = true;
                MainFormInstance.ProcessName_Text.Enabled = false;
                MainFormInstance.Status_Label.Text = "Process found!";
                PlayBeepSound();
                // Timers.BeginAngleScan_Timer.Start();
            }
        }

        public static async void ValueScan_Tick() {
            if (!ProgramEnabled || ValuesFound || IsAngleScanning || !ProcessFound)
                return;

            IsAngleScanning = true;
            MainFormInstance.Status_Label.Text = "Be patient, searching...";
            var scan = await MemLib.AoBScan(0, 0x7FFFFFFFFFFF, "44 74 64 BF 3F DB 74 3E F4 41 BD 3E", true);
            long result = scan.FirstOrDefault();
            if (result != 0) {
                ValuesFound = true;
                PlayBeepSound();
                MainFormInstance.Status_Label.Text = "Values found at: " + "0x" + result.ToString("X");
                RefreshValues(result);
                UnlockValueControls();
            }
            IsAngleScanning = false;
        }

        public static async void ZoomScan_Tick() {
            if (!ProgramEnabled || ZoomFound || !ValuesFound || IsZoomScanning || !ProcessFound)
                return;
            IsZoomScanning = true;

            MainFormInstance.Status_Label.Text = "Next step, searching for zoom value...";
            var scan = await MemLib.AoBScan(0, 0x7FFFFFFFFFFF, "00 00 06 00 00 00 ?? ?? ?? ?? ?? ?? ?? 43 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 01 00 00 00 00 00 00 00 00 00 80 3F", true);
            long result = scan.FirstOrDefault();
            if (result != 0) {
                long zoomBase = result + 0x32;
                ZoomValue.UpdateBase(zoomBase);
                ZoomFound = true;
                PlayBeepSound();
                MainFormInstance.Status_Label.Text = "Zoom found at: " + "0x" + zoomBase.ToString("X");
                UnlockZoomControls();                
                MainFormInstance.Zoom_UpDown.Value = (decimal)ZoomValue.Read();
                //RefreshValues(result);
                //UnlockValueControls();
            }
            IsZoomScanning = false;
        }

        public static void RefreshValues(long valuesBase) {
            if (valuesBase <= 0)
                return;

            PitchValue.UpdateBase(valuesBase);
            CamHeightValue.UpdateBase(valuesBase + 0x4);
            CamPanValue.UpdateBase(valuesBase + 0x8);
            RollValue.UpdateBase(valuesBase - 0x4);

            MainFormInstance.PitchSpinner.Value = (decimal)PitchValue.Read();
            MainFormInstance.CamHeight_UpDown.Value = (decimal)CamHeightValue.Read();
            MainFormInstance.CamPan_UpDown.Value = (decimal)CamPanValue.Read();
            MainFormInstance.Roll_UpDown.Value = (decimal)RollValue.Read();
        }

        private static void UnlockValueControls(bool unlocked = true) {
            MainFormInstance.PitchAngle_CheckBox.Enabled = unlocked;
            MainFormInstance.PitchSpinner.Enabled = unlocked;
            MainFormInstance.PitchReset.Enabled = unlocked;
            MainFormInstance.PitchDragButton.Enabled = unlocked;

            MainFormInstance.CamHeight_CheckBox.Enabled = unlocked;
            MainFormInstance.CamHeight_UpDown.Enabled = unlocked;
            MainFormInstance.CamHeight_Reset.Enabled = unlocked;

            MainFormInstance.CamPan_CheckBox.Enabled = unlocked;
            MainFormInstance.CamPan_UpDown.Enabled = unlocked;
            MainFormInstance.CamPan_Reset.Enabled = unlocked;

            MainFormInstance.Roll_CheckBox.Enabled = unlocked;
            MainFormInstance.Roll_UpDown.Enabled = unlocked;
            MainFormInstance.RollReset_Button.Enabled = unlocked;
        }

        private static void UnlockZoomControls(bool unlocked = true) {
            MainFormInstance.Zoom_CheckBox.Enabled = unlocked;
            MainFormInstance.Zoom_UpDown.Enabled = unlocked;
            MainFormInstance.ZoomReset_Button.Enabled = unlocked;
            MainFormInstance.ZoomDrag_Button.Enabled = unlocked;
        }
        public static void OpenUrl(string url) {
            try {
                ProcessStartInfo psi = new() { FileName = url, UseShellExecute = true };
                Process.Start(psi);
            } catch (Exception ex) {
                MessageBox.Show("Error opening URL: " + ex.Message);
            }
        }
        public static void PlayBeepSound() => System.Media.SystemSounds.Beep.Play();

        public static string FloatToHex(float floatValue) {
            byte[] bytes = BitConverter.GetBytes(floatValue);
            return BitConverter.ToString(bytes).Replace("-", " ");
        }

        public static bool TryChangeValue(FloatValue change, float newValue, NumericUpDown? spinner = null) {
            if (change == null || !ProgramEnabled || !ValuesFound || !ProcessFound)
                return false;

            if (change.Write(newValue))
                return true;

            return false;
        }

        public static bool TryChangeZoom(float zoom, NumericUpDown? spinner = null) {
            if (!ProgramEnabled || ZoomValue == null || !ZoomFound || !ProcessFound)
                return false;

            if (ZoomValue.Write(zoom)) {
            } else {
                ZoomFound = false;
                ZoomValue.UpdateBase(0);
                UnlockZoomControls(false);
            }
            return true;
        }

        public static void TryResetValue(FloatValue change, NumericUpDown? spinner = null) {
            if (change == null || change.BaseAddress <= 0 || !ProgramEnabled || !ValuesFound || !ProcessFound)
                return;

            change.Reset();

            if (spinner != null) {
                spinner.Value = (decimal)change.Read();
            }
        }

        public static void TryChangeWithMouseInput(FloatValue change) {
            Point mousePosition = Control.MousePosition;

            // Convert screen coordinates to client coordinates if necessary
            //mousePosition = button.PointToClient(Control.MousePosition);
        }
    }
}