using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game.Player.Skills;

namespace WinLewdity.Game.Player
{
    public class PlayerSchoolSkills
    {
        public EnglishSkills EnglishSkills { get; set; } = new EnglishSkills();
        public HistorySkills HistorySkills { get; set; } = new HistorySkills();
        public MathSkills MathSkills { get; set; } = new MathSkills();
        public ScienceSkills ScienceSkills { get; set; } = new ScienceSkills();

        public int OverallSchoolPerformance { get; set; }
    }
}