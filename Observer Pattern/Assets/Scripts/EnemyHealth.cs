using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {
    [SerializeField] public int maxHealth = 500;
    [SerializeField] private Slider healthBar;
    [SerializeField] private VictoryUI victoryUI;
    [SerializeField] private WinSound winSound;
    [SerializeField] private PlayerVictoryDance playerVictoryDance;
    [SerializeField] private AchievementUI achievementUI;
    [SerializeField] private GoldDrop goldDrop;
    [SerializeField] private CameraShake cameraShake;
    [SerializeField] private PlayerHealth playerHealth;
    private BossDeath bossDeath;
    private int currentHealth;
    private bool isDead = false;

    void Start() {
        currentHealth = maxHealth;
        healthBar.value = 1f;
        bossDeath = GetComponent<BossDeath>();
    }

    public void TakeDamage(int amount) {
        if (isDead) return;
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        healthBar.value = (float)currentHealth / maxHealth;
        if (currentHealth <= 0) {
            isDead = true;
            Die();
        }
    }

    void Die() {
        victoryUI.Show();
        winSound.Play();
        playerVictoryDance.Play();
        bossDeath.Play();
        achievementUI.Show();
        goldDrop.Drop();
        cameraShake.Play();
        playerHealth.Regen();
    }
}