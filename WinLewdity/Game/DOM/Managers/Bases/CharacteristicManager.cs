using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Game;

namespace WinLewdity_GUI.Game.DOM.Managers.Bases
{
    public abstract class CharacteristicManager : ManagerBase
    {
        public virtual int MaxTier { get; set; }
    }
}