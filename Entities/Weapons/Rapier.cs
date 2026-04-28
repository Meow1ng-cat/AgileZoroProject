using Zoro.Core;
using Zoro.Entities.Units;
using Zoro.Sprites;

namespace Zoro.Entities.Weapons
{
    public class Rapier : Weapon
    {
        public Rapier(int damage, Direction direction, Unit owner) : base(new RapierSpriteSet(), damage, direction, owner)
        {
        }
    }
}
