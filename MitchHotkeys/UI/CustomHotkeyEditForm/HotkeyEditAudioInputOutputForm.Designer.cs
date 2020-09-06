namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    partial class HotkeyEditAudioInputOutputForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblModifier = new System.Windows.Forms.Label();
            this.cbModifier = new System.Windows.Forms.ComboBox();
            this.lblCommand = new System.Windows.Forms.Label();
            this.lblED1 = new System.Windows.Forms.Label();
            this.lblED2 = new System.Windows.Forms.Label();
            this.lblED3 = new System.Windows.Forms.Label();
            this.lblED4 = new System.Windows.Forms.Label();
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.tbExtraData4 = new System.Windows.Forms.TextBox();
            this.cbOutputDeviceOne = new System.Windows.Forms.ComboBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.cbOutputDeviceTwo = new System.Windows.Forms.ComboBox();
            this.cbInputDeviceOne = new System.Windows.Forms.ComboBox();
            this.chkDataOneEdit = new System.Windows.Forms.CheckBox();
            this.chkDataTwoEdit = new System.Windows.Forms.CheckBox();
            this.chkDataThreeEdit = new System.Windows.Forms.CheckBox();
            this.chkDataFourEdit = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(318, 343);
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
            this.cbKey.Size = new System.Drawing.Size(283, 21);
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
            this.cbModifier.Size = new System.Drawing.Size(283, 21);
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
            this.lblED1.Size = new System.Drawing.Size(73, 13);
            this.lblED1.TabIndex = 7;
            this.lblED1.Text = "Extra Data #1";
            // 
            // lblED2
            // 
            this.lblED2.AutoSize = true;
            this.lblED2.Location = new System.Drawing.Point(12, 167);
            this.lblED2.Name = "lblED2";
            this.lblED2.Size = new System.Drawing.Size(73, 13);
            this.lblED2.TabIndex = 9;
            this.lblED2.Text = "Extra Data #2";
            // 
            // lblED3
            // 
            this.lblED3.AutoSize = true;
            this.lblED3.Location = new System.Drawing.Point(12, 228);
            this.lblED3.Name = "lblED3";
            this.lblED3.Size = new System.Drawing.Size(73, 13);
            this.lblED3.TabIndex = 11;
            this.lblED3.Text = "Extra Data #3";
            // 
            // lblED4
            // 
            this.lblED4.AutoSize = true;
            this.lblED4.Location = new System.Drawing.Point(12, 285);
            this.lblED4.Name = "lblED4";
            this.lblED4.Size = new System.Drawing.Size(73, 13);
            this.lblED4.TabIndex = 13;
            this.lblED4.Text = "Extra Data #4";
            // 
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Location = new System.Drawing.Point(110, 76);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(283, 21);
            this.cbCommand.TabIndex = 5;
            // 
            // tbExtraData4
            // 
            this.tbExtraData4.Enabled = false;
            this.tbExtraData4.Location = new System.Drawing.Point(15, 301);
            this.tbExtraData4.Name = "tbExtraData4";
            this.tbExtraData4.Size = new System.Drawing.Size(337, 20);
            this.tbExtraData4.TabIndex = 14;
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
            // cbOutputDeviceTwo
            // 
            this.cbOutputDeviceTwo.FormattingEnabled = true;
            this.cbOutputDeviceTwo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbOutputDeviceTwo.Location = new System.Drawing.Point(15, 243);
            this.cbOutputDeviceTwo.Name = "cbOutputDeviceTwo";
            this.cbOutputDeviceTwo.Size = new System.Drawing.Size(337, 21);
            this.cbOutputDeviceTwo.TabIndex = 15;
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
            // chkDataOneEdit
            // 
            this.chkDataOneEdit.AutoSize = true;
            this.chkDataOneEdit.Location = new System.Drawing.Point(358, 132);
            this.chkDataOneEdit.Name = "chkDataOneEdit";
            this.chkDataOneEdit.Size = new System.Drawing.Size(44, 17);
            this.chkDataOneEdit.TabIndex = 17;
            this.chkDataOneEdit.Text = "Edit";
            this.chkDataOneEdit.UseVisualStyleBackColor = true;
            // 
            // chkDataTwoEdit
            // 
            this.chkDataTwoEdit.AutoSize = true;
            this.chkDataTwoEdit.Location = new System.Drawing.Point(358, 187);
            this.chkDataTwoEdit.Name = "chkDataTwoEdit";
            this.chkDataTwoEdit.Size = new System.Drawing.Size(44, 17);
            this.chkDataTwoEdit.TabIndex = 18;
            this.chkDataTwoEdit.Text = "Edit";
            this.chkDataTwoEdit.UseVisualStyleBackColor = true;
            // 
            // chkDataThreeEdit
            // 
            this.chkDataThreeEdit.AutoSize = true;
            this.chkDataThreeEdit.Location = new System.Drawing.Point(358, 245);
            this.chkDataThreeEdit.Name = "chkDataThreeEdit";
            this.chkDataThreeEdit.Size = new System.Drawing.Size(44, 17);
            this.chkDataThreeEdit.TabIndex = 19;
            this.chkDataThreeEdit.Text = "Edit";
            this.chkDataThreeEdit.UseVisualStyleBackColor = true;
            // 
            // chkDataFourEdit
            // 
            this.chkDataFourEdit.AutoSize = true;
            this.chkDataFourEdit.Location = new System.Drawing.Point(358, 304);
            this.chkDataFourEdit.Name = "chkDataFourEdit";
            this.chkDataFourEdit.Size = new System.Drawing.Size(44, 17);
            this.chkDataFourEdit.TabIndex = 20;
            this.chkDataFourEdit.Text = "Edit";
            this.chkDataFourEdit.UseVisualStyleBackColor = true;
            // 
            // HotkeyEditAudioInputOutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 378);
            this.Controls.Add(this.chkDataFourEdit);
            this.Controls.Add(this.chkDataThreeEdit);
            this.Controls.Add(this.chkDataTwoEdit);
            this.Controls.Add(this.chkDataOneEdit);
            this.Controls.Add(this.cbInputDeviceOne);
            this.Controls.Add(this.cbOutputDeviceTwo);
            this.Controls.Add(this.cbOutputDeviceOne);
            this.Controls.Add(this.lblED4);
            this.Controls.Add(this.lblED3);
            this.Controls.Add(this.lblED2);
            this.Controls.Add(this.lblED1);
            this.Controls.Add(this.lblCommand);
            this.Controls.Add(this.lblModifier);
            this.Controls.Add(this.cbModifier);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbCommand);
            this.Controls.Add(this.tbExtraData4);
            this.Name = "HotkeyEditAudioInputOutputForm";
            this.Load += new System.EventHandler(this.HotkeyEditForm_Load);
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
        private System.Windows.Forms.ComboBox cbOutputDeviceTwo;
        private System.Windows.Forms.ComboBox cbInputDeviceOne;
        public System.Windows.Forms.Label lblED1;
        public System.Windows.Forms.Label lblED2;
        public System.Windows.Forms.Label lblED3;
        public System.Windows.Forms.Label lblED4;
        public System.Windows.Forms.TextBox tbExtraData4;
        public System.Windows.Forms.ComboBox cbCommand;
        private System.Windows.Forms.CheckBox chkDataOneEdit;
        private System.Windows.Forms.CheckBox chkDataTwoEdit;
        private System.Windows.Forms.CheckBox chkDataThreeEdit;
        private System.Windows.Forms.CheckBox chkDataFourEdit;
    }
}