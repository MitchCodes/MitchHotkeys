﻿using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class StopRecordingInputDeviceHotkey : Hotkey
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
            }

            if (recorder == null)
            {
                return;
            }

            recorder.StopRecording();

        }

        public override void Load()
        {
            if (audioDevice == null)
            {
                audioDevice = MainAudio.Instance.GetDevice(ExtraData2, AudioDeviceType.Input);
            }
        }

        public override void Dispose()
        {
        }
    }
}
