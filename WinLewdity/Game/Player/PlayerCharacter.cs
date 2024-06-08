using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.Player.Skills.Characteristics;
using WinLewdity_GUI.Game.Player.Skills.Physical;
using WinLewdity_GUI.Game.Player.Skills.School;
using WinLewdity_GUI.Game.Player.Skills.Sex;
using WinLewdity_GUI.Game.Player.Skills.Weapons;
using WinLewdity_GUI.Game.Player.Stats;

namespace WinLewdity_GUI.Game.Player
{
    public class PlayerCharacter
    {
        // Generalized player statistics rated on a slider-based scale. All of these are floats.
        public PlayerEmotions EmotionalStats { get; set; } = new PlayerEmotions();

        // Core player stats that affect gameplay. All are integer-based and are generic skill types.
        public PlayerCharacteristics Characteristics { get; set; } = new PlayerCharacteristics();

        // These skills are rated from None - A*. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.
        public PlayerPhysicalSkills PhysicalSkills { get; set; } = new PlayerPhysicalSkills();

        // These skills are rated from None - A*. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.
        public PlayerSexSkills SexSkills { get; set; } = new PlayerSexSkills();

        // These skills are rated from F - A*. These are text-based for display purposes but use integers as a backend. F equals tier 1 and goes up from there.
        public PlayerSchoolSkills SchoolSkills { get; set; } = new PlayerSchoolSkills();

        // These skills are rated from None - A*. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.
        public PlayerWeaponSkills WeaponSkills { get; set; } = new PlayerWeaponSkills();
    }
}