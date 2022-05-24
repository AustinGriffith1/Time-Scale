﻿using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using UnityEngine;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SideLoader;

namespace TimeScaleHotkey
{
    /* ~~~ Initial Setup ~~~
     * 
     * 1. Double click on "Properties" in the Solution Explorer panel to the left
     * 2. Click on the "Application" tab
     * 3. Change your "Assembly Name" and "Default Namespace" to something unique for your mod.
     * 4. Right click the namespace "OutwardModTemplate" above and rename it to what you chose for your Namespace.
     * 5. Right click "MyMod" below and rename it, generally you use what you chose for your Assembly Name.
     * 6. Read the rest of the comments in this file and make changes as needed.
     */

    [BepInPlugin(GUID, NAME, VERSION)]
    public class TimeScaleHotkey : BaseUnityPlugin
    {
        // Choose a GUID for your project. Change "myname" and "mymod".
        public const string GUID = "chickensalad.TimeScaleHotkey";
        // Choose a NAME for your project, generally the same as your Assembly Name.
        public const string NAME = "TimeScaleHotkey";
        // Increment the VERSION when you release a new version of your mod.
        public const string VERSION = "1.0.0";

        // For accessing your BepInEx Logger from outside of this class (MyMod.Log)
        internal static ManualLogSource Log;

        // If you need settings, define them like so:
        public static ConfigEntry<bool> ExampleConfig;

        // Awake is called when your plugin is created. Use this to set up your mod.
        internal void Awake()
        {
            Log = this.Logger;
            Log.LogMessage($"Hello world from {NAME} {VERSION}!");

            // Any config settings you define should be set up like this:
            // ExampleConfig = Config.Bind("ExampleCategory", "ExampleSetting", false, "This is an example setting.");

            // Harmony is for patching methods. If you're not patching anything, you can comment-out or delete this line.
            //new Harmony(GUID).PatchAll();

            CustomKeybindings.AddAction("TimeScale*4", KeybindingsCategory.CustomKeybindings, ControlType.Both);
        }

        // Update is called once per frame. Use this only if needed.
        // You also have all other MonoBehaviour methods available (OnGUI, etc)
        internal void Update()
        {
            if (CustomKeybindings.GetKeyDown("TimeScale*4"))
            {
                if (Time.timeScale <= 1)
                    Time.timeScale = 4;
                else
                    Time.timeScale = 1;
            }
        }

        public class ResourcesPrefabManager_Load
        {
            static void Postfix()
            {
                // This is a "Postfix" (runs after original) on ResourcesPrefabManager.Load
                // For more documentation on Harmony, see the Harmony Wiki.
                // https://harmony.pardeike.net/
            }
        }
    }
}
