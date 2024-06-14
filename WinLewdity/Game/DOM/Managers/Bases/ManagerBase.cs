using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity_GUI.Game.DOM.Managers.Bases
{
    public abstract class ManagerBase
    {
        /// <summary>
        /// String representation of the JS DOM variable.
        /// </summary>
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
        /// Gets the current object level.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<double> GetLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference);
            if (con.Result.GetType() == typeof(int))
            {
                int raw = (int)con.Result;
                return (double)raw;
            } else
            {
                return (double)con.Result;
            }
        }

        /// <summary>
        /// Retrieves the system type of the JS variable.
        /// </summary>
        /// <returns></returns>
        public virtual async Task<Type> GetVariableType()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult(VariableReference);
            return con.Result.GetType();
        }

        /// <summary>
        /// Sets the current object level.
        /// </summary>
        /// <param name="level"></param>
        public virtual async void SetLevel(double level)
        {
            var valueToSet = level;
            int maxArousal = await GetMaxLevel();
            Type varType = await GetVariableType();

            // Determine the variable data type & cast to integer if detected
            if (varType == typeof(int))
            {
                valueToSet = (int)level;
            }

            // Prevent overflows
            if (level > maxArousal)
            {
                JavascriptUtils.ExecuteJavascript($"{VariableReference} = {maxArousal}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"{VariableReference} = {valueToSet}");
            }
        }
    }
}
