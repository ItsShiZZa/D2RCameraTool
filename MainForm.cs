using System.Diagnostics;

namespace D2RCameraTool
{

    public partial class MainForm : Form
    {
        public static readonly double DEFAULT_THROTTLE_SECONDS = 0.01;
        public static readonly float DEFAULT_SENSITIVITY = 0.5f;

        public static bool DisableHotKeys;
        public static bool IsMousePanPressed;
        public static bool IsMouseZoomPressed;

        
        private static readonly string INI_FILE_NAME = "settings.ini";

        private static AppConfig IniFile;
        private static CameraPreset[] PresetsArray;
        private static Keys MousePanHotKey = Keys.Space;
        private static Keys MouseZoomHotKey = Keys.Z;
        private static double throttleDelay;
        private static float screenWidth;
        private static float mouseSensitivity;
        private long lastTicks;
        private Point lastMouse;
        private bool isDragging;
        private bool isZoomDragging;
        private float startPitch;
        private float startCamHeight;
        private float startCamPan;
        private float startRoll;
        private float startZoom;

        public MainForm() {
            InitializeComponent();
            PresetsArray = new CameraPreset[5];
            for (int i = 0; i < PresetsArray.Length; i++) {
                PresetsArray[i] = new CameraPreset();
            }

            if (Presets_Combo.Items.Count > 0) {
                Presets_Combo.SelectedIndex = 0;
            }
        }

        private void InitHotkeys() {
            GlobalHotkeys.HookKeyboard();
            GlobalHotkeys.KeyPressed += GlobalHotKey_Pressed!;
            GlobalHotkeys.KeyReleased += GlobalHotKey_Released!;
        }

        private void DestroyHotkeys() {
            GlobalHotkeys.UnhookKeyboard();
        }

        private void Form1_Load(object sender, EventArgs e) {
            throttleDelay = DEFAULT_THROTTLE_SECONDS;
            UpdateDelay_TextBox.Text = DEFAULT_THROTTLE_SECONDS.ToString();

            mouseSensitivity = DEFAULT_SENSITIVITY;
            Sensitivity_UpDown.Value = (decimal)DEFAULT_SENSITIVITY;

            IniFile = new AppConfig(INI_FILE_NAME);
            if (IniFile != null) {
                LoadSettingsIni();
            }

            screenWidth = (float)Screen.PrimaryScreen.Bounds.Width;
            InitHotkeys();

            TopMost = TopMost_CheckBox.Checked;
        }

        private void Form1_Shown(object sender, EventArgs e) {
            Application.Idle += FormIdle_Tick!;
            Application.Idle += Program.Idle_Tick!;
            Program.FormShown_Callback();

            TopMost = TopMost_CheckBox.Checked;
        }

        private void TopMost_CheckedChanged(object sender, EventArgs e) {
            TopMost = TopMost_CheckBox.Checked;
        }

        private void ProgramEnabled_CheckBox_CheckedChanged(object sender, EventArgs e) {
            if (ProgramEnabled_CheckBox.Checked) {
                Program.EnableChecked();
            } else {
                Program.EnableUnchecked();
            }
        }

        private void PitchSpinner_ValueChanged(object sender, EventArgs e) {
            Program.TryChangeValue(Program.PitchValue, (float)PitchSpinner.Value, PitchSpinner);
        }

        private void CamHeight_UpDown_ValueChanged(object sender, EventArgs e) {
            Program.TryChangeValue(Program.CamHeightValue, (float)CamHeight_UpDown.Value, CamHeight_UpDown);
        }

        private void PitchReset_Click(object sender, EventArgs e) {
            PitchSpinner.ValueChanged -= PitchSpinner_ValueChanged!;
            Program.TryResetValue(Program.PitchValue, PitchSpinner);
            PitchSpinner.ValueChanged += PitchSpinner_ValueChanged!;
        }

        private void CamHeight_Reset_Click(object sender, EventArgs e) {
            CamHeight_UpDown.ValueChanged -= CamHeight_UpDown_ValueChanged!;
            Program.TryResetValue(Program.CamHeightValue, CamHeight_UpDown);
            CamHeight_UpDown.ValueChanged += CamHeight_UpDown_ValueChanged!;
        }

        private void CamPan_Reset_Click(object sender, EventArgs e) {
            CamPan_UpDown.ValueChanged -= CamPan_UpDown_ValueChanged!;
            Program.TryResetValue(Program.CamPanValue, CamPan_UpDown);
            CamPan_UpDown.ValueChanged += CamPan_UpDown_ValueChanged!;
        }

        private void RollReset_Button_Click(object sender, EventArgs e) {
            Roll_UpDown.ValueChanged -= Roll_UpDown_ValueChanged!;
            Program.TryResetValue(Program.RollValue, Roll_UpDown);
            Roll_UpDown.ValueChanged += Roll_UpDown_ValueChanged!;
        }

        private void ZoomReset_Button_Click(object sender, EventArgs e) {
            if (!Program.ZoomFound)
                return;

            Zoom_UpDown.ValueChanged -= Zoom_UpDown_ValueChanged!;
            Program.ZoomValue.Write(0);
            Zoom_UpDown.Value = 0;
            Zoom_UpDown.ValueChanged += Zoom_UpDown_ValueChanged!;
        }

        private void PitchDragButton_MouseDown(object sender, MouseEventArgs e) {
            StartPitchDragging();
            isDragging = true;
        }

        private void StartPitchDragging() {
            lastMouse = Control.MousePosition;
            //startMouse = PitchDragButton.PointToClient(Control.MousePosition);
            startPitch = Program.PitchValue.Read();
            startCamHeight = Program.CamHeightValue.Read();
            startCamPan = Program.CamPanValue.Read();
            startRoll = Program.RollValue.Read();
            startZoom = Program.ZoomValue.Read();
            lastTicks = 0;
        }

        private void StartZoomDragging() {
            lastMouse = Control.MousePosition;
            //startMouse = PitchDragButton.PointToClient(Control.MousePosition);
            startZoom = Program.ZoomValue.Read();
            lastTicks = 0;
        }

        private void PitchDragButton_MouseUp(object sender, MouseEventArgs e) {
            isDragging = false;
            lastTicks = 0;
        }

        private void GlobalHotKey_Pressed(object sender, KeyEventArgs e) {
            if (MousePanHotKey != Keys.None && e.KeyCode == MousePanHotKey) {
                if (!IsMousePanPressed) {
                    StartPitchDragging();
                }
                IsMousePanPressed = true;
            } else if (MouseZoomHotKey != Keys.None && e.KeyCode == MouseZoomHotKey) {
                if (!IsMouseZoomPressed) {
                    StartZoomDragging();
                }
                IsMouseZoomPressed = true;
            }
        }

        private void GlobalHotKey_Released(object sender, KeyEventArgs e) {
            if (MousePanHotKey != Keys.None && e.KeyCode == MousePanHotKey) {
                IsMousePanPressed = false;
            } else if (MouseZoomHotKey != Keys.None && e.KeyCode == MouseZoomHotKey) {
                IsMouseZoomPressed = false;
            }
        }

        private void ZoomDrag_Tick() {
            if (!Program.ProgramEnabled || !Program.ZoomFound) {
                isZoomDragging = false;
                return;
            }

            long updateDelayInTicks = (long)(throttleDelay * TimeSpan.TicksPerSecond);
            long currentTicks = DateTime.Now.Ticks;
            long elapsedTicks = currentTicks - lastTicks;
            if (elapsedTicks < updateDelayInTicks)
                return;
            lastTicks = currentTicks;

            Point currentMousePosition = Control.MousePosition;
            int delta = currentMousePosition.X - lastMouse.X;
            lastMouse = currentMousePosition;
            float deltaValue = delta / screenWidth;

            float zoom = SmoothTransform(delta, Program.ZoomValue.Read(), -0.249f, 2.0f, mouseSensitivity);
            if (Program.TryChangeZoom(zoom, Zoom_UpDown)) {
                Zoom_UpDown.ValueChanged -= Zoom_UpDown_ValueChanged!;
                Zoom_UpDown.Value = (decimal)zoom;
                Zoom_UpDown.ValueChanged += Zoom_UpDown_ValueChanged!;
            }
        }

        private void PitchDrag_Tick() {
            if (!Program.ProgramEnabled || !Program.ValuesFound) {
                isDragging = false;
                return;
            }

            long updateDelayInTicks = (long)(throttleDelay * TimeSpan.TicksPerSecond);
            long currentTicks = DateTime.Now.Ticks;
            long elapsedTicks = currentTicks - lastTicks;
            if (elapsedTicks < updateDelayInTicks)
                return;
            lastTicks = currentTicks;

            Point currentMousePosition = Control.MousePosition;
            int delta = currentMousePosition.X - lastMouse.X;
            lastMouse = currentMousePosition;
            float deltaValue = delta / screenWidth;

            if (PitchAngle_CheckBox.Checked) {
                float pitchResult = SmoothTransform(delta, Program.PitchValue.Read(), -2.0f, 2.0f, mouseSensitivity);
                if (Program.TryChangeValue(Program.PitchValue, pitchResult, PitchSpinner)) {
                    PitchSpinner.ValueChanged -= PitchSpinner_ValueChanged!;
                    PitchSpinner.Value = (decimal)pitchResult;
                    PitchSpinner.ValueChanged += PitchSpinner_ValueChanged!;
                }
            }
            if (CamHeight_CheckBox.Checked) {
                float camHeightResult = SmoothTransform(delta, Program.CamHeightValue.Read(), -2.0f, 2.0f, mouseSensitivity);
                if (Program.TryChangeValue(Program.CamHeightValue, camHeightResult, CamHeight_UpDown)) {
                    CamHeight_UpDown.ValueChanged -= CamHeight_UpDown_ValueChanged!;
                    CamHeight_UpDown.Value = (decimal)camHeightResult;
                    CamHeight_UpDown.ValueChanged += CamHeight_UpDown_ValueChanged!;
                }
            }
            if (CamPan_CheckBox.Checked) {
                float camPanResult = SmoothTransform(delta, Program.CamPanValue.Read(), -2.0f, 2.0f, mouseSensitivity);
                if (Program.TryChangeValue(Program.CamPanValue, camPanResult, CamPan_UpDown)) {
                    CamPan_UpDown.ValueChanged -= CamPan_UpDown_ValueChanged!;
                    CamPan_UpDown.Value = (decimal)camPanResult;
                    CamPan_UpDown.ValueChanged += CamPan_UpDown_ValueChanged!;
                }
            }
            if (Roll_CheckBox.Checked) {
                float rollResult = SmoothTransform(delta, Program.RollValue.Read(), -2.0f, 2.0f, mouseSensitivity);
                if (Program.TryChangeValue(Program.RollValue, rollResult, Roll_UpDown)) {
                    Roll_UpDown.ValueChanged -= Roll_UpDown_ValueChanged!;
                    Roll_UpDown.Value = (decimal)rollResult;
                    Roll_UpDown.ValueChanged += Roll_UpDown_ValueChanged!;
                }
            }
            if (Zoom_CheckBox.Checked && Program.ZoomFound) {
                float zoom = SmoothTransform(delta, Program.ZoomValue.Read(), (float)Zoom_UpDown.Minimum, (float)Zoom_UpDown.Maximum, mouseSensitivity);
                if (Program.TryChangeZoom(zoom, Zoom_UpDown)) {
                    Zoom_UpDown.ValueChanged -= Zoom_UpDown_ValueChanged!;
                    Zoom_UpDown.Value = (decimal)zoom;
                    Zoom_UpDown.ValueChanged += Zoom_UpDown_ValueChanged!;
                }
            }
        }

        private void FormIdle_Tick(object sender, EventArgs e) {
            if (isDragging || IsMousePanPressed) {
                PitchDrag_Tick();
            } else if (isZoomDragging || IsMouseZoomPressed) {
                ZoomDrag_Tick();
            }

        }

        private static float SmoothTransform(int delta, float current, float minValue, float maxValue, float rate) {
            float scaledDelta = delta / screenWidth;
            float deltaValue = scaledDelta * rate;
            float result = current + deltaValue;
            result = Math.Clamp(result, minValue, maxValue);

            return result;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            DestroyHotkeys();
            SaveSettingsIni();
        }

        private void HotKeysEnabled_CheckBox_CheckedChanged(object sender, EventArgs e) {
            DisableHotKeys = !HotKeysEnabled_CheckBox.Checked;
        }

        private void MouseHotKey_TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.None) {
                MouseHotKey_TextBox.Text = e.KeyCode.ToString();
                System.Threading.Timer? delay = null;
                delay = new System.Threading.Timer((state) => {
                    MousePanHotKey = e.KeyCode;
                    delay?.Dispose();
                }, null, 1000, 0);
            }
            Program.PlayBeepSound();
        }

        private void ZoomHotKey_TextBox_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode != Keys.None) {
                ZoomHotKey_TextBox.Text = e.KeyCode.ToString();
                System.Threading.Timer? delay = null;
                delay = new System.Threading.Timer((state) => {
                    MouseZoomHotKey = e.KeyCode;
                    delay?.Dispose();
                }, null, 1000, 0);
            }
            Program.PlayBeepSound();
        }

        private void CamPan_UpDown_ValueChanged(object sender, EventArgs e) {
            Program.TryChangeValue(Program.CamPanValue, (float)CamPan_UpDown.Value, CamPan_UpDown);
        }

        private void Roll_UpDown_ValueChanged(object sender, EventArgs e) {
            Program.TryChangeValue(Program.RollValue, (float)Roll_UpDown.Value, Roll_UpDown);
        }

        private void Zoom_UpDown_ValueChanged(object sender, EventArgs e) {
            Program.TryChangeZoom((float)Zoom_UpDown.Value, Zoom_UpDown);
        }

        private void SensitivityReset_Button_Click(object sender, EventArgs e) {
            Sensitivity_UpDown.Value = (decimal)DEFAULT_SENSITIVITY;
            mouseSensitivity = DEFAULT_SENSITIVITY;
        }

        private void Sensitivity_UpDown_ValueChanged(object sender, EventArgs e) {
            mouseSensitivity = (float)Sensitivity_UpDown.Value;
        }

        private void UpdateDelay_TextBox_TextChanged(object sender, EventArgs e) {
            if (double.TryParse(UpdateDelay_TextBox.Text, out var t)) {
                throttleDelay = t;
            } else {
                throttleDelay = DEFAULT_THROTTLE_SECONDS;
            }
        }

        private void ZoomDrag_Button_MouseUp(object sender, MouseEventArgs e) {
            isZoomDragging = false;
            lastTicks = 0;
        }

        private void ZoomDrag_Button_MouseDown(object sender, MouseEventArgs e) {
            StartZoomDragging();
            isZoomDragging = true;
        }

        private void Main_Panel_Paint(object sender, PaintEventArgs e) {

        }

        private void Save_Button_Click(object sender, EventArgs e) {
            int i = Presets_Combo.SelectedIndex - 1;
            if (i < 0)
                return;

            SavePresetValues(PresetsArray[i]);

            Status_Label.Text = "Presets saved to slot " + Presets_Combo.SelectedIndex.ToString();
        }

        private void LoadPresetValues(CameraPreset preset) {
            if (preset == null || !Program.ValuesFound)
                return;

            Sensitivity_UpDown.Value = (decimal)preset.Sensitivity;
            UpdateDelay_TextBox.Text = preset.Throttle.ToString();

            PitchSpinner.Value = (decimal)preset.Pitch;
            CamPan_UpDown.Value = (decimal)preset.Yaw;
            Roll_UpDown.Value = (decimal)preset.Roll;
            CamHeight_UpDown.Value = (decimal)preset.Height;

            if (preset.ZoomHotKey != Keys.None) {
                MouseZoomHotKey = preset.ZoomHotKey;
                ZoomHotKey_TextBox.Text = preset.ZoomHotKey.ToString();
            }                
            if (preset.PanHotKey != Keys.None) {
                MousePanHotKey = preset.PanHotKey;
                MouseHotKey_TextBox.Text = preset.PanHotKey.ToString();
            }                

            if (Program.ZoomFound && preset.Zoom != float.MaxValue) {
                Zoom_UpDown.Value = (decimal)preset.Zoom;
            }
        }

        private void ResetDefaultValues() {
            UpdateDelay_TextBox.Text = DEFAULT_THROTTLE_SECONDS.ToString();
            Sensitivity_UpDown.Value = (decimal)DEFAULT_SENSITIVITY;

            if (Program.ValuesFound) {
                Program.PitchValue.Reset();
                PitchSpinner.Value = (decimal)Program.PitchValue.Read();
                Program.PitchValue.Reset();

                Program.CamPanValue.Reset();
                CamPan_UpDown.Value = (decimal)Program.CamPanValue.Read();
                Program.CamPanValue.Reset();

                Program.CamHeightValue.Reset();
                CamHeight_UpDown.Value = (decimal)Program.CamHeightValue.Read();
                Program.CamHeightValue.Reset();

                Program.RollValue.Reset();
                Roll_UpDown.Value = (decimal)Program.RollValue.Read();
                Program.RollValue.Reset();
            }
            if (Program.ZoomFound) {
                Program.ZoomValue.Reset();
                Zoom_UpDown.Value = (decimal)Program.ZoomValue.Read();
                Program.ZoomValue.Reset();
            }
        }

        private void SavePresetValues(CameraPreset preset) {
            if (preset == null || !Program.ValuesFound)
                return;

            Trace.WriteLine("Saving preset values");

            preset.Sensitivity = mouseSensitivity;
            preset.Throttle = throttleDelay;

            preset.Pitch = (float)PitchSpinner.Value;
            preset.Yaw = (float)CamPan_UpDown.Value;
            preset.Roll = (float)Roll_UpDown.Value;
            preset.Height = (float)CamHeight_UpDown.Value;

            preset.ZoomHotKey = MouseZoomHotKey;
            preset.PanHotKey = MousePanHotKey;

            if (Program.ZoomFound) {
                preset.Zoom = (float)Zoom_UpDown.Value;
            } else {
                preset.Zoom = float.MaxValue;
            }
        }

        private void Load_Button_Click(object sender, EventArgs e) {
            int i = Presets_Combo.SelectedIndex;
            if (i == 0) {
                Sensitivity_UpDown.Value = (decimal)DEFAULT_SENSITIVITY;
                UpdateDelay_TextBox.Text = DEFAULT_THROTTLE_SECONDS.ToString();
                ResetDefaultValues();
                Program.PlayBeepSound();
                Status_Label.Text = "Game default values loaded";
            } else {
                LoadPresetValues(PresetsArray[i - 1]);
                Status_Label.Text = "Loaded preset slot " + i.ToString();
            }
        }

        private void DonateLink_Label_Click(object sender, EventArgs e) {
            Program.OpenUrl(DonateLink_Label.Text);
        }

        private void SaveSettingsIni() {
            if (IniFile == null)
                return;

            Dictionary<string, string> data = new Dictionary<string, string>();
            data["sensitivity"] = mouseSensitivity.ToString();
            data["zoom_hotkey"] = MouseZoomHotKey.ToString();
            data["pan_hotkey"] = MousePanHotKey.ToString();
            data["throttle"] = throttleDelay.ToString();

            for (int i=0; i<PresetsArray.Length; i++) {
                float[] preset = { PresetsArray[i].Sensitivity, PresetsArray[i].Pitch, PresetsArray[i].Yaw, PresetsArray[i].Roll, PresetsArray[i].Height, PresetsArray[i].Zoom };
                data["preset" + (i+1).ToString()] = JoinFloats(preset);
            }
            

            IniFile.Save(data);
        }

        private void LoadSettingsIni() {
            if (IniFile == null)
                return;

            Dictionary<string, string> data = IniFile.Load();
            float[] preset;

            foreach (var pair in data) {
                switch (pair.Key) {
                    case "sensitivity":
                        if (float.TryParse(pair.Value, out var result)) {
                            Sensitivity_UpDown.Value = (decimal)result;
                            mouseSensitivity = result;
                        }
                        break;
                    case "zoom_hotkey":
                        Keys key = (Keys)Enum.Parse(typeof(Keys), pair.Value);
                        if (key != Keys.None) {
                            MouseZoomHotKey = key;
                            ZoomHotKey_TextBox.Text = pair.Value;
                        }
                        break;
                    case "pan_hotkey":
                        Keys panKey = (Keys)Enum.Parse(typeof(Keys), pair.Value);
                        if (panKey != Keys.None) {
                            MousePanHotKey = panKey;
                            ZoomHotKey_TextBox.Text = pair.Value;
                        }
                        break;
                    case "throttle":
                        UpdateDelay_TextBox.Text = pair.Value;
                        break;
                    case "preset1":
                        preset = StringToFloats(pair.Value);
                        FloatsToPreset(preset, 0);
                        break;
                    case "preset2":
                        preset = StringToFloats(pair.Value);
                        FloatsToPreset(preset, 1);
                        break;
                    case "preset3":
                        preset = StringToFloats(pair.Value);
                        FloatsToPreset(preset, 2);
                        break;
                    case "preset4":
                        preset = StringToFloats(pair.Value);
                        FloatsToPreset(preset, 3);
                        break;
                    case "preset5":
                        preset = StringToFloats(pair.Value);
                        FloatsToPreset(preset, 4);
                        break;

                }
                // MessageBox.Show($"Key: {pair.Key}, Value: {pair.Value}");
            }
        }

        private static void FloatsToPreset(float[] preset, int i) {
            if (i >= PresetsArray.Length)
                return;
            PresetsArray[i].Sensitivity = preset[0];
            PresetsArray[i].Pitch = preset[1];
            PresetsArray[i].Yaw = preset[2];
            PresetsArray[i].Roll = preset[3];
            PresetsArray[i].Height = preset[4];
            PresetsArray[i].Zoom = preset[5];

        }

        public static float[] StringToFloats(string str) {
            string[] parts = str.Split(',');
            float[] values = new float[parts.Length];
            for (int i = 0; i < parts.Length; i++) {
                if (float.TryParse(parts[i], out float value)) {
                    values[i] = value;
                } else {
                    throw new ArgumentException("Invalid float value in the input string.");
                }
            }
            return values;
        }
        private static string JoinFloats(float[] values) => string.Join(",", values);

    }
}
