using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {
    public CharacterController2D controller;
    
    public float runSpeed = 40f;
    private float horizontalMove = 0f;
    private Animator anim;
    private Rigidbody2D rigBody;
    bool jump = false;

    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
        }
    }

    void FixedUpdate () {

        if (horizontalMove != 0) {
            anim.SetBool("isRunning", true);
        } else {
            anim.SetBool("isRunning", false);
        }

        if (rigBody.velocity.y > 0.3f) {
            anim.SetBool("jump", true);
            anim.SetBool("falling", false);
        } else if (rigBody.velocity.y < -0.3f) {
            anim.SetBool("falling", true);
            anim.SetBool("jump", false);
        } else if (Math.Abs(rigBody.velocity.y) == 0) {
            anim.SetBool("jump", false);
            anim.SetBool("falling", false);
        }
                    
        anim.SetFloat("movement", Math.Abs(rigBody.velocity.x));
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;
    }
}
