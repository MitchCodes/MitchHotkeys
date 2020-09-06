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
    public partial class HotkeyEditAudioInputForm : Form, IHotkeyForm, ISupportBulkDataEdit
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

        public HotkeyEditAudioInputForm(bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));
        }

        public HotkeyEditAudioInputForm(Hotkey hotkey, bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            foreach (HotkeyAudioDevice currentDevice in MainAudio.Instance.AudioInputDevices)
            {
                cbDevices.Items.Add(currentDevice.AudioDeviceName);
            }

            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbCommand.Enabled = false;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;

            ChangeLabels(hotkey);
            ChangeEnabled(hotkey);

            
            tbExtraData1.Text = hotkey.ExtraData1;
            cbDevices.SelectedItem = hotkey.ExtraData2;
            tbExtraData3.Text = hotkey.ExtraData3;
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
            lblED1.Text = "Audio File";
            lblED2.Text = "Audio Input Device #1 (Primary)";
            lblED3.Text = "Audio Input Device #2";
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.StartRecordingInputDevice:
                    lblED1.Text = "";
                    lblED3.Text = "Seconds to hold onto sound (30 is default)";
                    break;
                case HotkeyTypeEnum.StopRecordingInputDevice:
                    lblED1.Text = "";
                    lblED3.Text = "";
                    break;
                case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                    lblED1.Text = "";
                    lblED3.Text = "";
                    break;
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                    break;
            }
        }

        private void ChangeEnabled(Hotkey hotkey) {
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.StartRecordingInputDevice:
                    tbExtraData1.Enabled = false;
                    btnBrowse.Enabled = false;
                    tbExtraData3.Enabled = true;
                    break;
                case HotkeyTypeEnum.StopRecordingInputDevice:
                    tbExtraData1.Enabled = false;
                    btnBrowse.Enabled = false;
                    tbExtraData3.Enabled = false;
                    break;
                case HotkeyTypeEnum.SaveInputDeviceRecordingToMemory:
                    tbExtraData1.Enabled = false;
                    btnBrowse.Enabled = false;
                    tbExtraData3.Enabled = false;
                    break;
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                    tbExtraData1.Enabled = true;
                    btnBrowse.Enabled = true;
                    tbExtraData3.Enabled = false;
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
            tempHotkey.ExtraData1 = tbExtraData1.Text;

            EditHotkeyData1 = chkDataOneEdit.Checked;
            EditHotkeyData2 = chkDataTwoEdit.Checked;
            EditHotkeyData3 = chkDataThreeEdit.Checked;
            EditHotkeyData4 = chkDataFourEdit.Checked;

            if (cbDevices.SelectedItem != null)
            {
                tempHotkey.ExtraData2 = cbDevices.SelectedItem.ToString();
            }
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
            int command = (int)((HotkeyTypeEnum)cbCommand.SelectedValue);
            switch ((HotkeyTypeEnum) command)
            {
                case HotkeyTypeEnum.SaveInputDeviceRecordingToFile:
                    saveFileDialog1.Filter = @"Audio File (*.wav)|*.wav";
                    DialogResult result = saveFileDialog1.ShowDialog();
                    // Process input if the user clicked OK.
                    if (result == DialogResult.OK)
                    {
                        tbExtraData1.Text = saveFileDialog1.FileName;
                    }
                    break;
            }

            
        }

        public ValidationResult Validate(Hotkey hotkey)
        {
            return ValidationService.Instance.Validate(hotkey);
        }
    }
}
