using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
        
    }
    public void SetMasterVolume()
    {
        float volume = masterVolumeSlider.value;
        audioMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }
    public void SetMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolumeSlider.value);
    }

     public void SetSFXVolume()
    {
        float volume = SFXVolumeSlider.value;
        audioMixer.SetFloat("sfx", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolumeSlider.value);
    }

    private void LoadVolume()
    {
         masterVolumeSlider.value = PlayerPrefs.GetFloat("masterVolume");
        musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
       
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
}
