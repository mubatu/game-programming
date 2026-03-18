using System.Collections;
using UnityEngine;

public class LaserBlinker : MonoBehaviour
{
    // You can change these times in the Unity Inspector!
    public float timeOn = 2f;
    public float timeOff = 2f;

    void Start()
    {
        // Start the Coroutine as soon as the game begins
        StartCoroutine(BlinkRoutine());
    }

    // This is the Coroutine
    IEnumerator BlinkRoutine()
    {
        while (true) // This creates an infinite loop
        {
            // 1. Turn ON all child cylinders
            foreach (Transform child in transform) 
            {
                child.gameObject.SetActive(true);
            }
            // Wait for 'timeOn' seconds
            yield return new WaitForSeconds(timeOn);

            // 2. Turn OFF all child cylinders
            foreach (Transform child in transform) 
            {
                child.gameObject.SetActive(false);
            }
            // Wait for 'timeOff' seconds
            yield return new WaitForSeconds(timeOff);
        }
    }
}