using System;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class StopAudioDeviceHotkey : Hotkey
    {
        private HotkeyAudioDevice audioDevice;
        // extra data 2: device name
        public override void HotkeyTriggered()
        {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2);
            }

            audioDevice.AssociatedEngine.StopAllSounds();

        }

        
        public override void Load()
        {
        }

        public override void Dispose()
        {
        }
    }
}
