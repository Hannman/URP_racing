using UnityEngine;
using TMPro;

public class StarDisplayer : MonoBehaviour
{
    private TextMeshProUGUI starText;

    private void OnEnable()
    {
        HGM_Event.starAdded += StarCountUpdate;
    }

    private void OnDisable()
    {
        HGM_Event.starAdded -= StarCountUpdate;
    }

    void Start()
    {
       starText = GetComponent<TextMeshProUGUI>();       
    }

    private void StarCountUpdate(int starCount) 
    {
        starText.text = $"x {starCount}";
    }
}
