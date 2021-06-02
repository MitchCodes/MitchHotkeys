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
    public partial class TextInput : Form
    {
        public string InputText { get; set; }

        public TextInput()
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

        private void TextInput_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void TextInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.InputText = tbText.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                tbText.Focus();
            }
        }

        private void tbText_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.InputText = tbText.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                tbText.Focus();
            }
        }
    }
}
