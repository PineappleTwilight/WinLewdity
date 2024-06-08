using CefSharp;
using CefSharp.DevTools.DOM;
using CefSharp.Internals;
using CefSharp.JavascriptBinding;
using CefSharp.WinForms;
using DiscordRPC;
using DiscordRPC.Logging;
using NAudio.Wave;
using WinLewdity.Events;
using WinLewdity.Forms;
using WinLewdity.Game;
using WinLewdity.Game.ExposedClasses;
using WinLewdity.Internal;
using System.Media;
using System.Reflection;
using System.Windows.Media;
using static System.Windows.Forms.LinkLabel;
using Console = System.Console;
using File = System.IO.File;
using WinLewdity_GUI.Game.ExposedClasses;

namespace WinLewdity
{
    public partial class GameView : Form
    {
        // Internal
        private Assembly mainAssembly = Assembly.GetExecutingAssembly();

        // Variables
        private Random rng = new Random();

        public DiscordRpcClient client;

        public Updater parentUpdateForm;
        private CancellationTokenSource childrenMonitorCancel;

        private DateTime startTime = DateTime.Now;

        private bool saveOverlayVisible = false;

        // RPC stuff
        private RichPresence locationRP = new RichPresence()
        {
            Assets = new Assets()
            {
                LargeImageKey = "gamelogo",
                LargeImageText = "Degrees of Lewdity Plus Bleeding Edge",
            },
        };

        /// <summary>
        /// Updates an existing RPC connection to Discord.
        /// </summary>
        /// <param name="message"></param>
        public async void UpdateRPC(string message)
        {
            await Task.Run(() =>
            {
                RichPresence richPresence = locationRP.Clone();
                if (GameValues.Money != null && GameValues.Time != null)
                {
                    richPresence.State = $"Money: £{GameValues.Money / 100} || Time: {GameValues.Time}";
                }
                richPresence.Timestamps = new Timestamps { Start = startTime.ToUniversalTime() };
                if (GameValues.DayOfWeek != null)
                {
                    richPresence.Details = GameValues.DayOfWeek + ": " + message;
                }
                else
                {
                    richPresence.Details = message;
                }
                client.SetPresence(richPresence);
            });
        }

        /// <summary>
        /// Form Constructor
        /// </summary>
        /// <param name="parentUpdater"></param>
        public GameView(Updater parentUpdater)
        {
            parentUpdateForm = parentUpdater;
            InitializeComponent();

            // Init cefsharp settings
            CefSettings cefSettingsBase = new CefSettings();
            Cef.Initialize(cefSettingsBase);

            // Hook up events
            gameBrowser.LoadingStateChanged += GameBrowser_LoadingStateChanged;

            // Bind functions
            gameBrowser.JavascriptObjectRepository.ResolveObject += (sender, e) =>
            {
                var repo = e.ObjectRepository;
                if (repo.NameConverter == null)
                {
                    CamelCaseJavascriptNameConverter camelConvert = new CamelCaseJavascriptNameConverter();
                    repo.NameConverter = camelConvert; // Convert method names to camelCase
                }

                if (e.ObjectName == Globals.AppName.ToLower())
                {
                    BindingOptions bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects
                    repo.Register(Globals.AppName.ToLower(), new WinLewdity_Hooks(), options: bindingOptions);
                }

                if (e.ObjectName == Globals.AppName.ToLower() + "_internal")
                {
                    BindingOptions bindingOptions = BindingOptions.DefaultBinder; //Use the default binder to serialize values into complex objects
                    repo.Register(Globals.AppName.ToLower() + "_internal", new WinLewdity_Hooks_Internal(), options: bindingOptions);
                }
            };

            // Log bound functions
            gameBrowser.JavascriptObjectRepository.ObjectBoundInJavascript += (sender, e) =>
            {
                var name = e.ObjectName;

                AppLogger.LogDebug($"Object \"{e.ObjectName}\" was bound to the javascript DOM successfully!");
            };

            // Hook JS events
            gameBrowser.FrameLoadEnd += GameBrowser_FrameLoadEnd;
            gameBrowser.JavascriptMessageReceived += GameBrowser_JavascriptMessageReceived;

            // Do music stuff
            string[] musicSamples = Directory.GetFiles("./Assets/music/background");
            string chosenMusicPath = musicSamples[rng.Next(0, musicSamples.Length)];

            // Initiate music output device
            if (Globals.musicOutputDevice == null)
            {
                Globals.musicOutputDevice = new WaveOutEvent();
                Globals.musicOutputDevice.PlaybackStopped += OnPlaybackStopped;
                Globals.musicOutputDevice.Volume = Globals.userPreferences.globalVolume;
            }

            // Initiate sfx output device
            if (Globals.sfxOutputDevice == null)
            {
                Globals.sfxOutputDevice = new WaveOutEvent();
                Globals.sfxOutputDevice.Volume = Globals.userPreferences.globalVolume;
            }

            // Initiate music audio file
            if (Globals.musicAudioFile == null)
            {
                Globals.musicAudioFile = new AudioFileReader(chosenMusicPath);
                Globals.musicOutputDevice.Init(Globals.musicAudioFile);
            }

            // Do discord stuff
            client = new DiscordRpcClient("1234692318091673671");
            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };
            client.Initialize();
        }

        /// <summary>
        /// GameView Form Loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Main_Load(object sender, EventArgs e)
        {
            // Enable debug mode title
            if (Globals.DebugMode)
            {
                this.Text = this.Text + " (Debug Mode)";
            }

            // Load preferences to log file
            AppLogger.LogDebug("Current Preferences:");
            AppLogger.LogDebug("Current Image Pack: " + Globals.userPreferences.preferredImagePack.ToString());
            AppLogger.LogDebug("Enable SFX: " + Globals.userPreferences.enableSfx);
            AppLogger.LogDebug("Enable Music: " + Globals.userPreferences.enableMusic);
            AppLogger.LogDebug("Global Volume: " + Globals.userPreferences.globalVolume);

            // Fill browser class
            Globals.cefSharpBrowser = gameBrowser;

            // Update buttons
            toggleSfxButton.Checked = Globals.userPreferences.enableSfx;
            toggleMusicButton.Checked = Globals.userPreferences.enableMusic;

            // Listen to events
            GameEvents.CombatEntered += GameEvents_CombatEntered;
            GameEvents.CombatEnded += GameEvents_CombatEnded;

            // Set music sliders
            globalVolumeSlider.Volume = Globals.userPreferences.globalVolume;

            // Load game
            if (gameBrowser != null)
            {
                /*
                while (!gameBrowser.IsBrowserInitialized)
                {
                    continue;
                }
                */
                if (File.Exists("./game/index.html"))
                {
                    gameBrowser.LoadUrl("file:///" + Path.GetFullPath("./game/index.html"));
                }
            }

            // Listen for story changes
            GameEvents.StoryProgressed += GameView_StoryProgressed;
        }

        /// <summary>
        /// Allows a TCP-like connection between the DOM and .NET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBrowser_JavascriptMessageReceived(object? sender, JavascriptMessageReceivedEventArgs e)
        {
            // Fetch over sent string
            var recievedString = (string)e.Message;

            /*
            if (requestedFunction == "doBloop")
            {
                Globals.gameApi.DoBloop();
            }
            */
        }

        /// <summary>
        /// Bleeding-edge event for when the URL is finished loading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GameBrowser_FrameLoadEnd(object? sender, FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
            }
        }

        private void DOM_DocumentUpdated(object? sender, EventArgs e)
        {
            AppLogger.LogDebug("Node IDs invalidated! This is bad!");
        }

        /// <summary>
        /// Called whenever the page begins or stops loading content.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameBrowser_LoadingStateChanged(object? sender, LoadingStateChangedEventArgs e)
        {
            if (e.IsLoading == false)
            {
                // Run code when game is loaded here

                // Play background music
                if (Globals.userPreferences.enableMusic)
                {
                    Globals.musicOutputDevice.Play();
                }

                // Dispose previous instance (if it even exists)
                if (JavascriptUtils.DevTools != null)
                {
                    JavascriptUtils.DevTools.Dispose();
                }

                // Inject JS binder
                JavascriptUtils.ExecuteJavascriptAsync($"await CefSharp.BindObjectAsync(\"{Globals.AppName.ToLower()}\");");
                JavascriptUtils.ExecuteJavascriptAsync($"await CefSharp.BindObjectAsync(\"{Globals.AppName.ToLower() + "_internal"}\");");

                // Create devtools
                JavascriptUtils.DevTools = gameBrowser.GetDevToolsClient();

                // Hook events
                JavascriptUtils.DevTools.DOM.DocumentUpdated += DOM_DocumentUpdated;

                // Load custom JS functions
                if (File.Exists("./Javascript/functions.js"))
                {
                    string jsCode = File.ReadAllText("./Javascript/functions.js");
                    gameBrowser.ExecuteScriptAsync(jsCode);
                }

                // Load custom JS events
                if (File.Exists("./Javascript/events.js"))
                {
                    string jsCode = File.ReadAllText("./Javascript/events.js");
                    gameBrowser.ExecuteScriptAsync(jsCode);
                }

                // Init player class
                Globals.PlayerCharacter = new WinLewdity_GUI.Game.Player.PlayerCharacter();
            }
        }

        /// <summary>
        /// User left combat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameEvents_CombatEnded(object sender, EventArgs e)
        {
            MusicManager.PlayRandomSong("./Assets/music/background"); // Return to background music after combat
        }

        /// <summary>
        /// User entered combat (or consensual sexy time)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameEvents_CombatEntered(object sender, CombatEnteredEventArgs e)
        {
            if (e.Consensual)
            {
                MusicManager.PlayRandomSong("./Assets/music/combat_consensual"); // Consensual Sex
            }
            else
            {
                MusicManager.PlayRandomSong("./Assets/music/combat"); // Assault & Rape
            }
        }

        /// <summary>
        /// Background music ended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            // Prevent excessive looping by seeing if the file finished before looping
            if (Globals.musicAudioFile.Position != Globals.musicAudioFile.Length)
            {
                return;
            }

            MusicManager.ShuffleCurrentQueue();
        }

        /// <summary>
        /// Fired whenever the story moves forward (or backward).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void GameView_StoryProgressed(object sender, StoryProgressedEventArgs e)
        {
            AppLogger.LogDebug("Current Pain: " + Globals.PlayerCharacter.EmotionalStats.Pain);
            AppLogger.LogDebug("Current Arousal: " + Globals.PlayerCharacter.EmotionalStats.Arousal);
            AppLogger.LogDebug("Current Fatigue: " + Globals.PlayerCharacter.EmotionalStats.Fatigue);
            AppLogger.LogDebug("Current Stress: " + Globals.PlayerCharacter.EmotionalStats.Stress);
            AppLogger.LogDebug("Current Trauma: " + Globals.PlayerCharacter.EmotionalStats.Trauma);
            AppLogger.LogDebug("Current Control: " + Globals.PlayerCharacter.EmotionalStats.Control);
            AppLogger.LogDebug("Current Allure: " + Globals.PlayerCharacter.EmotionalStats.Allure);

            // Fetch values for the current scene
            bool inCombat = await GameFunctions.InCombat();

            // Handle money changing event
            if (GameValues.Money != null)
            {
                int currentMoney = await GameFunctions.GetMoney();
                if (currentMoney != GameValues.Money)
                {
                    MoneyChangedEventArgs args = new MoneyChangedEventArgs();
                    args.newMoneyValue = currentMoney;
                    args.oldMoneyValue = (int)GameValues.Money;
                    GameEvents.WealthChanged(this, args);
                }
            }

            // Handle combat
            if (GameValues.InCombat)
            {
                if (inCombat == false)
                {
                    // User was in combat but has left
                    GameEvents.CombatStopped(this, new EventArgs());
                }
            }
            else
            {
                if (inCombat)
                {
                    // User was not in combat but now is
                    CombatEnteredEventArgs args = new CombatEnteredEventArgs();
                    args.Consensual = await GameFunctions.IsSceneConsensual();
                    GameEvents.CombatStarted(this, args);
                }
            }
            // Determine player location, i'm not yandere dev I swear, these are valid if statements. THIS SHOULD BE LAST!
        }

        /// <summary>
        /// Code run on application exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose resources
            // childrenMonitorCancel.Cancel();
            gameBrowser.Dispose();
            client.Dispose();
            parentUpdateForm.Close();
        }

        #region UI Controls

        private void toggleMusicButton_CheckedChanged(object sender, EventArgs e)
        {
            Globals.userPreferences.enableMusic = toggleMusicButton.Checked;

            if (Globals.userPreferences.enableMusic)
            {
                Globals.musicOutputDevice?.Play();
            }
            else
            {
                Globals.musicOutputDevice?.Stop();
            }
        }

        private void toggleSfxButton_CheckedChanged(object sender, EventArgs e)
        {
            Globals.userPreferences.enableSfx = toggleSfxButton.Checked;
        }

        private void showHideSettingsBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topPanel.Visible = !topPanel.Visible;
        }

        private void globalVolumeSlider_VolumeChanged(object sender, EventArgs e)
        {
            Globals.userPreferences.globalVolume = globalVolumeSlider.Volume;
            Globals.musicOutputDevice.Volume = globalVolumeSlider.Volume;
            Globals.sfxOutputDevice.Volume = globalVolumeSlider.Volume;
        }

        private void skipSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicManager.ShuffleCurrentQueue();
        }

        private void changeImgButton_Click(object sender, EventArgs e)
        {
            ImagepackSwitcher switcherForm = new ImagepackSwitcher(this);
            switcherForm.Show();
        }

        #endregion UI Controls
    }

    public static class GameViewExtensions
    {
        /// <summary>
        /// Stinky hack but I can't be bothered to code something better
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static async Task ForEachAsync<T>(this List<T> list, Func<T, Task> func)
        {
            foreach (var value in list)
            {
                await func(value);
            }
        }
    }
}