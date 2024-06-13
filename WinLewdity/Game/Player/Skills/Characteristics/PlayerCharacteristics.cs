using WinLewdity.Game.Player.Skills;
using WinLewdity_GUI.Game.DOM.Managers.Characteristics;

namespace WinLewdity.Game.Player
{
    public class PlayerCharacteristics
    {
        public PurityManager PurityManager { get; set; } = new PurityManager();
        public BeautyManager BeautyManager { get; set; } = new BeautyManager();
        public PhysiqueManager PhysiqueManager { get; set; } = new PhysiqueManager();
        public WillpowerManager WillpowerManager { get; set; } = new WillpowerManager();
        public AwarenessManager AwarenessManager { get; set; } = new AwarenessManager();
        public PromiscuityManager PromiscityManager { get; set; } = new PromiscuityManager();
        public ExhibitionismManager ExhibitionismManager { get; set; } = new ExhibitionismManager();
        public DeviancyManager DeviancyManager { get; set; } = new DeviancyManager();
    }
}