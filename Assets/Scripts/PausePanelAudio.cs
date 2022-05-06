using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PausePanelAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle carSoundToggle;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private Toggle effectsToggle;
    [SerializeField] private Slider carSoundSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider effectsSlider;


    private void Start()
    {
        SetPanelVolumes(true);
    }

    public void ChangeMasterVolume(float volume)
    {
        SavedSettings.carSoundLevel = volume;
        carSoundToggle.SetIsOnWithoutNotify(true);
        mixer.SetFloat("CarVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(volume)));
    }

    public void ChangeMusicVolume(float volume)
    {
        SavedSettings.musicLevel = volume;
        musicToggle.SetIsOnWithoutNotify(true);
        mixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(volume)));
    }

    public void ChangeEffectsVolume(float volume)
    {
        SavedSettings.effectsLevel = volume;
        effectsToggle.SetIsOnWithoutNotify(true);
        mixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 20, Mathf.Sqrt(volume)));
    }

    public void ToggleSound(bool enabled)
    {
        if (enabled)
        {
            carSoundSlider.SetValueWithoutNotify(SavedSettings.carSoundLevel);
            ChangeMasterVolume(SavedSettings.carSoundLevel);
        }
        else
        {
            SavedSettings.carSoundLevel = carSoundSlider.value;
            carSoundSlider.SetValueWithoutNotify(0);
            mixer.SetFloat("CarVolume", -80);
        }

    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            musicSlider.SetValueWithoutNotify(SavedSettings.musicLevel);
            ChangeMusicVolume(SavedSettings.musicLevel);
        }
        else
        {
            SavedSettings.musicLevel = musicSlider.value;
            musicSlider.SetValueWithoutNotify(0);
            mixer.SetFloat("MusicVolume", -80);
        }
    }

    public void ToggleEffects(bool enabled)
    {
        if (enabled)
        {
            effectsSlider.SetValueWithoutNotify(SavedSettings.effectsLevel);
            ChangeEffectsVolume(SavedSettings.effectsLevel);
        }
        else
        {
            SavedSettings.effectsLevel = effectsSlider.value;
            effectsSlider.SetValueWithoutNotify(0);
            mixer.SetFloat("EffectsVolume", -80);
        }
    }


    private void OnEnable()
    {
        mixer.SetFloat("MasterVolume", -80);
        SetPanelVolumes();
    }


    private void OnDisable()
    {
        mixer.SetFloat("MasterVolume", 0);
    }

    private void SetPanelVolumes(bool Init = false)
    {
        if (Init)
        {
            carSoundToggle.SetIsOnWithoutNotify(SavedSettings.carSoundLevel > 0.01f);
            musicToggle.SetIsOnWithoutNotify(SavedSettings.musicLevel > 0.01f);
            effectsToggle.SetIsOnWithoutNotify(SavedSettings.effectsLevel > 0.01f);
        }

        carSoundSlider.SetValueWithoutNotify(SavedSettings.carSoundLevel);
        musicSlider.SetValueWithoutNotify(SavedSettings.musicLevel);
        effectsSlider.SetValueWithoutNotify(SavedSettings.effectsLevel);
    }
}
