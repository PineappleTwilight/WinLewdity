using CefSharp.DevTools;
using CefSharp.WinForms;
using NAudio.Wave;
using SimpleHtmlViewer.Game.ExposedClasses;
using SimpleHtmlViewer.Lovense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace SimpleHtmlViewer.Internal
{
    public static class Globals
    {
        // Preferences
        public static Preferences? userPreferences { get; set; }

        public static MasterSextoyServer? sextoyServer { get; set; }

        public static ChromiumWebBrowser? cefSharpBrowser { get; set; }

        // Media players
        public static WaveOutEvent sfxOutputDevice;

        public static AudioFileReader sfxAudioFile;

        public static WaveOutEvent musicOutputDevice;

        public static AudioFileReader musicAudioFile;

        // Game Stuff
        public static DDOLP_Hooks gameApi = new DDOLP_Hooks();

        public static DevToolsClient gameDevClient { get; set; }
    }
}