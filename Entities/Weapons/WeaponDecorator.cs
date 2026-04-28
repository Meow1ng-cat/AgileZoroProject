using System;
using System.Collections.Generic;
using System.Text;
using Zoro.Entities.Units;

namespace Zoro.Entities.Weapons
{
    public abstract class WeaponDecorator : IWeapon
    {
        protected IWeapon Weapon;

        public WeaponDecorator(IWeapon weapon)
        {
            Weapon = weapon;
        }

        public virtual void DealDamage(Unit damageTaker) => Weapon.DealDamage(damageTaker);
    }
}
