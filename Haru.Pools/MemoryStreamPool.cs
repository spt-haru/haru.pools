using System.IO;
using Microsoft.Extensions.ObjectPool;

namespace Haru.Pools
{
    public class MemoryStreamPool
    {
        private static readonly ObjectPool<MemoryStream> _shared;

        static MemoryStreamPool()
        {
            var policy = new DefaultPooledObjectPolicy<MemoryStream>();
            var provider = new DefaultObjectPoolProvider();
            _shared = provider.Create(policy);
        }

        public static MemoryStream Rent()
        {
            return _shared.Get();
        }

        public static void Return(MemoryStream stream)
        {
            stream.SetLength(0L);
            _shared.Return(stream);
        }
    }
}