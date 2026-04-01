using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform target;
    private Vector3 offset;

    void Start() {
        offset = transform.position - target.position;
    }

    void LateUpdate() {
        transform.position = target.position + offset;
    }

    public Vector3 GetOffset() { return offset; }
    public void SetOffset(Vector3 newOffset) { offset = newOffset; }
}