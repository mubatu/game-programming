using UnityEngine;
using System.Collections;
using TMPro;

public class GoldLoot : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private float floatSpeed = 1.5f;
    [SerializeField] private float floatDuration = 1.5f;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            StartCoroutine(CollectRoutine());
        }
    }

    IEnumerator CollectRoutine() {
        // Disable the gold mesh so it disappears immediately on touch
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = false;

        // Disable collider so it can't be collected twice
        GetComponent<Collider>().enabled = false;

        // Show and float the text
        goldText.gameObject.SetActive(true);
        Vector3 startPos = goldText.transform.position;
        float elapsed = 0f;

        while (elapsed < floatDuration) {
            float t = elapsed / floatDuration;
            goldText.transform.position = Vector3.Lerp(startPos, 
                startPos + Vector3.up * floatSpeed, t);
            Color c = goldText.color;
            c.a = Mathf.Lerp(1f, 0f, t);
            goldText.color = c;
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }
}