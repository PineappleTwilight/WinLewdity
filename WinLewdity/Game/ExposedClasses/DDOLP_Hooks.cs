using NAudio.Wave;
using SimpleHtmlViewer.Events;
using SimpleHtmlViewer.Internal;
using WinLewdity_GUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHtmlViewer.Game.ExposedClasses
{
    public class DDOLP_Hooks
    {
        /// <summary>
        /// Plays a bloop sound effect
        /// </summary>
        public void DoBloop()
        {
            if (Globals.userPreferences.enableSfx)
            {
                if (Globals.sfxOutputDevice.PlaybackState == PlaybackState.Playing)
                {
                    Globals.sfxOutputDevice.Stop();
                }
                Globals.sfxAudioFile = new AudioFileReader(Resources.bloopSfx);
                Globals.sfxAudioFile.CurrentTime = TimeSpan.Zero;
                Globals.sfxOutputDevice.Init(Globals.sfxAudioFile);
                Globals.sfxOutputDevice.Play();
                AppLogger.LogDebug("Bloop sfx triggered!");
            }
        }

        /// <summary>
        /// Triggers a scene change
        /// </summary>
        public void TriggerSceneChange()
        {
            GameEvents.SceneChanged(this, new StoryProgressedEventArgs());
        }
    }
}