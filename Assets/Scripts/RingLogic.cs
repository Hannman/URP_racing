using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class RingLogic : MonoBehaviour
{
    private AudioSource sound;
    private MeshRenderer[] meshes;

    void Start()
    {
        gameObject.SetActive(true);
        sound = GetComponent<AudioSource>();
        meshes = GetComponentsInChildren<MeshRenderer>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {

            sound.Play();
            foreach (var item in meshes)
            {
                item.enabled = false;
            }
            GameStates.AddTime(SavedSettings.ringTime + Random.Range(-5, 6));
            StartCoroutine(DisableAfterSeconds(1f));
        }
    }

    IEnumerator DisableAfterSeconds(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        gameObject.SetActive(false);
    }
}
