using SimpleHtmlViewer.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using static SimpleHtmlViewer.Game.Enums;

namespace SimpleHtmlViewer.Events
{
    public class CombatEnteredEventArgs : EventArgs
    {
        public EntityType EnemySpecies;
        public int EnemyNumber;
        public bool Consensual = false;
    }
}