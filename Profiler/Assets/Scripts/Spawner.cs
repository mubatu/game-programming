using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.CompilerServices;

// This object handles every spawning operation.
public class Spawner : MonoBehaviour
{
    public GameObject metalPrefab;
    float spawnRange = 49f;
    [SerializeField] GameManager gameManager;
    float spawnRatio = 0.2f;

    [SerializeField] GameObject metalParent;

    // Spawn the first batch of metals at a random location within the map's boundaries.
    public void SpawnFirstMetals(int maxMetals)
    {
        for (int i = 0; i < maxMetals; i++)
        {
            float randomX = UnityEngine.Random.Range(-spawnRange, spawnRange);
            float randomZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
            Vector3 randomPos = new Vector3(randomX, 5f, randomZ);
            
            Instantiate(metalPrefab, randomPos, Quaternion.identity, metalParent.transform);
            gameManager.totalMetals++;
        }
    }

    // Spawn a new singular metal at a random location within the map's boundaries.
    // Only called after a metal is destroyed.
    public void SpawnNewMetal(){
        if (gameManager.totalMetals >= gameManager.maxMetals) return;

        float randomX = UnityEngine.Random.Range(-spawnRange, spawnRange);
        float randomZ = UnityEngine.Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(randomX, 5f, randomZ);
        Instantiate(metalPrefab, randomPos, Quaternion.identity, metalParent.transform);
        // metal.transform.position = randomPos;
        // metal.gameObject.SetActive(true);
        gameManager.totalMetals++;
    }

    // Spawn a batch of metals at a random location within the map's boundaries.
    // Called when the player presses the M key or the S key.
    // The number of metals to spawn is maxMetals * spawnRatio, which is 0.2f.
    // The metals are spawned around the center of mass of the existing metals.
    // Spawn location is based on the center of mass, with a random offset.
    // The spawn location is clamped to the spawnRange to prevent out of bounds spawning.
    public void SpawnMoreMetal(){
        if (gameManager.totalMetals > gameManager.maxMetals) return;
        int numToSpawn = Mathf.RoundToInt(gameManager.maxMetals * spawnRatio);
        for (int i = 0; i < numToSpawn; i++)
        {
            Vector3 centerOfMass = gameManager.CalculateCenterOfMass();
            Vector3 randomOffset = new Vector3(UnityEngine.Random.Range(-Mathf.Sqrt(numToSpawn), Mathf.Sqrt(numToSpawn)), 5f, UnityEngine.Random.Range(-Mathf.Sqrt(numToSpawn), Mathf.Sqrt(numToSpawn)));
            Vector3 spawnPos = centerOfMass + randomOffset;
            //clamp the spawnPos to the spawnRange
            spawnPos = new Vector3(Mathf.Clamp(spawnPos.x, -spawnRange, spawnRange), 5f, Mathf.Clamp(spawnPos.z, -spawnRange, spawnRange));
            Instantiate(metalPrefab, spawnPos, Quaternion.identity, metalParent.transform);
            gameManager.totalMetals++;
        }
    }
}
