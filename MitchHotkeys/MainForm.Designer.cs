namespace MitchHotkeys
{
    partial class MainForm
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
            this.btnConfigure = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLoadGroup = new System.Windows.Forms.Button();
            this.cbGroups = new System.Windows.Forms.ComboBox();
            this.btnNewGroup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnConfigure
            // 
            this.btnConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigure.Location = new System.Drawing.Point(12, 129);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(208, 23);
            this.btnConfigure.TabIndex = 0;
            this.btnConfigure.Text = "Configure Hotkeys";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 30);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 1;
            // 
            // btnLoadGroup
            // 
            this.btnLoadGroup.Location = new System.Drawing.Point(145, 69);
            this.btnLoadGroup.Name = "btnLoadGroup";
            this.btnLoadGroup.Size = new System.Drawing.Size(75, 23);
            this.btnLoadGroup.TabIndex = 2;
            this.btnLoadGroup.Text = "Load Group";
            this.btnLoadGroup.UseVisualStyleBackColor = true;
            this.btnLoadGroup.Click += new System.EventHandler(this.btnLoadGroup_Click);
            // 
            // cbGroups
            // 
            this.cbGroups.FormattingEnabled = true;
            this.cbGroups.Location = new System.Drawing.Point(12, 71);
            this.cbGroups.Name = "cbGroups";
            this.cbGroups.Size = new System.Drawing.Size(127, 21);
            this.cbGroups.TabIndex = 3;
            // 
            // btnNewGroup
            // 
            this.btnNewGroup.Location = new System.Drawing.Point(15, 100);
            this.btnNewGroup.Name = "btnNewGroup";
            this.btnNewGroup.Size = new System.Drawing.Size(205, 23);
            this.btnNewGroup.TabIndex = 4;
            this.btnNewGroup.Text = "New Group";
            this.btnNewGroup.UseVisualStyleBackColor = true;
            this.btnNewGroup.Click += new System.EventHandler(this.btnNewGroup_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 164);
            this.Controls.Add(this.btnNewGroup);
            this.Controls.Add(this.cbGroups);
            this.Controls.Add(this.btnLoadGroup);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnConfigure);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Mitch\'s Hotkeys";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigure;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLoadGroup;
        private System.Windows.Forms.ComboBox cbGroups;
        private System.Windows.Forms.Button btnNewGroup;
    }
}

