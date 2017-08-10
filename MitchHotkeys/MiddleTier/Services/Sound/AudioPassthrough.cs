using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MitchHotkeys.Logic.Models;
using MitchHotkeys.Logic.Models.Sound;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    public class AudioPassthrough : IDisposable
    {
        private WaveIn _waveSource;
        private WaveOutEvent _waveOutput;
        private AutoTuneSettings _autoTuneSettings;
        private AutoTuneWaveProvider _autoTuner;
        private JoeWaveInProvider _waveInProvider;
        private MonoToStereoProvider16 _monoToStereoProvider;
        private bool _passingThrough;
        private DateTime _lastPauseOrStart;
        private Wave16ToFloatProvider _wave16ToFloatProvider;
        private WaveFloatTo16Provider _waveFloatTo16Provider;
        private DirectSoundOut _directSoundOut;

        public WaveIn WaveSource
        {
            get { return _waveSource; }
        }

        public JoeWaveInProvider WaveInProvider
        {
            get { return _waveInProvider; }
        }

        public WaveOutEvent WaveOutput
        {
            get { return _waveOutput; }
        }

        public AutoTuneSettings AutoTuneSettings
        {
            get { return _autoTuneSettings; }
        }

        public MonoToStereoProvider16 MonoToStereoProvider
        {
            get { return _monoToStereoProvider; }
        }

        public Wave16ToFloatProvider Wave16ToFloatProvider
        {
            get { return _wave16ToFloatProvider; }
        }

        public WaveFloatTo16Provider WaveFloatTo16Provider
        {
            get { return _waveFloatTo16Provider; }
        }
    

        public AutoTuneWaveProvider AutoTuner
        {
            get { return _autoTuner; }
        }

        public bool PassingThrough
        {
            get { return _passingThrough; }
            set { _passingThrough = value; }
        }

        private DateTime LastPauseOrStart
        {
            get { return _lastPauseOrStart; }
            set { _lastPauseOrStart = value; }
        }

        public DirectSoundOut DirectSoundOutput

        {
            get { return _directSoundOut; }
            set { _directSoundOut = value; }
        }

        public MemoryStream MemoryStream { get; set; }

        public AudioPassthrough(HotkeyAudioDevice input, HotkeyAudioDevice output, AutoTuneSettings autoTuneSettings)
        {
            LastPauseOrStart = new DateTime(2000, 1, 1);
            _autoTuneSettings = autoTuneSettings;

            _waveSource = new WaveIn();
            WaveSource.DeviceNumber = input.AudioDeviceId;
            //WaveSource.WaveFormat = new WaveFormat();
            WaveSource.WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
            WaveSource.RecordingStopped += WaveSource_RecordingStopped;
            WaveSource.DataAvailable += WaveSource_DataAvailable;
            //WaveSource.BufferMilliseconds = 300;
            //_waveInProvider = new JoeWaveInProvider(WaveSource);


            //StereoToMonoProvider16 stereoToMonoprovider = new StereoToMonoProvider16(_waveInProvider);

            //_wave16ToFloatProvider = new Wave16ToFloatProvider(stereoToMonoprovider);
            //var test3 = ;
            MemoryStream = new MemoryStream(new byte[8192]);

            var rawSourceStream = new RawSourceWaveStream(MemoryStream, WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));

            //_autoTuner = new AutoTuneWaveProvider(_wave16ToFloatProvider, AutoTuneSettings);

            _autoTuner = new AutoTuneWaveProvider(rawSourceStream, AutoTuneSettings);

            _waveFloatTo16Provider = new WaveFloatTo16Provider(_autoTuner);

            _monoToStereoProvider = new MonoToStereoProvider16(_waveFloatTo16Provider);

            //_monoToStereoProvider = new MonoToStereoProvider16(_autoTuner);

            _waveOutput = new WaveOutEvent();
            WaveOutput.DeviceNumber = output.AudioDeviceId;
            WaveOutput.PlaybackStopped += WaveOutput_PlaybackStopped;
            WaveOutput.Init(_monoToStereoProvider);


            //JoeWaveOutEvent joeWaveOut = new JoeWaveOutEvent();
            //joeWaveOut.DeviceNumber = output.AudioDeviceId;
            //joeWaveOut.DesiredLatency = 329;
            //joeWaveOut.NumberOfBuffers = 7;
            //joeWaveOut.Init(_monoToStereoProvider);

            //DirectSoundDeviceInfo foundDeviceInfo = null;
            //foreach (DirectSoundDeviceInfo deviceInfo in DirectSoundOut.Devices)
            //{
            //    if (deviceInfo.Description.Contains(output.AudioDeviceName))
            //    {
            //        foundDeviceInfo = deviceInfo;
            //        break;
            //    }
            //}

            //if (foundDeviceInfo != null)
            //{
            //    DirectSoundOutput = new DirectSoundOut(foundDeviceInfo.Guid, 300);
            //    DirectSoundOutput.PlaybackStopped += DirectSoundOutput_PlaybackStopped;
            //    DirectSoundOutput.Init(_monoToStereoProvider);
            //}

        }

        private void DirectSoundOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (PassingThrough)
            {
                DirectSoundOutput.Play();
            }
        }

        private void WaveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            //Console.WriteLine(e.Buffer.Count());
            if (e.BytesRecorded > 8192)
            {
                int bytesRemaining = e.BytesRecorded;
                int bytesSent = 0;
                byte[] temp = new byte[8192];
                //byte[] remaining;
                while (bytesRemaining > 8192)
                {
                    //remaining = new byte[bytesRemaining];
                    Array.Copy(e.Buffer, bytesSent, temp, 0, 8192);
                    //MemoryStream.Write(temp, 0, 8192);
                    byte[] buffer = MemoryStream.GetBuffer();
                    Array.Copy(temp, 0, buffer, 0, 8192);
                    //Array.Copy(e.Buffer, bytesSent, remaining, 0, bytesRemaining);
                    bytesSent += 8192;
                    bytesRemaining -= 8192;
                }

                temp = new byte[bytesRemaining];
                Array.Copy(e.Buffer, bytesSent, temp, 0, bytesRemaining);
                MemoryStream.Write(temp, 0, bytesRemaining);

            } else
            {
                MemoryStream.Write(e.Buffer, 0, e.BytesRecorded);
            }
        }

        public void StartPassingThrough()
        {
            if (DateTime.Now <= LastPauseOrStart.AddMilliseconds(500))
            {
                return;
            }
            LastPauseOrStart = DateTime.Now;
            try
            {
                WaveSource.StartRecording();
                if (WaveOutput != null)
                {
                    WaveOutput.Play();
                }
                if (DirectSoundOutput != null)
                {
                    DirectSoundOutput.Play();
                }
                PassingThrough = true;
            } catch (Exception)
            {
                
            }
            
        }

        public void StopPassingThrough()
        {
            if (DateTime.Now <= LastPauseOrStart.AddMilliseconds(500))
            {
                return;
            }
            LastPauseOrStart = DateTime.Now;
            try
            {
                WaveSource.StopRecording();
                if (WaveOutput != null)
                {
                    WaveOutput.Pause();
                }
                if (DirectSoundOutput != null)
                {
                    DirectSoundOutput.Pause();
                }
                PassingThrough = false;
            }
            catch (Exception)
            {

            }
        }

        public void ToggleAutoTune()
        {
            AutoTuneSettings.Enabled = !AutoTuneSettings.Enabled;
        }

        private void WaveOutput_PlaybackStopped(object sender, StoppedEventArgs e)
        {
            if (PassingThrough)
            {
                WaveOutput.Play();
            }
        }

        private void WaveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (PassingThrough)
            {
                WaveSource.StartRecording();
            }
        }

        public void Dispose()
        {
            try
            {
                if (WaveSource != null)
                {
                    WaveSource.StopRecording();
                    WaveSource.Dispose();
                }

                if (WaveOutput != null)
                {
                    WaveOutput.Stop();
                    WaveOutput.Dispose();
                }

                if (DirectSoundOutput != null)
                {
                    DirectSoundOutput.Stop();
                    DirectSoundOutput.Dispose();
                }
            } catch (Exception) { }
        }
    }
}
