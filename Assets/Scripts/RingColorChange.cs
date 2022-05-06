using UnityEngine;

public class RingColorChange : MonoBehaviour
{
    private Renderer RingRenderer;

    private void OnEnable()
    {
        HGM_Event.changeRingColor += ChangeColour;
    }

    private void OnDisable()
    {
        HGM_Event.changeRingColor -= ChangeColour;
    }

    void Start()
    {
        RingRenderer = GetComponent<Renderer>();

    }

    // смена цвета
    private void ChangeColour()
    {
        if (isActiveAndEnabled)
        {
            var ringColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
            RingRenderer.material.SetColor("_EmissionColor", ringColor);
        }
    }

}
