using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SimpleHtmlViewer.Game.Enums;

namespace SimpleHtmlViewer.Game
{
    public static class EntityTypeExtensions
    {
        public static string ToDescriptionString(this EntityType val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }

    public static class Enums
    {
        public enum Gender
        {
            Male,
            Female
        }

        public enum EntityType
        {
            [Description("Dog")]
            Dog,

            [Description("Wolf")]
            Wolf,

            [Description("Cat")]
            Cat,

            [Description("Wildcat")]
            Wildcat,

            [Description("Boar")]
            Boar,

            [Description("Pig")]
            Pig,

            [Description("Horse")]
            Horse,

            [Description("Bear")]
            Bear,

            [Description("Dolphin")]
            Dolphin,

            [Description("Lizard")]
            Lizard,

            [Description("The Night Monster")]
            NightMonster,

            [Description("Squid")]
            Squid,

            [Description("Slug")]
            Slug,

            [Description("Lurker")]
            Lurker,

            [Description("Wasp")]
            Wasp,

            [Description("Giant Snake")]
            GiantSnake,

            [Description("Giant Frog")]
            GiantFrog,

            [Description("Urchin Parasite")]
            UrchinParasite,

            [Description("Slime Parasite")]
            SlimeParasite,

            [Description("Maggot Parasite")]
            MaggotParasite,

            [Description("Plant Person")]
            Plantperson,

            [Description("Beast Person")]
            Beastperson,

            [Description("Ivory Wraith")]
            IvoryWraith,

            [Description("The Black Wolf")]
            TheBlackWolf,

            [Description("The Great Hawk")]
            TheGreatHawk,

            [Description("Human")]
            Human
        }
    }
}