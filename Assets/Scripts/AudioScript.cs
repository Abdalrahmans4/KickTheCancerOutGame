using UnityEngine;

public class AudioScript : MonoBehaviour
{
    [SerializeField] private AudioSource goalSource;
    [SerializeField] private AudioSource buzzerSource;
    [SerializeField] private AudioSource crowdSource;
    [SerializeField] private AudioSource winSource;
    [SerializeField] private AudioSource loseSource;

    void Start()
    {
        // when start the crowd for background music.
        if (crowdSource != null && !crowdSource.isPlaying)
        {
            crowdSource.Play();
        }
    }

    public void PlayGoal()
    {
        if (goalSource != null)
        {
            goalSource.PlayOneShot(goalSource.clip); //one shot to play the clip once
        }
    }

    public void PlayBuzzer()
    {
        if (buzzerSource != null)
        {
            buzzerSource.PlayOneShot(buzzerSource.clip);
        }
    }
    public void PlayWinSound()
    {
        if (winSource != null)
            winSource.PlayOneShot(winSource.clip);
    }

    public void PlayLoseSound()
    {
        if (loseSource != null)
            loseSource.PlayOneShot(loseSource.clip);
    }


    public void StopCrowd()
    {
        if (crowdSource != null && crowdSource.isPlaying)
            crowdSource.Stop();
    }
}
