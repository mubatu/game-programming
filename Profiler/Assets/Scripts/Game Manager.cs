using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This object manages the communications between other classes.
// Manages the game state.
// Keeps track of the total number of metals in the game.
public class GameManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    public int maxMetals = 1000;
    [HideInInspector] public int totalMetals = 0; // This is used by the Spawner to know when to stop spawning.

    void Start()
    {
        spawner.SpawnFirstMetals(maxMetals);
    }

    // Calculate the center of mass of the metals in the game.
    public Vector3 CalculateCenterOfMass()
    {
        GameObject[] metals = GameObject.FindGameObjectsWithTag("Metal");
        float totalX = 0;
        float totalY = 0;
        float totalZ = 0;
        foreach (GameObject metal in metals)
        {
            totalX += metal.transform.position.x;
            totalY += metal.transform.position.y;
            totalZ += metal.transform.position.z;
        }
        return new Vector3(totalX / metals.Length, totalY / metals.Length, totalZ / metals.Length);
    }

    // Destroy a metal. Send command to spawn a new one.
    public void DestroyMetal(Metal metal)
    {
        Destroy(metal.gameObject);
        //metal.gameObject.SetActive(false);
        totalMetals--;
        spawner.SpawnNewMetal();
    }
}
