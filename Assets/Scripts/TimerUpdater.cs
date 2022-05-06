using System;
using UnityEngine;
using TMPro;

public class TimerUpdater : MonoBehaviour
{

    private TextMeshProUGUI timerText;
    private int timeRemaining;
    float G_B_Colour;

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        timeRemaining = (int)GameStates.timeRemaining;
        timerText.text = string.Format("{0}:{1:00}", timeRemaining / 60, timeRemaining % 60);


        if (timeRemaining < 9.5)
        {
            G_B_Colour = 1- Math.Abs(2 *(GameStates.timeRemaining % 1-0.5f));
            timerText.color = new Color(1, G_B_Colour, G_B_Colour);
        }
        else
        {
            timerText.color = Color.white;
        }
    }
}
