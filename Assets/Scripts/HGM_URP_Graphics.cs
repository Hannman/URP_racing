using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using TMPro;

public class HGM_URP_Graphics : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Dropdown dropdown;

    //[Header("Pipeline Assets")]
    //[Space(10)] // 10 pixels of spacing here.
    //[SerializeField] private RenderPipelineAsset[] qualityAssets;

    void Start()
    {
        Application.targetFrameRate = 300;
        SetLevel(SavedSettings.Quality);
        dropdown.SetValueWithoutNotify(SavedSettings.Quality);
    }



    public void SetLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
        SavedSettings.Quality = level;
    }

}
