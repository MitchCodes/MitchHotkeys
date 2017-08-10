using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MitchHotkeys.UI.HotkeyInputForms
{
    public partial class FileSaveInput : Form
    {

        public string InputText { get; set; }
        public FileSaveInput()
        {
            InitializeComponent();
            InputText = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.InputText = tbText.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tbText.Text = saveFileDialog1.FileName;
            }
        }
    }
}
