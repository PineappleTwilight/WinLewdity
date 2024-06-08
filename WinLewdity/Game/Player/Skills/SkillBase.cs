using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity.Game.Player.Bases
{
    public abstract class SkillBase
    {
        public virtual int Tier { get; set; }
        public virtual float Progress { get; set; }
    }
}