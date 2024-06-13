using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity_GUI.Game.DOM.Managers.Bases
{
    public abstract class CharacteristicManager : ManagerBase
    {
        public virtual int MaxTier { get; set; }
        public virtual double RawValue { 
            get
            {
                var level = this.GetLevel();
                level.Wait();
                return level.Result;
            }
        }
        public virtual double PointsPerTier { 
            get
            {
                var maxlevel = this.GetMaxLevel();
                var maxtier = this.MaxTier;
                maxlevel.Wait();
                return (double)maxlevel.Result / (double)maxtier;
            }
        }
        public virtual int Tier { 
            get
            {
                var ppt = this.PointsPerTier;
                var level = this.GetLevel();
                level.Wait();
                return (int)Math.Floor((double)level.Result / (double)ppt);
            }
        }
    }
}