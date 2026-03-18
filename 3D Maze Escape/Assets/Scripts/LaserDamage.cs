using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the laser is the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("ZAPPED! The player hit the laser. Game Over.");
            
            GameManager.instance.GameOver(); // Game over
        }
    }
}