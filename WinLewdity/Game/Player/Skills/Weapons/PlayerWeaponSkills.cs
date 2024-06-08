using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.Player.Skills.Weapons.Subweapons;

namespace WinLewdity_GUI.Game.Player.Skills.Weapons
{
    public class PlayerWeaponSkills
    {
        public WeaponSpraySkills SpraySkills { get; set; } = new WeaponSpraySkills();
        public WeaponBatonSkills BatonSkills { get; set; } = new WeaponBatonSkills();
        public WeaponWhipSkills WhipSkills { get; set; } = new WeaponWhipSkills();
        public WeaponNetSkills NetSkills { get; set; } = new WeaponNetSkills();
    }
}