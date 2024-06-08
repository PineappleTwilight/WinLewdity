using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Game.Player.Skills
{
    public abstract class SkillBase
    {
        public virtual int Tier { get; set; }
        public virtual float Progress { get; set; }
    }
}