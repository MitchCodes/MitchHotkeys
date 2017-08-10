using MitchHotkeys.MiddleTier.Model;
using MitchHotkeys.MiddleTier.Services.Sound;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes {
    public class StepUpAudioVolumeHotkey : Hotkey {
        private HotkeyAudioDevice audioDevice;
        private HotkeyAudioDevice audioDevice2;
        private float volumeSetTo = -1.0f;
        // extra data 1: audio amount
        // extra data 2: device name
        // extra data 3: device name #2
        public override void HotkeyTriggered() {

            if (audioDevice != null && audioDevice.AssociatedEngine != null) {
                audioDevice.AssociatedEngine.StepVolumeUp(volumeSetTo);
            }

            if (audioDevice2 != null && audioDevice2.AssociatedEngine != null) {
                audioDevice2.AssociatedEngine.StepVolumeUp(volumeSetTo);

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
