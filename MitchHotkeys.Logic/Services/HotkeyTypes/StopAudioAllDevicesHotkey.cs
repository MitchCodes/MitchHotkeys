using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
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
