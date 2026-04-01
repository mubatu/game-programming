using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AchievementUI : MonoBehaviour {
    [SerializeField] private float slideDuration = 0.5f;
    [SerializeField] private float stayDuration = 4f;
    [SerializeField] private float offScreenX = 600f;
    [SerializeField] private float onScreenX = -220f;
    private RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(offScreenX, rectTransform.anchoredPosition.y);
    }

    public void Show() {
        StartCoroutine(SlideRoutine());
    }

    IEnumerator SlideRoutine() {
        yield return StartCoroutine(Slide(offScreenX, onScreenX));
        yield return new WaitForSeconds(stayDuration);
        yield return StartCoroutine(Slide(onScreenX, offScreenX));
    }

    IEnumerator Slide(float from, float to) {
        float elapsed = 0f;
        while (elapsed < slideDuration) {
            float t = elapsed / slideDuration;
            float smoothT = t * t * (3f - 2f * t); // smoothstep
            float x = Mathf.Lerp(from, to, smoothT);
            rectTransform.anchoredPosition = new Vector2(x, rectTransform.anchoredPosition.y);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = new Vector2(to, rectTransform.anchoredPosition.y);
    }
}