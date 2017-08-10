using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MitchHotkeys.MiddleTier.Model.GenericStructures
{
    public class ReadWriteBuffer
    {
        private readonly byte[] _buffer;
        private int _endIndex;

        public ReadWriteBuffer(int capacity)
        {
            _buffer = new byte[capacity];
        }

        public int Count
        {
            get
            {
                if (_endIndex > 0)
                    return _endIndex;
                if (_endIndex < 0) // won't use this unless you are reading
                    return _buffer.Length + _endIndex;
                return 0;
            }
        }

        public void Write(byte[] dataSentIn, int bytesUsed = 0, bool truncate = true)
        {
            //if (Count + data.Length > _buffer.Length)
            //    throw new Exception("buffer overflow");
            if (bytesUsed == 0)
            {
                bytesUsed = dataSentIn.Length;
            }

            byte[] data = new byte[bytesUsed];

            Array.Copy(dataSentIn, 0, data, 0, bytesUsed);

            if (data.Length > _buffer.Length && truncate)
            {
                int startIndexCopy = data.Length - _buffer.Length - 1;
                Array.Copy(data, startIndexCopy, _buffer, 0, _buffer.Length);
                _endIndex = _buffer.Length;
                return;
            }


            if (_endIndex + data.Length > _buffer.Length)
            {
                var endLen = _buffer.Length - _endIndex; // how much space is left in the buffer that isn't filled
                var remainingLen = data.Length - endLen; // how much the new data goes over the max space limit
                var bufferRemainingLenDiff = _buffer.Length - remainingLen; // how much needs to get shifted down

                Array.Copy(_buffer, remainingLen, _buffer, 0, bufferRemainingLenDiff);
                Array.Copy(data, 0, _buffer, bufferRemainingLenDiff, data.Length);
                _endIndex = _buffer.Length;
            }
            else
            {
                Array.Copy(data, 0, _buffer, _endIndex, data.Length);
                _endIndex += data.Length;
            }
        }

        public byte[] Read(int len)
        {
            if (len > Count)
                throw new Exception("not enough data in buffer");
            var result = new byte[len];
            if (len < _buffer.Length)
            {
                Array.Copy(_buffer, 0, result, 0, len);
                return result;
            }
            else
            {
                var endLen = _buffer.Length;
                var remainingLen = len - endLen;
                Array.Copy(_buffer, 0, result, 0, endLen);
                Array.Copy(_buffer, 0, result, endLen, remainingLen);
                return result;
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new ArgumentOutOfRangeException();
                return _buffer[index % _buffer.Length];
            }
        }

        public IEnumerable<byte> Bytes
        {
            get
            {
                for (var i = 0; i < Count; i++)
                    yield return _buffer[i % _buffer.Length];
            }
        }

        public byte[] Copy()
        {
            byte[] bufferCopy = new byte[_buffer.Length];
            Array.Copy(_buffer, 0, bufferCopy, 0, _buffer.Length);
            return bufferCopy;
        }
    }
}
