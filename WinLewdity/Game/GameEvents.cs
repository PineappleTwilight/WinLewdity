using SimpleHtmlViewer.Events;
using SimpleHtmlViewer.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleHtmlViewer.Game
{
    public static class GameEvents
    {
        // Event delegates
        public delegate void StoryProgressEventHandler(object sender, StoryProgressedEventArgs e);

        public delegate void CombatEnteredEventHandler(object sender, CombatEnteredEventArgs e);

        public delegate void CombatEndedEventHandler(object sender, EventArgs e); // No special arguments needed here

        public delegate void MoneyChangedEventHandler(object sender, MoneyChangedEventArgs e);

        // Events
        public static event StoryProgressEventHandler StoryProgressed;

        public static event CombatEnteredEventHandler CombatEntered;

        public static event CombatEndedEventHandler CombatEnded;

        public static event MoneyChangedEventHandler MoneyChanged;

        // Functions

        /// <summary>
        /// Function to manually call the StoryProgressed event. This is only used internally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SceneChanged(object sender, StoryProgressedEventArgs e)
        {
            if (StoryProgressed != null)
            {
                StoryProgressed(sender, e);
            }
        }

        /// <summary>
        /// Function to manually call the CombatEntered event. This is only used internally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public static void CombatStarted(object sender, CombatEnteredEventArgs args)
        {
            AppLogger.LogDebug("Combat entered!");
            GameValues.InCombat = true;

            if (args.Consensual)
            {
                GameValues.InConsensualSex = true;
            }

            if (CombatEntered != null)
            {
                CombatEntered(sender, args);
            }
        }

        /// <summary>
        /// Function to manually call the CombatEnded event. This is only used internally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void CombatStopped(object sender, EventArgs e)
        {
            AppLogger.LogDebug("Combat exited!");
            GameValues.InCombat = false;
            GameValues.InConsensualSex = false;

            if (CombatEnded != null)
            {
                CombatEnded(sender, e);
            }
        }

        /// <summary>
        /// Function to manually call the MoneyChanged event. This is only used internally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void WealthChanged(object sender, MoneyChangedEventArgs e)
        {
            AppLogger.LogDebug("Money value changed!");
            if (MoneyChanged != null)
            {
                MoneyChanged(sender, e);
            }
        }
    }
}