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
    }
}