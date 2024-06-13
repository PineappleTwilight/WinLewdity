using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Characteristics
{
    public class PurityManager : CharacteristicManager
    {
        public override int MaxTier { get; set; } = 7;
        public override string VariableReference { get; set; } = "V.purity";

        public override async Task<int> GetMaxLevel()
        {
            return 1000;
        }
    }
}
