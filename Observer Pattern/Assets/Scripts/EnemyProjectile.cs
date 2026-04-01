using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    [SerializeField] private float speed = 4f;
    [SerializeField] public int damage = 15;
    [SerializeField] private float lifetime = 15f;
    private Transform player;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifetime);
    }

    void OnEnable() {
        EnemyHealth.FinalBossDeath += DestroyProjectile;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= DestroyProjectile;
    }

    void Update() {
        if (player == null) {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            other.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        } else if (other.CompareTag("PlayerProjectile")) {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
    void DestroyProjectile() {
        Destroy(gameObject);
    }
}