using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpHeight = 10;
    public Vector3 respawnPos;
    
    private CharacterController characterController;
    private Animator animator;
    private Ragdoll ragdoll;
    new public Camera camera;
    private Score score;
    private Vector2 moveInput = new Vector2();
    private bool jumpInput = false;

    public bool isGrounded = true;
    private bool win = false;
    public bool isRespawning = false;
    public bool isTackling = false;
    public Vector3 velocity = new Vector3();
    public Vector3 hitDirection;

    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        ragdoll = GetComponentInChildren<Ragdoll>();
        camera = Camera.main;
        score = GetComponent<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        if (win) return;

        if (Input.GetMouseButtonDown(0) && isGrounded)
        {
            animator.SetBool("Tackle", true);
            StartCoroutine(Tackling());
        }
                
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        jumpInput = Input.GetButton("Jump");
        
        animator.SetFloat("Forwards", moveInput.y);
        animator.SetFloat("Side", moveInput.x);
        animator.SetBool("Jump", !isGrounded);

        if(transform.position.y < -10 && !ragdoll.ragdollOn)
            ragdoll.ragdollOn = true;
      
        if(ragdoll.ragdollOn && !isRespawning)
            StartCoroutine(Respawning());
        
        if(Input.GetKeyDown(KeyCode.E))
        {

            if(Physics.Raycast(camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)), out RaycastHit hitInfo, 25, LayerMask.GetMask("Interactable")) && 
                hitInfo.rigidbody.gameObject.CompareTag("Elevator"))
            {
                CallElevator button = hitInfo.rigidbody.gameObject.GetComponent<CallElevator>();
                if (button != null)
                    button.UseElevator();
            }
        }

    }

    void FixedUpdate()
    {
        if (win) return;

        Vector3 camForward = camera.transform.forward;
        camForward.y = 0;
        camForward.Normalize();

        if(ragdoll.ragdollOn)
        {
            return;
        }

        transform.forward = Quaternion.Slerp(Quaternion.Euler(transform.forward), Quaternion.Euler(camForward), 1) * camForward;

        Vector3 camRight = camera.transform.right;

        Vector3 delta = (moveInput.x * camRight + moveInput.y * camForward) * moveSpeed;

        if(isGrounded || moveInput.x != 0 || moveInput.y != 0)
        {
            velocity.x = delta.x;
            velocity.z = delta.z;
        }

        if (jumpInput && isGrounded && !animator.GetBool("Tackle"))
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

        if (!animator.GetBool("Tackle"))
            characterController.Move(velocity * Time.fixedDeltaTime);
        isGrounded = characterController.isGrounded;
    }

    private void OnControllerColliderHit(ControllerColliderHit _hit)
    {
        hitDirection = _hit.point - transform.position;
    }

    IEnumerator Respawning()
    {
        isRespawning = true;
        animator.SetBool("Tackle", false);
        score.AddDeathCount();
        yield return new WaitForSecondsRealtime(3);

        velocity = Vector3.zero;
        characterController.enabled = false;
        characterController.transform.position = respawnPos;

        ragdoll.ragdollOn = false;
        animator.enabled = true;

        characterController.enabled = true;
        isRespawning = false;
    }

    IEnumerator Tackling()
    {
        yield return new WaitForSecondsRealtime(1.5f);

        animator.SetBool("Tackle", false);
    }

    public void WinGame()
    {
        win = true;
    }
}
