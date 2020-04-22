using UnityEngine;

public class Controller2D : PhysicsObject {
    public float MaxSpeed = 7;
    public float JumpTakeOffSpeed = 7;

    //private Animator _animator;

    // Use this for initialization
    private void Awake () {
        //_animator = GetComponent<Animator> ();
    }

    protected override void ComputeVelocity() {
        var move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && Grounded) {
            Velocity.y = JumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (Velocity.y > 0) {
                Velocity.y *= 0.5f;
            }
        }

        //_animator.SetBool ("grounded", Grounded);
        //_animator.SetFloat ("velocityX", Mathf.Abs (Velocity.x) / MaxSpeed);

        TargetVelocity = move * MaxSpeed;
    }
}
