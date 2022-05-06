using UnityEngine;

public class SecondaryMenu : MonoBehaviour
{
    public void OnRestart()
    {
        HGM_LoadManager.StartGame();
    }

    public void OnMenuPick()
    {
        HGM_LoadManager.Menu();
    }

    public void OnExitPick()
    {
        HGM_LoadManager.Exit();
    }
}
