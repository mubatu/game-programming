using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This object manages the input from the player.
// It listens for the M key or the S key to be pressed, and spawns more metals.
public class InputManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.S))
        {
            spawner.SpawnMoreMetal();
        }
    }
}
