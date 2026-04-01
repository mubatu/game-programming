using UnityEngine;

public class WinSound : MonoBehaviour {
    private AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }
    void OnEnable() {
        EnemyHealth.FinalBossDeath += Play;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= Play;
    }

    public void Play() {
        audioSource.Play();
    }
}