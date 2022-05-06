using UnityEngine;

public class DeadZoneScript : MonoBehaviour
{
    private void OnTriggerEnter()
    {
        GameStates.GameOver();
    }
}
