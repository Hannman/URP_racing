using Cinemachine;
using UnityEngine;

public class InGameMenuManager : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    [SerializeField] private GameObject menuCanvas;
    [Tooltip("UI Dashboard canvas")]
    [SerializeField] private Canvas dashboardCanvas;

    [Space(15)] // 15 pixels of spacing here.
    [Tooltip("Master volume when menu is open")]
    [Range(0.001f, 1f)]
    [SerializeField] private float volumeWhenMenuOpen;

    private CinemachineBrain camFreeLook;


    void Start()
    {
        Time.timeScale = 1f;
        menuCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        camFreeLook = Camera.main.GetComponent<CinemachineBrain>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameStates.IsOver)
        {
            TogglePauseMenu();
        }
    }


    public void TogglePauseMenu()
    {
        if (menuCanvas.activeInHierarchy)
        {
            Cursor.visible = false;
            menuCanvas.SetActive(false);
            dashboardCanvas.enabled = true;
            Time.timeScale = 1f;
            camFreeLook.enabled = true;
        }
        else
        {
            camFreeLook.enabled = false;
            Cursor.visible = true;
            menuCanvas.SetActive(true);
            dashboardCanvas.enabled = false;
            Time.timeScale = 0f;
        }

    }


    public void ExitToMainMenu()
    {
        HGM_LoadManager.Menu();
    }

}
