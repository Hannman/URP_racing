using UnityEngine;

public class ReverseLight : MonoBehaviour
{
    private Material �urrentMat;
    private RCC_CarControllerV3 carController;
    private bool �urrentFrameReverseResult;
    private bool lastFrameReverseResult;


    void Awake()
    {
        �urrentMat = gameObject.GetComponent<Renderer>().material;
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }

    void Update()
    {
        //��������� ��������� �������� ����� ��� �������� �����
        �urrentFrameReverseResult = carController.direction == -1;

        if (�urrentFrameReverseResult != lastFrameReverseResult)
        {
            if (�urrentFrameReverseResult)
            {
                �urrentMat.EnableKeyword("_EMISSION");
            }
            else
            {
                �urrentMat.DisableKeyword("_EMISSION");
            }
            lastFrameReverseResult = �urrentFrameReverseResult;
        }
    }
}
