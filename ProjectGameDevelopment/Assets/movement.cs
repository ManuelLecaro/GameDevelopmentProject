using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public Player controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool punch=false;
    bool crouch = false;
    bool grounded = true;

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping",true);
        }
        if(Input.GetButtonDown("Fire1")){
            punch=true;
            animator.SetBool("isPunching",true);
        }

        //if (Input.GetButtonDown("Crouch"))
        //{
        //    crouch = true;
        //}
        //else if (Input.GetButtonUp("Crouch"))
        //{
          //  crouch = false;
        //}

    }

    public void onLanding(){
        animator.SetBool("isJumping",false);
    }

    public void onPunching(){
        animator.SetBool("isPunching",false);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        grounded = false;
        punch=false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        grounded = true;

    }
    void OnTriggerStay2D(Collider2D collision)
    {
        
        grounded = true;

    }

}
