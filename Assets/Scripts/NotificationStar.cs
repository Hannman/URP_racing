using UnityEngine;

public class NotificationStar : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void OnEnable()
    {
        HGM_Event.starAdded += AddedStar;
    }

    private void OnDisable()
    {
        HGM_Event.starAdded -= AddedStar;
    }

    private void AddedStar(int stars)
    {
        if (!GameStates.IsOver)
        {
            animator.SetTrigger("Popup");
        }
    }
}
