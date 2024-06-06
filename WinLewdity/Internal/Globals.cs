﻿using CefSharp.DevTools;
using CefSharp.WinForms;
using NAudio.Wave;
using WinLewdity.Game.ExposedClasses;
using WinLewdity.Lovense;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace WinLewdity.Internal
{
    public static class Globals
    {
        // App
        public static readonly string AppName = "WinLewdity";

        public static readonly string AppVersion = "0.1.0";

        public static bool DebugMode = false;

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