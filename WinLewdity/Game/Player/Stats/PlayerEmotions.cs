using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity_GUI.Game.Player.Stats
{
    public class PlayerEmotions
    {
        /// <summary>
        /// Player's pain value.
        /// </summary>
        public float Pain
        {
            get
            {
                var tasky = GameFunctions.GetPainLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Arousal
        {
            get
            {
                var tasky = GameFunctions.GetArousalLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Fatigue
        {
            get
            {
                var tasky = GameFunctions.GetFatigueLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Stress
        {
            get
            {
                var tasky = GameFunctions.GetStressLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Trauma
        {
            get
            {
                var tasky = GameFunctions.GetTraumaLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Control
        {
            get
            {
                var tasky = GameFunctions.GetControlLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
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
        public float Allure
        {
            get
            {
                var tasky = GameFunctions.GetAllureLevel();
                tasky.Wait();
                return (float)(tasky.Result / 100);
            }
            set
            {
                int floatToInt = (int)(value * 100);
                GameFunctions.SetAllureLevel(floatToInt);
            }
        }
    }
}