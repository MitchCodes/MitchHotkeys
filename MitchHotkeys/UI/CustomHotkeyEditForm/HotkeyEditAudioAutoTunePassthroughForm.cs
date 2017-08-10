using System;
using System.IO;
using System.Windows.Forms;
using MitchHotkeys.MiddleTier.Factories;
using MitchHotkeys.MiddleTier.Services.Misc;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.UI.Model;
using MitchHotkeys.UI.Model.Validation;
using MitchHotkeys.UI.Services;
using MitchHotkeys.UI.Model.Sound;
using System.Collections.ObjectModel;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Models.Sound;

namespace MitchHotkeys.UI.CustomHotkeyEditForm
{
    public partial class HotkeyEditAudioAutoTunePassthroughForm : Form, IHotkeyForm
    {
        private Hotkey _hotkey;
        private AutoTuneViewModel _autoTuneViewModel;

        public Hotkey Hotkey
        {
            get { return _hotkey; }
            set { _hotkey = value; }
        }

        public AutoTuneViewModel AutoTuneViewModel
        {
            get { return _autoTuneViewModel; }
            set { _autoTuneViewModel = value; }
        }

        public HotkeyEditAudioAutoTunePassthroughForm()
        {
            InitializeComponent();
            AutoTuneViewModel = new AutoTuneViewModel();
            cbCommand.DataSource = Enum.GetValues(typeof(HotkeyTypeEnum));
            cbModifier.DataSource = Enum.GetValues(typeof(KeyModifier));
            cbKey.DataSource = Enum.GetValues(typeof(Keys));
        }

        public HotkeyEditAudioAutoTunePassthroughForm(Hotkey hotkey)
        {
            InitializeComponent();
            AutoTuneViewModel = new AutoTuneViewModel();
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
            }

            foreach(string currentScale in AutoTuneViewModel.Scales)
            {
                cbScale.Items.Add(currentScale);
            }

            string trbAttackValue = hotkey.GetAdditionalData(HotkeyAdditionalDataType.AutoTuneAttack);
            if (trbAttackValue != null)
            {
                trBAttack.Value = int.Parse(trbAttackValue);
                lblAttackVal.Text = trbAttackValue + "ms";
            }

            string vibratoRate = hotkey.GetAdditionalData(HotkeyAdditionalDataType.AutoTuneVibratoRate);
            if (vibratoRate != null)
            {
                tbVibratoRate.Text = vibratoRate;
            }

            foreach(NoteViewModel pitch in AutoTuneViewModel.Pitches)
            {
                HotkeyAdditionalDataType pitchAddtDataType = GetAddtDataTypeFromPitch(pitch);
                string pitchAddt = hotkey.GetAdditionalData(pitchAddtDataType);
                CheckBox pitchCb = GetCheckboxFromPitch(pitch);
                if (pitchAddt != null && pitchCb != null)
                {
                    pitchCb.Checked = bool.Parse(pitchAddt);
                    pitch.Selected = bool.Parse(pitchAddt);
                }
            }

            string selectedScale = AutoTuneViewModel.GetScaleFromSelectedPitches();
            if (!String.IsNullOrWhiteSpace(selectedScale))
            {
                cbScale.SelectedItem = selectedScale;
            }

            cbCommand.SelectedItem = (HotkeyTypeEnum) hotkey.Command;
            cbCommand.Enabled = false;
            cbModifier.SelectedItem = (KeyModifier)hotkey.Modifier;
            cbKey.SelectedItem = (Keys)hotkey.Key;
            

            cbInputDeviceOne.SelectedItem = hotkey.ExtraData1;
            cbOutputDeviceOne.SelectedItem = hotkey.ExtraData2;
        }

        private HotkeyAdditionalDataType GetAddtDataTypeFromPitch(NoteViewModel pitch)
        {
            switch (pitch.Note)
            {
                case Note.C:
                    return HotkeyAdditionalDataType.AutoTunePitchC;
                case Note.CSharp:
                    return HotkeyAdditionalDataType.AutoTunePitchCSharp;
                case Note.D:
                    return HotkeyAdditionalDataType.AutoTunePitchD;
                case Note.DSharp:
                    return HotkeyAdditionalDataType.AutoTunePitchDSharp;
                case Note.E:
                    return HotkeyAdditionalDataType.AutoTunePitchE;
                case Note.F:
                    return HotkeyAdditionalDataType.AutoTunePitchF;
                case Note.FSharp:
                    return HotkeyAdditionalDataType.AutoTunePitchFSharp;
                case Note.G:
                    return HotkeyAdditionalDataType.AutoTunePitchG;
                case Note.GSharp:
                    return HotkeyAdditionalDataType.AutoTunePitchGSharp;
                case Note.A:
                    return HotkeyAdditionalDataType.AutoTunePitchA;
                case Note.ASharp:
                    return HotkeyAdditionalDataType.AutoTunePitchASharp;
                case Note.B:
                    return HotkeyAdditionalDataType.AutoTunePitchB;
                default:
                    throw new Exception("unknown pitch. must be a misconfiguration");
            }
        }

        private CheckBox GetCheckboxFromPitch(NoteViewModel pitch)
        {
            switch (pitch.Note)
            {
                case Note.C:
                    return cbC;
                case Note.CSharp:
                    return cbCSharp;
                case Note.D:
                    return cbD;
                case Note.DSharp:
                    return cbDSharp;
                case Note.E:
                    return cbE;
                case Note.F:
                    return cbF;
                case Note.FSharp:
                    return cbFSharp;
                case Note.G:
                    return cbG;
                case Note.GSharp:
                    return cbGSharp;
                case Note.A:
                    return cbA;
                case Note.ASharp:
                    return cbASharp;
                case Note.B:
                    return cbB;
                default:
                    throw new Exception("unknown pitch. must be a misconfiguration");
            }
        }

        //private CheckBox GetCheckboxFromName(string cbName)
        //{
        //    foreach(Control formControl in this.Controls)
        //    {
        //        if (formControl is CheckBox)
        //        {
        //            if (formControl.Name == cbName)
        //            {
        //                return (CheckBox)formControl;
        //            }
        //        }
        //    }
        //    return null;
        //}

        private NoteViewModel GetPitchFromCheckbox(CheckBox cb)
        {
            switch(cb.Name)
            {
                case "cbC":
                    return GetPitchFromNote(Note.C, AutoTuneViewModel.Pitches);
                case "cbCSharp":
                    return GetPitchFromNote(Note.CSharp, AutoTuneViewModel.Pitches);
                case "cbD":
                    return GetPitchFromNote(Note.D, AutoTuneViewModel.Pitches);
                case "cbDSharp":
                    return GetPitchFromNote(Note.DSharp, AutoTuneViewModel.Pitches);
                case "cbE":
                    return GetPitchFromNote(Note.E, AutoTuneViewModel.Pitches);
                case "cbF":
                    return GetPitchFromNote(Note.F, AutoTuneViewModel.Pitches);
                case "cbFSharp":
                    return GetPitchFromNote(Note.FSharp, AutoTuneViewModel.Pitches);
                case "cbG":
                    return GetPitchFromNote(Note.G, AutoTuneViewModel.Pitches);
                case "cbGSharp":
                    return GetPitchFromNote(Note.GSharp, AutoTuneViewModel.Pitches);
                case "cbA":
                    return GetPitchFromNote(Note.A, AutoTuneViewModel.Pitches);
                case "cbASharp":
                    return GetPitchFromNote(Note.ASharp, AutoTuneViewModel.Pitches);
                case "cbB":
                    return GetPitchFromNote(Note.B, AutoTuneViewModel.Pitches);
                default:
                    throw new Exception("unknown pitch. must be a misconfiguration");
            }
        }

        private NoteViewModel GetPitchFromNote(Note theNote, ObservableCollection<NoteViewModel> collection)
        {
            foreach(NoteViewModel currentViewModel in collection)
            {
                if (currentViewModel.Note == theNote)
                {
                    return currentViewModel;
                }
            }

            return null;
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
            if (cbInputDeviceOne.SelectedItem != null)
            {
                tempHotkey.ExtraData1 = cbInputDeviceOne.SelectedItem.ToString();
            }
            if (cbOutputDeviceOne.SelectedItem != null)
            {
                tempHotkey.ExtraData2 = cbOutputDeviceOne.SelectedItem.ToString();
            }

            tempHotkey.SetAdditionalData(HotkeyAdditionalDataType.AutoTuneAttack, trBAttack.Value.ToString());
            tempHotkey.SetAdditionalData(HotkeyAdditionalDataType.AutoTuneVibratoRate, tbVibratoRate.Text);

            foreach(NoteViewModel currentPitch in AutoTuneViewModel.Pitches)
            {
                HotkeyAdditionalDataType additionalType = GetAddtDataTypeFromPitch(currentPitch);
                tempHotkey.SetAdditionalData(additionalType, currentPitch.Selected.ToString());
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

        private void cbPitch_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox cbCasted = (CheckBox)sender;
                NoteViewModel pitch = GetPitchFromCheckbox(cbCasted);
                if (pitch != null)
                {
                    pitch.Selected = cbCasted.Checked;
                }
            }
        }

        private void cbScale_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbCasted = (ComboBox) sender;
            string selectedScale = cbCasted.SelectedItem.ToString();
            AutoTuneViewModel.SelectedScale = selectedScale;
            foreach(NoteViewModel currentPitch in AutoTuneViewModel.Pitches)
            {
                CheckBox pitchCb = GetCheckboxFromPitch(currentPitch);
                if (pitchCb != null)
                {
                    pitchCb.Checked = currentPitch.Selected;
                } else
                {
                    throw new Exception("Checkbox is null");
                }
            }
        }

        private void trBAttack_Scroll(object sender, EventArgs e)
        {
            TrackBar trbCasted = (TrackBar)sender;
            lblAttackVal.Text = trbCasted.Value + "ms";
        }
    }
}
