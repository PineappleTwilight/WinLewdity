using CefSharp.DevTools.CSS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;
using WinLewdity_GUI.Game.DOM.Managers.Bases;
using WinLewdity_GUI.Game.DOM.Managers.Emotions;

namespace WinLewdity.Game.Player
{
    public class PlayerEmotions
    {
        public PainEmotionManager PainManager { get; private set; } = new PainEmotionManager();
        public ArousalEmotionManager ArousalManager { get; private set; } = new ArousalEmotionManager();
        public FatigueEmotionManager FatigueManager { get; private set; } = new FatigueEmotionManager();
        public StressEmotionManager StressManager { get; private set; } = new StressEmotionManager();
        public TraumaEmotionManager TraumaEmotionManager { get; private set; } = new TraumaEmotionManager();
        public ControlEmotionManager ControlManager { get; private set; } = new ControlEmotionManager();
        public AllureEmotionManager AllureManager { get; private set; } = new AllureEmotionManager();

        /// <summary>
        /// Fetches and formats a value in the range 0.0 - 1.0, with 1.0 representing 100% full and 0.0 representing 0% full.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        private double FetchValue(EmotionTraitManager manager)
        {
            var tasky = manager.GetLevel();
            var tasky2 = manager.GetMaxLevel();
            tasky.Wait();
            tasky2.Wait();
            return (tasky.Result / (double)tasky2.Result);
        }

        /// <summary>
        /// Sets a value in a consistent format. Accepts ranges 0.0 - 1.0, with 1.0 representing 100% full and 0.0 representing 0% full.
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="val"></param>
        private void SetValue(EmotionTraitManager manager, double val)
        {
            int floatToInt = (int)(val * 100);
            manager.SetLevel(floatToInt);
        }

        /// <summary>
        /// Player's pain value.
        /// </summary>
        public double Pain
        {
            get
            {
                return FetchValue(PainManager);
            }
            set
            {
                SetValue(PainManager, value);
            }
        }

        /// <summary>
        /// Player's arousal value.
        /// </summary>
        public double Arousal
        {
            get
            {
                return FetchValue(ArousalManager);
            }
            set
            {
                SetValue(ArousalManager, value);
            }
        }

        /// <summary>
        /// Player's fatigue value.
        /// </summary>
        public double Fatigue
        {
            get
            {
                return FetchValue(FatigueManager);
            }
            set
            {
                SetValue(FatigueManager, value);
            }
        }

        /// <summary>
        /// Player's stress value.
        /// </summary>
        public double Stress
        {
            get
            {
                return FetchValue(StressManager);
            }
            set
            {
                SetValue(StressManager, value);
            }
        }

        /// <summary>
        /// Player's trauma value.
        /// </summary>
        public double Trauma
        {
            get
            {
                return FetchValue(TraumaEmotionManager);
            }
            set
            {
                SetValue(TraumaEmotionManager, value);
            }
        }

        /// <summary>
        /// Player's control value.
        /// </summary>
        public double Control
        {
            get
            {
                return FetchValue(ControlManager);
            }
            set
            {
                SetValue(ControlManager, value);
            }
        }

        /// <summary>
        /// Player's allure level.
        /// </summary>
        public double Allure
        {
            get
            {
                return FetchValue(AllureManager);
            }
            set
            {
                SetValue(AllureManager, value);
            }
        }
    }
}