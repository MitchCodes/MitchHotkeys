using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.MiddleTier.Services.Sound;
using MitchHotkeys.Logic.Models;

namespace MitchHotkeys.MiddleTier.Services.HotkeyTypes
{
    public class PlayInputDeviceRecordingFromMemory : Hotkey
    {
        private HotkeyAudioDevice audioInputDevice;
        private AudioRecorder recorder;
        private HotkeyAudioDevice audioOutputDevice;
        private HotkeyAudioDevice audioOutputDeviceTwo;

        public override void HotkeyTriggered()
        {
            if (audioInputDevice != null)
            {
                if (recorder == null)
                {
                    if (audioInputDevice.Recorders.Count > 0)
                    {
                        recorder = audioInputDevice.Recorders[0];
                    }
                }

                if (recorder == null)
                {
                    return;
                }

                byte[] memorySoundData = recorder.TempMemoryRecordedBytes;

                if (audioOutputDevice != null)
                {
                    audioOutputDevice.AssociatedEngine.PlayRawWaveSound(memorySoundData, recorder.WaveSource.WaveFormat);
                }

                if (audioOutputDeviceTwo != null)
                {
                    audioOutputDeviceTwo.AssociatedEngine.PlayRawWaveSound(memorySoundData,
                        recorder.WaveSource.WaveFormat);
                } 

            }
        }

        public override void Load()
        {
            if (audioInputDevice == null && !String.IsNullOrWhiteSpace(ExtraData1))
            {
                audioInputDevice = MainAudio.Instance.GetDevice(ExtraData1, AudioDeviceType.Input);
            }

            if (audioOutputDevice == null && !String.IsNullOrWhiteSpace(ExtraData2))
            {
                audioOutputDevice = MainAudio.Instance.GetDevice(ExtraData2, AudioDeviceType.Output);
            }

            if (audioOutputDeviceTwo == null && !String.IsNullOrWhiteSpace(ExtraData3))
            {
                audioOutputDeviceTwo = MainAudio.Instance.GetDevice(ExtraData3, AudioDeviceType.Output);
            }
        }

        public override void Dispose()
        {

        }
    }
}
