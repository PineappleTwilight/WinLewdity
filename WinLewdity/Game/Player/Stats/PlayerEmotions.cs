using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity.Game.Player
{
    public class PlayerEmotions
    {
        /// <summary>
        /// Player's pain value.
        /// </summary>
        public double Pain
        {
            get
            {
                var tasky = GameFunctions.GetPainLevel();
                var tasky2 = GameFunctions.GetMaxPainLevel();
                tasky.Wait();
                return tasky.Result / (double)tasky2;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetPainLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's arousal value.
        /// </summary>
        public double Arousal
        {
            get
            {
                var tasky = GameFunctions.GetArousalLevel();
                var tasky2 = GameFunctions.GetMaxArousalLevel();
                tasky.Wait();
                tasky2.Wait();
                return tasky.Result / (double)tasky2.Result;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetArousalLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's fatigue value.
        /// </summary>
        public double Fatigue
        {
            get
            {
                var tasky = GameFunctions.GetFatigueLevel();
                var tasky2 = GameFunctions.GetMaxFatigueLevel();
                tasky.Wait();
                return tasky.Result / (double)tasky2;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetFatigueLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's stress value.
        /// </summary>
        public double Stress
        {
            get
            {
                var tasky = GameFunctions.GetStressLevel();
                var tasky2 = GameFunctions.GetMaxStressLevel();
                tasky.Wait();
                tasky2.Wait();
                return tasky.Result / (double)tasky2.Result;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetStressLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's trauma value.
        /// </summary>
        public double Trauma
        {
            get
            {
                var tasky = GameFunctions.GetTraumaLevel();
                var tasky2 = GameFunctions.GetMaxTraumaLevel();
                tasky.Wait();
                tasky2.Wait();
                return tasky.Result / (double)tasky2.Result;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetTraumaLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's control value.
        /// </summary>
        public double Control
        {
            get
            {
                var tasky = GameFunctions.GetControlLevel();
                var tasky2 = GameFunctions.GetMaxControlLevel();
                tasky.Wait();
                tasky2.Wait();
                return tasky.Result / (double)tasky2.Result;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetControlLevel(floatToInt);
            }
        }

        /// <summary>
        /// Player's allure level.
        /// </summary>
        public double Allure
        {
            get
            {
                var tasky = GameFunctions.GetAllureLevel();
                var tasky2 = GameFunctions.GetMaxAllureLevel();
                tasky.Wait();
                return tasky.Result / (double)tasky2;
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetAllureLevel(floatToInt);
            }
        }
    }
}