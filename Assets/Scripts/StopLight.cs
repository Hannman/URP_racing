using UnityEngine;

public class StopLight : MonoBehaviour
{
    private Material ñurrentMat;
    private RCC_CarControllerV3 carController;
    private bool ñurrentFrameStopResult;
    private bool lastFrameStopResult;


    void Awake()
    {
        ñurrentMat = gameObject.GetComponent<Renderer>().material;
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }

    void Update()
    {
        //ïîëó÷åíèå ñîñòîÿíèÿ ñòîï-ñèãíàëà äëÿ òåêóùåãî êàäðà
        ñurrentFrameStopResult = carController.brakeInput >= .1f;

        if (ñurrentFrameStopResult != lastFrameStopResult)
        {
            if (ñurrentFrameStopResult)
            {
                ñurrentMat.EnableKeyword("_EMISSION");
            }
            else
            {
                ñurrentMat.DisableKeyword("_EMISSION");
            }
            lastFrameStopResult = ñurrentFrameStopResult;
        }
    }
}
