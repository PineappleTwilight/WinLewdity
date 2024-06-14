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
            set
            {
                this.SetLevel(value);
            }
        }
        public virtual double PointsPerTier { 
            get
            {
                var maxlevel = this.GetMaxLevel();
                var maxtier = this.MaxTier + 1;
                maxlevel.Wait();
                return (double)maxlevel.Result / (double)maxtier;
            }
        }
        public virtual double ProgressToNextTier
        {
            get
            {
                var ppt = this.PointsPerTier;
                var level = this.GetLevel();
                var tier = this.Tier;
                level.Wait();
                double remainderFromTier = level.Result - (tier * ppt);
                double percentage = (remainderFromTier / ppt) * 100;
                return percentage;
            }
        }
        public virtual int Tier { 
            get
            {
                var ppt = this.PointsPerTier;
                var level = this.GetLevel();
                level.Wait();
                int tier = (int)Math.Floor((double)level.Result / (double)ppt);
                if (tier > MaxTier)
                {
                    return MaxTier;
                } else
                {
                    return tier;
                }
            }
        }
    }
}