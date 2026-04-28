using System;
using System.Collections.Generic;
using System.Text;
using Zoro.Entities.Units;

namespace Zoro.Entities.Weapons
{
    public interface IWeapon
    {
        public void DealDamage(Unit damageTaker);
    }
}
