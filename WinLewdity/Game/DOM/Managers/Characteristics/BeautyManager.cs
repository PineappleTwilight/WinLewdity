using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Characteristics
{
    public class BeautyManager : CharacteristicManager
    {
        public override int MaxTier { get; set; } = 6;
        public override double PointsPerTier
        {
            get
            {
                var maxlevel = this.GetMaxLevel();
                var maxtier = this.MaxTier;
                maxlevel.Wait();
                return (double)maxlevel.Result / (double)maxtier + 1;
            }
        }
        public override string VariableReference { get; set; } = "V.beauty";
    }
}
