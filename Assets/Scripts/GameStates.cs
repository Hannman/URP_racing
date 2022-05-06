using System.Collections;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    [SerializeField] private GameObject wastedScreen;
    [SerializeField] private GameObject timeOverScreen;
    public static float timeRemaining { get; private set; }
    public static bool IsOver { get; private set; }

    private static GameStates instance;

    private static int starsCount;
    private static bool raceStarted;


    void Awake()
    {
        instance = this;
        SavedSettings.starCount = starsCount = 0;
        timeRemaining = SavedSettings.startTime;
        raceStarted = false;
        IsOver = false;
    }

    private void Start()
    {
        instance.StartCoroutine(Gamestart());
    }

    // Update is called once per frame
    void Update()
    {
        if (raceStarted && !IsOver)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                Win();
            }
        }
    }

    public static void Win()
    {
        IsOver = true;
        instance.timeOverScreen.SetActive(true);
        instance.StartCoroutine(LoadCoroutine(true));
    }

    public static void GameOver()
    {
        IsOver = true;
        instance.wastedScreen.SetActive(true);
        instance.StartCoroutine(LoadCoroutine(false));
    }

    public static void AddStar()
    {
        if (!IsOver)
        {
            starsCount++;
            SavedSettings.starCount = starsCount;
            HGM_Event.starAdded?.Invoke(starsCount);
        }
    }

    public static void AddTime(int additionalTime)
    {
        if (!IsOver)
        {
            timeRemaining += additionalTime;
            HGM_Event.changeRingColor?.Invoke();
            HGM_Event.addTime?.Invoke(additionalTime);
        }
    }

    private static IEnumerator LoadCoroutine(bool win)
    {
        HGM_Event.onControlOff?.Invoke();
        yield return new WaitForSeconds(7f);

        if (win)
        {
            HGM_LoadManager.Win();
        }
        else
        {
            HGM_LoadManager.Lose();
        }
    }

    private static IEnumerator Gamestart()
    {
        yield return new WaitForSeconds(7f);
        HGM_Event.onControlOn?.Invoke();
        raceStarted = true;
    }

}
