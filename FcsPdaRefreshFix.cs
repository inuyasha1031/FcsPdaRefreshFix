using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("com.yourname.fcsfix", "FCS PDA Refresh Fix", "1.0.0")]
public class FcsPdaRefreshFix : BaseUnityPlugin
{
    private void Awake()
    {
        Harmony harmony = new Harmony("com.yourname.fcsfix");
        harmony.PatchAll();
        Logger.LogInfo("FCS PDA Refresh Fix loaded.");
    }
}

[HarmonyPatch(typeof(FCS_PDAController), "OnTabChanged")]
class FcsPdaRefreshPatch
{
    static void Postfix()
    {
        foreach (Canvas canvas in Object.FindObjectsOfType<Canvas>())
        {
            if (canvas.isRootCanvas)
            {
                canvas.enabled = false;
                canvas.enabled = true;
            }
        }
    }
}
