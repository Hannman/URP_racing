using UnityEngine;
using UnityEngine.SceneManagement;

public static class HGM_LoadManager
{
    // Переход на начало игры
    public static void StartGame()
    {
        HGM_Event.ResetRings();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        HGM_SceneTransition.LoadScene("HGM_Scene_1");
    }

    //Переход на сцену победы
    public static void Win()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("WinScene");
    }

    //Переход на сцену поражения  
    public static void Lose()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("LoseScene");
    }

    //Переход к главному меню
    public static void Menu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Intro_menu");
    }

    // Выход из игры
    public static void Exit()
    {
        Application.Quit();
    }
}
