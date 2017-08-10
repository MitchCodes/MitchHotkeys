using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace MitchHotkeys.MiddleTier.Services.Sound
{
    public class AutoDisposeFileReader : ISampleProvider
    {
        private readonly AudioFileReader reader;
        private bool isDisposed;
        private Action<int> FinishCallback { get; set; }
        public AutoDisposeFileReader(AudioFileReader reader, Action<int> finishCallback =  null)
        {
            this.reader = reader;
            this.WaveFormat = reader.WaveFormat;
            FinishCallback = finishCallback;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            if (isDisposed)
                return 0;
            int read = reader.Read(buffer, offset, count);
            if (read == 0)
            {
                FinishCallback?.Invoke(0);
                reader.Dispose();
                isDisposed = true;
            }
            return read;
        }

        public WaveFormat WaveFormat { get; private set; }
    }
}
