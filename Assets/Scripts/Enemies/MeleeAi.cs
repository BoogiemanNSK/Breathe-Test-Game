using UnityEngine;

public class MeleeAi : MonoBehaviour {

    public int MoveSpeed;
    public Collider PointA, PointB; // A - Left, B - Right

    private Vector3 _moveDirection;

    private void Start() {
        _moveDirection = Vector3.right * MoveSpeed;
    }

    private void Update() {
        transform.position += _moveDirection * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) {
        // If bumped into player
        if (other.CompareTag(Constants.PLAYER_TAG)) {
            EventManager.TriggerEvent(Constants.PLAYER_DEATH_EVENT_NAME);
        }
        // If reached point A or B
        if (other == PointA) {
            _moveDirection = Vector3.right * MoveSpeed;
        }
        if (other == PointB) {
            _moveDirection = Vector3.left * MoveSpeed;
        }
    }
    
}
