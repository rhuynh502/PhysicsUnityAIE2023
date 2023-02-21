using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    
    private CharacterController characterController;
    public Camera camera;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput = false;

    public bool isGrounded = true;
    public Vector3 velocity = new Vector3();

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
    }

    void FixedUpdate()
    {
        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

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

        characterController.Move(velocity * Time.fixedDeltaTime);
        isGrounded = characterController.isGrounded;
    }
}
