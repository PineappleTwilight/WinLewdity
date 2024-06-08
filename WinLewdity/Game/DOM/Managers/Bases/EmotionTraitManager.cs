using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity_GUI.Game.DOM.Managers.Bases
{
    public abstract class EmotionTraitManager
    {
        public virtual string VariableReference { get; set; }

        /// <summary>
        /// Gets the maximum possible trait level.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> GetMaxLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference + "max");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<int> GetLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference);
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public virtual async void SetLevel(int level)
        {
            int maxArousal = await GetMaxLevel();
            if (level > maxArousal)
            {
                JavascriptUtils.ExecuteJavascript($"{VariableReference} = {maxArousal}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"{VariableReference} = {level}");
            }
        }
    }
}