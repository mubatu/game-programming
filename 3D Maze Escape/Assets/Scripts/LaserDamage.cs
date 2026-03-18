using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the laser is the Player
        if (other.CompareTag("Player"))
        {
            Debug.Log("ZAPPED! The player hit the laser. Game Over.");
            
            // Freeze the game to act as a Game Over state
            Time.timeScale = 0f; 
        }
    }
}