using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class CameraPostProcessing : MonoBehaviour
{
    private Toggle processingToggle;
    private PostProcessLayer postProcessing;
   
    void Start()
    {
        postProcessing = Camera.main.GetComponent<PostProcessLayer>();
        processingToggle = GetComponent<Toggle>();
        processingToggle.SetIsOnWithoutNotify(postProcessing.enabled);
        processingToggle.onValueChanged.AddListener(OnPostProcessingChange);
    }

    public void OnPostProcessingChange(bool value) 
    {
        postProcessing.enabled = value;
    }
}
