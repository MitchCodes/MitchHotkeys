using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.IO;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    public class AudioPlaybackEngine : IDisposable
    {
        private readonly WaveOutEvent outputDevice;
        private readonly MixingSampleProvider mixer;
        private readonly VolumeSampleProvider volume;


        public AudioPlaybackEngine(int sampleRate = 44100, int channelCount = 2, int deviceNumber = 0)
        {
            outputDevice = new WaveOutEvent();
            outputDevice.DeviceNumber = deviceNumber;
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount));
            mixer.ReadFully = true;
            volume = new VolumeSampleProvider(mixer);
            outputDevice.Init(volume);
            outputDevice.Play();
        }

        public void PlaySound(string fileName)
        {
            var input = new AudioFileReader(fileName);
            AddMixerInput(new AutoDisposeFileReader(input));
        }

        public void StopSound(ISampleProvider input)
        {
            mixer.RemoveMixerInput(input);
        }

        public void StopAllSounds()
        {
            mixer.RemoveAllMixerInputs();
        }

        public void SetVolume(float newVolume)
        {
            volume.Volume = newVolume;
        }

        public void StepVolumeUp(float stepAmount)
        {
            volume.Volume += stepAmount;
        }

        public void StepVolumeDown(float stepAmount)
        {
            if (volume.Volume - stepAmount >= 0)
            {
                volume.Volume -= stepAmount;
            }
            else
            {
                volume.Volume = 0;
            }
        }

        private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
        {
            if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
            {
                return input;
            }
            if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                return new MonoToStereoSampleProvider(input);
            }
            throw new NotImplementedException("Not yet implemented this channel count conversion");
        }

        public ISampleProvider PlaySound(CachedSound sound)
        {
            ISampleProvider provider = new CachedSoundSampleProvider(sound);
            AddMixerInput(provider);
            return provider;
        }

        public IWaveProvider PlayRawWaveSound(byte[] rawWaveData, WaveFormat format)
        {
            IWaveProvider provider = new RawSourceWaveStream(new MemoryStream(rawWaveData), format);
            AddMixerInput(provider);
            return provider;
        }

        private void AddMixerInput(ISampleProvider input)
        {
            mixer.AddMixerInput(ConvertToRightChannelCount(input));
        }

        private void AddMixerInput(IWaveProvider input)
        {
            mixer.AddMixerInput(input);
        }

        public void Dispose()
        {
            outputDevice.Dispose();
        }

        public static readonly AudioPlaybackEngine Instance = new AudioPlaybackEngine(44100, 2);
    }
}
