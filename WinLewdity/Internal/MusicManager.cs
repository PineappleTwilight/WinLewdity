using NAudio.Wave;
using WinLewdity.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity.Internal
{
    public static class MusicManager
    {
        /// <summary>
        /// Selects a random song from a folder.
        /// </summary>
        /// <param name="path"></param>
        public static void PlayRandomSong(string path)
        {
            if (Globals.userPreferences.enableMusic)
            {
                Random rng = new Random();
                AppLogger.LogDebug("Shuffling music from " + path);
                Globals.musicOutputDevice?.Stop();
                string[] musicSamples = Directory.GetFiles(path);
                string chosenMusicPath = musicSamples[rng.Next(0, musicSamples.Length)];
                Globals.musicAudioFile = new AudioFileReader(chosenMusicPath);
                Globals.musicOutputDevice?.Init(Globals.musicAudioFile);
                Globals.musicAudioFile.Position = 0;
                Globals.musicOutputDevice?.Play();
            }
        }

        /// <summary>
        /// Adjusts the global music playback volume.
        /// </summary>
        /// <param name="value"></param>
        public static void AdjustMusicAudio(float value)
        {
            if (value > 1.0f)
            {
                Globals.musicOutputDevice.Volume = 1.0f;
            }
            else if (value < 0.0f)
            {
                Globals.musicOutputDevice.Volume = 0.0f;
            }
            else
            {
                Globals.musicOutputDevice.Volume = value;
            }
        }

        /// <summary>
        /// Shuffles the song playlist
        /// </summary>
        public static void ShuffleCurrentQueue()
        {
            if (GameValues.InCombat)
            {
                if (GameValues.InConsensualSex)
                {
                    PlayRandomSong("./Assets/music/combat_consensual"); // Loop random consensual sex songs
                }
                else
                {
                    PlayRandomSong("./Assets/music/combat"); // Loop random combat songs
                }
            }
            else
            {
                PlayRandomSong("./Assets/music/background"); // Loop background music
            }
        }
    }
}