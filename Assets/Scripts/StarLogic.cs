using System.Collections;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class StarLogic : MonoBehaviour
{
    private AudioSource sound;
    private MeshRenderer[] meshes;

    private void Start()
    {
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
            GameStates.AddStar();
            StartCoroutine(DisableAfterSeconds(1f));

        }
    }

    IEnumerator DisableAfterSeconds(float sec)
    {
        yield return new WaitForSecondsRealtime(sec);
        gameObject.SetActive(false);
    }
}
