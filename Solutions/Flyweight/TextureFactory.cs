using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Flyweight
{
    class TextureFactory
    {
        private readonly Dictionary<string, Texture> _cache = new(StringComparer.OrdinalIgnoreCase);
        private readonly object _lock = new();

        public Texture GetTexture(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            if (_cache.TryGetValue(path, out var t)) return t;

            lock (_lock)
            {
                if (_cache.TryGetValue(path, out t)) return t;

                Console.WriteLine($"Loading texture '{Path.GetFileName(path)}'...");
                var data = File.Exists(path) ? File.ReadAllBytes(path) : Array.Empty<byte>();
                Thread.Sleep(150);
                t = new Texture(path, data);
                _cache[path] = t;
                Console.WriteLine($"Loaded: {t}");
                return t;
            }
        }

        public int CacheCount => _cache.Count;
    }
}
