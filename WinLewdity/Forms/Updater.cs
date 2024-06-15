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

namespace WinLewdity
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Attempts to update the game dynamically.
        /// </summary>
        public void UpdateGame()
        {
            updateButton.Enabled = false;
            startButton.Enabled = false;
            musicFolderButton.Enabled = false;
            logsFolderButton.Enabled = false;
            imagepackUpdaterButton.Enabled = false;

            AppLogger.LogDebug("Attempting to update the game...");

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                DateTime date = DateTime.Now;
                string buildVersionText = $"v{date.Day}.{date.Month}.{date.Year}";

                // Clone repository
                if (Directory.Exists("./source/.git"))
                {
                    AppLogger.LogDebug("Source folder found!");
                    using (Repository repository = new Repository("./source"))
                    {
                        AppLogger.LogDebug("Pulling latest commits from remote repository...");
                        MergeResult result = Commands.Pull(repository, new Signature(new Identity("John Doe", "anonymous@example.com"), DateTime.Now), new PullOptions());
                        if (result.Status == MergeStatus.UpToDate)
                        {
                            AppLogger.LogDebug("No new commits found in the remote repository!");
                            Invoke((Delegate)(() =>
                            {
                                MessageBox.Show("Game already up-to-date!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                updateButton.Enabled = true;
                                startButton.Enabled = true;
                                musicFolderButton.Enabled = true;
                                logsFolderButton.Enabled = true;
                                imagepackUpdaterButton.Enabled = true;
                            }));
                            return;
                        }
                        else
                        {
                            AppLogger.LogDebug("Local repository updated to commit: " + result.Commit.Id);
                        }
                    }
                }
                else
                {
                    AppLogger.LogWarning("Source directory not found! Source repository will now be cloned!");
                    Repository.Clone("https://gitgud.io/Andrest07/degrees-of-lewdity-plus.git", "./source");
                }

                // Remove old game files
                if (File.Exists("./game/index.html"))
                {
                    File.Delete("./game/index.html");
                }

                if (Directory.Exists("./game/img"))
                {
                    Directory.Delete("./game/img", true);
                }

                AppLogger.LogDebug("Modifying VERSION file...");

                // Back up version file, I really don't know what this does but we change it anyway
                File.Copy("./source/version", "./source/version.old");

                // Modify version file
                string versionText = File.ReadAllText("./source/version");

                File.WriteAllText("./source/version", versionText.Replace("version", buildVersionText));

                AppLogger.LogDebug("Starting game compilation...");

                // Run compile
                Process p = new Process();

                string batch_file_path = Path.GetFullPath("./source/compile.bat");

                // Scream at the commands to make them obey
                p.StartInfo.FileName = "cmd"; // <-- EXECUTABLE NAME
                p.StartInfo.Arguments = "/c \"" + batch_file_path + "\""; // <-- COMMAND TO BE RUN BY CMD '/k', and the content of the command "PATH"
                p.StartInfo.CreateNoWindow = true; // <-- CREATE NO WINDOW
                p.StartInfo.UseShellExecute = false; // <-- USE THE C# APPLICATION AS THE SHELL THROUGH WHICH THE PROCESS IS EXECUTED, NOT THE OS ITSELF
                p.Start(); // <-- START THE APPLICATION
                p.WaitForExit(); // <-- WAIT FOR APPLICATION TO FINISH

                AppLogger.LogDebug("Moving build artifacts to the game directory...");

                // Move newly generated executable to game folder
                File.Move("./source/Degrees of Lewdity VERSION.html", "./game/index.html");

                // Ensure graphic mods exist
                if (!Directory.Exists("./game/img"))
                {
                    Directory.CreateDirectory("./game/img");
                }

                AppLogger.LogDebug("Moving preferred image pack to game directory...");

                // Compile the image packs
                switch (Globals.userPreferences.preferredImagePack)
                {
                    case ImagePack.Vanilla:
                        WinFunctions.CopyFilesRecursively("./source/vanillaimg", "./game/img");
                        break;

                    case ImagePack.Bees:
                        WinFunctions.CopyFilesRecursively("./source/beeesssimg", "./game/img");
                        break;

                    case ImagePack.BeesHikari_Female:
                        WinFunctions.CopyFilesRecursively("./source/beeessshikarifemaleimg", "./game/img");
                        break;

                    case ImagePack.BeesHikari_Male:
                        WinFunctions.CopyFilesRecursively("./source/beeessshikarimaleimg", "./game/img");
                        break;

                    case ImagePack.BeesParilHairExtended:
                        WinFunctions.CopyFilesRecursively("./source/beeesssparilhairstyleextendedimg", "./game/img");
                        break;

                    case ImagePack.BeesWax:
                        WinFunctions.CopyFilesRecursively("./source/beeessswaximg", "./game/img");
                        break;

                    case ImagePack.BeesOkbd:
                        WinFunctions.CopyFilesRecursively("./source/beeesssokbdimg", "./game/img");
                        break;

                    case ImagePack.Lllysmasc:
                        WinFunctions.CopyFilesRecursively("./source/lllysmascimg", "./game/img");
                        break;

                    case ImagePack.Susato:
                        WinFunctions.CopyFilesRecursively("./source/susatoimg", "./game/img");
                        break;

                    case ImagePack.Mizz:
                        WinFunctions.CopyFilesRecursively("./source/mizzimg", "./game/img");
                        break;

                    case ImagePack.MVCR:
                        WinFunctions.CopyFilesRecursively("./source/mvcrimg", "./game/img");
                        break;
                }

                AppLogger.LogDebug("Cleaning up...");

                // Replace original version file
                File.Delete("./source/version");
                File.Move("./source/version.old", "./source/version");

                // Scan game files and replace DoLP versions
                string compiledHtml = File.ReadAllText("./game/index.html");
                File.WriteAllText("./game/index.html", compiledHtml.Replace("DoLP version", $"WinLewdity {buildVersionText}"));

                // Clean up
                Invoke((Delegate)(() =>
                {
                    MessageBox.Show("Update Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateButton.Enabled = true;
                    startButton.Enabled = true;
                    musicFolderButton.Enabled = true;
                    logsFolderButton.Enabled = true;
                    imagepackUpdaterButton.Enabled = true;
                }));
            }).Start();
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

            // Fancy update form title change
            if (!Globals.DebugMode)
            {
                this.Text = Globals.AppName + " Updater v" + Globals.AppVersion;
            }
            else
            {
                this.Text = Globals.AppName + " Updater v" + Globals.AppVersion + " (Debug Mode)";
            }

            // Create game folder
            if (!Directory.Exists("./game"))
            {
                Directory.CreateDirectory("./game");
            }

            // Create source folder
            if (!Directory.Exists("./source"))
            {
                Directory.CreateDirectory("./source");
            }

            // Create logs folder
            if (!Directory.Exists("./logs"))
            {
                Directory.CreateDirectory("./logs");
            }

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
                MasterSextoyServer sextoyServer = new MasterSextoyServer();
                Globals.sextoyServer = sextoyServer;
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
            UpdateGame();
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
            gameView.Show();
            this.Hide();
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
    }
}