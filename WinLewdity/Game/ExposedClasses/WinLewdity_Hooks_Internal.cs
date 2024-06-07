using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinLewdity.Events;
using WinLewdity.Game;
using WinLewdity.Internal;

namespace WinLewdity_GUI.Game.ExposedClasses
{
    public class WinLewdity_Hooks_Internal
    {
        /// <summary>
        /// Event fired from the JS DOM whenever an element is clicked. This is handled by the backend and mod developers should not use this
        /// </summary>
        /// <param name="tagName"></param>
        /// <param name="classList"></param>
        public void ElementClicked(string tagName, string classList)
        {
            AppLogger.LogDebug($"Element \"{tagName}\" clicked with classes \"{classList}\"");

            // Divs may or may not change page content, do further scanning with classes & events
            if (tagName == "DIV")
            {
                // Linkified divs
                if (classList.Contains("div-link"))
                {
                    Globals.gameApi.DoBloop();
                }

                // Clothing shop div stuff
                if (classList.Contains("clothing-body") || classList.Contains("clothing-integrity") || classList.Contains("clothing-reveal") || classList.Contains("clothing-warmth") || classList.Contains("clothing-traits") || classList.Contains("clothing-icon"))
                {
                    Globals.gameApi.DoBloop();
                }
            }

            // Page content MIGHT not change here, handle accordingly
            if (tagName == "BUTTON")
            {
                Globals.gameApi.DoBloop();
            }

            // Page content always changes here
            if (tagName == "A")
            {
                Globals.gameApi.DoBloop();
            }
        }

        /// <summary>
        /// Triggers a scene change
        /// </summary>
        public void TriggerSceneChange()
        {
            GameEvents.SceneChanged(this, new StoryProgressedEventArgs());
        }

        // Triggers a child addition event
        public void ChildAdded(string elementId, string tagName, string classList)
        {
            if (tagName == "DIV" && classList.Contains("passage"))
            {
                AppLogger.LogDebug("Scene change was detected! New scene: " + elementId);
                TriggerSceneChange();
            }
        }
    }
}