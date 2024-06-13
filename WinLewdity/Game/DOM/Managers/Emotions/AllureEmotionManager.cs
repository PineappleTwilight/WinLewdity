using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;
using WinLewdity_GUI.Game.DOM.Managers.Bases;

namespace WinLewdity_GUI.Game.DOM.Managers.Emotions
{
    public class AllureEmotionManager : EmotionTraitManager
    {
        public override string VariableReference { get; set; } = "V.allure";

        public override async Task<int> GetMaxLevel()
        {
            return 10000;
        }

        public override async Task<int> GetLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference);
            double raw = (double)con.Result;
            return await Task.FromResult((int)raw);
        }
    }
}