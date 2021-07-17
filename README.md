# VRCMG Unchained-Core

The Official Core Library Mod for VRChat Modding Group Unchained!

## How to Use
Added the dll from the releases tab as a reference to your project.

```csharp
[assembly: MelonInfo(typeof(TestMod.Class1), "TestMod", "1.0.0")]
[assembly: MelonGame("VRChat", "VRChat")]
[assembly: MelonAdditionalDependencies("Unchained-Core")]

namespace TestMod
{
    public class Class1 : MelonMod
    {
      public void VRCUI()
      {
          var menu = new VRCMGU.API.QMNestedButton("ShortcutMenu", 0, 0, "you can just leave this blank", "");
          VRCMGU.UI.AddToUnchainedMenu(menu, "Test Mod", "Test mod lmfao");
      }
    }
}
```

This will create a menu inside of the Unchained Mod's tab for you to add buttons and such to.

### Outcome
![outcome image](https://wtfblaze.com/uploads/png/vrVbr.png)
