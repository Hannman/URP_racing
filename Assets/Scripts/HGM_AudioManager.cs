using System.Collections;
using UnityEngine;
using UnityEngine.Audio;


[RequireComponent(typeof(AudioSource))]
public class HGM_AudioManager : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;
    public AudioClip[] musicList;
    private int currentTrack;
    private static AudioSource source;


    void Start()
    {
        source = GetComponent<AudioSource>();
        if (musicList.Length != 0)
        {
            Mixer.SetFloat("CarVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(SavedSettings.carSoundLevel)));
            Mixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(SavedSettings.musicLevel)));
            Mixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(SavedSettings.effectsLevel)));
            PlayMusic();
        }

    }

    public void PlayMusic()
    {
        if (source.isPlaying)
        {
            return;
        }

        StartCoroutine(WaitForMusicEnd());
    }

    public void StopMusic()
    {
        StopCoroutine(WaitForMusicEnd());
        source.Stop();
    }

    private void NextTrack()
    {
        source.Stop();
        currentTrack = GetTrack();
        Debug.Log("Song >> " + currentTrack + "/" + musicList.Length);
        source.clip = musicList[currentTrack];
        source.Play();

        StartCoroutine(WaitForMusicEnd());
    }

    //Получение рандомного номера трека 
    private int GetTrack()
    {
        return Random.Range(0, musicList.Length);
    }

    private IEnumerator WaitForMusicEnd()
    {
        while (source.isPlaying)
        {
            yield return new WaitForSeconds(0.5f);
        }
        NextTrack();
    }



}
