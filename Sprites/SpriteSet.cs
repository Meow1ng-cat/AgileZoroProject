using Zoro.Core;

namespace Zoro.Sprites
{
    public struct Sprite
    {
        public Vector2d SpriteCenter;
        public string[] SpriteImage;
        public IReadOnlyDictionary<string, Vector2d> Sockets;
    }
    public abstract class SpriteSet
    {
    }
}
