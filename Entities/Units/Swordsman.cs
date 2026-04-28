using System;
using Zoro.Core;
using Zoro.Sprites;

namespace Zoro.Entities.Units
{
    public class Swordsman : Unit, ICloneable
    {
        public Swordsman(int health, Direction direction) : base(new PlayerSpriteSet(), health, direction)
        {
        }
        public object Clone()
        {
            Swordsman clone = (Swordsman)this.MemberwiseClone();
            clone.SpriteSet = new PlayerSpriteSet();  
            clone.pos = new Vector2d(this.pos.X, this.pos.Y);
            clone.ID = Entity.NextID++;  //Deep copy только полей которые копировались как ссылка.
            clone.SpawnEntity();
            return clone;
        }
    }
}
