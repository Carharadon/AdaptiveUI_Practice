using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    private static AudioManager instance;


    void Start()
    {
        if (PlayerPrefs.HasKey("MasterVolume"))
        {
            musicSource.volume = PlayerPrefs.GetFloat("MasterVolume");
        }
        else
        {
            musicSource.volume = 1f;
        }

        if (PlayerPrefs.HasKey("SfxVolume"))
        {
            sfxSource.volume = PlayerPrefs.GetFloat("SfxVolume");
        }
        else
        {
            sfxSource.volume = 1f;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void UpdateVolumes(float musicVolume, float sfxVolume)
    {
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }

        if (sfxSource != null)
        {
            sfxSource.volume = sfxVolume;
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
            PlayerPrefs.SetFloat("MasterVolume", volume);
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
            PlayerPrefs.SetFloat("SfxVolume", volume);
        }
    }

}
