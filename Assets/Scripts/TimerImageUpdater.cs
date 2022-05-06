using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerImageUpdater : MonoBehaviour
{
    private Image timerImage;

    void Start()
    {
        timerImage = gameObject.GetComponent<Image>();
    }

    
    void Update()
    {
        if (GameStates.timeRemaining<=10)
        {
            timerImage.enabled = true;
        }
        else
        {
            timerImage.enabled = false;
        }
    }
}
