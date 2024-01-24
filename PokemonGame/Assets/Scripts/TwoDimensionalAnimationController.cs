using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationController : MonoBehaviour
{
    Animator animator;
    public float speed; 
    float velocityX;
    float velocityZ;
    float velocityXSmooth;
    float velocityZSmooth;

    float acceleration = 20f; // Increased for faster acceleration
    float deceleration = 20f; // Increased for faster deceleration
    float walkSpeed = 2f;   // Adjust as needed
    float runSpeed = 4f;    // Adjust as needed
    private CharacterController characterController;

    // Animator animator;
    // float walkSpeed = 0.5f;
    // float runSpeed = 2.0f;
    // float velocityXSmooth;
    // float velocityZSmooth;
    // float velocityZ = 0.0f;
    // float velocityX = 0.0f;
    // public float acceleration = 10.0f;
    // public float deceleration = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    // void Update()
    // {
    //     bool forwardPressed = Input.GetKey("w");
    //     bool leftPressed = Input.GetKey("a");
    //     bool rightPressed = Input.GetKey("d");
    //     bool runPressed = Input.GetKey("left shift");

    //     if (forwardPressed && velocityZ < 0.5f && !runPressed) {
    //         velocityZ += Time.deltaTime * acceleration;
    //     }

    //     if (leftPressed && velocityX > -0.5f && !runPressed) {
    //         velocityX -= Time.deltaTime * acceleration;
    //     }

    //     if (rightPressed && velocityX < 0.5f && !runPressed) {
    //         velocityX += Time.deltaTime * acceleration;
    //     }

    //     if (!forwardPressed && velocityZ > 0.0f) {
    //         velocityZ -= Time.deltaTime * deceleration;
    //     }

    //     if (!forwardPressed && velocityZ < 0.0f) {
    //         velocityZ = 0.0f;
    //     }

    //     if (!leftPressed && velocityX < 0.0f) {
    //         velocityX += Time.deltaTime * deceleration;
    //     }

    //     if (!rightPressed && velocityX > 0.0f) {
    //         velocityX -= Time.deltaTime * deceleration;
    //     }

    //     if (!leftPressed && !rightPressed && velocityX != 0.0f && (velocityX > -0.05f && velocityX < 0.05f)) {
    //         velocityX = 0.0f;
    //     }

    //     animator.SetFloat("Velocity Z", velocityZ);
    //     animator.SetFloat("Velocity X", velocityX);
    // }

    void Update()
    {
        HandleMovementInput();
        UpdateAnimator();
    }

    void HandleMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        float targetVelocityX = horizontalInput * (runPressed ? runSpeed : walkSpeed);
        float targetVelocityZ = verticalInput * (runPressed ? runSpeed : walkSpeed);

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        if (horizontalInput == 0)
        {
            velocityX = 0f;
        }
        else
        {
            velocityX = Mathf.Lerp(velocityX, targetVelocityX, Time.deltaTime * acceleration);
        }

        if (verticalInput == 0)
        {
            velocityZ = 0f;
        }
        else
        {
            velocityZ = Mathf.Lerp(velocityZ, targetVelocityZ, Time.deltaTime * acceleration);
        }
    }

    void UpdateAnimator()
    {
        animator.SetFloat("Velocity Z", velocityZ);
        animator.SetFloat("Velocity X", velocityX);
    }
}
