using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Model.Sound;
using MitchHotkeys.MiddleTier.Services.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class DevicePassthroughHotkey : Hotkey
    {
        private AudioPassthroughSettings _audioPassthroughSettings;
        private bool _startOn;
        private bool _enabled;
        private AudioPassthrough _audioPassthrough;

        public AudioPassthroughSettings AudioPassthroughSettings
        {
            get { return _audioPassthroughSettings; }
            set { _audioPassthroughSettings = value; }
        }

        private bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        private bool StartOn
        {
            get { return _startOn; }
            set { _startOn = value; }
        }

        private AudioPassthrough AudioPassthrough
        {
            get { return _audioPassthrough; }
            set { _audioPassthrough = value; }
        }

        public override void HotkeyTriggered()
        {
            TogglePassingThrough();
        }

        public override void Load()
        {
            AudioPassthroughSettings = new AudioPassthroughSettings();
            if (AudioPassthroughSettings.InputDevice == null)
            {
                AudioPassthroughSettings.InputDevice = MainAudio.Instance.GetDevice(ExtraData1, AudioDeviceType.Input);
            }

            if (AudioPassthroughSettings.OutputDevice == null)
            {
                AudioPassthroughSettings.OutputDevice = MainAudio.Instance.GetDevice(ExtraData2, AudioDeviceType.Output);
            }

            AudioPassthroughSettings.AutoTuneSettings = new AutoTuneSettings();

            string startOnSaved = this.GetAdditionalData(HotkeyAdditionalDataType.ExtraData4);
            if (!String.IsNullOrWhiteSpace(startOnSaved))
            {
                StartOn = bool.Parse(startOnSaved);
            }

            AudioPassthroughSettings.AssociatedHotkey = this;

            AudioPassthroughSettings.InputDevice.Passthroughs.Add(AudioPassthroughSettings);
            AudioPassthroughSettings.OutputDevice.Passthroughs.Add(AudioPassthroughSettings);
            

            if (AudioPassthroughSettings.InputDevice != null && AudioPassthroughSettings.OutputDevice != null)
            {
                AudioPassthrough = new AudioPassthrough(AudioPassthroughSettings.InputDevice, AudioPassthroughSettings.OutputDevice, AudioPassthroughSettings.AutoTuneSettings);
                AudioPassthroughSettings.AudioPassthrough = AudioPassthrough;

                if (StartOn)
                {
                    StartPassingThrough();
                    Enabled = true;
                }
            }

        }

       

        public override void Dispose()
        {
            AudioPassthrough.Dispose();
        }

        private void TogglePassingThrough()
        {
            Enabled = !Enabled;
            if (Enabled)
            {
                AudioPassthrough.StartPassingThrough();
            } else
            {
                AudioPassthrough.StopPassingThrough();
            }
        }

        private void StartPassingThrough()
        {
            AudioPassthrough.StartPassingThrough();
        }

        private void StopPassingThrough()
        {
            AudioPassthrough.StopPassingThrough();
        }
        
    }
}
