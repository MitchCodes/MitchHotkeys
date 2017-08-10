using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes {
    public class ChangeAudioVolumeHotkey : Hotkey {
        private HotkeyAudioDevice audioDevice;
        private HotkeyAudioDevice audioDevice2;
        private float volumeSetTo = -1.0f;
        // extra data 1: audio amount
        // extra data 2: device name
        // extra data 2: device name #2
        public override void HotkeyTriggered() {

            if (audioDevice != null && audioDevice.AssociatedEngine != null)
            {
                audioDevice.AssociatedEngine.SetVolume(volumeSetTo);
            }

            if (audioDevice2 != null && audioDevice2.AssociatedEngine != null)
            {
                audioDevice2.AssociatedEngine.SetVolume(volumeSetTo);
            }

        }


        public override void Load() {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2);
            }

            if (audioDevice2 == null && !String.IsNullOrWhiteSpace(ExtraData3))
            {
                audioDevice2 = MainAudio.Instance.GetDevice(ExtraData3);
            }

            if (volumeSetTo == -1.0f)
            {
                float volumeConverted = -1.0f;
                if (!float.TryParse(ExtraData1, out volumeConverted))
                {
                    Console.WriteLine("Error: volume amount is not a float.");
                }
                volumeSetTo = volumeConverted;
            }
        }

        public override void Dispose() {
        }
    }
}
