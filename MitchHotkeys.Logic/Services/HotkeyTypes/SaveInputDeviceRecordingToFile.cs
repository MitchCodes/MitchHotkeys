using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Services.Sound;

namespace MitchHotkeys.Logic.Services.HotkeyTypes
{
    public class SaveInputDeviceRecordingToFile : Hotkey
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

            int count = recorder.RecordedBytes.Count;
            byte[] audioData = recorder.RecordedBytes.Copy();
            NAudio.Wave.WaveFileWriter waveWriter = new NAudio.Wave.WaveFileWriter(ExtraData1, recorder.WaveSource.WaveFormat);
            waveWriter.Write(audioData, 0, count);
            waveWriter.Flush();
            waveWriter.Dispose();

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
