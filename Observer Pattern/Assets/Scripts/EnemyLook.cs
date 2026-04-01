using UnityEngine;

public class EnemyLook : MonoBehaviour {
    [SerializeField] private Transform player;

    void Update() {
        if (player == null) return;
        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        if (direction != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(direction);
    }
}