using UnityEngine;

public class DoorController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // We check if the object crashing into the door has the tag "Key"
        if (collision.gameObject.CompareTag("Key"))
        {
            Debug.Log("Key detected! Opening door and ending game. You Win!");
            
            // "Open" the door by hiding it
            gameObject.SetActive(false);
            
            // End the game by stopping time
            GameManager.instance.WinGame(); 
        }
    }
}