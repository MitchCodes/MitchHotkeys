using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    public class JoeWaveOutEvent : IWavePlayer, IDisposable, IWavePosition
    {
        private float volume = 1f;
        private readonly object waveOutLock;
        private readonly SynchronizationContext syncContext;
        private IntPtr hWaveOut;
        private IWaveProvider waveStream;
        private volatile PlaybackState playbackState;
        private AutoResetEvent callbackEvent;
        private float _volume;

        /// <summary>
        /// Gets or sets the desired latency in milliseconds
        /// Should be set before a call to Init
        /// </summary>
        public int DesiredLatency { get; set; }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public float Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public long GetPosition()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets or sets the number of buffers used
        /// Should be set before a call to Init
        /// </summary>
        public int NumberOfBuffers { get; set; }

        /// <summary>
        /// Gets or sets the device number
        /// Should be set before a call to Init
        /// This must be between 0 and <see>DeviceCount</see> - 1.
        /// </summary>
        public int DeviceNumber { get; set; }

        /// <summary>
        /// Gets a <see cref="T:NAudio.Wave.WaveFormat" /> instance indicating the format the hardware is using.
        /// </summary>
        public WaveFormat OutputWaveFormat
        {
            get
            {
                return this.waveStream.WaveFormat;
            }
        }

        /// <summary>Playback State</summary>
        public PlaybackState PlaybackState
        {
            get
            {
                return this.playbackState;
            }
        }
        

        /// <summary>Indicates playback has stopped automatically</summary>
        public event EventHandler<StoppedEventArgs> PlaybackStopped;

        /// <summary>Opens a WaveOut device</summary>
        public JoeWaveOutEvent()
        {
            this.syncContext = SynchronizationContext.Current;
            if (this.syncContext != null && (this.syncContext.GetType().Name == "LegacyAspNetSynchronizationContext" || this.syncContext.GetType().Name == "AspNetSynchronizationContext"))
                this.syncContext = (SynchronizationContext)null;
            this.DeviceNumber = 0;
            this.DesiredLatency = 300;
            this.NumberOfBuffers = 2;
            this.waveOutLock = new object();
        }

        /// <summary>
        /// Finalizer. Only called when user forgets to call <see>Dispose</see>
        /// </summary>
        ~JoeWaveOutEvent()
        {
            this.Dispose(false);
        }

        private void Dispose(bool v)
        {
            throw new NotImplementedException();
        }

        /// <summary>Initialises the WaveOut device</summary>
        /// <param name="waveProvider">WaveProvider to play</param>
        public void Init(IWaveProvider waveProvider)
        {
            if (this.playbackState != PlaybackState.Stopped)
                throw new InvalidOperationException("Can't re-initialize during playback");

            this.waveStream = waveProvider;
            int byteSize = this.ConvertLatencySneaky(waveProvider.WaveFormat, ((this.DesiredLatency + this.NumberOfBuffers - 1) / this.NumberOfBuffers));
        }


        private int ConvertLatencySneaky(WaveFormat format, int milliseconds)
        {
            int num = (int)((double)format.AverageBytesPerSecond / 1000.0 * (double)milliseconds);
            if (num % format.BlockAlign != 0)
                num = num + format.BlockAlign - num % format.BlockAlign;
            return num;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
