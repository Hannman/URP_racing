using System;
using System.Collections;
using UnityEngine;

public class MineLogic : MonoBehaviour
{
    private Rigidbody targetRigidbody;
    private AudioSource sound;
    private void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Car")
        {
            sound.Play();
            StartCoroutine(DisableAfterSeconds(6f));
            GameStates.GameOver();
            targetRigidbody = other.gameObject.GetComponentInParent<Rigidbody>();
            targetRigidbody.AddForceAtPosition(transform.up * (float)Math.Pow(10, 6.3f), transform.position);
            targetRigidbody.AddForce(Vector3.up* (float)Math.Pow(10, 6.3f));
        }
    }

    IEnumerator DisableAfterSeconds(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        gameObject.SetActive(false);
    }
}
