using BepInEx;
using System;
using System.Collections;
using UnityEngine;
using Utilla;

namespace DelayQuit
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Start()
        {
            Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            StartCoroutine(QuitAfterDelay());
        }

        IEnumerator QuitAfterDelay()
        {
            yield return new WaitForSeconds(10);
            Application.Quit();
        }

    }
}
