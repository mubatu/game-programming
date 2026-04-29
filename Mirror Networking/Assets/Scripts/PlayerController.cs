using Mirror;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (!isLocalPlayer) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0.1f)
            CmdMove(dir.normalized);
    }

    [Command]  // Client calls, Server executes
    void CmdMove(Vector3 direction)
    {
        // Server validates the input
        if (direction.magnitude > 1.1f) return;

        // Server moves the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
