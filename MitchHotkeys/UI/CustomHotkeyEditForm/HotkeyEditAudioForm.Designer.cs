namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    partial class HotkeyEditAudioForm
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
            this.cbCommand = new System.Windows.Forms.ComboBox();
            this.lblED1 = new System.Windows.Forms.Label();
            this.lblED2 = new System.Windows.Forms.Label();
            this.lblED3 = new System.Windows.Forms.Label();
            this.lblED4 = new System.Windows.Forms.Label();
            this.tbExtraData1 = new System.Windows.Forms.TextBox();
            this.cbDevices = new System.Windows.Forms.ComboBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cbDevicesTwo = new System.Windows.Forms.ComboBox();
            this.cbDevicesThree = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(277, 338);
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
            this.cbKey.Size = new System.Drawing.Size(242, 21);
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
            this.cbModifier.Size = new System.Drawing.Size(242, 21);
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
            // cbCommand
            // 
            this.cbCommand.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCommand.FormattingEnabled = true;
            this.cbCommand.Location = new System.Drawing.Point(110, 76);
            this.cbCommand.Name = "cbCommand";
            this.cbCommand.Size = new System.Drawing.Size(242, 21);
            this.cbCommand.TabIndex = 5;
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
            // tbExtraData1
            // 
            this.tbExtraData1.Location = new System.Drawing.Point(15, 129);
            this.tbExtraData1.Name = "tbExtraData1";
            this.tbExtraData1.Size = new System.Drawing.Size(337, 20);
            this.tbExtraData1.TabIndex = 8;
            // 
            // cbDevices
            // 
            this.cbDevices.FormattingEnabled = true;
            this.cbDevices.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbDevices.Location = new System.Drawing.Point(15, 183);
            this.cbDevices.Name = "cbDevices";
            this.cbDevices.Size = new System.Drawing.Size(337, 21);
            this.cbDevices.TabIndex = 13;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(277, 103);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 14;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // cbDevicesTwo
            // 
            this.cbDevicesTwo.FormattingEnabled = true;
            this.cbDevicesTwo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbDevicesTwo.Location = new System.Drawing.Point(15, 243);
            this.cbDevicesTwo.Name = "cbDevicesTwo";
            this.cbDevicesTwo.Size = new System.Drawing.Size(337, 21);
            this.cbDevicesTwo.TabIndex = 15;
            // 
            // cbDevicesThree
            // 
            this.cbDevicesThree.FormattingEnabled = true;
            this.cbDevicesThree.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbDevicesThree.Location = new System.Drawing.Point(15, 300);
            this.cbDevicesThree.Name = "cbDevicesThree";
            this.cbDevicesThree.Size = new System.Drawing.Size(337, 21);
            this.cbDevicesThree.TabIndex = 16;
            // 
            // HotkeyEditAudioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 373);
            this.Controls.Add(this.cbDevicesTwo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cbDevices);
            this.Controls.Add(this.cbDevicesThree);
            this.Controls.Add(this.lblED4);
            this.Controls.Add(this.lblED3);
            this.Controls.Add(this.lblED2);
            this.Controls.Add(this.lblED1);
            this.Controls.Add(this.cbCommand);
            this.Controls.Add(this.tbExtraData1);
            this.Controls.Add(this.lblModifier);
            this.Controls.Add(this.cbModifier);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.lblCommand);
            this.Name = "HotkeyEditAudioForm";
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
        private System.Windows.Forms.ComboBox cbDevices;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox cbDevicesTwo;
        private System.Windows.Forms.ComboBox cbDevicesThree;
        public System.Windows.Forms.Label lblED1;
        public System.Windows.Forms.Label lblED2;
        public System.Windows.Forms.Label lblED3;
        public System.Windows.Forms.Label lblED4;
        public System.Windows.Forms.ComboBox cbCommand;
        public System.Windows.Forms.TextBox tbExtraData1;
    }
}