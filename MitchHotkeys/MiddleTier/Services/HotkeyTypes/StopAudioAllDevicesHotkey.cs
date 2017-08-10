using System;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class StopAudioAllDevicesHotkey : Hotkey
    {
        
        public override void HotkeyTriggered()
        {

            foreach (HotkeyAudioDevice currentDevice in MainAudio.Instance.AudioOutputDevices)
            {
                currentDevice.AssociatedEngine.StopAllSounds();
            }

        }

        
        public override void Load()
        {
        }

        public override void Dispose()
        {
        }
    }
}
