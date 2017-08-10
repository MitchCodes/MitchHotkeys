using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace MitchHotkeys.Logic.Services.Sound
{
    public class CachedSound
    {
        public float[] AudioData { get; private set; }
        public WaveFormat WaveFormat { get; private set; }
        public CachedSound(string audioFileName, int playerSampleRate = 44100)
        {
            using (var audioFileReader = new AudioFileReader(audioFileName))
            {
                WaveFormat = audioFileReader.WaveFormat;
                if (WaveFormat.SampleRate != playerSampleRate)
                {
                    using (var resampler = new MediaFoundationResampler(audioFileReader, playerSampleRate))
                    {
                        var wholeFile = new List<byte>();
                        var readBuffer = new byte[resampler.WaveFormat.SampleRate * resampler.WaveFormat.Channels];
                        int samplesRead;
                        while ((samplesRead = resampler.Read(readBuffer, 0, readBuffer.Length)) > 0)
                        {
                            wholeFile.AddRange(readBuffer.Take(samplesRead));
                        }
                        AudioData = new float[wholeFile.Count/4];
                        Buffer.BlockCopy(wholeFile.ToArray(), 0, AudioData, 0, wholeFile.Count);
                        WaveFormat = new WaveFormat(playerSampleRate, audioFileReader.WaveFormat.Channels);
                    }
                }
                else
                {
                    var wholeFile = new List<float>((int)(audioFileReader.Length / 4));
                    var readBuffer = new float[audioFileReader.WaveFormat.SampleRate * audioFileReader.WaveFormat.Channels];
                    int samplesRead;
                    while ((samplesRead = audioFileReader.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        wholeFile.AddRange(readBuffer.Take(samplesRead));
                    }
                    AudioData = wholeFile.ToArray();
                }
                
                
            }
        }
    }
}
