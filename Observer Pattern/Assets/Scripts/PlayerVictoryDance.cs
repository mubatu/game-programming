using UnityEngine;
using System.Collections;

public class PlayerVictoryDance : MonoBehaviour {
    [SerializeField] private float spinDuration = 1.75f;
    private PlayerMovement playerMovement;

    void Start() {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnEnable() {
        EnemyHealth.FinalBossDeath += Play;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= Play;
    }

    public void Play() {
        StartCoroutine(Spin());
    }

    IEnumerator Spin() {
        playerMovement.enabled = false;
        float elapsed = 0f;
        float totalRotation = 720f;

        while (elapsed < spinDuration) {
            float step = (totalRotation / spinDuration) * Time.deltaTime;
            transform.Rotate(0, step, 0);
            elapsed += Time.deltaTime;
            yield return null;
        }

        playerMovement.enabled = true;
    }
}