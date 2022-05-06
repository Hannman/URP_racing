using UnityEngine;
using UnityEngine.Events;


public class HGM_Event
{
    public static UnityAction changeRingColor;
    public static UnityAction<int> starAdded;
    public static UnityAction onControlOn;
    public static UnityAction onControlOff;
    public static UnityAction<int> addTime;

    static HGM_Event()
    {
        addTime += (time) => Debug.Log($">>> ���������� ������� -> {time} ������ <<<");
    }

    internal static void ResetRings()
    {
        changeRingColor = null;
    }
}

