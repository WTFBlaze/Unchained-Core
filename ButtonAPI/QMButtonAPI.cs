using System.Collections.Generic;
using UnityEngine;

namespace VRCMGU.API
{
    //Credits:
    //Emilia - Porting it to MelonLoader and helping to keep the git updated
    //Tritn - Helping to keep the git updated

    //This adds a couple of new functions compared to the old one, however,
    //like the last one, I will not be providing any support as I will
    //personally not be using melonloader/unhollower in the near future.

    //Look here for a useful example guide:
    //https://github.com/DubyaDude/RubyButtonAPI/blob/master/RubyButtonAPI_Old.cs

    //Blaze's Notes:
    //This is just my edited version of RubyButtonAPI for usage for VRCMG Unchained Core & Other VRCMGU Mods!
    //I am okay with other mods using my button api edit however I want to be credited in the github repo or somewhere in the mod itself.

    public static class QMButtonAPI
    {
        //REPLACE THIS STRING SO YOUR MENU DOESNT COLLIDE WITH OTHER MENUS
        public static string identifier = "UNCHAINED";
        public static Color mBackground = Color.red;
        public static Color mForeground = Color.white;
        public static Color bBackground = Color.red;
        public static Color bForeground = Color.yellow;
        public static List<QMSingleButton> allSingleButtons = new List<QMSingleButton>();
        public static List<QMToggleButton> allToggleButtons = new List<QMToggleButton>();
        public static List<QMNestedButton> allNestedButtons = new List<QMNestedButton>();
    }
}