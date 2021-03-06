﻿using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class StartRecordingInputDeviceHotkey : Hotkey
    {
        private HotkeyAudioDevice audioDevice;
        private AudioRecorder recorder;

        public override void HotkeyTriggered()
        {
            if (recorder == null)
            {
                if (audioDevice.Recorders.Count > 0)
                {
                    recorder = audioDevice.Recorders[0];
                }
                else
                {
                    if (audioDevice != null)
                    {
                        int finalSecondsToWait = 0;
                        if (!int.TryParse(ExtraData3, out finalSecondsToWait))
                        {
                            finalSecondsToWait = 30;
                        }
                        AudioRecorder newRecorder = new AudioRecorder(audioDevice, finalSecondsToWait);
                        recorder = newRecorder;
                    }
                }
            }

            if (recorder == null)
            {
                return;
            }

            recorder.StartRecording();

        }

        public override void Load()
        {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2, AudioDeviceType.Input);
                if (audioDevice.Recorders.Count > 0)
                {
                    recorder = audioDevice.Recorders[0];
                }
                else
                {
                    if (audioDevice != null)
                    {
                        int finalSecondsToWait = 0;
                        if (!int.TryParse(ExtraData3, out finalSecondsToWait))
                        {
                            finalSecondsToWait = 30;
                        }
                        AudioRecorder newRecorder = new AudioRecorder(audioDevice, finalSecondsToWait);
                        recorder = newRecorder;
                    }
                }
            }
        }

        public override void Dispose()
        {
        }
    }
}
