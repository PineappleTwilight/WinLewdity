using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Characteristics
{
    public class DeviancyManager : CharacteristicManager
    {
        public override int MaxTier { get; set; } = 6;
        public override string VariableReference { get; set; } = "V.deviancy";

        public override async Task<int> GetMaxLevel()
        {
            return 100;
        }
    }
}
