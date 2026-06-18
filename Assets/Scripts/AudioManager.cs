using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;

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

    public void UpdateVolumes(float musicVolume, float sfxVolume)
    {
        musicSource.volume = musicVolume;
        sfxSource.volume = sfxVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
    }
}
