using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This object picks a random point on the map, within bounds of the map, and moves towards it.
// It also attracts nearby metals to it, with realistic power calculations.
// Any metal that hits the magnet is destroyed, and a new metal is spawned in a random location.
public class FrenzyMagnet : MonoBehaviour
{
    float speed = 20f;

    float attractPower = 400f;
    private float attractCutoff; // We don't need to attract metals that are too far away.

    private Vector3 targetWaypoint;

    [SerializeField] GameManager gameManager;
    [SerializeField] Spawner spawner;

    // Initialize the magnet.
    void Start()
    {
        PickNewWaypoint();
        attractCutoff = Mathf.Sqrt(attractPower);
    }

    // Move the magnet towards the target waypoint. Select new one if it's close enough (2f units).
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint) < 2f)
        {
            PickNewWaypoint();
        }

        // AttractCloseMetals();
    }
    void FixedUpdate()
    {
        AttractCloseMetals();
    }

    // Attract nearby metals to the magnet. By applying force on their rigidbodies.
    // Magnitude should be attractPower / distance squared.
    void AttractCloseMetals(){
        GameObject[] metals = GameObject.FindGameObjectsWithTag("Metal");
        foreach (GameObject metal in metals)
        {
            if (Vector3.Distance(metal.transform.position, transform.position) < attractCutoff)
            {
                float distance = Vector3.Distance(metal.transform.position, transform.position);
                Vector3 direction = (transform.position - metal.transform.position).normalized;
                float magnitude = attractPower / (distance * distance);
                metal.GetComponent<Rigidbody>().AddForce(direction * magnitude, ForceMode.Acceleration);
            }
        }
    }
    
    // Pick a new random waypoint on the map.
    void PickNewWaypoint()
    {
        float randomX = Random.Range(-49f, 49f);
        float randomZ = Random.Range(-49f, 49f);
        targetWaypoint = new Vector3(randomX, 2f, randomZ);
    }

    // If the magnet collides with a metal, destroy it.
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Metal")
        {
            gameManager.DestroyMetal(collision.gameObject.GetComponent<Metal>());
        }
    }
}
