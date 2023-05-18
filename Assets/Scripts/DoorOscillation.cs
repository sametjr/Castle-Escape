using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOscillation : MonoBehaviour
{
    public Rigidbody rb;
    HingeJoint hinge;
    public FacingDirection facingDirection;
    private Vector3 forceAxis;
    public float force;
    private bool isPlayerTouching = false;
    JointMotor motor;
    private float velocity;
    private float angle;
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();
        switch (facingDirection)
        {
            case FacingDirection.PlusX:
                forceAxis = Vector3.right;
                break;
            case FacingDirection.PlusY:
                forceAxis = Vector3.up;
                break;
            case FacingDirection.PlusZ:
                forceAxis = Vector3.forward;
                break;
            case FacingDirection.MinusX:
                forceAxis = Vector3.left;
                break;
            case FacingDirection.MinusY:
                forceAxis = Vector3.down;
                break;
            case FacingDirection.MinusZ:
                forceAxis = Vector3.back;
                break;
            default:
                break;
        }
    }
    private void Update()
    {
        angle = hinge.angle;
        if ((angle < 15 || angle > -15) && !isPlayerTouching)
        {
            rb.AddForce(forceAxis * force);
        }
        else if(!isPlayerTouching)
        {
            rb.velocity = Vector3.zero;
            motor.targetVelocity = -angle;
            hinge.motor = motor;
        }


    }

    public enum FacingDirection
    {
        PlusX,
        PlusY,
        PlusZ,
        MinusX,
        MinusY,
        MinusZ
    }


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            isPlayerTouching = true;
        }
    }

    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Player") {
            isPlayerTouching = false;
        }
    }
}
