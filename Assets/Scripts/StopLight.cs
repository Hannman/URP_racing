using UnityEngine;

public class StopLight : MonoBehaviour
{
    private Material �urrentMat;
    private RCC_CarControllerV3 carController;
    private bool �urrentFrameStopResult;
    private bool lastFrameStopResult;


    void Awake()
    {
        �urrentMat = gameObject.GetComponent<Renderer>().material;
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }

    void Update()
    {
        //��������� ��������� ����-������� ��� �������� �����
        �urrentFrameStopResult = carController.brakeInput >= .1f;

        if (�urrentFrameStopResult != lastFrameStopResult)
        {
            if (�urrentFrameStopResult)
            {
                �urrentMat.EnableKeyword("_EMISSION");
            }
            else
            {
                �urrentMat.DisableKeyword("_EMISSION");
            }
            lastFrameStopResult = �urrentFrameStopResult;
        }
    }
}
