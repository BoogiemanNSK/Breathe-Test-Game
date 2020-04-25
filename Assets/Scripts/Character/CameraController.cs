using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform Target;
    public float SmoothSpeed = 0.125f;
    
    private Vector3 _offset;

    private void Start() {
        _offset = Target.position - transform.position;
    }

    private void LateUpdate() {
        Vector3 desiredPos = Target.position - _offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, SmoothSpeed);
        transform.position = smoothedPos;

        transform.LookAt(Target);
    }
    
}
