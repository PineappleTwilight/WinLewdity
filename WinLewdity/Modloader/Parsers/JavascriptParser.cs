using Acornima;
using Acornima.Ast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity_GUI.Modloader.Parsers
{
    /// <summary>
    /// Class that holds various functions related to AST.
    /// </summary>
    public class JavascriptParser
    {
        /// <summary>
        /// Main AST parser class.
        /// </summary>
        private Parser parser = new Parser();

        /// <summary>
        /// Parses raw JS code into AST.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public Script ParseJavascript(string script)
        {
            return parser.ParseScript(script);
        }

        /// <summary>
        /// Parses compiled AST into raw JS code.
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public string ParseAST(Script script)
        {
            return script.ToJavaScript();
        }
    }
}