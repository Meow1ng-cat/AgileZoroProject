using System;
using System.Collections.Generic;
using System.Text;
using Zoro.Entities.Units;

namespace Zoro.Entities.Weapons
{
    public class FireBladeModifier : WeaponDecorator
    {
        private const int FIRE_DAMAGE = 5;
        public FireBladeModifier(IWeapon weapon) : base(weapon) { }
        public override void DealDamage(Unit damageTaker)
        {
            Weapon.DealDamage(damageTaker);
            damageTaker.TakeDamage(FIRE_DAMAGE);
        }
    } 
}
