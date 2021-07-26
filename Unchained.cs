using MelonLoader;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRCMGU.API;

[assembly: MelonInfo(typeof(VRCMGU.Unchained), "Unchained-Core", "1.0.1")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace VRCMGU
{
    public class Unchained : MelonMod
    {
        private class VersionApi
        {
            public string Version { get; set; }
            public string LoaderVersion { get; set; }
            public string DownloadURL { get; set; }
        }

        private string Version = "1.0.1";
        public static QMNestedButton UnchainedMenu;
        public static QMScrollMenu UnchainedScroll;
        public static AssetBundle UnchainedBundle;
        public static Sprite UnchainedLogo;
        public static List<UnchainedItem> AllModMenus = new List<UnchainedItem>();
        MelonPreferences_Category category;
        MelonPreferences_Entry<float> ButtonX;
        MelonPreferences_Entry<float> ButtonY;

        public override void OnApplicationStart()
        {
            using (WebClient wc = new WebClient())
            {
                var obj = JsonConvert.DeserializeObject<VersionApi>(wc.DownloadString("https://wtfblaze.com/ModInfo/Unchained-Core.json"));

                if (obj.Version == Version)
                {
                    MelonLogger.Msg(ConsoleColor.Green, "You are running the latest version of Unchained Core!");
                }
                else
                {
                    MelonLogger.Msg(ConsoleColor.Yellow, $"You are running an outdated version of Unchained Core! Latest Version: {obj.Version} | Your Version: {Version}. You can download the latest version from the Unchained Discord! discord.gg/boycottknah");
                }
            }
            MelonLogger.Msg("Starting Unchained Core...");
            category = MelonPreferences.CreateCategory("Unchained Core", "Unchained Core");
            ButtonX = category.CreateEntry("ButtonXPos", 0f, "The X Position of the Unchained Core Button");
            ButtonY = category.CreateEntry("ButtonYPos", 0f, "The Y Position of the Unchained Core Button");
            MelonCoroutines.Start(FindUI());
        }

        private void VRCUIInit()
        {
            try
            {
                UnchainedMenu = new QMNestedButton("ShortcutMenu", ButtonX.Value, ButtonY.Value, "VRCMG\nUnchained", "VRCMGU Mods");
                UnchainedScroll = new QMScrollMenu(UnchainedMenu);
                UnchainedScroll.SetAction(delegate 
                {
                    foreach (var m in AllModMenus)
                    {
                        UnchainedScroll.Add(new QMSingleButton(UnchainedScroll.BaseMenu, 0, 0, m.ButtonText, delegate 
                        {
                            UnchainedMenu.getBackButton().ClickMe();
                            m.Menu.OpenMe();
                        }, m.ToolTipText));
                    }
                });
                MelonLogger.Msg(ConsoleColor.Green, "Unchained Core Finished!");
            }
            catch (Exception e)
            {
                MelonLogger.Error("Error Creating VRCMG Unchained Menu!\nPlease submit this to the mod support channel! | Error Message:\n" + e.Message);
            }
        }

        /*private void LoadBundle()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("VRCMGU.unchained")) //String is MainNamespace.assetbundlename
            using (var tempStream = new MemoryStream((int)stream.Length))
            {
                stream.CopyTo(tempStream);

                UnchainedBundle = AssetBundle.LoadFromMemory_Internal(tempStream.ToArray(), 0);
                UnchainedBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            }

            UnchainedLogo = UnchainedBundle.LoadAsset_Internal("Assets/kek.png", Il2CppType.Of<Sprite>()).Cast<Sprite>(); //String is the location/name of the asset in the assetbundle
            UnchainedLogo.hideFlags |= HideFlags.DontUnloadUnusedAsset;
        }*/

        private IEnumerator FindUI()
        {
            while (VRCUiManager.prop_VRCUiManager_0 == null) yield return null;
            VRCUIInit();
            yield break;
        }
    }
}
