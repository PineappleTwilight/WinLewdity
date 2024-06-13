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
        public override int Tier
        {
            get
            {
                var ppt = this.PointsPerTier;
                var level = this.GetLevel();
                level.Wait();
                return (int)Math.Floor((double)level.Result / (double)ppt);
            }
        }
        public override string VariableReference { get; set; } = "V.beauty";
    }
}
