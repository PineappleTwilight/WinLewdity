using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game.Player.Skills;

namespace WinLewdity.Game.Player
{
    public class PlayerPhysicalSkills
    {
        public SkulduggerySkills Skulduggery { get; set; } = new SkulduggerySkills();
        public DancingSkills Dancing { get; set; } = new DancingSkills();
        public SwimmingSkills Swimming { get; set; } = new SwimmingSkills();
        public AthleticsSkills Athletics { get; set; } = new AthleticsSkills();
        public TendingSkills Tending { get; set; } = new TendingSkills();
        public HousekeepingSkills Housekeeping { get; set; } = new HousekeepingSkills();
    }
}