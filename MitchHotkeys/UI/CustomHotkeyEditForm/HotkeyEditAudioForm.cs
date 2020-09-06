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
    public partial class HotkeyEditAudioForm : Form, IHotkeyForm, ISupportBulkDataEdit
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

        public HotkeyEditAudioForm(bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            SetupBulkEditControls(setupBulkEditMode);
        }

        public HotkeyEditAudioForm(Hotkey hotkey, bool setupBulkEditMode = false)
        {
            InitializeComponent();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));

            foreach (HotkeyAudioDevice currentDevice in MainAudio.Instance.AudioOutputDevices)
            {
                cbDevices.Items.Add(currentDevice.AudioDeviceName);
                cbDevicesTwo.Items.Add(currentDevice.AudioDeviceName);
                cbDevicesThree.Items.Add(currentDevice.AudioDeviceName);
            }

            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbCommand.Enabled = false;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;

            ChangeLabels(hotkey);
            ChangeEnabled(hotkey);

            tbExtraData1.Text = hotkey.ExtraData1;
            cbDevices.SelectedItem = hotkey.ExtraData2;
            cbDevicesTwo.SelectedItem = hotkey.ExtraData3;

            if (hotkey.AdditionalExtraData != null && hotkey.AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree))
            {
                cbDevicesThree.SelectedItem = hotkey.AdditionalExtraData[(int) HotkeyAdditionalDataType.DeviceThree];
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
            lblED2.Text = "Audio Device #1";
            lblED3.Text = "Audio Device #2";
            lblED4.Text = "Audio Device #3";
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.StopAudioDevice:
                    break;
                case HotkeyTypeEnum.ChangeAudioVolume:
                    lblED1.Text = "Volume (0.0 (mute) to 3.0 (3x volume))";
                    break;
                case HotkeyTypeEnum.StepUpAudioVolume:
                case HotkeyTypeEnum.StepDownAudioVolume:
                    lblED1.Text = "Change in volume per press (ex: 0.05 is 5%)";
                    break;
                default:
                    lblED1.Text = "Audio File";
                    break;
            }
        }

        private void ChangeEnabled(Hotkey hotkey) {
            switch ((HotkeyTypeEnum)hotkey.Command) {
                case HotkeyTypeEnum.StopAudioDevice:
                    tbExtraData1.Enabled = false;
                    btnBrowse.Enabled = false;
                    cbDevicesThree.Enabled = false;
                    break;
                case HotkeyTypeEnum.StopAudioAllDevices:
                    tbExtraData1.Enabled = false;
                    btnBrowse.Enabled = false;
                    cbDevices.Enabled = false;
                    cbDevicesTwo.Enabled = false;
                    cbDevicesThree.Enabled = false;
                    break;
                case HotkeyTypeEnum.ChangeAudioVolume:
                case HotkeyTypeEnum.StepUpAudioVolume:
                case HotkeyTypeEnum.StepDownAudioVolume:
                    cbDevicesTwo.Enabled = false;
                    cbDevicesThree.Enabled = false;
                    btnBrowse.Enabled = false;
                    break;
                case HotkeyTypeEnum.ToggleAudio:
                case HotkeyTypeEnum.PlayAudio:
                    cbDevicesThree.Enabled = true;
                    break;
                default:
                    cbDevicesThree.Enabled = false;
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
            if (cbDevicesTwo.SelectedItem != null)
            {
                tempHotkey.ExtraData3 = cbDevicesTwo.SelectedItem.ToString();
            }
            if (cbDevicesThree.SelectedItem != null)
            {
                if (tempHotkey.AdditionalExtraData != null)
                {
                    if (tempHotkey.AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree))
                    {
                        tempHotkey.AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree] = cbDevicesThree.SelectedItem.ToString();
                    } else
                    {
                        tempHotkey.AdditionalExtraData.Add((int) HotkeyAdditionalDataType.DeviceThree, cbDevicesThree.SelectedItem.ToString());
                    }
                }
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = @"Audio Files (*.mp3, *.wav)|*.mp3;*.wav";

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
