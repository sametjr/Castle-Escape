using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    
    [SerializeField] private Animator animator;
    [SerializeField] private float speed = 5f;
    [SerializeField] private FloatingJoystick joystick;
    public bool canMove = true;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        if (!canMove) return;
        rb.velocity = new Vector3(joystick.Horizontal * speed, 0, joystick.Vertical * speed);
        if (rb.velocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("isRunning", true);
        }

        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("attack");
        }
    }
}
