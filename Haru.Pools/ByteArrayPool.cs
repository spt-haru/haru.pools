using System.Buffers;

namespace Haru.Pools
{
    public class ByteArrayPool
    {
        private static readonly ArrayPool<byte> _shared;

        static ByteArrayPool()
        {
            _shared = ArrayPool<byte>.Shared;
        }

        public static byte[] Rent(int bufferSize)
        {
            return _shared.Rent(bufferSize);
        }

        public static void Return(byte[] buffer)
        {
            _shared.Return(buffer);
        }
    }
}