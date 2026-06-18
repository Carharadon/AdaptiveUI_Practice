using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;            

public class MainMenu : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider sfxVolumeSlider;
    public GameObject settingsPanel;

    void Start()
    {

        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            masterVolumeSlider.value = 1f;
        }

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            sfxVolumeSlider.value = PlayerPrefs.GetFloat("SfxVolume");
        }
        else
        {
            sfxVolumeSlider.value = 1f;
        }

        settingsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Игрок вышел из игры!"); 
    }

    public void ChangeMasterVolume()
    {
        PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);

        AudioManager am = Object.FindFirstObjectByType<AudioManager>();
        if (am != null)
        {
            am.UpdateVolumes(masterVolumeSlider.value, sfxVolumeSlider.value);
        }
    }

    public void ChangeSfxVolume()
    {
        PlayerPrefs.SetFloat("SfxVolume", sfxVolumeSlider.value);

        AudioManager am = Object.FindFirstObjectByType<AudioManager>();
        if (am != null)
        {
            am.UpdateVolumes(masterVolumeSlider.value, sfxVolumeSlider.value);
        }
    }
}
