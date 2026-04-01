using UnityEngine;

public class FallingCube : MonoBehaviour {
    [SerializeField] public int damage = 20;

    void OnEnable() {
        EnemyHealth.FinalBossDeath += DestroyCube;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= DestroyCube;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground")) {
            Destroy(gameObject);
        }
    }
    void DestroyCube() {
        Destroy(gameObject);
    }
}