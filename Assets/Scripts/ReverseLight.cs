using UnityEngine;

public class ReverseLight : MonoBehaviour
{
    private Material ñurrentMat;
    private RCC_CarControllerV3 carController;
    private bool ñurrentFrameReverseResult;
    private bool lastFrameReverseResult;


    void Awake()
    {
        ñurrentMat = gameObject.GetComponent<Renderer>().material;
        carController = GetComponentInParent<RCC_CarControllerV3>();
    }

    void Update()
    {
        //ïîëó÷åíèå ñîñòîÿíèÿ äâèæåíèÿ íàçàä äëÿ òåêóùåãî êàäğà
        ñurrentFrameReverseResult = carController.direction == -1;

        if (ñurrentFrameReverseResult != lastFrameReverseResult)
        {
            if (ñurrentFrameReverseResult)
            {
                ñurrentMat.EnableKeyword("_EMISSION");
            }
            else
            {
                ñurrentMat.DisableKeyword("_EMISSION");
            }
            lastFrameReverseResult = ñurrentFrameReverseResult;
        }
    }
}
