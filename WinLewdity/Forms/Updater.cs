using LibGit2Sharp;
using ProtoBuf;
using SimpleHtmlViewer.Internal;
using SimpleHtmlViewer.Lovense;
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

namespace SimpleHtmlViewer
{
    public partial class Updater : Form
    {
        public Updater()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Executes a Windows command.
        /// </summary>
        /// <param name="command"></param>
        private static void ExecuteCommand(string command)
        {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            // Warning: This approach can lead to deadlocks, see Edit #2
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
        }

        /// <summary>
        /// Copies all files from a source directory to a target directory. Includes descendants.
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            // Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            // Copy the files & replace any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        /// <summary>
        /// Attempts to update the game dynamically.
        /// </summary>
        public void UpdateGame()
        {
            updateButton.Enabled = false;
            startButton.Enabled = false;
            musicFolderButton.Enabled = false;

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
                            Invoke(() =>
                            {
                                MessageBox.Show("Game already up-to-date!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                updateButton.Enabled = true;
                                startButton.Enabled = true;
                                musicFolderButton.Enabled = true;
                            });
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
                        CopyFilesRecursively("./source/vanillaimg", "./game/img");
                        break;

                    case ImagePack.Bees:
                        CopyFilesRecursively("./source/beeesssimg", "./game/img");
                        break;

                    case ImagePack.BeesHikari_Female:
                        CopyFilesRecursively("./source/beeessshikarifemaleimg", "./game/img");
                        break;

                    case ImagePack.BeesHikari_Male:
                        CopyFilesRecursively("./source/beeessshikarimaleimg", "./game/img");
                        break;

                    case ImagePack.BeesParilHairExtended:
                        CopyFilesRecursively("./source/beeesssparilhairstyleextendedimg", "./game/img");
                        break;

                    case ImagePack.BeesWax:
                        CopyFilesRecursively("./source/beeessswaximg", "./game/img");
                        break;

                    case ImagePack.BeesOkbd:
                        CopyFilesRecursively("./source/beeesssokbdimg", "./game/img");
                        break;

                    case ImagePack.Lllysmasc:
                        CopyFilesRecursively("./source/lllysmascimg", "./game/img");
                        break;

                    case ImagePack.Susato:
                        CopyFilesRecursively("./source/susatoimg", "./game/img");
                        break;

                    case ImagePack.Mizz:
                        CopyFilesRecursively("./source/mizzimg", "./game/img");
                        break;

                    case ImagePack.MVCR:
                        Updater.CopyFilesRecursively("./source/mvcrimg", "./game/img");
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
                Invoke(() =>
                {
                    MessageBox.Show("Update Complete!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    updateButton.Enabled = true;
                    startButton.Enabled = true;
                    musicFolderButton.Enabled = true;
                });
            }).Start();
        }

        /// <summary>
        /// Form load event.
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

        private void emptyInfoLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://developer.microsoft.com/en-us/microsoft-edge/webview2/?form=MA13LH#download", UseShellExecute = true });
        }

        private void Updater_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppLogger.LogDebug("Flushing preferences back to disk...");
            using (var file = File.Create("./Assets/cfg/prefs.frot"))
            {
                Serializer.Serialize(file, Globals.userPreferences);
            }
        }

        private void musicFolderButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetFullPath("./Assets/music"),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        private void openLogsButton_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                Arguments = Path.GetFullPath("./logs"),
                FileName = "explorer.exe"
            };
            Process.Start(startInfo);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo { FileName = "https://github.com/intiface/intiface-central/releases/latest/", UseShellExecute = true });
        }
    }
}