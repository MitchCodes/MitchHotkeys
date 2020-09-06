using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MitchHotkeys.Logic.Factories;
using MitchHotkeys.UI.Model;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.UI.Services;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys
{
    public partial class HotkeyEditForm : Form, IHotkeyForm, ISupportBulkDataEdit
    {
        public Hotkey Hotkey { get; set; }
        public bool EditHotkeyData1 { get; set; }
        public bool EditHotkeyData2 { get; set; }
        public bool EditHotkeyData3 { get; set; }
        public bool EditHotkeyData4 { get; set; }

        public HotkeyEditForm(bool bulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            SetupBulkEditControls(bulkEditMode);
        }

        public HotkeyEditForm(Hotkey hotkey, bool bulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;
            tbExtraData1.Text = hotkey.ExtraData1;
            tbExtraData2.Text = hotkey.ExtraData2;
            tbExtraData3.Text = hotkey.ExtraData3;

            ChangeLabels(hotkey);
            ChangeEnabled(hotkey);

            SetupBulkEditControls(bulkEditMode);
        }

        private void SetupBulkEditControls(bool isBulkEditMode)
        {
            if (isBulkEditMode) {
                chkDataOneEdit.Enabled = true;
                chkDataTwoEdit.Enabled = true;
                chkDataThreeEdit.Enabled = true;
                chkDataFourEdit.Enabled = true;
            } else {
                chkDataOneEdit.Enabled = false;
                chkDataTwoEdit.Enabled = false;
                chkDataThreeEdit.Enabled = false;
                chkDataFourEdit.Enabled = false;
            }
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

            EditHotkeyData1 = chkDataOneEdit.Checked;
            EditHotkeyData2 = chkDataTwoEdit.Checked;
            EditHotkeyData3 = chkDataThreeEdit.Checked;
            EditHotkeyData4 = chkDataFourEdit.Checked;

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

        private void ChangeLabels(Hotkey hotkey)
        {
            switch ((HotkeyTypeEnum)hotkey.Command)
            {
                case HotkeyTypeEnum.DownloadYouTubeVideo:
                    lblED1.Text = "";
                    lblED2.Text = "";
                    lblED3.Text = "";
                    break;
            }
        }

        private void ChangeEnabled(Hotkey hotkey)
        {
            switch ((HotkeyTypeEnum)hotkey.Command)
            {
                case HotkeyTypeEnum.DownloadYouTubeVideo:
                    tbExtraData1.Enabled = false;
                    tbExtraData2.Enabled = false;
                    tbExtraData3.Enabled = false;
                    break;
            }
        }

        public ValidationResult Validate(Hotkey hotkey)
        {
            return ValidationService.Instance.Validate(hotkey);
        }
    }
}
