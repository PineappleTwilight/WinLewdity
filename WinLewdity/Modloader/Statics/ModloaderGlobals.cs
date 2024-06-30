using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity_GUI.Modloader.Parsers;

namespace WinLewdity_GUI.Modloader.Statics
{
    public static class ModloaderGlobals
    {
        /// <summary>
        /// Modloader Javascript interpreter and splicer class. Handles all Javascript manipulation and re-structuring.
        /// </summary>
        public static JavascriptParser JavascriptInterpreter { get; } = new JavascriptParser();
    }
}