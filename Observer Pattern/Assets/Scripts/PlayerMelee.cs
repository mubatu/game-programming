using UnityEngine;
using System.Collections;

public class PlayerMelee : MonoBehaviour {
    [SerializeField] private Transform weapon;
    [SerializeField] private float swingSpeed = 10f;
    [SerializeField] private float swingAngle = 120f;
    [SerializeField] public int damage = 25;
    [SerializeField] private float cooldown = 0.5f;
    private bool isSwinging = false;
    private Collider weaponCollider;

    void Start() {
        weaponCollider = weapon.GetComponentInChildren<Collider>();
        weaponCollider.isTrigger = false;
    }

    void Update() {
        if (Input.GetMouseButtonDown(1) && !isSwinging) {
            StartCoroutine(Swing());
        }
    }

    IEnumerator Swing() {
        isSwinging = true;
        weaponCollider.isTrigger = true;
        float swung = 0f;

        // Swing forward
        while (swung < swingAngle) {
            float step = swingSpeed * Time.deltaTime * 100f;
            weapon.localEulerAngles -= new Vector3(0, step, 0);
            swung += step;
            yield return null;
        }

        // Swing back
        swung = 0f;
        while (swung < swingAngle) {
            float step = swingSpeed * Time.deltaTime * 100f;
            weapon.localEulerAngles += new Vector3(0, step, 0);
            swung += step;
            yield return null;
        }

        weaponCollider.isTrigger = false;
        yield return new WaitForSeconds(cooldown);
        isSwinging = false;
    }

    void OnTriggerEnter(Collider other) {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null && isSwinging) {
            enemy.TakeDamage(damage);
        }
    }
}