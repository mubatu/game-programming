using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private float runMultiplier = 2f;
    private Rigidbody rb;
    private Camera cam;

    void Start() {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void FixedUpdate() {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
    
        Vector3 camForward = cam.transform.forward;
        camForward.y = 0;
        camForward.Normalize();
    
        Vector3 camRight = cam.transform.right;
        camRight.y = 0;
        camRight.Normalize();
    
        Vector3 moveDir = (camForward * v + camRight * h).normalized;
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? moveSpeed * runMultiplier : moveSpeed;
        rb.velocity = new Vector3(moveDir.x * currentSpeed, rb.velocity.y, moveDir.z * currentSpeed);
    }

    void Update() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, LayerMask.GetMask("Ground"))) {
            Vector3 lookTarget = hit.point;
            lookTarget.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(lookTarget - transform.position);
        }
    }
}