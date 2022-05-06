using UnityEngine;
using UnityEngine.UI;

public class MainMenuBackgroundAnimation : MonoBehaviour
{
    public static bool AnimateCar { get; set; }
    public RawImage[] images;

    private Canvas canvas;
    private const float time_intro = 4; //врем€ по€влени€ картинки
    private const float time_outro = 5; //врем€ исчезновени€ картинки
    private const float showTime = 20;
    private Vector2 currentPosition;
    private Vector2 currentScale;
    private int currentPicture;
    private float currentTime;
    private Color opacity;
    private float[,] dataUnscaled;
    private float[,] data = new float[4, 4];


    void Start()
    {
        AnimateCar = true;
        Initialization();
        canvas = GetComponentInParent<Canvas>();
        EnablePicture();
    }


    void Update()
    {
        if (AnimateCar)
        {
            ScaleUI();
            CarAnimation();
        }
    }

    private void ScaleUI()
    {
        currentScale = canvas.transform.localScale;

        for (int i = 0; i < 4; i++)
        {
            for (int n = 0; n < 4; n++)
            {
                data[i, n] = dataUnscaled[i, n] * currentScale.x;
            }
        }
    }

    private void Initialization()
    {
        Time.timeScale = 1f;

        /*
        0. —мещение по X в секунду
        1. —мещение по Y в секунду
        2. »сходный X
        3. »сходный Y
        */

        dataUnscaled = new float[4, 4]
        {
        { 20, -8, 1000, 500 },
        { -24, -8, 1650, 500 },
        { 20, -8, 700, 600 },
        { -20, -8, 1150, 500 }
        };

        opacity.r = 1;
        opacity.g = 1;
        opacity.b = 1;
    }

    private void CarAnimation()
    {
        currentTime += Time.deltaTime; //приращение времени

        //переход между картинками и задание начальных координат
        if (currentTime >= showTime)
        {
            PictureChange();
        }
        FrameCalculations();
        ShowTransform();
    }

    private void PictureChange()
    {
        currentTime = 0;
        currentPicture += 1;

        if (currentPicture >= images.Length)
        {
            currentPicture = 0;
        }

        EnablePicture();
    }

    void EnablePicture() 
    {
        foreach (var image in images)
        {
            image.enabled = false;
        }

        images[currentPicture].enabled = true;
    }


    private void FrameCalculations() 
    {
        if (currentTime <= time_intro)
        {
            opacity.a = currentTime / time_intro;
        }

        if (currentTime >= showTime - time_outro)
        {
            opacity.a = (showTime - currentTime) / time_outro;
        }

        //задание координаты ’ и Y
        currentPosition.x = data[currentPicture, 2] + data[currentPicture, 0] * currentTime;
        currentPosition.y = data[currentPicture, 3] + data[currentPicture, 1] * currentTime;
    }

    private void ShowTransform()
    {
        images[currentPicture].color = opacity;
        images[currentPicture].rectTransform.position = currentPosition;
    }
}
