namespace D2RCameraTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            statusStrip1 = new StatusStrip();
            Status_Label = new ToolStripStatusLabel();
            DonateLink_Label = new ToolStripStatusLabel();
            Main_Panel = new Panel();
            Save_Button = new Button();
            Load_Button = new Button();
            Presets_Combo = new ComboBox();
            Warning_Label = new Label();
            SensitivityReset_Button = new Button();
            Sensitivity_UpDown = new NumericUpDown();
            Sensitivity_Label = new Label();
            label2 = new Label();
            ZoomHotKey_TextBox = new TextBox();
            ZoomDrag_Button = new Button();
            Zoom_CheckBox = new CheckBox();
            ZoomReset_Button = new Button();
            Zoom_UpDown = new NumericUpDown();
            Roll_CheckBox = new CheckBox();
            RollReset_Button = new Button();
            Roll_UpDown = new NumericUpDown();
            CamPan_CheckBox = new CheckBox();
            CamPan_Reset = new Button();
            CamPan_UpDown = new NumericUpDown();
            CamHeight_CheckBox = new CheckBox();
            CamHeight_Reset = new Button();
            CamHeight_UpDown = new NumericUpDown();
            MouseHotKey_Label = new Label();
            MouseHotKey_TextBox = new TextBox();
            PitchAngle_CheckBox = new CheckBox();
            HotKeysEnabled_CheckBox = new CheckBox();
            UpdateDelay_TextBox = new TextBox();
            UpdateDelay_Label = new Label();
            PitchDragButton = new Button();
            PitchReset = new Button();
            PitchSpinner = new NumericUpDown();
            TopMost_CheckBox = new CheckBox();
            ProgramEnabled_CheckBox = new CheckBox();
            ProcessName_Text = new TextBox();
            label1 = new Label();
            statusStrip1.SuspendLayout();
            Main_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Sensitivity_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Zoom_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Roll_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CamPan_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)CamHeight_UpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PitchSpinner).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { Status_Label, DonateLink_Label });
            statusStrip1.Location = new Point(0, 322);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(791, 24);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // Status_Label
            // 
            Status_Label.AutoSize = false;
            Status_Label.BackColor = SystemColors.Control;
            Status_Label.Name = "Status_Label";
            Status_Label.Padding = new Padding(0, 0, 400, 0);
            Status_Label.Size = new Size(535, 19);
            Status_Label.Text = "Scanning for process...   ";
            Status_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // DonateLink_Label
            // 
            DonateLink_Label.BackColor = SystemColors.Control;
            DonateLink_Label.BorderSides = ToolStripStatusLabelBorderSides.Left;
            DonateLink_Label.BorderStyle = Border3DStyle.Sunken;
            DonateLink_Label.DisplayStyle = ToolStripItemDisplayStyle.Text;
            DonateLink_Label.IsLink = true;
            DonateLink_Label.LinkBehavior = LinkBehavior.AlwaysUnderline;
            DonateLink_Label.Name = "DonateLink_Label";
            DonateLink_Label.Overflow = ToolStripItemOverflow.Never;
            DonateLink_Label.Padding = new Padding(20, 0, 0, 0);
            DonateLink_Label.Size = new Size(240, 19);
            DonateLink_Label.Text = "https://www.buymeacoffee.com/shizza";
            DonateLink_Label.ToolTipText = "Donations link";
            DonateLink_Label.Click += DonateLink_Label_Click;
            // 
            // Main_Panel
            // 
            Main_Panel.BackColor = SystemColors.ControlLightLight;
            Main_Panel.Controls.Add(Save_Button);
            Main_Panel.Controls.Add(Load_Button);
            Main_Panel.Controls.Add(Presets_Combo);
            Main_Panel.Controls.Add(Warning_Label);
            Main_Panel.Controls.Add(SensitivityReset_Button);
            Main_Panel.Controls.Add(Sensitivity_UpDown);
            Main_Panel.Controls.Add(Sensitivity_Label);
            Main_Panel.Controls.Add(label2);
            Main_Panel.Controls.Add(ZoomHotKey_TextBox);
            Main_Panel.Controls.Add(ZoomDrag_Button);
            Main_Panel.Controls.Add(Zoom_CheckBox);
            Main_Panel.Controls.Add(ZoomReset_Button);
            Main_Panel.Controls.Add(Zoom_UpDown);
            Main_Panel.Controls.Add(Roll_CheckBox);
            Main_Panel.Controls.Add(RollReset_Button);
            Main_Panel.Controls.Add(Roll_UpDown);
            Main_Panel.Controls.Add(CamPan_CheckBox);
            Main_Panel.Controls.Add(CamPan_Reset);
            Main_Panel.Controls.Add(CamPan_UpDown);
            Main_Panel.Controls.Add(CamHeight_CheckBox);
            Main_Panel.Controls.Add(CamHeight_Reset);
            Main_Panel.Controls.Add(CamHeight_UpDown);
            Main_Panel.Controls.Add(MouseHotKey_Label);
            Main_Panel.Controls.Add(MouseHotKey_TextBox);
            Main_Panel.Controls.Add(PitchAngle_CheckBox);
            Main_Panel.Controls.Add(HotKeysEnabled_CheckBox);
            Main_Panel.Controls.Add(UpdateDelay_TextBox);
            Main_Panel.Controls.Add(UpdateDelay_Label);
            Main_Panel.Controls.Add(PitchDragButton);
            Main_Panel.Controls.Add(PitchReset);
            Main_Panel.Controls.Add(PitchSpinner);
            Main_Panel.Controls.Add(TopMost_CheckBox);
            Main_Panel.Controls.Add(ProgramEnabled_CheckBox);
            Main_Panel.Controls.Add(ProcessName_Text);
            Main_Panel.Controls.Add(label1);
            Main_Panel.Location = new Point(12, 12);
            Main_Panel.Name = "Main_Panel";
            Main_Panel.Size = new Size(767, 296);
            Main_Panel.TabIndex = 1;
            Main_Panel.Paint += Main_Panel_Paint;
            // 
            // Save_Button
            // 
            Save_Button.Location = new Point(274, 44);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(96, 23);
            Save_Button.TabIndex = 39;
            Save_Button.Text = "Save";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += Save_Button_Click;
            // 
            // Load_Button
            // 
            Load_Button.Location = new Point(179, 44);
            Load_Button.Name = "Load_Button";
            Load_Button.Size = new Size(89, 23);
            Load_Button.TabIndex = 38;
            Load_Button.Text = "Load";
            Load_Button.UseVisualStyleBackColor = true;
            Load_Button.Click += Load_Button_Click;
            // 
            // Presets_Combo
            // 
            Presets_Combo.DropDownStyle = ComboBoxStyle.DropDownList;
            Presets_Combo.FormattingEnabled = true;
            Presets_Combo.Items.AddRange(new object[] { "Default Values", "Preset 1", "Preset 2", "Preset 3", "Preset 4", "Preset 5" });
            Presets_Combo.Location = new Point(179, 16);
            Presets_Combo.Name = "Presets_Combo";
            Presets_Combo.Size = new Size(191, 23);
            Presets_Combo.TabIndex = 37;
            // 
            // Warning_Label
            // 
            Warning_Label.Location = new Point(3, 225);
            Warning_Label.Name = "Warning_Label";
            Warning_Label.Size = new Size(761, 60);
            Warning_Label.TabIndex = 36;
            Warning_Label.Text = resources.GetString("Warning_Label.Text");
            Warning_Label.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // SensitivityReset_Button
            // 
            SensitivityReset_Button.Location = new Point(663, 14);
            SensitivityReset_Button.Name = "SensitivityReset_Button";
            SensitivityReset_Button.Size = new Size(89, 23);
            SensitivityReset_Button.TabIndex = 35;
            SensitivityReset_Button.Text = "Reset";
            SensitivityReset_Button.UseVisualStyleBackColor = true;
            SensitivityReset_Button.Click += SensitivityReset_Button_Click;
            // 
            // Sensitivity_UpDown
            // 
            Sensitivity_UpDown.DecimalPlaces = 1;
            Sensitivity_UpDown.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            Sensitivity_UpDown.Location = new Point(561, 14);
            Sensitivity_UpDown.Maximum = new decimal(new int[] { 100, 0, 0, 65536 });
            Sensitivity_UpDown.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            Sensitivity_UpDown.Name = "Sensitivity_UpDown";
            Sensitivity_UpDown.Size = new Size(96, 23);
            Sensitivity_UpDown.TabIndex = 34;
            Sensitivity_UpDown.UpDownAlign = LeftRightAlignment.Left;
            Sensitivity_UpDown.Value = new decimal(new int[] { 5, 0, 0, 65536 });
            Sensitivity_UpDown.ValueChanged += Sensitivity_UpDown_ValueChanged;
            // 
            // Sensitivity_Label
            // 
            Sensitivity_Label.AutoSize = true;
            Sensitivity_Label.Location = new Point(388, 16);
            Sensitivity_Label.Name = "Sensitivity_Label";
            Sensitivity_Label.Size = new Size(60, 15);
            Sensitivity_Label.TabIndex = 33;
            Sensitivity_Label.Text = "Sensitivity";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 199);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 32;
            label2.Text = "Mouse zoom hotkey";
            // 
            // ZoomHotKey_TextBox
            // 
            ZoomHotKey_TextBox.Location = new Point(175, 196);
            ZoomHotKey_TextBox.Name = "ZoomHotKey_TextBox";
            ZoomHotKey_TextBox.ReadOnly = true;
            ZoomHotKey_TextBox.Size = new Size(195, 23);
            ZoomHotKey_TextBox.TabIndex = 31;
            ZoomHotKey_TextBox.Text = "Z";
            ZoomHotKey_TextBox.TextAlign = HorizontalAlignment.Center;
            ZoomHotKey_TextBox.KeyDown += ZoomHotKey_TextBox_KeyDown;
            // 
            // ZoomDrag_Button
            // 
            ZoomDrag_Button.Enabled = false;
            ZoomDrag_Button.Location = new Point(3, 167);
            ZoomDrag_Button.Name = "ZoomDrag_Button";
            ZoomDrag_Button.Size = new Size(367, 23);
            ZoomDrag_Button.TabIndex = 30;
            ZoomDrag_Button.Text = "Click and drag to zoom";
            ZoomDrag_Button.UseVisualStyleBackColor = true;
            ZoomDrag_Button.MouseDown += ZoomDrag_Button_MouseDown;
            ZoomDrag_Button.MouseUp += ZoomDrag_Button_MouseUp;
            // 
            // Zoom_CheckBox
            // 
            Zoom_CheckBox.AutoSize = true;
            Zoom_CheckBox.Enabled = false;
            Zoom_CheckBox.Location = new Point(3, 141);
            Zoom_CheckBox.Name = "Zoom_CheckBox";
            Zoom_CheckBox.Size = new Size(58, 19);
            Zoom_CheckBox.TabIndex = 29;
            Zoom_CheckBox.Text = "Zoom";
            Zoom_CheckBox.UseVisualStyleBackColor = true;
            // 
            // ZoomReset_Button
            // 
            ZoomReset_Button.Enabled = false;
            ZoomReset_Button.Location = new Point(281, 138);
            ZoomReset_Button.Name = "ZoomReset_Button";
            ZoomReset_Button.Size = new Size(89, 23);
            ZoomReset_Button.TabIndex = 28;
            ZoomReset_Button.Text = "Reset";
            ZoomReset_Button.UseVisualStyleBackColor = true;
            ZoomReset_Button.Click += ZoomReset_Button_Click;
            // 
            // Zoom_UpDown
            // 
            Zoom_UpDown.DecimalPlaces = 6;
            Zoom_UpDown.Enabled = false;
            Zoom_UpDown.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            Zoom_UpDown.Location = new Point(179, 138);
            Zoom_UpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            Zoom_UpDown.Minimum = new decimal(new int[] { 249, 0, 0, -2147287040 });
            Zoom_UpDown.Name = "Zoom_UpDown";
            Zoom_UpDown.Size = new Size(96, 23);
            Zoom_UpDown.TabIndex = 27;
            Zoom_UpDown.UpDownAlign = LeftRightAlignment.Left;
            Zoom_UpDown.ValueChanged += Zoom_UpDown_ValueChanged;
            // 
            // Roll_CheckBox
            // 
            Roll_CheckBox.AutoSize = true;
            Roll_CheckBox.Checked = true;
            Roll_CheckBox.CheckState = CheckState.Checked;
            Roll_CheckBox.Enabled = false;
            Roll_CheckBox.Location = new Point(388, 103);
            Roll_CheckBox.Name = "Roll_CheckBox";
            Roll_CheckBox.Size = new Size(46, 19);
            Roll_CheckBox.TabIndex = 26;
            Roll_CheckBox.Text = "Roll";
            Roll_CheckBox.UseVisualStyleBackColor = true;
            // 
            // RollReset_Button
            // 
            RollReset_Button.Enabled = false;
            RollReset_Button.Location = new Point(663, 102);
            RollReset_Button.Name = "RollReset_Button";
            RollReset_Button.Size = new Size(89, 23);
            RollReset_Button.TabIndex = 24;
            RollReset_Button.Text = "Reset";
            RollReset_Button.UseVisualStyleBackColor = true;
            RollReset_Button.Click += RollReset_Button_Click;
            // 
            // Roll_UpDown
            // 
            Roll_UpDown.DecimalPlaces = 6;
            Roll_UpDown.Enabled = false;
            Roll_UpDown.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            Roll_UpDown.Location = new Point(561, 102);
            Roll_UpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            Roll_UpDown.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            Roll_UpDown.Name = "Roll_UpDown";
            Roll_UpDown.Size = new Size(96, 23);
            Roll_UpDown.TabIndex = 23;
            Roll_UpDown.UpDownAlign = LeftRightAlignment.Left;
            Roll_UpDown.ValueChanged += Roll_UpDown_ValueChanged;
            // 
            // CamPan_CheckBox
            // 
            CamPan_CheckBox.AutoSize = true;
            CamPan_CheckBox.Checked = true;
            CamPan_CheckBox.CheckState = CheckState.Checked;
            CamPan_CheckBox.Enabled = false;
            CamPan_CheckBox.Location = new Point(388, 74);
            CamPan_CheckBox.Name = "CamPan_CheckBox";
            CamPan_CheckBox.Size = new Size(47, 19);
            CamPan_CheckBox.TabIndex = 22;
            CamPan_CheckBox.Text = "Yaw";
            CamPan_CheckBox.UseVisualStyleBackColor = true;
            // 
            // CamPan_Reset
            // 
            CamPan_Reset.Enabled = false;
            CamPan_Reset.Location = new Point(663, 73);
            CamPan_Reset.Name = "CamPan_Reset";
            CamPan_Reset.Size = new Size(89, 23);
            CamPan_Reset.TabIndex = 20;
            CamPan_Reset.Text = "Reset";
            CamPan_Reset.UseVisualStyleBackColor = true;
            CamPan_Reset.Click += CamPan_Reset_Click;
            // 
            // CamPan_UpDown
            // 
            CamPan_UpDown.DecimalPlaces = 6;
            CamPan_UpDown.Enabled = false;
            CamPan_UpDown.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            CamPan_UpDown.Location = new Point(561, 73);
            CamPan_UpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            CamPan_UpDown.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            CamPan_UpDown.Name = "CamPan_UpDown";
            CamPan_UpDown.Size = new Size(96, 23);
            CamPan_UpDown.TabIndex = 19;
            CamPan_UpDown.UpDownAlign = LeftRightAlignment.Left;
            CamPan_UpDown.ValueChanged += CamPan_UpDown_ValueChanged;
            // 
            // CamHeight_CheckBox
            // 
            CamHeight_CheckBox.AutoSize = true;
            CamHeight_CheckBox.Checked = true;
            CamHeight_CheckBox.CheckState = CheckState.Checked;
            CamHeight_CheckBox.Enabled = false;
            CamHeight_CheckBox.Location = new Point(388, 132);
            CamHeight_CheckBox.Name = "CamHeight_CheckBox";
            CamHeight_CheckBox.Size = new Size(62, 19);
            CamHeight_CheckBox.TabIndex = 18;
            CamHeight_CheckBox.Text = "Height";
            CamHeight_CheckBox.UseVisualStyleBackColor = true;
            // 
            // CamHeight_Reset
            // 
            CamHeight_Reset.Enabled = false;
            CamHeight_Reset.Location = new Point(663, 131);
            CamHeight_Reset.Name = "CamHeight_Reset";
            CamHeight_Reset.Size = new Size(89, 23);
            CamHeight_Reset.TabIndex = 16;
            CamHeight_Reset.Text = "Reset";
            CamHeight_Reset.UseVisualStyleBackColor = true;
            CamHeight_Reset.Click += CamHeight_Reset_Click;
            // 
            // CamHeight_UpDown
            // 
            CamHeight_UpDown.DecimalPlaces = 6;
            CamHeight_UpDown.Enabled = false;
            CamHeight_UpDown.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            CamHeight_UpDown.Location = new Point(561, 131);
            CamHeight_UpDown.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            CamHeight_UpDown.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            CamHeight_UpDown.Name = "CamHeight_UpDown";
            CamHeight_UpDown.Size = new Size(96, 23);
            CamHeight_UpDown.TabIndex = 15;
            CamHeight_UpDown.UpDownAlign = LeftRightAlignment.Left;
            CamHeight_UpDown.ValueChanged += CamHeight_UpDown_ValueChanged;
            // 
            // MouseHotKey_Label
            // 
            MouseHotKey_Label.AutoSize = true;
            MouseHotKey_Label.Location = new Point(388, 199);
            MouseHotKey_Label.Name = "MouseHotKey_Label";
            MouseHotKey_Label.Size = new Size(105, 15);
            MouseHotKey_Label.TabIndex = 14;
            MouseHotKey_Label.Text = "Mouse pan hotkey";
            // 
            // MouseHotKey_TextBox
            // 
            MouseHotKey_TextBox.Location = new Point(561, 196);
            MouseHotKey_TextBox.Name = "MouseHotKey_TextBox";
            MouseHotKey_TextBox.ReadOnly = true;
            MouseHotKey_TextBox.Size = new Size(191, 23);
            MouseHotKey_TextBox.TabIndex = 13;
            MouseHotKey_TextBox.Text = "Space";
            MouseHotKey_TextBox.TextAlign = HorizontalAlignment.Center;
            MouseHotKey_TextBox.KeyDown += MouseHotKey_TextBox_KeyDown;
            // 
            // PitchAngle_CheckBox
            // 
            PitchAngle_CheckBox.AutoSize = true;
            PitchAngle_CheckBox.Checked = true;
            PitchAngle_CheckBox.CheckState = CheckState.Checked;
            PitchAngle_CheckBox.Enabled = false;
            PitchAngle_CheckBox.Location = new Point(388, 49);
            PitchAngle_CheckBox.Name = "PitchAngle_CheckBox";
            PitchAngle_CheckBox.Size = new Size(53, 19);
            PitchAngle_CheckBox.TabIndex = 12;
            PitchAngle_CheckBox.Text = "Pitch";
            PitchAngle_CheckBox.UseVisualStyleBackColor = true;
            // 
            // HotKeysEnabled_CheckBox
            // 
            HotKeysEnabled_CheckBox.AutoSize = true;
            HotKeysEnabled_CheckBox.Checked = true;
            HotKeysEnabled_CheckBox.CheckState = CheckState.Checked;
            HotKeysEnabled_CheckBox.Location = new Point(3, 53);
            HotKeysEnabled_CheckBox.Name = "HotKeysEnabled_CheckBox";
            HotKeysEnabled_CheckBox.Size = new Size(117, 19);
            HotKeysEnabled_CheckBox.TabIndex = 11;
            HotKeysEnabled_CheckBox.Text = "Hot keys enabled";
            HotKeysEnabled_CheckBox.UseVisualStyleBackColor = true;
            HotKeysEnabled_CheckBox.CheckedChanged += HotKeysEnabled_CheckBox_CheckedChanged;
            // 
            // UpdateDelay_TextBox
            // 
            UpdateDelay_TextBox.Location = new Point(179, 106);
            UpdateDelay_TextBox.MaxLength = 10;
            UpdateDelay_TextBox.Name = "UpdateDelay_TextBox";
            UpdateDelay_TextBox.Size = new Size(191, 23);
            UpdateDelay_TextBox.TabIndex = 10;
            UpdateDelay_TextBox.Text = "0.1";
            UpdateDelay_TextBox.TextChanged += UpdateDelay_TextBox_TextChanged;
            // 
            // UpdateDelay_Label
            // 
            UpdateDelay_Label.AutoSize = true;
            UpdateDelay_Label.Location = new Point(0, 109);
            UpdateDelay_Label.Name = "UpdateDelay_Label";
            UpdateDelay_Label.Size = new Size(94, 15);
            UpdateDelay_Label.TabIndex = 9;
            UpdateDelay_Label.Text = "Throttle seconds";
            // 
            // PitchDragButton
            // 
            PitchDragButton.Enabled = false;
            PitchDragButton.Location = new Point(388, 167);
            PitchDragButton.Name = "PitchDragButton";
            PitchDragButton.Size = new Size(364, 23);
            PitchDragButton.TabIndex = 8;
            PitchDragButton.Text = "Click and drag to pan";
            PitchDragButton.UseVisualStyleBackColor = true;
            PitchDragButton.MouseDown += PitchDragButton_MouseDown;
            PitchDragButton.MouseUp += PitchDragButton_MouseUp;
            // 
            // PitchReset
            // 
            PitchReset.Enabled = false;
            PitchReset.Location = new Point(663, 42);
            PitchReset.Name = "PitchReset";
            PitchReset.Size = new Size(89, 23);
            PitchReset.TabIndex = 7;
            PitchReset.Text = "Reset";
            PitchReset.UseVisualStyleBackColor = true;
            PitchReset.Click += PitchReset_Click;
            // 
            // PitchSpinner
            // 
            PitchSpinner.DecimalPlaces = 6;
            PitchSpinner.Enabled = false;
            PitchSpinner.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
            PitchSpinner.Location = new Point(561, 44);
            PitchSpinner.Maximum = new decimal(new int[] { 2, 0, 0, 0 });
            PitchSpinner.Minimum = new decimal(new int[] { 2, 0, 0, int.MinValue });
            PitchSpinner.Name = "PitchSpinner";
            PitchSpinner.Size = new Size(96, 23);
            PitchSpinner.TabIndex = 5;
            PitchSpinner.UpDownAlign = LeftRightAlignment.Left;
            PitchSpinner.ValueChanged += PitchSpinner_ValueChanged;
            // 
            // TopMost_CheckBox
            // 
            TopMost_CheckBox.AutoSize = true;
            TopMost_CheckBox.Checked = true;
            TopMost_CheckBox.CheckState = CheckState.Checked;
            TopMost_CheckBox.Location = new Point(3, 28);
            TopMost_CheckBox.Name = "TopMost_CheckBox";
            TopMost_CheckBox.Size = new Size(135, 19);
            TopMost_CheckBox.TabIndex = 4;
            TopMost_CheckBox.Text = "Keep window on top";
            TopMost_CheckBox.UseVisualStyleBackColor = true;
            TopMost_CheckBox.CheckedChanged += TopMost_CheckedChanged;
            // 
            // ProgramEnabled_CheckBox
            // 
            ProgramEnabled_CheckBox.AutoSize = true;
            ProgramEnabled_CheckBox.Checked = true;
            ProgramEnabled_CheckBox.CheckState = CheckState.Checked;
            ProgramEnabled_CheckBox.Location = new Point(3, 3);
            ProgramEnabled_CheckBox.Name = "ProgramEnabled_CheckBox";
            ProgramEnabled_CheckBox.Size = new Size(68, 19);
            ProgramEnabled_CheckBox.TabIndex = 3;
            ProgramEnabled_CheckBox.Text = "Enabled";
            ProgramEnabled_CheckBox.UseVisualStyleBackColor = true;
            ProgramEnabled_CheckBox.CheckedChanged += ProgramEnabled_CheckBox_CheckedChanged;
            // 
            // ProcessName_Text
            // 
            ProcessName_Text.Location = new Point(179, 77);
            ProcessName_Text.Name = "ProcessName_Text";
            ProcessName_Text.Size = new Size(191, 23);
            ProcessName_Text.TabIndex = 1;
            ProcessName_Text.Text = "D2R.exe";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 80);
            label1.Name = "label1";
            label1.Size = new Size(104, 15);
            label1.TabIndex = 0;
            label1.Text = "D2R process name";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(791, 346);
            Controls.Add(Main_Panel);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "MainForm";
            Text = "D2RCameraTool 1.0 [created by shiZZa]";
            TopMost = true;
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            Shown += Form1_Shown;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            Main_Panel.ResumeLayout(false);
            Main_Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Sensitivity_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Zoom_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Roll_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CamPan_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)CamHeight_UpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)PitchSpinner).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public StatusStrip statusStrip1;
        public ToolStripStatusLabel Status_Label;
        private Panel Main_Panel;
        private Label label1;
        public TextBox ProcessName_Text;
        private CheckBox TopMost_CheckBox;
        private CheckBox ProgramEnabled_CheckBox;
        public NumericUpDown PitchSpinner;
        public Button PitchReset;
        public Button PitchDragButton;
        public TextBox UpdateDelay_TextBox;
        private Label UpdateDelay_Label;
        private CheckBox HotKeysEnabled_CheckBox;
        public CheckBox PitchAngle_CheckBox;
        private Label MouseHotKey_Label;
        public TextBox MouseHotKey_TextBox;
        public CheckBox CamHeight_CheckBox;
        public Button CamHeight_Reset;
        public NumericUpDown CamHeight_UpDown;
        public CheckBox CamPan_CheckBox;
        public Button CamPan_Reset;
        public NumericUpDown CamPan_UpDown;
        public CheckBox Roll_CheckBox;
        public Button RollReset_Button;
        public NumericUpDown Roll_UpDown;
        public CheckBox Zoom_CheckBox;
        public Button ZoomReset_Button;
        public NumericUpDown Zoom_UpDown;
        public Button ZoomDrag_Button;
        private Label label2;
        public TextBox ZoomHotKey_TextBox;
        private Label Sensitivity_Label;
        public Button SensitivityReset_Button;
        public NumericUpDown Sensitivity_UpDown;
        private Label Warning_Label;
        public ComboBox Presets_Combo;
        public Button Load_Button;
        public Button Save_Button;
        private ToolStripStatusLabel DonateLink_Label;
    }
}
