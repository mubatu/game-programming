using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {
    [SerializeField] private float shakeDuration = 3f;
    [SerializeField] private float shakeMagnitude = 0.05f;
    [SerializeField] private float shakeSpeed = 25f;
    private CameraFollow cameraFollow;

    void Start() {
        cameraFollow = GetComponent<CameraFollow>();
    }

    public void Play() {
        StartCoroutine(ShakeRoutine());
    }

    IEnumerator ShakeRoutine() {
        Vector3 originalOffset = cameraFollow.GetOffset();
        float elapsed = 0f;

        while (elapsed < shakeDuration) {
            float t = 1f - (elapsed / shakeDuration);
            float x = Mathf.Sin(elapsed * shakeSpeed) * shakeMagnitude * t;
            float y = Mathf.Sin(elapsed * shakeSpeed * 1.3f) * shakeMagnitude * t;
            cameraFollow.SetOffset(originalOffset + new Vector3(x, y, 0));
            elapsed += Time.deltaTime;
            yield return null;
        }

        cameraFollow.SetOffset(originalOffset);
    }
}