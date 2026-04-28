using System;
using System.Collections.Generic;
using System.Text;
using Zoro.Entities.Units;

namespace Zoro.Entities.Weapons
{
    public class CriticalStrikeModifier : WeaponDecorator
    {
        private const int CriticalMultiplier = 2;
        public CriticalStrikeModifier(IWeapon weapon) : base(weapon) { }
        public override void DealDamage(Unit damageTaker)
        {
            for (int i = 0; i < CriticalMultiplier; i++)
            {
                Weapon.DealDamage(damageTaker);
            }
        }
    }
}
