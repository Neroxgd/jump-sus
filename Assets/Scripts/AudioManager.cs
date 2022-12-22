using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayAudioClip("Kevin MacLeod Pixelland", true);
    }

    public void PlayAudioClip(string name, bool ifLoop)
    {
        AudioClip audioClip = null;
        foreach(AudioClip clip in audioClips)
        {
            if (clip.name == name)
            {
                audioClip = clip;
                break;
            }
        }

        if (audioClip == null)
        {
            print("audio clip not found: " + name);
            return;
        }

        if (ifLoop)
        {
            audioSource.loop = true;
            audioSource.clip = audioClip;
            audioSource.Play();
            return;
        }

        audioSource.PlayOneShot(audioClip);
    }
}
