using UnityEngine;

public class HUD_Dasboard : MonoBehaviour
{
    [SerializeField] private GameObject RPMNeedle;
    [SerializeField] private GameObject KMHNeedle;
    [SerializeField] private GameObject[] Gears;

    private float RPMNeedleRotation = 0f;
    private float KMHNeedleRotation = 0f;


    internal int Direction = 1;
    internal int Gear;
    internal bool changingGear = false;
    internal bool NGear = false;


    void Update()
    {
        GetValues();
    }

    void LateUpdate()
    {
        if (!NGear && !changingGear)
        {
            if (Direction == 1)
            {
                SetGear(Gear + 1);
            }
            else
            {
                SetGear(7);
            }
        }
        else
        {
            SetGear(0);
        }

    }

    //установка передачи
    void SetGear(int G)
    {
        for (int i = 0; i < Gears.Length; i++)
        {
            if (G == i)
            {
                Gears[i].SetActive(true);
            }
            else
            {
                Gears[i].SetActive(false);
            }
        }
    }


    void GetValues()
    {
        if (!RCC_SceneManager.Instance.activePlayerVehicle || !RCC_SceneManager.Instance.activePlayerVehicle.canControl)
            return;

        Direction = RCC_SceneManager.Instance.activePlayerVehicle.direction;
        Gear = RCC_SceneManager.Instance.activePlayerVehicle.currentGear;
        changingGear = RCC_SceneManager.Instance.activePlayerVehicle.changingGear;
        NGear = RCC_SceneManager.Instance.activePlayerVehicle.NGear;

        if (RPMNeedle)
        {
            RPMNeedleRotation = (RCC_SceneManager.Instance.activePlayerVehicle.engineRPM / 36f);
            RPMNeedle.transform.eulerAngles = new Vector3(RPMNeedle.transform.eulerAngles.x, RPMNeedle.transform.eulerAngles.y, -RPMNeedleRotation);
        }

        if (KMHNeedle)
        {
            KMHNeedleRotation = (RCC_SceneManager.Instance.activePlayerVehicle.speed);
            KMHNeedle.transform.eulerAngles = new Vector3(KMHNeedle.transform.eulerAngles.x, KMHNeedle.transform.eulerAngles.y, -3 * KMHNeedleRotation / 4);
        }
    }
}
