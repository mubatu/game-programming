using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] public int maxHealth = 100;
    [SerializeField] private Slider healthBar;
    [SerializeField] private float regenDuration = 3f;
    private int currentHealth;

    void Start() {
        currentHealth = maxHealth;
        healthBar.value = 1f;
    }

    public void TakeDamage(int amount) {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = (float)currentHealth / maxHealth;
        Debug.Log("Player HP: " + currentHealth);
        if (currentHealth <= 0) {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
        }
    }

    public void Regen() {
    StartCoroutine(RegenRoutine());
    }

    IEnumerator RegenRoutine() {
        float elapsed = 0f;
        int startHealth = currentHealth;

        while (elapsed < regenDuration) {
            float t = elapsed / regenDuration;
            int newHealth = Mathf.RoundToInt(Mathf.Lerp(startHealth, maxHealth, t));
            SetHealth(newHealth);
            elapsed += Time.deltaTime;
            yield return null;
        }

        SetHealth(maxHealth);
    }

    void SetHealth(int health) {
        currentHealth = health;
        healthBar.value = (float)currentHealth / maxHealth;
    }
}