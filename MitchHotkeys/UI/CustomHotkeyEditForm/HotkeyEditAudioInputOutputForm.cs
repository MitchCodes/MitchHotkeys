using System;
using System.IO;
using System.Windows.Forms;
using MitchHotkeys.Logic.Factories;
using MitchHotkeys.UI.Model;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.UI.Services;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    public partial class HotkeyEditAudioInputOutputForm : Form, IHotkeyForm, ISupportBulkDataEdit
    {
        private Hotkey _hotkey;

        public Hotkey Hotkey
        {
            get { return _hotkey; }
            set { _hotkey = value; }
        }

        public bool EditHotkeyData1 { get; set; }
        public bool EditHotkeyData2 { get; set; }
        public bool EditHotkeyData3 { get; set; }
        public bool EditHotkeyData4 { get; set; }

        public HotkeyEditAudioInputOutputForm(bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            SetupBulkEditControls(setupBulkEditMode);
        }

        public HotkeyEditAudioInputOutputForm(Hotkey hotkey, bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            foreach (HotkeyAudioDevice currentDevice in MainAudio.Instance.AudioInputDevices)
            {
                cbInputDeviceOne.Items.Add(currentDevice.AudioDeviceName);
            }

            foreach (HotkeyAudioDevice currentDevice in MainAudio.Instance.AudioOutputDevices)
            {
                cbOutputDeviceOne.Items.Add(currentDevice.AudioDeviceName);
                cbOutputDeviceTwo.Items.Add(currentDevice.AudioDeviceName);
            }
            
            ChangeLabels(hotkey);
            ChangeEnabled(hotkey);
            ChangeDefaults(hotkey);

            cbCommand.SelectedItem = (HotkeyTypeEnum)hotkey.Command;
            cbCommand.Enabled = false;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;

            cbInputDeviceOne.SelectedItem = hotkey.ExtraData1;
            cbOutputDeviceOne.SelectedItem = hotkey.ExtraData2;
            cbOutputDeviceTwo.SelectedItem = hotkey.ExtraData3;

            string extraData4 = hotkey.GetAdditionalData(HotkeyAdditionalDataType.ExtraData4);
            if (extraData4 != null)
            {
                tbExtraData4.Text = extraData4;
            }

            SetupBulkEditControls(setupBulkEditMode);
        }

        private void SetupBulkEditControls(bool isBulkEditMode)
        {
            if (isBulkEditMode)
            {
                chkDataOneEdit.Enabled = true;
                chkDataTwoEdit.Enabled = true;
                chkDataThreeEdit.Enabled = true;
                chkDataFourEdit.Enabled = true;
            }
            else
            {
                chkDataOneEdit.Enabled = false;
                chkDataTwoEdit.Enabled = false;
                chkDataThreeEdit.Enabled = false;
                chkDataFourEdit.Enabled = false;
            }
        }

        private void ChangeLabels(Hotkey hotkey)
        {
            lblED1.Text = "Audio Input Device #1 (Primary)";
            lblED2.Text = "Audio Output Device #1 (Primary)";
            lblED3.Text = "Audio Output Device #2";
            lblED4.Text = "";
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                    break;
                case HotkeyTypeEnum.DevicePassthrough:
                    lblED3.Text = "";
                    lblED4.Text = "Start On (enter true or false)";
                    break;
            }
        }

        private void ChangeEnabled(Hotkey hotkey) {
            tbExtraData4.Enabled = false;
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                    break;
                case HotkeyTypeEnum.DevicePassthrough:
                    cbOutputDeviceTwo.Enabled = false;
                    tbExtraData4.Enabled = true;
                    break;
            }
        }

        private void ChangeDefaults(Hotkey hotkey)
        {
            switch ((HotkeyTypeEnum)hotkey.Command)
            {
                case HotkeyTypeEnum.PlayInputDeviceRecordingFromMemory:
                    break;
                case HotkeyTypeEnum.DevicePassthrough:
                    tbExtraData4.Text = "true";
                    break;
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

            EditHotkeyData1 = chkDataOneEdit.Checked;
            EditHotkeyData2 = chkDataTwoEdit.Checked;
            EditHotkeyData3 = chkDataThreeEdit.Checked;
            EditHotkeyData4 = chkDataFourEdit.Checked;

            if (cbInputDeviceOne.SelectedItem != null)
            {
                tempHotkey.ExtraData1 = cbInputDeviceOne.SelectedItem.ToString();
            }
            if (cbOutputDeviceOne.SelectedItem != null)
            {
                tempHotkey.ExtraData2 = cbOutputDeviceOne.SelectedItem.ToString();
            }
            if (cbOutputDeviceTwo.SelectedItem != null)
            {
                tempHotkey.ExtraData3 = cbOutputDeviceTwo.SelectedItem.ToString();
            }

            if (!String.IsNullOrEmpty(tbExtraData4.Text))
            {
                tempHotkey.SetAdditionalData(HotkeyAdditionalDataType.ExtraData4, tbExtraData4.Text);
            }

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

        public ValidationResult Validate(Hotkey hotkey)
        {
            return ValidationService.Instance.Validate(hotkey);
        }
    }
}
