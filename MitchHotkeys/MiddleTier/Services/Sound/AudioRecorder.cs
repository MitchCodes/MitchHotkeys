using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using System.Collections.Concurrent;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Models.GenericStructures;
using MitchHotkeys.Logic.Models.Sound;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    // reference link: http://stackoverflow.com/questions/17982468/naudio-record-sound-from-microphone-then-save
    public class AudioRecorder
    {
        private Guid _recorderId = new Guid();
        private HotkeyAudioDevice _device;
        private WaveFileWriter _waveWriter;
        private int _secondsToHold;
        private bool _isRecording = false;
        private WaveIn _waveIn;
        private long _maximumBytes;
        private ReadWriteBuffer _recordedBytes;
        private byte[] _tempMemoryRecordedBytes;


        public AudioRecorder(HotkeyAudioDevice device, int secondsToHold = 30)
        {
            Device = device;
            SecondsToHold = secondsToHold;

            WaveSource = new WaveIn();
            WaveSource.DeviceNumber = device.AudioDeviceId;
            WaveSource.WaveFormat = new WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(device.AudioDeviceId).Channels);
            MaximumBytes = WaveSource.WaveFormat.AverageBytesPerSecond*(SecondsToHold+1);
            WaveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            WaveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            RecordedBytes = new ReadWriteBuffer((int)MaximumBytes);

            Device.Recorders.Add(this);
        }
        
        public HotkeyAudioDevice Device
        {
            get { return _device; }
            set { _device = value; }
        }

        public WaveIn WaveSource
        {
            get { return _waveIn; }
            set { _waveIn = value; }
        }

        public WaveFileWriter WaveWriter
        {
            get { return _waveWriter; }
            set { _waveWriter = value; }
        }

        public int SecondsToHold
        {
            get { return _secondsToHold; }
            set { _secondsToHold = value; }
        }

        private long MaximumBytes
        {
            get { return _maximumBytes; }
            set { _maximumBytes = value; }
        }

        public ReadWriteBuffer RecordedBytes
        {
            get { return _recordedBytes; }
            set { _recordedBytes = value; }
        }

        public byte[] TempMemoryRecordedBytes
        {
            get { return _tempMemoryRecordedBytes; }
        }

        public bool IsRecording
        {
            get { return _isRecording; }
        }

        public void StartRecording()
        {
            if (_isRecording)
            {
                return;
            }
            _isRecording = true;
            WaveSource.StartRecording();
        }

        public void StopRecording()
        {
            if (!_isRecording)
            {
                return;
            }
            _isRecording = false;
            WaveSource.StopRecording();
        }

        public void SaveCurrentRecordingTempInMemory()
        {
            _tempMemoryRecordedBytes = RecordedBytes.Copy();
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (this.IsRecording)
            {
                RecordedBytes.Write(e.Buffer, e.BytesRecorded);
            }
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            _isRecording = false;
        }
    }
}
