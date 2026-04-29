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

    [SyncVar(hook = nameof(OnHealthChanged))]
    public int health = 100;

    // Hook: called on ALL CLIENTS when health changes
    void OnHealthChanged(int oldHealth, int newHealth)
    {
        // Change color: green (100) to red (0)
        float ratio = newHealth / 100f;
        GetComponent<Renderer>().material.color =
            Color.Lerp(Color.red, Color.green, ratio);
    }

    void OnTriggerStay(Collider other)
    {
        if (!isServer) return;  // Only server applies damage

        health -= 1;
        // SyncVar auto-syncs to all clients
        // OnHealthChanged hook fires on every client

        RpcDamageFlash();  // Server tells ALL clients to show effect
    }

    [ClientRpc]  // Runs on ALL clients
    void RpcDamageFlash()
    {
        // Brief scale pulse for visual feedback
        StartCoroutine(DamageFlashCoroutine());
    }

    IEnumerator DamageFlashCoroutine()
    {
        transform.localScale = Vector3.one * 1.3f;
        yield return new WaitForSeconds(0.1f);
        transform.localScale = Vector3.one;
    }


}
