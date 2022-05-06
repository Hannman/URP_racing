using UnityEngine;
using UnityEngine.UI;

public class HGM_Graphics : MonoBehaviour
{
    [Header("Toggles")]
    [Space(10)] // 10 pixels of spacing here.
    [Tooltip("Toggle Shadows")]
    [SerializeField] private Toggle shadowsToggle;
    [Tooltip("Vertical Synchronization Toggle")]
    [SerializeField] private Toggle vSyncToggle;
    [Tooltip("Anti-aliasing Toggle")]
    [SerializeField] private Toggle aaToggle;


    void Start()
    {
        ButtonInit();
        ApplySettings();
    }

    public void SetShadows(bool value)
    {
        SavedSettings.Shadows = value;
        QualitySettings.shadows = value ? ShadowQuality.All : ShadowQuality.Disable;
    }

    public void SetVSync(bool value)
    {
        SavedSettings.vSync = value ? true : false;
        QualitySettings.vSyncCount = value ? 1 : 0;
        Application.targetFrameRate = value ? Screen.currentResolution.refreshRate : 300;
    }

    public void SetAntiAliasing(bool value)
    {
        SavedSettings.antiAliasing = value ? true : false;
        QualitySettings.antiAliasing = value ? 4 : 0;
    }

    private void ButtonInit()
    {
        shadowsToggle.SetIsOnWithoutNotify(SavedSettings.Shadows);
        vSyncToggle.SetIsOnWithoutNotify(SavedSettings.vSync);
        aaToggle.SetIsOnWithoutNotify(SavedSettings.antiAliasing);
    }

    private void ApplySettings()
    {
        SetShadows(SavedSettings.Shadows);
        SetVSync(SavedSettings.vSync);
        SetAntiAliasing(SavedSettings.antiAliasing);
    }
}
