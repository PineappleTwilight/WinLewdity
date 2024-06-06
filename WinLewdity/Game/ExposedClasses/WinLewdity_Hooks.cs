using NAudio.Wave;
using WinLewdity.Events;
using WinLewdity.Internal;
using WinLewdity_GUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLewdity.Game.ExposedClasses
{
    /// <summary>
    /// Primary class exported to the JS DOM as an API that developers may use.
    /// </summary>
    public class WinLewdity_Hooks
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