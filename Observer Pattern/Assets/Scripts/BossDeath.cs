using UnityEngine;
using System.Collections;

public class BossDeath : MonoBehaviour {
    [SerializeField] private float deathDuration = 2f;

    public void Play() {
        StartCoroutine(DeathRoutine());
    }

    IEnumerator DeathRoutine() {
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        float elapsed = 0f;

        while (elapsed < deathDuration) {
            float t = elapsed / deathDuration;
            foreach (Renderer r in renderers) {
                foreach (Material mat in r.materials) {
                    mat.SetFloat("_DissolveAmount", t);
                }
            }
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}