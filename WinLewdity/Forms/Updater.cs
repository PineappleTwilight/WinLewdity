using LibGit2Sharp;
using ProtoBuf;
using WinLewdity.Internal;
using WinLewdity.Lovense;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLewdity.Forms;
using CefSharp.DevTools.CSS;
using EnumsNET;
using WinLewdity_GUI.Internal.Windows;
using ABI.System;
using ReaLTaiizor.Forms;
using ReaLTaiizor.Manager;
using ReaLTaiizor.Colors;
using CefSharp.WinForms;

namespace WinLewdity
{
    public partial class Updater : MaterialForm
    {
        /// <summary>
        /// Stupid skin manager class.
        /// </summary>
        private MaterialSkinManager MaterialSkinManager { get; } = MaterialSkinManager.Instance;

        /// <summary>
        /// Constructor
        /// </summary>
        public Updater()
        {
            InitializeComponent();

            // Set this to false to disable backcolor enforcing on non-materialSkin components
            // This HAS to be set before the AddFormToManage()
            MaterialSkinManager.EnforceBackcolorOnAllComponents = true;

            // MaterialSkinManager properties
            MaterialSkinManager.AddFormToManage(this);
            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;

            // Init colorscheme
            Color richPurpleBase = (Color)new ColorConverter().ConvertFromString("#792187"); // 33% opacity
            Color richPurpleDark = (Color)new ColorConverter().ConvertFromString("#5c1967"); // 2 Steps Down From Base
            Color richPurpleLight = (Color)new ColorConverter().ConvertFromString("#9428a4"); // 2 Steps Up From Base
            Color richPurpleAccent = (Color)new ColorConverter().ConvertFromString("#c75bd7"); // 60% opacity

            //materialSkinManager.ColorScheme = new MaterialColorScheme(0x00C926b3, 0xA1008B, 0xDC2EFF, 0x006E70FF, MaterialTextShade.LIGHT);
            //materialSkinManager.ColorScheme = new MaterialColorScheme("#00480157", "#370142", "DC2EFF", "00BB5FCF", MaterialTextShade.LIGHT);
            //materialSkinManager.ColorScheme = new MaterialColorScheme(Color.Orange, Color.DarkOrange, Color.Orchid, Color.OrangeRed, Color.MediumOrchid);
            // https://m2.material.io/design/color/the-color-system.html#tools-for-picking-colors
            MaterialColorScheme materialColorScheme = new(richPurpleBase, richPurpleDark, richPurpleLight, richPurpleAccent, ReaLTaiizor.Util.MaterialTextShade.WHITESMOKE);
            MaterialSkinManager.ColorScheme = materialColorScheme;
        }

        /// <summary>
        /// Disables UI buttons.
        /// </summary>
        private void DisableButtons()
        {
            this.ActiveControl = null;
            updateButton.Enabled = false;
            startButton.Enabled = false;
            musicFolderButton.Enabled = false;
            logsFolderButton.Enabled = false;
            imagepackUpdaterButton.Enabled = false;
            openCefLogsButton.Enabled = false;
            if (Globals.DebugMode)
            {
                // Debug only buttons
                forceRecompileButton.Enabled = false;
            }
        }

        /// <summary>
        /// Enables UI buttons.
        /// </summary>
        private void EnableButtons()
        {
            updateButton.Enabled = true;
            startButton.Enabled = true;
            musicFolderButton.Enabled = true;
            logsFolderButton.Enabled = true;
            imagepackUpdaterButton.Enabled = true;
            openCefLogsButton.Enabled = true;
            if (Globals.DebugMode)
            {
                // Debug only buttons
                forceRecompileButton.Enabled = true;
            }
        }

        /// <summary>
        /// Code run when the application is done loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Updater_Load(object sender, EventArgs e)
        {
            // Check if we are debugging
            if (File.Exists("./.debug"))
            {
                Globals.DebugMode = true;
            }

            // Init logging service
            AppLogger.InitializeLogger();

            // Fancy debug mode changes
            if (Globals.DebugMode)
            {
                this.Text = Globals.AppName + " Updater v" + Globals.AppVersion + " (Debug Mode)";
                this.forceRecompileButton.Enabled = true;
            }
            else
            {
                this.Text = Globals.AppName + " Updater v" + Globals.AppVersion;
            }

            // Create folders on a separate thread
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                // Create game folder
                if (!Directory.Exists("./game"))
                {
                    Directory.CreateDirectory("./game");
                }
            }));

            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                // Create source folder
                if (!Directory.Exists("./source"))
                {
                    Directory.CreateDirectory("./source");
                }
            }));

            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                // Create source folder
                if (!Directory.Exists("./browsercache"))
                {
                    Directory.CreateDirectory("./browsercache");
                }
            }));

            // Create logs folder on this thread
            if (!Directory.Exists("./logs"))
            {
                Directory.CreateDirectory("./logs");
            }

            AppLogger.LogDebug("--------------------------------------------------");
            AppLogger.LogInfo("Starting app...");

            // Check for existing user preferences
            if (File.Exists("./Assets/cfg/prefs.frot"))
            {
                AppLogger.LogDebug("Preferences found! They will be loaded instead of initializing new ones!");
                using (var file = File.OpenRead("./Assets/cfg/prefs.frot"))
                {
                    Globals.userPreferences = Serializer.Deserialize<Preferences>(file);
                }
            }
            else
            {
                AppLogger.LogDebug("This appears to be a first run, so a new preferences instance has been created!");

                // Create new preferences
                Globals.userPreferences = new Preferences();
                Globals.userPreferences.preferredImagePack = ImagePack.Vanilla;
                Globals.userPreferences.enableMusic = true;
                Globals.userPreferences.enableSfx = true;
                Globals.userPreferences.enableSexToys = true;
                Globals.userPreferences.globalVolume = 0.5f;
            }

            // Init sex toy server
            if (Globals.userPreferences.enableSexToys)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
                {
                    SextoyServerConnector sextoyServer = new SextoyServerConnector();
                    Globals.sextoyServer = sextoyServer;
                }));
            }

            // Populate ImagePack label
            string description = Globals.userPreferences.preferredImagePack.AsString(EnumFormat.Description);
            imagepackResultLabel.Text = description;
        }

        /// <summary>
        /// Update button click handler.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                Invoke(DisableButtons);
                bool? UpdateNeeded = WinFunctions.IsGameUpdateAvailable();
                if (UpdateNeeded == true || UpdateNeeded == null)
                {
                    // AutoResetEvent waitHandle = new AutoResetEvent(false);
                    // ThreadPool.QueueUserWorkItem(new WaitCallback(WinFunctions.UpdateGame), waitHandle);
                    // waitHandle.WaitOne(); // Wait for our thread to stop executing
                    WinFunctions.UpdateGame();
                    MessageBox.Show("Updates successfully installed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (UpdateNeeded == false)
                {
                    MessageBox.Show("Game is already up-to-date!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Invoke(EnableButtons);
            }));
        }

        /// <summary>
        /// Disables the arrow keys for input handlers. Pretty much does nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisableArrowKeys(object sender, PreviewKeyDownEventArgs e)
        {
            var keys = new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down };
            if (keys.Contains(e.KeyData))
                e.IsInputKey = true;
        }

        /// <summary>
        /// Exits this form and initializes the game view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startButton_Click(object sender, EventArgs e)
        {
            if (!File.Exists("./game/index.html"))
            {
                MessageBox.Show("Hey! It looks like this is your first time using the app! Please run the updater to install the game before clicking this button!", "Game Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            GameView gameView = new GameView(this);
            Invoke(() => gameView.Show());
            Invoke(() => this.Hide());
        }

        /// <summary>
        /// Code run when the application is exiting.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppLogger.LogDebug("Flushing preferences back to disk...");
            using (var file = File.Create("./Assets/cfg/prefs.frot"))
            {
                Serializer.Serialize(file, Globals.userPreferences);
            }
        }

        /// <summary>
        /// Opens the music storage folder in windows explorer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void musicFolderButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetFullPath("./Assets/music"),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        /// <summary>
        /// Opens the logs folder in windows explorer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openLogsButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetFullPath("./logs"),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        /// <summary>
        /// Handle the opening of the spritepack switcher & wait for exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imagepackUpdaterButton_Click(object sender, EventArgs e)
        {
            ImagepackSwitcher switcherForm = new ImagepackSwitcher(null);
            switcherForm.ShowDialog();
            string description = Globals.userPreferences.preferredImagePack.AsString(EnumFormat.Description);
            imagepackResultLabel.Text = description;
        }

        /// <summary>
        /// Disables weird button effects looking off. Also disables accessibility, may want to rework this.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PreventButtonFocus(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void imagepackResultLabel_Click(object sender, EventArgs e)
        {
        }

        private void discordLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFunctions.OpenLinkInBrowser(Globals.DiscordInvite.AbsoluteUri);
        }

        private void linkLabelEdit1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFunctions.OpenLinkInBrowser(Globals.GithubLink.AbsoluteUri);
        }

        private void trelloLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            WinFunctions.OpenLinkInBrowser(Globals.TrelloLink.AbsoluteUri);
        }

        private void openCefLogsButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                WinFunctions.OpenFileInNotepad("./debug.log");
            }));
        }

        private void forceRecompileButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(delegate
            {
                Invoke(DisableButtons);
                WinFunctions.UpdateGame();
                Invoke(EnableButtons);
            }));
        }
    }
}