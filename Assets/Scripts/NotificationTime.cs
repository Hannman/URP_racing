using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotificationTime : MonoBehaviour
{
    private Animator animator;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        HGM_Event.addTime += AddedTime;
    }

    private void OnDisable()
    {
        HGM_Event.addTime -= AddedTime;
    }

    // Update is called once per frame
    void AddedTime(int time)
    {
        if (!GameStates.IsOver)
        {
            text.text = $"+{time / 60}:{time % 60}";
            animator.SetTrigger("Popup");
        }
    }
}
