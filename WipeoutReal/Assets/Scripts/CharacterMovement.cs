using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    
    private CharacterController characterController;
    private Animator animator;
    public Camera camera;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput = false;

    public bool isGrounded = true;
    public Vector3 velocity = new Vector3();
    public Vector3 hitDirection;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
        animator.SetFloat("Forwards", moveInput.y);
        animator.SetFloat("Side", moveInput.x);
        animator.SetBool("Jump", !isGrounded);
    }

    void FixedUpdate()
    {
        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        transform.forward = Quaternion.Slerp(Quaternion.Euler(transform.forward), Quaternion.Euler(camForward), 1) * camForward;

        Vector3 camRight = camera.transform.right;
        
        Vector3 delta = (moveInput.x * camRight + moveInput.y * camForward) * moveSpeed;

        if(isGrounded || moveInput.x != 0 || moveInput.y != 0)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }

        if (jumpInput && isGrounded)
        {
            float jumpVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);

            velocity.y = jumpVelocity;
        }

        if (isGrounded && velocity.y < 0)
            velocity.y = 0;

        velocity += Physics.gravity * Time.fixedDeltaTime;

        if (!isGrounded)
            hitDirection = Vector3.zero;

        if(moveInput.x == 0 && moveInput.y == 0)
        {
            Vector3 horizontalHitDirection = hitDirection;
            horizontalHitDirection.y = 0;
            float displacement = horizontalHitDirection.magnitude;
            if (displacement > 0 && !Physics.Raycast(transform.position, -transform.up, 0.1f))
                velocity -= 0.2f * horizontalHitDirection / displacement;
        }

        characterController.Move(velocity * Time.fixedDeltaTime);
        isGrounded = characterController.isGrounded;
    }

    private void OnControllerColliderHit(ControllerColliderHit _hit)
    {
        hitDirection = _hit.point - transform.position;
    }
}
