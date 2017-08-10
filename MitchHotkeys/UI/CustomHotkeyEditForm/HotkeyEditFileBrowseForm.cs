using System;
using System.Windows.Forms;
using MitchHotkeys.Logic.Factories;
using MitchHotkeys.UI.Model;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.UI.Services;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    public partial class HotkeyEditFileBrowseForm : Form, IHotkeyForm
    {
        private Hotkey _hotkey;

        public Hotkey Hotkey
        {
            get { return _hotkey; }
            set { _hotkey = value; }
        }

        public HotkeyEditFileBrowseForm()
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));
        }

        public HotkeyEditFileBrowseForm(Hotkey hotkey)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));


            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbCommand.Enabled = false;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;
            tbExtraData1.Text = hotkey.ExtraData1;
            tbExtraData2.Text = hotkey.ExtraData2;
            tbExtraData3.Text = hotkey.ExtraData3;
        }

        private void HotkeyEditForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int command = (int)((HotkeyTypeEnum)cbCommand.SelectedValue);
            Hotkey tempHotkey = HotkeyTypeFactory.GetHotkeyType(command);
            tempHotkey.Command = command;
            tempHotkey.Modifier = (int)((KeyModifier)cbModifier.SelectedValue);
            tempHotkey.Key = (int)((Keys)cbKey.SelectedValue);
            tempHotkey.ExtraData1 = tbExtraData1.Text;
            tempHotkey.ExtraData2 = tbExtraData2.Text;
            tempHotkey.ExtraData3 = tbExtraData3.Text;
            ValidationResult result = Validate(tempHotkey);
            if (result.HasErrors())
            {
                MessageBox.Show("Errors: " + result.CommaDelimErrors());
            }
            else
            {
                Hotkey = tempHotkey;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
                
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = @"All Files|*.*";

            DialogResult result = openFileDialog.ShowDialog();
            // Process input if the user clicked OK.
            if (result == DialogResult.OK)
            {
                tbExtraData1.Text = openFileDialog.FileName;
            }
        }

        public ValidationResult Validate(Hotkey hotkey)
        {
            return ValidationService.Instance.Validate(hotkey);
        }
    }
}
