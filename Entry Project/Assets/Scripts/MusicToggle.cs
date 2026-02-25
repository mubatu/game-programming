using UnityEngine;

public class MusicToggle : MonoBehaviour
{
    public AudioSource audioSource;
    public KeyCode toggleKey = KeyCode.M;

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if (audioSource.isPlaying)
                audioSource.Pause();
            else
                audioSource.UnPause();
        }
    }
}