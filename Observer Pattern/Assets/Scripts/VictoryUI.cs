using UnityEngine;
using System.Collections;
using TMPro;

public class VictoryUI : MonoBehaviour {
    private TextMeshProUGUI text;

    void Start() {
        text = GetComponent<TextMeshProUGUI>();
    }
    void OnEnable() {
        EnemyHealth.FinalBossDeath += Show;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= Show;
    }
    public void Show() {
        StartCoroutine(ShowRoutine());
    }

    IEnumerator ShowRoutine() {
        for(int i = 0; i < 10; i++) {
            text.enabled = true;
            yield return new WaitForSeconds(0.25f);
            text.enabled = false;
            yield return new WaitForSeconds(0.25f);
        }
    }
}