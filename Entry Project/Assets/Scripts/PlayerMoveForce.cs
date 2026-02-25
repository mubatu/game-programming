using UnityEngine;

public class PlayerMoveForce : MonoBehaviour
{
    public Rigidbody rb;
    public float force = 10f;

    private float h;
    private float v;

    void Update()
    {
        // Uses Input Manager axes
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector3 dir = new Vector3(h, 0f, v);
        rb.AddForce(dir * force);
    }
}