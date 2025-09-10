using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace remove_myopia_filter;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class Plugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger;
    private readonly Harmony harmony = new Harmony(MyPluginInfo.PLUGIN_GUID);
        
    private void Awake()
    {
        harmony.PatchAll();
    }
    
    [HarmonyPatch(typeof(HeroLight), "Awake")]
    public class AtStart
    {
        [HarmonyPostfix]
        static void Postfix(StartManager __instance, 
            ref SpriteRenderer ___spriteRenderer, 
            ref SpriteRenderer ___heroLightDonut, 
            ref Transform ___vignette)
        {
            // ___spriteRenderer.enabled = false;
            // ___heroLightDonut.enabled = false;
            ___spriteRenderer.gameObject.active = false;
            ___vignette.gameObject.active = false;
        }
    }
}
