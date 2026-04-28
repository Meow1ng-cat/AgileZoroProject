using Zoro.Core;
using Zoro.Sprites;

namespace Zoro.Entities.Units
{
    public class PlayerChar : Unit
    {
        public PlayerChar(int health, Direction direction) : base(new PlayerSpriteSet(), health, direction)
        {
        }

    }
}
