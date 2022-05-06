using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FramerateCounter : MonoBehaviour
{
    private TextMeshProUGUI fpsText;
    private float pollingTime = 0.2f;
    private float deltaTime = 0f;
    private int frameCount = 0;
    private float framerate;


    void Start()
    {
        fpsText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        deltaTime += Time.deltaTime;
        frameCount++;

        if (deltaTime >= pollingTime)
        {
            framerate = (float)frameCount / deltaTime;
            fpsText.color = GetColor(framerate);

            fpsText.text = Mathf.RoundToInt(framerate).ToString();

            deltaTime = 0f;
            frameCount = 0;
        }

    }


    Color GetColor(float framerate)
    {
        Color result = Color.black;

        if (framerate < 20)
        {
            result.r = 1;
            result.g = 0;
        }
        else
        {
            if (framerate < 40)
            {
                result.r = 1;
                result.g = (framerate - 20) * 0.05f;
            }
            else
            {
                if (framerate < 60)
                {
                    result.r = 1 - ((framerate - 40) * 0.05f);
                    result.g = 1;
                }
                else
                {
                    result.r = 0;
                    result.g = 1;
                }
            }
        }

        return result;
    }



}
