using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public Transform spawnPoint;
    public KeyCode spawnKey = KeyCode.Space;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            // Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);

            Vector3 pos = spawnPoint != null ? spawnPoint.position : transform.position;
            Instantiate(prefabToSpawn, pos, Quaternion.identity);
        }
    }
}
