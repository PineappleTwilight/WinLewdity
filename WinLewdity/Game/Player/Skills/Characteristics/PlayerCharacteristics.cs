using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game.Player.Skills;

namespace WinLewdity.Game.Player
{
    public class PlayerCharacteristics
    {
        public PlayerPurity Purity { get; set; } = new PlayerPurity();
        public PlayerBeauty Beauty { get; set; } = new PlayerBeauty();
        public PlayerPhysique Physique { get; set; } = new PlayerPhysique();
        public PlayerWillpower Willpower { get; set; } = new PlayerWillpower();
        public PlayerAwareness Awareness { get; set; } = new PlayerAwareness();
        public PlayerPromiscuity Promiscity { get; set; } = new PlayerPromiscuity();
        public PlayerExhibitionism Exhibitionism { get; set; } = new PlayerExhibitionism();
        public PlayerDeviancy Deviancy { get; set; } = new PlayerDeviancy();
    }
}