using CefSharp.DevTools;
using CefSharp.WinForms;
using NAudio.Wave;
using WinLewdity.Lovense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using WinLewdity.Game.Player;
using WinLewdity.Game.Hooks;

namespace WinLewdity.Internal
{
    public static class Globals
    {
        // App
        public static readonly string AppName = "WinLewdity";

        public static readonly Version AppVersion = new Version("0.2.0");

        public static bool DebugMode = false;
        public static Uri DiscordInvite = new Uri("https://discord.gg/GX7sjmdRMQ");
        public static Uri GithubLink = new Uri("https://github.com/PineappleTwilight/WinLewdity");
        public static Uri TrelloLink = new Uri("https://trello.com/b/JJSrt8zW/winlewdity");

        // Preferences
        public static Preferences? userPreferences { get; set; }

        public static SextoyServerConnector? sextoyServer { get; set; }

        public static ChromiumWebBrowser? cefSharpBrowser { get; set; }

        // Media players
        public static WaveOutEvent sfxOutputDevice;

        public static AudioFileReader sfxAudioFile;

        public static WaveOutEvent musicOutputDevice;

        public static AudioFileReader musicAudioFile;

        // Game Stuff
        public static WinLewdity_Hooks gameApi { get; } = new WinLewdity_Hooks();

        public static WinLewdity_Hooks_Internal gameApiInternal { get; } = new WinLewdity_Hooks_Internal();

        public static DevToolsClient gameDevClient { get; set; }
        public static PlayerCharacter PlayerCharacter { get; set; }
    }
}