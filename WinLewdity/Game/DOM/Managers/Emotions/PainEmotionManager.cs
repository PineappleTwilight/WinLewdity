﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Emotions
{
    public class PainEmotionManager : EmotionTraitManager
    {
        public override string VariableReference { get; set; } = "V.pain";

        public override async Task<int> GetMaxLevel()
        {
            return 100;
        }
    }
}