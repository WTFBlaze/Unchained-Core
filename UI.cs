using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using VRCMGU.API;

namespace VRCMGU
{
    public static class UI
    {
        public static void AddToUnchainedMenu(QMNestedButton QMNB, string ButtonText, string ToolTipText, Color? btnBackgroundColor = null, Color? btnTextColor = null, bool HalfButton = false)
        {
            QMNB.getMainButton().DestroyMe();
            QMNB.getBackButton().setAction(delegate 
            {
                QMStuff.ShowQuickmenuPage(Unchained.UnchainedMenu.getMenuName());
            });
            UnchainedItem item = new UnchainedItem() 
            {
                Menu = QMNB,
                ButtonText = ButtonText,
                ToolTipText = ToolTipText
            };
            Unchained.AllModMenus.Add(item);
        }
    }
}
