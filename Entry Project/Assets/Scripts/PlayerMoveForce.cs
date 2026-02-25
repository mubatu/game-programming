using UnityEngine;

public class PlayerMoveForce : MonoBehaviour
{
    public Rigidbody rb;          // drag your movable's Rigidbody here
    public float force = 10f;     // tweak in Inspector

    private float h;
    private float v;

    void Update()
    {
        // Uses Input Manager axes: A/D + Left/Right and W/S + Up/Down
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(h, 0f, v);
        rb.AddForce(dir * force);
    }
}