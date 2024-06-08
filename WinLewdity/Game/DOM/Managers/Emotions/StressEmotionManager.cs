using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Emotions
{
    public class StressEmotionManager : EmotionTraitManager
    {
        public override string VariableReference { get; set; } = "V.stress";
    }
}