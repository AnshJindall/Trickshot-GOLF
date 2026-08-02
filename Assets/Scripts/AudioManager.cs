using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Source")]
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip launchClip;
    [SerializeField] private AudioClip fireworkClip;
    [SerializeField] private AudioClip clapClip;
    [SerializeField] private AudioClip whooshClip;
    [SerializeField] private AudioClip loseLifeClip;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip victoryClip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayLaunch()
    {
        sfxSource.PlayOneShot(launchClip);
    }

    public void PlayLevelWin()
    {
        sfxSource.PlayOneShot(fireworkClip, 0.8f);
        sfxSource.PlayOneShot(clapClip);
    }

    public void PlayWhoosh()
    {
        sfxSource.PlayOneShot(whooshClip, 0.6f);
    }

    public void PlayLoseLife()
    {
        sfxSource.PlayOneShot(loseLifeClip);
    }

    public void PlayButton()
    {
        sfxSource.PlayOneShot(buttonClip);
    }

    public void PlayVictory()
    {
        sfxSource.PlayOneShot(victoryClip);
    }
}