using System;
using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Sound;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class ToggleAudioHotkey : Hotkey
    {
        private CachedSound cachedSound;
        private HotkeyAudioDevice audioDevice;
        private HotkeyAudioDevice audioDeviceTwo;
        private HotkeyAudioDevice audioDeviceThree;
        private NAudio.Wave.ISampleProvider provider = null;
        private NAudio.Wave.ISampleProvider providerTwo = null;
        private NAudio.Wave.ISampleProvider providerThree = null;
        // extra data 1: file path
        // extra data 2: device name
        // extra data 3: second device name
        public override void HotkeyTriggered()
        {
            if (provider == null)
            {
                if (audioDevice == null)
                {
                    audioDevice = MainAudio.Instance.GetDevice(ExtraData2);
                }
                if (audioDevice != null)
                {
                    provider = audioDevice.AssociatedEngine.PlaySound(cachedSound);
                }

                if (!String.IsNullOrWhiteSpace(ExtraData3))
                {
                    if (audioDeviceTwo == null)
                    {
                        audioDeviceTwo = MainAudio.Instance.GetDevice(ExtraData3);
                    }

                    if (audioDeviceTwo != null)
                    {
                        providerTwo = audioDeviceTwo.AssociatedEngine.PlaySound(cachedSound);
                    }
                }

                if (AdditionalExtraData != null && AdditionalExtraData.ContainsKey((int)HotkeyAdditionalDataType.DeviceThree) && !String.IsNullOrWhiteSpace(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]))
                {
                    if (audioDeviceThree == null)
                    {
                        audioDeviceThree = MainAudio.Instance.GetDevice(AdditionalExtraData[(int)HotkeyAdditionalDataType.DeviceThree]);
                    }

                    if (audioDeviceThree != null)
                    {
                        providerThree = audioDeviceThree.AssociatedEngine.PlaySound(cachedSound);
                    }
                }
            }
            else
            {
                if (audioDevice != null)
                {
                    audioDevice.AssociatedEngine.StopSound(provider);
                }
                provider = null;
                providerTwo = null;
                providerThree = null;
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
