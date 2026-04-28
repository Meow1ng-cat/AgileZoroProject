using Zoro.Core;
using Zoro.Entities.Units;
using Zoro.Sprites;

namespace Zoro.Entities.Weapons
{
    public abstract class Weapon : Entity, IWeapon
    {
        private readonly WeaponSpriteSet WeaponSpriteSet;

        protected Direction Direction;
        protected int Damage;
        protected Unit Owner;
        public Weapon(WeaponSpriteSet spriteSet, int damage, Direction direction, Unit owner) : base(spriteSet)
        {

            WeaponSpriteSet = spriteSet;
            Damage = damage;
            Direction = direction;
            Owner = owner;
            Sprite = Direction == Direction.Right
                        ? WeaponSpriteSet.GetIdleRight
                        : WeaponSpriteSet.GetIdleLeft;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            if (Direction != Owner.Direction)
            {
                Direction = Owner.Direction;
            }

            if (Direction == Direction.Left && !Sprite.Equals(WeaponSpriteSet.GetIdleLeft))
            {
                Sprite = WeaponSpriteSet.GetIdleLeft;
            }
            else if (Direction == Direction.Right && !Sprite.Equals(WeaponSpriteSet.GetIdleRight))
            {
                Sprite = WeaponSpriteSet.GetIdleRight;
            }
            else
            {
                //Лог
            }

            pos.X = Owner.GetPos().X + Owner.GetSprite().Sockets["WeaponSocket"].X;
            pos.Y = Owner.GetPos().Y + Owner.GetSprite().Sockets["WeaponSocket"].Y;
        }

        public override void OnCollision(Entity other) 
        {
            if (other is Unit unit && 
                unit.ID != Owner.ID &&
                Owner.IsAttacking == true)
            {
                DealDamage(unit);
                Owner.IsAttacking = false;
            }
        }

        public void DealDamage(Unit damageTaker)
        {
            damageTaker.TakeDamage(Damage);
        }
    }
}
