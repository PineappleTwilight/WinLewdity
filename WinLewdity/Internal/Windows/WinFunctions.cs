using LibGit2Sharp;
using LibGit2Sharp.Handlers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Internal;

namespace WinLewdity_GUI.Internal.Windows
{
    /// <summary>
    /// Static class used to interact with the underlying Windows OS.
    /// </summary>
    public static class WinFunctions
    {
        /// <summary>
        /// Opens a URL in the user's default browser.
        /// </summary>
        /// <param name="url"></param>
        public static void OpenLinkInBrowser(string url)
        {
            Process.Start("explorer", url);
        }

        public static void OpenFileInNotepad(string filepath)
        {
            Process.Start("notepad.exe", Path.GetFullPath(filepath));
        }

        /// <summary>
        /// Executes a Windows command.
        /// </summary>
        /// <param name="command"></param>
        [Obsolete]
        public static void ExecuteCommand(string command)
        {
            AppLogger.LogInfo("Executing command \"" + command + "\"");

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
            // Warning: This approach can lead to deadlocks
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            AppLogger.LogDebug("output >>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            AppLogger.LogDebug("error >>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            AppLogger.LogDebug("ExitCode: " + exitCode.ToString());
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
        /// Fetches a remote git repository and syncs changes.
        /// </summary>
        /// <param name="repository"></param>
        public static void UpdateGitRepository(Repository repository)
        {
            var options = new FetchOptions();
            options.Prune = true;
            options.TagFetchMode = TagFetchMode.Auto;
            var remote = repository.Network.Remotes["origin"];
            var msg = "Fetching remote";
            var refSpecs = remote.FetchRefSpecs.Select(x => x.Specification);
            Commands.Fetch(repository, remote.Name, refSpecs, options, msg);
        }

        /// <summary>
        /// Checks whether an update is available. Returns null if the repo didn't exist and was freshly created.
        /// </summary>
        /// <returns></returns>
        public static bool? IsGameUpdateAvailable()
        {
            if (Directory.Exists("./source/.git"))
            {
                AppLogger.LogDebug("Source folder found!");
                using (Repository repository = new Repository("./source"))
                {
                    // Fetch the remote repository
                    UpdateGitRepository(repository);

                    // Check for changes
                    Branch masterBranch = repository.Branches["master"];
                    AppLogger.LogDebug($"Branch '{masterBranch}' ahead by " + masterBranch.TrackingDetails.AheadBy + " commit(s).");
                    AppLogger.LogDebug($"Branch '{masterBranch}' behind by " + masterBranch.TrackingDetails.BehindBy + " commit(s).");
                    if (masterBranch.TrackingDetails.BehindBy > 0)
                    {
                        return true;
                    }
                    else
                    {
                        AppLogger.LogDebug("Nothing to update! Local repository is synced with upstream!");
                        return false;
                    }
                }
            }
            else
            {
                AppLogger.LogWarning("Source directory not found! Can't check for updates! Will now clone repository.");
                Repository.Clone("https://gitgud.io/Andrest07/degrees-of-lewdity-plus.git", "./source");
                return null;
            }
        }

        /// <summary>
        /// Attempts to update the game dynamically. Must be run on a threadpool.
        /// </summary>
        public static void UpdateGame()
        {
            AppLogger.LogDebug("Attempting to update the game...");

            // Fetch current date and formulate versioning string
            DateTime date = DateTime.Now;
            string buildVersionText = $"v{date.Day}.{date.Month}.{date.Year}";

            using (Repository repo = new Repository("./source"))
            {
                Commands.Pull(repo, new Signature(new Identity("John Doe", "anonymous@example.com"), DateTime.Now), new PullOptions()); // Dummy credentials
            }

            // Continue execution if update check returns NULL or true, aka new files.

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
            p.StartInfo.Arguments = "/c \"" + batch_file_path + "\""; // <-- COMMAND TO BE RUN BY CMD '/c', and the content of the command "PATH"
            p.StartInfo.CreateNoWindow = true; // <-- CREATE NO WINDOW
            p.StartInfo.UseShellExecute = false; // <-- USE THE C# APPLICATION AS THE SHELL THROUGH WHICH THE PROCESS IS EXECUTED, NOT THE OS ITSELF
            p.Start(); // <-- START THE APPLICATION
            p.WaitForExit(); // <-- WAIT FOR APPLICATION TO FINISH

            AppLogger.LogDebug("Moving build artifacts to the game directory...");

            // Move newly generated executable to game folder
            File.Move("./source/Degrees of Lewdity VERSION.html", "./game/index.html");

            // Hardpatch executable for link replacements, etc
            string gameHtml = File.ReadAllText("./game/index.html");
            gameHtml = gameHtml.Replace("discord.gg/mGpRSn9qMF", "discord.gg/GX7sjmdRMQ"); // Replace modding server discord with mine lmao
            gameHtml = gameHtml.Replace("https://discord.gg/mGpRSn9qMF", "https://discord.gg/GX7sjmdRMQ");
            File.WriteAllText("./game/index.html", gameHtml);

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
        }
    }
}