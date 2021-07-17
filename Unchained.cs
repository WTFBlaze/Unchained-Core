using MelonLoader;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;
using VRCMGU.API;

[assembly: MelonInfo(typeof(VRCMGU.Unchained), "Unchained-Core", "1.0.0")]
[assembly: MelonGame("VRChat", "VRChat")]

namespace VRCMGU
{
    public class Unchained : MelonMod
    {
        public static QMNestedButton UnchainedMenu;
        public static QMScrollMenu UnchainedScroll;
        public static AssetBundle UnchainedBundle;
        public static Sprite UnchainedLogo;
        public static List<UnchainedItem> AllModMenus = new List<UnchainedItem>();

        public override void OnApplicationStart()
        {
            MelonLogger.Msg("Starting Unchained Core...");
            //LoadBundle();
            MelonCoroutines.Start(FindUI());
        }

        private void VRCUIInit()
        {
            try
            {
                UnchainedMenu = new QMNestedButton("ShortcutMenu", 0, 0, "VRCMG\nUnchained", "VRCMGU Mods");
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
