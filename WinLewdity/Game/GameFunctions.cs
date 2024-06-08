using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CefSharp;
using WinLewdity.Internal;
using static WinLewdity.Game.Enums;

namespace WinLewdity.Game
{
    public static class GameFunctions
    {
        /// <summary>
        /// Fetches a number relating to the current scene's "consentness".
        /// </summary>
        /// <returns>0 if there is no consent, 1 if consent is present</returns>
        public static async Task<bool> IsSceneConsensual()
        {
            AppLogger.LogDebug("Attempting fetch of consent value...");
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.consensual");
            int consentRaw = (int)con.Result;
            AppLogger.LogDebug("Consent Value: " + consentRaw);
            if (consentRaw == 0)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await Task.FromResult(true);
            }
        }

        /// <summary>
        /// Fetches a boolean describing whether the player is engaged in combat or not.
        /// </summary>
        /// <returns></returns>
        public static async Task<bool> InCombat()
        {
            AppLogger.LogDebug("Attempting fetch of combat value...");
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.combat");
            int combatRaw = (int)con.Result;
            AppLogger.LogDebug("In Combat: " + combatRaw);
            if (combatRaw == 0)
            {
                return await Task.FromResult(false);
            }
            else
            {
                return await Task.FromResult(true);
            }
        }

        /// <summary>
        /// Fetches the current money amount in cents.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetMoney()
        {
            AppLogger.LogDebug("Attempting fetch of money value...");
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.money");
            int moneyRaw = (int)con.Result;
            AppLogger.LogDebug("Money Value: " + moneyRaw);
            return await Task.FromResult(moneyRaw);
        }

        /// <summary>
        /// Fetches the current number of enemies. Only returns meaningful data in combat.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetNumberOfEnemies()
        {
            AppLogger.LogDebug("Attempting to determine number of current enemies...");
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.enemyno");
            int enemiesRaw = (int)con.Result;
            AppLogger.LogDebug("Number Of Enemies: " + enemiesRaw);
            return await Task.FromResult(enemiesRaw);
        }

        /// <summary>
        /// Fetches the current number of enemies. Only returns meaningful data in combat.
        /// </summary>
        /// <returns></returns>
        public static async Task<EntityType> GetEnemyType()
        {
            AppLogger.LogDebug("Attempting fetch of enemy type...");
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.enemytype");
            string entityRaw = (string)con.Result;
            AppLogger.LogDebug("Enemy Type: " + entityRaw);

            switch (entityRaw)
            {
                case "man":
                    return await Task.FromResult(EntityType.Human);
                    break;

                default:
                    // Return human if unknown
                    return await Task.FromResult(EntityType.Human);
                    break;
            }
        }

        #region Pain Functions

        /// <summary>
        /// Gets the maximum pain level possible.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxPainLevel()
        {
            return 100;
        }

        /// <summary>
        /// Gets the current pain level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetPainLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.pain");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current pain level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetPainLevel(int level)
        {
            if (level > GetMaxPainLevel())
            {
                JavascriptUtils.ExecuteJavascript($"V.pain = {GetMaxPainLevel()}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.pain = {level}");
            }
        }

        #endregion Pain Functions

        #region Arousal Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetMaxArousalLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.arousalmax");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetArousalLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.arousal");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetArousalLevel(int level)
        {
            int maxArousal = await GetMaxArousalLevel();
            if (level > maxArousal)
            {
                JavascriptUtils.ExecuteJavascript($"V.arousal = {maxArousal}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.arousal = {level}");
            }
        }

        #endregion Arousal Functions

        #region Fatigue Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxFatigueLevel()
        {
            return 2000;
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetFatigueLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.tiredness");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetFatigueLevel(int level)
        {
            int max = GetMaxFatigueLevel();
            if (level > max)
            {
                JavascriptUtils.ExecuteJavascript($"V.tiredness = {max}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.tiredness = {level}");
            }
        }

        #endregion Fatigue Functions

        #region Stress Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetMaxStressLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.stressmax");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetStressLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.stress");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetStressLevel(int level)
        {
            int max = await GetMaxStressLevel();
            if (level > max)
            {
                JavascriptUtils.ExecuteJavascript($"V.stress = {max}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.stress = {level}");
            }
        }

        #endregion Stress Functions

        #region Trauma Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetMaxTraumaLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.traumamax");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetTraumaLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.trauma");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetTraumaLevel(int level)
        {
            int max = await GetMaxTraumaLevel();
            if (level > max)
            {
                JavascriptUtils.ExecuteJavascript($"V.trauma = {max}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.trauma = {level}");
            }
        }

        #endregion Trauma Functions

        #region Control Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetMaxControlLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.controlmax");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetControlLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.control");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetControlLevel(int level)
        {
            int max = await GetMaxControlLevel();
            if (level > max)
            {
                JavascriptUtils.ExecuteJavascript($"V.control = {max}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.control = {level}");
            }
        }

        #endregion Control Functions

        #region Allure Functions

        /// <summary>
        /// Gets the maximum possible arousal level.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxAllureLevel()
        {
            return 10000;
        }

        /// <summary>
        /// Gets the current arousal level.
        /// </summary>
        /// <returns></returns>
        public static async Task<int> GetAllureLevel()
        {
            JavascriptResponse con = await JavascriptUtils.FetchJavascriptResult("V.allure");
            int raw = (int)con.Result;
            return await Task.FromResult(raw);
        }

        /// <summary>
        /// Sets the current arousal level.
        /// </summary>
        /// <param name="level"></param>
        public static async void SetAllureLevel(int level)
        {
            int max = GetMaxAllureLevel();
            if (level > max)
            {
                JavascriptUtils.ExecuteJavascript($"V.allure = {max}");
            }
            else
            {
                JavascriptUtils.ExecuteJavascript($"V.allure = {level}");
            }
        }

        #endregion Allure Functions
    }
}