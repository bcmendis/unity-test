using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool isJump = false;
    bool isCrouch = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump")) {
            isJump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            isCrouch = true;
        }
        else if (Input.GetButtonUp("Crouch")) {
            isCrouch = false;
        }

    }

    public void onCrouching(bool isCrouching) {

        animator.SetBool("IsCrouching", isCrouching);

    }

    public void OnLanding() {

        animator.SetBool("IsJumping", false);

    }

    void FixedUpdate() 
    {

        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, isCrouch, isJump);
        isJump = false;


    }
}
