using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MainMenuAudio : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Toggle menuMusicToggle;
    [SerializeField] private Slider menuMusicSlider;

    public void ChangeMusicVolume(float volume)
    {
        SavedSettings.menuMusicLevel = volume;
        menuMusicToggle.SetIsOnWithoutNotify(true);
        mixer.SetFloat("MenuMusicVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(volume)));
    }

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
        {
            menuMusicSlider.SetValueWithoutNotify(SavedSettings.menuMusicLevel);
            ChangeMusicVolume(SavedSettings.menuMusicLevel);
        }
        else
        {
            SavedSettings.menuMusicLevel = menuMusicSlider.value;
            menuMusicSlider.SetValueWithoutNotify(0);
            mixer.SetFloat("MenuMusicVolume", -80);
        }
    }
    private void Start()
    {
        SetPanelVolumes();
        mixer.SetFloat("MenuMusicVolume", Mathf.Lerp(-80, 0, Mathf.Sqrt(SavedSettings.menuMusicLevel)));
    }

    public void SetPanelVolumes()
    {
        menuMusicToggle.SetIsOnWithoutNotify(SavedSettings.menuMusicLevel > 0.01f);
        menuMusicSlider.SetValueWithoutNotify(SavedSettings.menuMusicLevel);
    }
}
