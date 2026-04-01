using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockDoor : MonoBehaviour
{
    [SerializeField] public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnEnable() {
        EnemyHealth.FinalBossDeath += DestroyDoor;
    }
    void OnDisable() {
        EnemyHealth.FinalBossDeath -= DestroyDoor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void DestroyDoor()
    {
        door.SetActive(false);
    }
}
