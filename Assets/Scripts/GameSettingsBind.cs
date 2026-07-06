using UnityEngine;
using UnityEngine.UI;

public class GameSettingsBind : MonoBehaviour
{
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
        AudioManager am = Object.FindFirstObjectByType<AudioManager>();
        if (am != null)
        {
            musicSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
            sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1f);

            musicSlider.onValueChanged.AddListener(am.SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(am.SetSFXVolume);
        }
    }
}
