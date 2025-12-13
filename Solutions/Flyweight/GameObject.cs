using System;

namespace Flyweight
{
    class GameObject
    {
        public string Name { get; }
        public string TexturePath { get; }
        private Texture? _texture;

        public GameObject(string name, string texturePath)
        {
            Name = name;
            TexturePath = texturePath;
        }

        public void Initialize(TextureFactory factory)
        {
            _texture = factory.GetTexture(TexturePath);
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing {Name} with texture: {( _texture != null ? _texture.Name : "null")}");
        }
    }
}
