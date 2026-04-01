using UnityEngine;

public class EnemyAttack : MonoBehaviour {
    [SerializeField] private GameObject fallingCubePrefab;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float meleeRange = 5f;
    [SerializeField] private float meleeCooldown = 2f;
    [SerializeField] private float projectileCooldown = 3f;
    [SerializeField] private float cubeSpeed = 5f;
    [SerializeField] private float cubeSpawnHeight = 4f;
    [SerializeField] private float projectileSpawnHeight = 4f;
    private float nextMeleeTime = 0f;
    private float nextProjectileTime = 0f;
    
    public bool bossActive = true;

    void OnEnable() {
        EnemyHealth.FinalBossDeath += BossIsDead;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= BossIsDead;
    }
    void Update() {
        if (!bossActive) return;
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (Time.time >= nextMeleeTime && distance <= meleeRange) {
            DropCube();
            nextMeleeTime = Time.time + meleeCooldown;
        }

        if (Time.time >= nextProjectileTime && distance > meleeRange) {
            ShootProjectile();
            nextProjectileTime = Time.time + projectileCooldown;
        }
    }

    void DropCube() {
        Vector3 spawnPos = new Vector3(player.position.x, cubeSpawnHeight, player.position.z);
        GameObject cube = Instantiate(fallingCubePrefab, spawnPos, Quaternion.identity);
        cube.GetComponent<Rigidbody>().velocity = Vector3.down * cubeSpeed;
    }

    void ShootProjectile() {
        Vector3 spawnPos = new Vector3(
            transform.position.x,
            transform.position.y + projectileSpawnHeight,
            transform.position.z
        );
        Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
    }
    void BossIsDead()
    {
        bossActive = false;
    }
}