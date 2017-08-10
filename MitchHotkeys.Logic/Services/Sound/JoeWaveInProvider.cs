using System;
using NAudio.Wave;

namespace MitchHotkeys.Logic.Services.Sound
{
    public class JoeWaveInProvider : IWaveProvider
    {
        IWaveIn waveIn;
        BufferedWaveProvider bufferedWaveProvider;

        /// <summary>
        /// Creates a new WaveInProvider
        /// n.b. Should make sure the WaveFormat is set correctly on IWaveIn before calling
        /// </summary>
        /// <param name="waveIn">The source of wave data</param>
        public JoeWaveInProvider(IWaveIn waveIn)
        {
            this.waveIn = waveIn;
            waveIn.DataAvailable += waveIn_DataAvailable;
            bufferedWaveProvider = new BufferedWaveProvider(this.WaveFormat);
            bufferedWaveProvider.BufferDuration = new TimeSpan(0, 0, 1);
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            bufferedWaveProvider.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }

        /// <summary>
        /// Reads data from the WaveInProvider
        /// </summary>
        public int Read(byte[] buffer, int offset, int count)
        {
            return bufferedWaveProvider.Read(buffer, 0, count);
        }

        /// <summary>
        /// The WaveFormat
        /// </summary>
        public WaveFormat WaveFormat
        {
            get { return waveIn.WaveFormat; }
        }
    }
}
