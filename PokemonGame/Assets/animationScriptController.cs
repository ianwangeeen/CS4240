using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationScriptController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isWalkingBackwardsHash;
    int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isWalkingHash = Animator.StringToHash("isWalking");
        isWalkingBackwardsHash = Animator.StringToHash("isWalkingBackwards");
        isRunningHash = Animator.StringToHash("isRunning");

    }

    // Update is called once per frame
    void Update()
    {
        UpdateWalkingAnimation();
        UpdateRunningAnimation();
    }

    void UpdateWalkingAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isWalkingBackwards = animator.GetBool(isWalkingBackwardsHash);
        bool forwardPressed = Input.GetKey("w");
        bool backPressed = Input.GetKey("s");

        if (!isWalking && forwardPressed)
        {
            SetWalkingAnimation(true);
        }

        if (isWalking && !forwardPressed)
        {
            SetWalkingAnimation(false);
        }

        if (!isWalkingBackwards && backPressed)
        {
            SetWalkingBackAnimation(true);
        }

        if (isWalkingBackwards && !backPressed)
        {
            SetWalkingBackAnimation(false);
        }
    }

    void UpdateRunningAnimation()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey(KeyCode.LeftShift);

        if (!isRunning && forwardPressed && runPressed)
        {
            SetRunningAnimation(true);
        }

        if (isRunning && (!forwardPressed || !runPressed))
        {
            SetRunningAnimation(false);
        }
    }

    void SetWalkingAnimation(bool value)
    {
        animator.SetBool(isWalkingHash, value);
    }
    void SetWalkingBackAnimation(bool value)
    {
        animator.SetBool(isWalkingBackwardsHash, value);
    }

    void SetRunningAnimation(bool value)
    {
        animator.SetBool(isRunningHash, value);
    }
}
