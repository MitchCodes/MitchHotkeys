namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    partial class HotkeyEditAudioAutoTunePassthroughForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyEditAudioAutoTunePassthroughForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblModifier = new System.Windows.Forms.Label();
            this.cbModifier = new System.Windows.Forms.ComboBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblED1 = new System.Windows.Forms.Label();
            this.lblED2 = new System.Windows.Forms.Label();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.cbOutputDeviceOne = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbInputDeviceOne = new System.Windows.Forms.ComboBox();
            this.gbAutotuneSettings = new System.Windows.Forms.GroupBox();
            this.tbVibratoRate = new System.Windows.Forms.TextBox();
            this.lblVibratoRate = new System.Windows.Forms.Label();
            this.gbSnapPitches = new System.Windows.Forms.GroupBox();
            this.cbB = new System.Windows.Forms.CheckBox();
            this.cbASharp = new System.Windows.Forms.CheckBox();
            this.cbA = new System.Windows.Forms.CheckBox();
            this.cbGSharp = new System.Windows.Forms.CheckBox();
            this.cbG = new System.Windows.Forms.CheckBox();
            this.cbFSharp = new System.Windows.Forms.CheckBox();
            this.cbF = new System.Windows.Forms.CheckBox();
            this.cbE = new System.Windows.Forms.CheckBox();
            this.cbDSharp = new System.Windows.Forms.CheckBox();
            this.cbD = new System.Windows.Forms.CheckBox();
            this.cbCSharp = new System.Windows.Forms.CheckBox();
            this.cbC = new System.Windows.Forms.CheckBox();
            this.cbScale = new System.Windows.Forms.ComboBox();
            this.lblScale = new System.Windows.Forms.Label();
            this.lblAttackVal = new System.Windows.Forms.Label();
            this.lblAttack = new System.Windows.Forms.Label();
            this.trBAttack = new System.Windows.Forms.TrackBar();
            this.lblAutoTuneNote = new System.Windows.Forms.Label();
            this.gbAutotuneSettings.SuspendLayout();
            this.gbSnapPitches.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBAttack)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(715, 389);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbKey
            // 
            this.cbKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Location = new System.Drawing.Point(110, 22);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(680, 21);
            this.cbKey.TabIndex = 1;
            // 
            // lblKey
            // 
            this.lblKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(12, 25);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(25, 13);
            this.lblKey.TabIndex = 2;
            this.lblKey.Text = "Key";
            // 
            // lblModifier
            // 
            this.lblModifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblModifier.AutoSize = true;
            this.lblModifier.Location = new System.Drawing.Point(12, 52);
            this.lblModifier.Name = "lblModifier";
            this.lblModifier.Size = new System.Drawing.Size(44, 13);
            this.lblModifier.TabIndex = 4;
            this.lblModifier.Text = "Modifier";
            // 
            // cbModifier
            // 
            this.cbModifier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbModifier.FormattingEnabled = true;
            this.cbModifier.Location = new System.Drawing.Point(110, 49);
            this.cbModifier.Name = "cbModifier";
            this.cbModifier.Size = new System.Drawing.Size(680, 21);
            this.cbModifier.TabIndex = 3;
            // 
            // lblCommand
            // 
            this.lblCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCommand.AutoSize = true;
            this.lblCommand.Location = new System.Drawing.Point(12, 79);
            this.lblCommand.Name = "lblCommand";
            this.lblCommand.Size = new System.Drawing.Size(54, 13);
            this.lblCommand.TabIndex = 6;
            this.lblCommand.Text = "Command";
            // 
            // lblED1
            // 
            this.lblED1.AutoSize = true;
            this.lblED1.Location = new System.Drawing.Point(12, 113);
            this.lblED1.Name = "lblED1";
            this.lblED1.Size = new System.Drawing.Size(68, 13);
            this.lblED1.TabIndex = 7;
            this.lblED1.Text = "Input Device";
            // 
            // lblED2
            // 
            this.lblED2.AutoSize = true;
            this.lblED2.Location = new System.Drawing.Point(12, 167);
            this.lblED2.Name = "lblED2";
            this.lblED2.Size = new System.Drawing.Size(76, 13);
            this.lblED2.TabIndex = 9;
            this.lblED2.Text = "Output Device";
            // 
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Location = new System.Drawing.Point(110, 76);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(680, 21);
            this.cbCommand.TabIndex = 5;
            // 
            // cbOutputDeviceOne
            // 
            this.cbOutputDeviceOne.FormattingEnabled = true;
            this.cbOutputDeviceOne.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbOutputDeviceOne.Location = new System.Drawing.Point(15, 183);
            this.cbOutputDeviceOne.Name = "cbOutputDeviceOne";
            this.cbOutputDeviceOne.Size = new System.Drawing.Size(337, 21);
            this.cbOutputDeviceOne.TabIndex = 13;
            // 
            // cbInputDeviceOne
            // 
            this.cbInputDeviceOne.FormattingEnabled = true;
            this.cbInputDeviceOne.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbInputDeviceOne.Location = new System.Drawing.Point(15, 128);
            this.cbInputDeviceOne.Name = "cbInputDeviceOne";
            this.cbInputDeviceOne.Size = new System.Drawing.Size(337, 21);
            this.cbInputDeviceOne.TabIndex = 16;
            // 
            // gbAutotuneSettings
            // 
            this.gbAutotuneSettings.Controls.Add(this.tbVibratoRate);
            this.gbAutotuneSettings.Controls.Add(this.lblVibratoRate);
            this.gbAutotuneSettings.Controls.Add(this.gbSnapPitches);
            this.gbAutotuneSettings.Controls.Add(this.cbScale);
            this.gbAutotuneSettings.Controls.Add(this.lblScale);
            this.gbAutotuneSettings.Controls.Add(this.lblAttackVal);
            this.gbAutotuneSettings.Controls.Add(this.lblAttack);
            this.gbAutotuneSettings.Controls.Add(this.trBAttack);
            this.gbAutotuneSettings.Location = new System.Drawing.Point(392, 128);
            this.gbAutotuneSettings.Name = "gbAutotuneSettings";
            this.gbAutotuneSettings.Size = new System.Drawing.Size(398, 250);
            this.gbAutotuneSettings.TabIndex = 17;
            this.gbAutotuneSettings.TabStop = false;
            this.gbAutotuneSettings.Text = "AutoTune Settings";
            // 
            // tbVibratoRate
            // 
            this.tbVibratoRate.Location = new System.Drawing.Point(83, 115);
            this.tbVibratoRate.Name = "tbVibratoRate";
            this.tbVibratoRate.Size = new System.Drawing.Size(235, 20);
            this.tbVibratoRate.TabIndex = 7;
            this.tbVibratoRate.Text = "4.0";
            // 
            // lblVibratoRate
            // 
            this.lblVibratoRate.AutoSize = true;
            this.lblVibratoRate.Location = new System.Drawing.Point(6, 118);
            this.lblVibratoRate.Name = "lblVibratoRate";
            this.lblVibratoRate.Size = new System.Drawing.Size(66, 13);
            this.lblVibratoRate.TabIndex = 6;
            this.lblVibratoRate.Text = "Vibrato Rate";
            // 
            // gbSnapPitches
            // 
            this.gbSnapPitches.Controls.Add(this.cbB);
            this.gbSnapPitches.Controls.Add(this.cbASharp);
            this.gbSnapPitches.Controls.Add(this.cbA);
            this.gbSnapPitches.Controls.Add(this.cbGSharp);
            this.gbSnapPitches.Controls.Add(this.cbG);
            this.gbSnapPitches.Controls.Add(this.cbFSharp);
            this.gbSnapPitches.Controls.Add(this.cbF);
            this.gbSnapPitches.Controls.Add(this.cbE);
            this.gbSnapPitches.Controls.Add(this.cbDSharp);
            this.gbSnapPitches.Controls.Add(this.cbD);
            this.gbSnapPitches.Controls.Add(this.cbCSharp);
            this.gbSnapPitches.Controls.Add(this.cbC);
            this.gbSnapPitches.Location = new System.Drawing.Point(9, 144);
            this.gbSnapPitches.Name = "gbSnapPitches";
            this.gbSnapPitches.Size = new System.Drawing.Size(383, 100);
            this.gbSnapPitches.TabIndex = 5;
            this.gbSnapPitches.TabStop = false;
            this.gbSnapPitches.Text = "Snap Pitches";
            // 
            // cbB
            // 
            this.cbB.AutoSize = true;
            this.cbB.Location = new System.Drawing.Point(300, 69);
            this.cbB.Name = "cbB";
            this.cbB.Size = new System.Drawing.Size(33, 17);
            this.cbB.TabIndex = 11;
            this.cbB.Text = "B";
            this.cbB.UseVisualStyleBackColor = true;
            this.cbB.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbASharp
            // 
            this.cbASharp.AutoSize = true;
            this.cbASharp.Location = new System.Drawing.Point(201, 69);
            this.cbASharp.Name = "cbASharp";
            this.cbASharp.Size = new System.Drawing.Size(64, 17);
            this.cbASharp.TabIndex = 10;
            this.cbASharp.Text = "A Sharp";
            this.cbASharp.UseVisualStyleBackColor = true;
            this.cbASharp.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbA
            // 
            this.cbA.AutoSize = true;
            this.cbA.Location = new System.Drawing.Point(100, 70);
            this.cbA.Name = "cbA";
            this.cbA.Size = new System.Drawing.Size(33, 17);
            this.cbA.TabIndex = 9;
            this.cbA.Text = "A";
            this.cbA.UseVisualStyleBackColor = true;
            this.cbA.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbGSharp
            // 
            this.cbGSharp.AutoSize = true;
            this.cbGSharp.Location = new System.Drawing.Point(6, 70);
            this.cbGSharp.Name = "cbGSharp";
            this.cbGSharp.Size = new System.Drawing.Size(65, 17);
            this.cbGSharp.TabIndex = 8;
            this.cbGSharp.Text = "G Sharp";
            this.cbGSharp.UseVisualStyleBackColor = true;
            this.cbGSharp.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbG
            // 
            this.cbG.AutoSize = true;
            this.cbG.Location = new System.Drawing.Point(300, 44);
            this.cbG.Name = "cbG";
            this.cbG.Size = new System.Drawing.Size(34, 17);
            this.cbG.TabIndex = 7;
            this.cbG.Text = "G";
            this.cbG.UseVisualStyleBackColor = true;
            this.cbG.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbFSharp
            // 
            this.cbFSharp.AutoSize = true;
            this.cbFSharp.Location = new System.Drawing.Point(201, 44);
            this.cbFSharp.Name = "cbFSharp";
            this.cbFSharp.Size = new System.Drawing.Size(63, 17);
            this.cbFSharp.TabIndex = 6;
            this.cbFSharp.Text = "F Sharp";
            this.cbFSharp.UseVisualStyleBackColor = true;
            this.cbFSharp.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbF
            // 
            this.cbF.AutoSize = true;
            this.cbF.Location = new System.Drawing.Point(100, 44);
            this.cbF.Name = "cbF";
            this.cbF.Size = new System.Drawing.Size(32, 17);
            this.cbF.TabIndex = 5;
            this.cbF.Text = "F";
            this.cbF.UseVisualStyleBackColor = true;
            this.cbF.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbE
            // 
            this.cbE.AutoSize = true;
            this.cbE.Location = new System.Drawing.Point(6, 44);
            this.cbE.Name = "cbE";
            this.cbE.Size = new System.Drawing.Size(33, 17);
            this.cbE.TabIndex = 4;
            this.cbE.Text = "E";
            this.cbE.UseVisualStyleBackColor = true;
            this.cbE.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbDSharp
            // 
            this.cbDSharp.AutoSize = true;
            this.cbDSharp.Location = new System.Drawing.Point(300, 19);
            this.cbDSharp.Name = "cbDSharp";
            this.cbDSharp.Size = new System.Drawing.Size(65, 17);
            this.cbDSharp.TabIndex = 3;
            this.cbDSharp.Text = "D Sharp";
            this.cbDSharp.UseVisualStyleBackColor = true;
            this.cbDSharp.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbD
            // 
            this.cbD.AutoSize = true;
            this.cbD.Location = new System.Drawing.Point(201, 19);
            this.cbD.Name = "cbD";
            this.cbD.Size = new System.Drawing.Size(34, 17);
            this.cbD.TabIndex = 2;
            this.cbD.Text = "D";
            this.cbD.UseVisualStyleBackColor = true;
            this.cbD.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbCSharp
            // 
            this.cbCSharp.AutoSize = true;
            this.cbCSharp.Location = new System.Drawing.Point(100, 19);
            this.cbCSharp.Name = "cbCSharp";
            this.cbCSharp.Size = new System.Drawing.Size(64, 17);
            this.cbCSharp.TabIndex = 1;
            this.cbCSharp.Text = "C Sharp";
            this.cbCSharp.UseVisualStyleBackColor = true;
            this.cbCSharp.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbC
            // 
            this.cbC.AutoSize = true;
            this.cbC.Location = new System.Drawing.Point(6, 19);
            this.cbC.Name = "cbC";
            this.cbC.Size = new System.Drawing.Size(33, 17);
            this.cbC.TabIndex = 0;
            this.cbC.Text = "C";
            this.cbC.UseVisualStyleBackColor = true;
            this.cbC.CheckedChanged += new System.EventHandler(this.cbPitch_CheckedChanged);
            // 
            // cbScale
            // 
            this.cbScale.FormattingEnabled = true;
            this.cbScale.Location = new System.Drawing.Point(83, 77);
            this.cbScale.Name = "cbScale";
            this.cbScale.Size = new System.Drawing.Size(235, 21);
            this.cbScale.TabIndex = 4;
            this.cbScale.SelectedIndexChanged += new System.EventHandler(this.cbScale_SelectedIndexChanged);
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(6, 80);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(34, 13);
            this.lblScale.TabIndex = 3;
            this.lblScale.Text = "Scale";
            // 
            // lblAttackVal
            // 
            this.lblAttackVal.AutoSize = true;
            this.lblAttackVal.Location = new System.Drawing.Point(335, 24);
            this.lblAttackVal.Name = "lblAttackVal";
            this.lblAttackVal.Size = new System.Drawing.Size(26, 13);
            this.lblAttackVal.TabIndex = 2;
            this.lblAttackVal.Text = "0ms";
            // 
            // lblAttack
            // 
            this.lblAttack.AutoSize = true;
            this.lblAttack.Location = new System.Drawing.Point(6, 24);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(38, 13);
            this.lblAttack.TabIndex = 1;
            this.lblAttack.Text = "Attack";
            // 
            // trBAttack
            // 
            this.trBAttack.Location = new System.Drawing.Point(83, 19);
            this.trBAttack.Maximum = 50;
            this.trBAttack.Name = "trBAttack";
            this.trBAttack.Size = new System.Drawing.Size(235, 45);
            this.trBAttack.TabIndex = 0;
            this.trBAttack.Scroll += new System.EventHandler(this.trBAttack_Scroll);
            // 
            // lblAutoTuneNote
            // 
            this.lblAutoTuneNote.AutoSize = true;
            this.lblAutoTuneNote.Location = new System.Drawing.Point(12, 246);
            this.lblAutoTuneNote.Name = "lblAutoTuneNote";
            this.lblAutoTuneNote.Size = new System.Drawing.Size(344, 117);
            this.lblAutoTuneNote.TabIndex = 18;
            this.lblAutoTuneNote.Text = resources.GetString("lblAutoTuneNote.Text");
            // 
            // HotkeyEditAudioAutoTunePassthroughForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 424);
            this.Controls.Add(this.lblAutoTuneNote);
            this.Controls.Add(this.gbAutotuneSettings);
            this.Controls.Add(this.cbInputDeviceOne);
            this.Controls.Add(this.cbOutputDeviceOne);
            this.Controls.Add(this.lblED2);
            this.Controls.Add(this.lblED1);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.lblModifier);
            this.Controls.Add(this.cbModifier);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbCommand);
            this.Name = "HotkeyEditAudioAutoTunePassthroughForm";
            this.Load += new System.EventHandler(this.HotkeyEditForm_Load);
            this.gbAutotuneSettings.ResumeLayout(false);
            this.gbAutotuneSettings.PerformLayout();
            this.gbSnapPitches.ResumeLayout(false);
            this.gbSnapPitches.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trBAttack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblModifier;
        private System.Windows.Forms.ComboBox cbModifier;
        private System.Windows.Forms.Label lblCommand;
        private System.Windows.Forms.ComboBox cbOutputDeviceOne;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox cbInputDeviceOne;
        public System.Windows.Forms.Label lblED1;
        public System.Windows.Forms.Label lblED2;
        public System.Windows.Forms.ComboBox cbCommand;
        private System.Windows.Forms.GroupBox gbAutotuneSettings;
        private System.Windows.Forms.GroupBox gbSnapPitches;
        private System.Windows.Forms.CheckBox cbB;
        private System.Windows.Forms.CheckBox cbASharp;
        private System.Windows.Forms.CheckBox cbA;
        private System.Windows.Forms.CheckBox cbGSharp;
        private System.Windows.Forms.CheckBox cbG;
        private System.Windows.Forms.CheckBox cbFSharp;
        private System.Windows.Forms.CheckBox cbF;
        private System.Windows.Forms.CheckBox cbE;
        private System.Windows.Forms.CheckBox cbDSharp;
        private System.Windows.Forms.CheckBox cbD;
        private System.Windows.Forms.CheckBox cbCSharp;
        private System.Windows.Forms.CheckBox cbC;
        private System.Windows.Forms.ComboBox cbScale;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.Label lblAttackVal;
        private System.Windows.Forms.Label lblAttack;
        private System.Windows.Forms.TrackBar trBAttack;
        private System.Windows.Forms.Label lblVibratoRate;
        private System.Windows.Forms.TextBox tbVibratoRate;
        private System.Windows.Forms.Label lblAutoTuneNote;
    }
}