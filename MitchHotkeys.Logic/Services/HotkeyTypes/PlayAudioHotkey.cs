using System;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class PlayAudioHotkey : Hotkey
    {
        private CachedSound cachedSound;
        private HotkeyAudioDevice audioDevice;
        private HotkeyAudioDevice audioDeviceTwo;
        private HotkeyAudioDevice audioDeviceThree;
        private NAudio.Wave.ISampleProvider provider;
        private NAudio.Wave.ISampleProvider providerTwo;
        private NAudio.Wave.ISampleProvider providerThree;
        // extra data 1: file path
        // extra data 2: device name
        // extra data 3: second device name
        public override void HotkeyTriggered()
        {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2);
            }

            provider = audioDevice.AssociatedEngine.PlaySound(cachedSound);

            if (!String.IsNullOrWhiteSpace(ExtraData3))
            {
                if (audioDeviceTwo == null)
                {
                    audioDeviceTwo = MainAudio.Instance.GetDevice(ExtraData3);
                }

                providerTwo = audioDeviceTwo.AssociatedEngine.PlaySound(cachedSound);
            }
            
            if (AdditionalExtraData != null && AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree) && !String.IsNullOrWhiteSpace(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]))
            {
                if (audioDeviceThree == null)
                {
                    audioDeviceThree = MainAudio.Instance.GetDevice(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]);
                }

                providerThree = audioDeviceThree.AssociatedEngine.PlaySound(cachedSound);
            }

        }

        
        public override void Load()
        {
            cachedSound = new CachedSound(ExtraData1);
        }

        public override void Dispose()
        {
            if (audioDevice != null && provider != null)
            {
                audioDevice.AssociatedEngine.StopSound(provider);
            }

            if (audioDeviceTwo != null && providerTwo != null)
            {
                audioDeviceTwo.AssociatedEngine.StopSound(providerTwo);
            }

            if (audioDeviceThree != null && providerThree != null)
            {
                audioDeviceThree.AssociatedEngine.StopSound(providerThree);
            }
        }
    }
}
