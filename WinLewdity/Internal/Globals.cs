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
        /// <summary>
        /// Application name. Should never really be changed unless a rebrand happens.
        /// </summary>
        public static readonly string AppName = "WinLewdity";

        /// <summary>
        /// Application version.
        /// </summary>
        public static readonly Version AppVersion = new Version("0.2.0");

        /// <summary>
        /// Internally managed debug mode variable. Do not set manually.
        /// </summary>
        public static bool DebugMode = false;

        /// <summary>
        /// Discord server URL.
        /// </summary>
        public static Uri DiscordInvite = new Uri("https://discord.gg/GX7sjmdRMQ");

        /// <summary>
        /// Github repository URL.
        /// </summary>
        public static Uri GithubLink = new Uri("https://github.com/PineappleTwilight/WinLewdity");

        /// <summary>
        /// Trello project management URL.
        /// </summary>
        public static Uri TrelloLink = new Uri("https://trello.com/b/JJSrt8zW/winlewdity");

        /// <summary>
        /// User-loaded preferences, flushed to disk and reconstructed back into memory at runtime.
        /// </summary>
        public static Preferences? userPreferences { get; set; }

        /// <summary>
        /// Appwide sex toy server. Only one of these is needed.
        /// </summary>
        public static SextoyServerConnector? sextoyServer { get; set; }

        /// <summary>
        /// Internal chromium web browser used by the game view. Acts as a core for the entire app.
        /// </summary>
        public static ChromiumWebBrowser? cefSharpBrowser { get; set; }

        /// <summary>
        /// Audio output device handler for sound effects.
        /// </summary>
        public static WaveOutEvent sfxOutputDevice;

        /// <summary>
        /// Audio file reading/parsing device for sound effects.
        /// </summary>
        public static AudioFileReader sfxAudioFile;

        /// <summary>
        /// Audio output device handler for music.
        /// </summary>
        public static WaveOutEvent musicOutputDevice;

        /// <summary>
        /// Audio file reading/parsing device for sound effects.
        /// </summary>
        public static AudioFileReader musicAudioFile;

        /// <summary>
        /// Appwide serversided game API. This class gets exposed to JS and this appwide class is used for accessing those functions from C# if needed.
        /// </summary>
        public static WinLewdity_Hooks gameApi { get; } = new WinLewdity_Hooks();

        /// <summary>
        /// Appwide serversided game internally-managed API. This class gets exposed to JS and this appwide class is used for accessing those functions from C# if needed.
        /// </summary>
        public static WinLewdity_Hooks_Internal gameApiInternal { get; } = new WinLewdity_Hooks_Internal();

        /// <summary>
        /// Appwide current developer tools hooks provided by CefSharp. Changes whenever the page reloads/navigates.
        /// </summary>
        public static DevToolsClient gameDevClient { get; set; }

        /// <summary>
        /// A C# representation of the game's player character with accompanying stats.
        /// </summary>
        public static PlayerCharacter PlayerCharacter { get; set; }
    }
}