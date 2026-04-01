using UnityEngine;
using System.Collections;

public class GoldDrop : MonoBehaviour {
    [SerializeField] private GameObject goldLootPrefab;
    [SerializeField] private Transform bossTransform;
    [SerializeField] private float dropDelay = 3f;

    void OnEnable() {
        EnemyHealth.FinalBossDeath += Drop;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= Drop;
    }

    public void Drop() {
        StartCoroutine(DropRoutine());
    }

    IEnumerator DropRoutine() {
        yield return new WaitForSeconds(dropDelay);
        if (bossTransform != null){
            Vector3 spawnPos = new Vector3(bossTransform.position.x, 1f, bossTransform.position.z);
            Instantiate(goldLootPrefab, spawnPos, Quaternion.identity);
        } else {
            Instantiate(goldLootPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}