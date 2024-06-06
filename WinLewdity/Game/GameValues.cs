using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity.Game
{
    public static class GameValues
    {
        /// <summary>
        /// Player's money value. Includes the pound symbol.
        /// </summary>
        public static int? Money = null;

        /// <summary>
        /// Time of day the game is currently experiencing.
        /// </summary>
        public static string? Time = null;

        /// <summary>
        /// Day of the week the game is currently experiencing.
        /// </summary>
        public static string? DayOfWeek = null;

        /// <summary>
        /// Whether the player is in combat or not.
        /// </summary>
        public static bool InCombat = false;

        /// <summary>
        /// Whether the current sex scene is consensual or not. Typically only applies to combat.
        /// </summary>
        public static bool InConsensualSex = false;
    }
}