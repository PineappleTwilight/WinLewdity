using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CefSharp;
using SimpleHtmlViewer.Internal;
using static SimpleHtmlViewer.Game.Enums;

namespace SimpleHtmlViewer.Game
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
    }
}