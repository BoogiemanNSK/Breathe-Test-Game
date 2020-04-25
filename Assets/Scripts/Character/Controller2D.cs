using UnityEngine;

public class Controller2D : MonoBehaviour {

    public float MoveSpeed;
    public float JumpForce;
    public float GravityScale;
    public GameObject Char;
    
    private CharacterController _playerPhysics;
    private Vector3 _moveDirection;
    private int _jumpsCount, _lastDir;
    
    private void Start() {
        _playerPhysics = GetComponent<CharacterController>();
        _jumpsCount = 0;
        _lastDir = 1;
    }

    private void Update() {
        if (GameState.IsGameFinished()) return;
        
        _moveDirection = new Vector3(Input.GetAxis("Horizontal") * MoveSpeed, _moveDirection.y);

        if (_playerPhysics.isGrounded) {
            _jumpsCount = 0;
        }
        
        if (Input.GetAxis("Vertical") > 0 && Input.GetButtonDown("Vertical")) {
            if (_jumpsCount < 2) {
                _moveDirection = new Vector3(_playerPhysics.velocity.x, JumpForce);
                _jumpsCount++;
            }
        }

        var dir = 0;
        if (_moveDirection.x > 0) { dir = 1; }
        if (_moveDirection.x < 0) { dir = -1; }
        if (dir != 0 && dir != _lastDir) {
            Char.transform.Rotate(0, 180, 0);
            _lastDir = dir;
        }

        _moveDirection.y += Physics.gravity.y * GravityScale * Time.deltaTime;
        
        if (!_playerPhysics.enabled) { return; }
        _playerPhysics.Move(_moveDirection * Time.deltaTime);
    }

    public void Die() {
        if (GameState.IsGameFinished()) return;
        
        _playerPhysics.enabled = false;
        
        var rb = gameObject.AddComponent<Rigidbody>();

        if (_moveDirection.x >= 0) {
            rb.AddForce(Vector3.right * 2, ForceMode.Impulse);
        } else {
            rb.AddForce(Vector3.left * 2, ForceMode.Impulse);
        }
    }
    
}
