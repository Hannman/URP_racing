using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class URP_CameraPostProcessing : MonoBehaviour
{
    private Toggle processingToggle;
    public Volume volume;

    void Start()
    {
        processingToggle = GetComponent<Toggle>();
        processingToggle.SetIsOnWithoutNotify(volume.enabled);
        processingToggle.onValueChanged.AddListener(OnPostProcessingChange);
    }

    public void OnPostProcessingChange(bool value) 
    {

        volume.enabled = value;
    }
}
