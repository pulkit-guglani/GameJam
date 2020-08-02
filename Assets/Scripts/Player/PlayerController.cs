﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    //Animator anim;

    // for Movement
    public float movSpeed;

    // for Jump
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGround;
    public float jumpHeight;
    bool grounded;

    // for Flip
    bool movingRight;
    Vector3 theScale;
    public Transform firePoint;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        movingRight = true;

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
            // rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

            FindObjectOfType<AudioManager>().Play("Jump");
          
        }

        
    }

    void FixedUpdate()
    {
        // for checking is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
        
        // for moving Left and Right
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movSpeed * move , rb.velocity.y);

        if(movingRight && move < 0)
        {
            flip();
        }
        else if(!movingRight && move > 0)
        {
            flip();
        }

        
    }

    void flip()
    {
        movingRight = !movingRight;
        theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        firePoint.Rotate(0, 180, 0);
    }

}
