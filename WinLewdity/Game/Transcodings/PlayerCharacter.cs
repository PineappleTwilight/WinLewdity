using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Game.Transcodings
{
    public class PlayerCharacter
    {
        // Generalized player statistics rated on a slider-based scale. All of these are floats.

        #region General Stats

        public float Pain { get; set; }
        public float Arousal { get; set; }
        public float Fatigue { get; set; }
        public float Stress { get; set; }
        public float Trauma { get; set; }
        public float Control { get; set; }
        public float Allure { get; set; }

        #endregion General Stats

        // Core player stats that affect gameplay. All are integer-based and go by tiers + progress to the next tier.

        #region Core Characteristics

        public int PurityTier { get; set; }
        public float PurityProgress { get; set; }
        public int BeautyTier { get; set; }
        public float BeautyProgress { get; set; }
        public int PhysiqueTier { get; set; }
        public float PhysiqueProgress { get; set; }
        public int WillpowerTier { get; set; }
        public float WillpowerProgress { get; set; }
        public int AwarenessTier { get; set; }
        public float AwarenessProgress { get; set; }
        public int PromiscuityTier { get; set; }
        public float PromiscuityProgress { get; set; }
        public int ExhibitionismTier { get; set; }
        public float ExhibitionismProgress { get; set; }
        public int DeviancyTier { get; set; }
        public float DeviancyProgress { get; set; }

        #endregion Core Characteristics

        // These skills are rated from None - A* and use progress floats. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.

        #region Skills

        public int SkuduggeryTier { get; set; }
        public float SkuduggeryProgress { get; set; }
        public int DancingTier { get; set; }
        public float DancingProgress { get; set; }
        public int SwimmingTier { get; set; }
        public float SwimmingProgress { get; set; }
        public int AthleticsTier { get; set; }
        public float AthleticsProgress { get; set; }
        public int TendingTier { get; set; }
        public float TendingProgress { get; set; }
        public int HousekeepingTier { get; set; }
        public float HousekeepingProgress { get; set; }

        #endregion Skills

        // These skills are rated from None - A* and use progress floats. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.

        #region Sex Skills

        public int SeductionTier { get; set; }
        public float SeductionProgress { get; set; }
        public int ChestTier { get; set; }
        public float ChestProgress { get; set; }
        public int ButtTier { get; set; }
        public float ButtProgress { get; set; }
        public int VaginalTier { get; set; }
        public float VaginalProgress { get; set; }
        public int ThighsTier { get; set; }
        public float ThighsProgress { get; set; }
        public int OralTier { get; set; }
        public float OralProgress { get; set; }
        public int HandsTier { get; set; }
        public float HandsProgress { get; set; }
        public int AnalTier { get; set; }
        public float AnalProgress { get; set; }
        public int FeetTier { get; set; }
        public float FeetProgress { get; set; }

        #endregion Sex Skills

        // These skills are rated from F - A* and use progress floats. These are text-based for display purposes but use integers as a backend. F equals tier 1 and goes up from there.

        #region School Skills

        public int ScienceTier { get; set; }
        public float ScienceProgress { get; set; }

        /// <summary>
        /// Ranges from 0-3
        /// </summary>
        public int DailyScienceProgress { get; set; }

        public int MathTier { get; set; }
        public float MathProgress { get; set; }

        /// <summary>
        /// Ranges from 0-3
        /// </summary>
        public int DailyMathProgress { get; set; }

        public int EnglishTier { get; set; }
        public float EnglishProgress { get; set; }

        /// <summary>
        /// Ranges from 0-3
        /// </summary>
        public int DailyEnglishProgress { get; set; }

        public int HistoryTier { get; set; }
        public float HistoryProgress { get; set; }

        /// <summary>
        /// Ranges from 0-3
        /// </summary>
        public int DailyHistoryProgress { get; set; }

        /// <summary>
        /// Cumulative value of all other skills
        /// </summary>
        public int OverallSchoolSkills { get; set; }

        #endregion School Skills

        // These skills are rated from None - A* and use progress floats. These are text-based for display purposes but use integers as a backend. None equals tier 0 and goes up from there.

        #region Weapon Skills

        public int SpraysTier { get; set; }
        public float SpraysProgress { get; set; }

        #endregion Weapon Skills
    }
}