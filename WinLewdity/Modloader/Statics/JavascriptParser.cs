using Acornima;
using Acornima.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Modloader.Statics
{
    public static class JavascriptParser
    {
        private static Parser parser = new Parser();

        public static Script ParseScript(string script)
        {
            return parser.ParseScript(script);
        }
    }
}