using UnityEngine;
using UnityEngine.UI;

public class FramerateControl : MonoBehaviour
{
    [Header("Toggle")]
    [Tooltip("Toggle FPS counter")]
    [SerializeField] private Toggle fpsToggle;

    [SerializeField] private GameObject frameCounter;

    void Start()
    {
        Application.targetFrameRate = SavedSettings.vSync ? Screen.currentResolution.refreshRate : 300;
        fpsToggle.SetIsOnWithoutNotify(SavedSettings.fpsCounter);
        frameCounter.SetActive(SavedSettings.fpsCounter);
    }

    public void OnFramerateCounterChanged(bool newValue)
    {
        if (newValue)
        {
            frameCounter.SetActive(true);
            SavedSettings.fpsCounter = true;
        }
        else
        {
            frameCounter.SetActive(false);
            SavedSettings.fpsCounter = false;
        }
    }
}
