using Acornima;
using Acornima.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Modloader.Statics
{
    /// <summary>
    /// Class that holds various functions related to AST.
    /// </summary>
    public static class JavascriptParser
    {
        private static Parser parser = new Parser();

        /// <summary>
        /// Parses raw JS code into AST.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static Script ParseJavascript(string script)
        {
            return parser.ParseScript(script);
        }

        /// <summary>
        /// Parses compiled AST into raw JS code.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static string ParseAST(Script script)
        {
            return script.ToJavaScript();
        }
    }
}