using System;

namespace Flyweight
{
    class Texture
    {
        public string Name { get; }

        public string FullPath { get; }
        public byte[] Data { get; }

        public Texture(string fullPath, byte[] data)
        {
            FullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));
            Name = System.IO.Path.GetFileName(fullPath);
            Data = data ?? Array.Empty<byte>();
        }

        public override string ToString()
        {
            return $"Texture(Name={Name}, Size={Data?.Length ?? 0} bytes)";
        }
    }
}
