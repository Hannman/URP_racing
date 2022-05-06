using UnityEngine;

public class MainMenuBehaviour : MonoBehaviour
{

    [Header("Object to enable")]
    [SerializeField] private GameObject mainMenuButtons;

    [Space(15)] // 15 pixels of spacing here.


    [Header("Object to disable")]
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private GameObject aboutMenu;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnBackPressed();
        }
    }
    public void OnStartPressed()
    {
        MainMenuBackgroundAnimation.AnimateCar = false;
        HGM_LoadManager.StartGame();
    }

    public void OnExitPressed()
    {
        HGM_LoadManager.Exit();
    }

    private void OnBackPressed()
    {
        mainMenuButtons.SetActive(true);
        settingsMenu.SetActive(false);
        aboutMenu.SetActive(false);
    }
}
