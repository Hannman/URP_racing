using UnityEngine;
using TMPro;

public class WinScreenScoreDisplayer : MonoBehaviour
{

    private TextMeshProUGUI starText;
    
    void Start()
    {
        starText = GetComponent<TextMeshProUGUI>();
        starText.text = SavedSettings.starCount.ToString();
    }
}
