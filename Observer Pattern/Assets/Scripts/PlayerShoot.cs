using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float fireRate = 0.3f;
    private float nextFireTime = 0f;

    void Update() {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime) {
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground"))) {
            Vector3 targetPoint = new Vector3(hit.point.x, spawnPoint.position.y, hit.point.z);
            Vector3 direction = (targetPoint - spawnPoint.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(projectilePrefab, spawnPoint.position, rotation);
        }
    }
}