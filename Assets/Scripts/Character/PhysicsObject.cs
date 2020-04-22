using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour {
    public float MinGroundNormalY = .65f;
    public float GravityModifier = 1f;

    protected Vector2 TargetVelocity;
    protected bool Grounded;
    protected Vector2 GroundNormal;
    protected Rigidbody2D Rb2d;
    protected Vector2 Velocity;
    protected ContactFilter2D ContactFilter;
    protected RaycastHit2D[] HitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> HitBufferList = new List<RaycastHit2D> (16);
    
    protected const float MIN_MOVE_DISTANCE = 0.001f;
    protected const float SHELL_RADIUS = 0.01f;

    private void OnEnable() {
        Rb2d = GetComponent<Rigidbody2D> ();
    }

    private void Start ()  {
        ContactFilter.useTriggers = false;
        ContactFilter.SetLayerMask (Physics2D.GetLayerCollisionMask (gameObject.layer));
        ContactFilter.useLayerMask = true;
    }

    private void Update ()  {
        TargetVelocity = Vector2.zero;
        ComputeVelocity ();    
    }

    protected virtual void ComputeVelocity() {}

    private void FixedUpdate() {
        Velocity += Physics2D.gravity * (GravityModifier * Time.deltaTime);
        Velocity.x = TargetVelocity.x;
        Grounded = false;

        var deltaPosition = Velocity * Time.deltaTime;
        var moveAlongGround = new Vector2 (GroundNormal.y, -GroundNormal.x);

        var move = moveAlongGround * deltaPosition.x;
        Movement (move, false);

        move = Vector2.up * deltaPosition.y;
        Movement (move, true);
    }

    private void Movement(Vector2 move, bool yMovement) {
        var distance = move.magnitude;

        if (distance > MIN_MOVE_DISTANCE) {
            var count = Rb2d.Cast (move, ContactFilter, HitBuffer, distance + SHELL_RADIUS);
            HitBufferList.Clear ();
            for (var i = 0; i < count; i++) {
                HitBufferList.Add (HitBuffer [i]);
            }

            foreach (var t in HitBufferList) {
                var currentNormal = t.normal;
                if (currentNormal.y > MinGroundNormalY)  {
                    Grounded = true;
                    if (yMovement)  {
                        GroundNormal = currentNormal;
                        currentNormal.x = 0;
                    }
                }

                var projection = Vector2.Dot (Velocity, currentNormal);
                if (projection < 0)  {
                    Velocity = Velocity - projection * currentNormal;
                }

                var modifiedDistance = t.distance - SHELL_RADIUS;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }
            
        }

        Rb2d.position += move.normalized * distance;
    }
}
