using UnityEngine;

public class Controller2D : MonoBehaviour {

    public float MoveSpeed;
    public float JumpForce;
    public float GravityScale;
    
    private CharacterController _playerPhysics;
    //private Animator _animator;
    private Vector3 _moveDirection;
    private int _jumpsCount;

    private void Start() {
        _playerPhysics = GetComponent<CharacterController>();
        //_animator = GetComponent<Animator>();

        _jumpsCount = 0;
    }

    private void Update() {
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

        _moveDirection.y += Physics.gravity.y * GravityScale;
        _playerPhysics.Move(_moveDirection * Time.deltaTime);
    }
    
}
