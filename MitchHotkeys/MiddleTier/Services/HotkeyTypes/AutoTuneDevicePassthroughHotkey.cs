using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Model.Sound;
using MitchHotkeys.MiddleTier.Services.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class AutoTuneDevicePassthroughHotkey : Hotkey
    {
        public AudioPassthroughSettings AudioPassthroughSettings { get; set; }
        public override void HotkeyTriggered()
        {
            if (AudioPassthroughSettings == null)
            {
                LoadAudioPassthroughSettings();
            }
            if (AudioPassthroughSettings == null)
            {
                return;
            }
            AudioPassthroughSettings.AudioPassthrough.ToggleAutoTune();
        }

        public override void Load()
        {
            if (AudioPassthroughSettings == null)
            {
                LoadAudioPassthroughSettings();
            }
        }

        private void LoadAudioPassthroughSettings()
        {
            HotkeyAudioDevice inputDevice = MainAudio.Instance.GetDevice(ExtraData1, AudioDeviceType.Input);

            HotkeyAudioDevice outputDevice = MainAudio.Instance.GetDevice(ExtraData2, AudioDeviceType.Output);


            foreach (AudioPassthroughSettings audioPassthroughSetting in inputDevice.Passthroughs)
            {
                if (audioPassthroughSetting.InputDevice.AudioDeviceId == inputDevice.AudioDeviceId && audioPassthroughSetting.OutputDevice.AudioDeviceId == outputDevice.AudioDeviceId)
                {
                    AudioPassthroughSettings = audioPassthroughSetting;
                    break;
                }
            }
            if (AudioPassthroughSettings == null)
            {
                foreach (AudioPassthroughSettings audioPassthroughSetting in outputDevice.Passthroughs)
                {
                    if (audioPassthroughSetting.InputDevice.AudioDeviceId == inputDevice.AudioDeviceId && audioPassthroughSetting.OutputDevice.AudioDeviceId == outputDevice.AudioDeviceId)
                    {
                        AudioPassthroughSettings = audioPassthroughSetting;
                        break;
                    }
                }
            }

            if (AudioPassthroughSettings != null)
            {
                LoadAutoTuneSettings();
            }
        }

        public override void Dispose()
        {
        }

        private void LoadAutoTuneSettings()
        {
            string vibratoRate = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTuneVibratoRate);
            string attack = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTuneAttack);

            string pitchC = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchC);
            string pitchCSharp = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchCSharp);
            string pitchD = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchD);
            string pitchDSharp = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchDSharp);
            string pitchE = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchE);
            string pitchF = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchF);
            string pitchFSharp = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchFSharp);
            string pitchG = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchG);
            string pitchGSharp = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchGSharp);
            string pitchA = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchA);
            string pitchASharp = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchASharp);
            string pitchB = this.GetAdditionalData(HotkeyAdditionalDataType.AutoTunePitchB);


            if (vibratoRate != null) AudioPassthroughSettings.AutoTuneSettings.VibratoRate = double.Parse(vibratoRate);
            if (attack != null) AudioPassthroughSettings.AutoTuneSettings.AttackTimeMilliseconds = double.Parse(attack);

            if (pitchC != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.C, bool.Parse(pitchC));
            if (pitchCSharp != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.CSharp, bool.Parse(pitchCSharp));
            if (pitchD != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.D, bool.Parse(pitchD));
            if (pitchDSharp != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.DSharp, bool.Parse(pitchDSharp));
            if (pitchE != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.E, bool.Parse(pitchE));
            if (pitchF != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.F, bool.Parse(pitchF));
            if (pitchFSharp != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.FSharp, bool.Parse(pitchFSharp));
            if (pitchG != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.G, bool.Parse(pitchG));
            if (pitchA != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.A, bool.Parse(pitchA));
            if (pitchASharp != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.ASharp, bool.Parse(pitchASharp));
            if (pitchB != null) AudioPassthroughSettings.AutoTuneSettings.TurnPitchOnOrOff(Note.B, bool.Parse(pitchB));
        }
    }
}
