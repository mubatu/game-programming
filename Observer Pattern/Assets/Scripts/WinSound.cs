using UnityEngine;

public class WinSound : MonoBehaviour {
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    public void Play() {
        audioSource.Play();
    }
}