using CefSharp;
using CefSharp.DevTools;
using WinLewdity.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity.Game
{
    public static class JavascriptUtils
    {
        public static DevToolsClient? DevTools { get; set; }

        /// <summary>
        /// Fetches a javascript value. Any code run by this MUST return a value!
        /// </summary>
        /// <param name="script"></param>
        /// <returns></returns>
        public static async Task<JavascriptResponse> FetchJavascriptResult(string script)
        {
            JavascriptResponse response = await Globals.cefSharpBrowser.EvaluateScriptAsPromiseAsync(script);
            return response;
        }

        /// <summary>
        /// Executes Javascript code synchronously and does not return any values.
        /// </summary>
        /// <param name="script"></param>
        public static async void ExecuteJavascript(string script)
        {
            await Globals.cefSharpBrowser.EvaluateScriptAsync("(function() {" + script + "})();");
        }

        /// <summary>
        /// Executes Javascript code asynchronously and does not return any values.
        /// </summary>
        /// <param name="script"></param>
        public static async void ExecuteJavascriptAsync(string script)
        {
            await Globals.cefSharpBrowser.EvaluateScriptAsync("(async function() {" + script + "})();");
        }
    }
}