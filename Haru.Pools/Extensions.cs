using System;
using System.IO;

namespace Haru.Pools
{
    public static class Extensions
    {
#if !NETSTANDARD2_1_OR_GREATER || !NETCOREAPP2_1_OR_GREATER
        public static void Write(this Stream stream, ReadOnlySpan<byte> data)
        {
            var buffer = ByteArrayPool.Rent(data.Length);

            try
            {
                data.CopyTo(buffer);
                stream.Write(buffer, 0, data.Length);
            }
            finally
            {
                ByteArrayPool.Return(buffer);
            }
        }
#endif
    }
}