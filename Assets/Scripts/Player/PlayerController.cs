using System.Collections;
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
    private bool isMoving = false;

    // for Flip
    public bool movingRight;
    Vector3 theScale;
    public Transform firePoint;

    [SerializeField] PlayerHealth playerHealth;
    private Animator _animator;
    private PlayerAttack _playerAttack;

 

    

    void Start()
    {
        _playerAttack = GetComponent<PlayerAttack>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        movingRight = true;
        _animator = GetComponent<Animator>();
        
        // temporary music location
        FindObjectOfType<AudioManager>().Play("Music");

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && grounded && !playerHealth.isDead)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jumpHeight));
            // rb.velocity = new Vector2(rb.velocity.x, jumpHeight);

            FindObjectOfType<AudioManager>().Play("Jump");
          
        }


    }

    void FixedUpdate()
    {
        if(playerHealth.isDead) { return; }

        // for checking is grounded
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
        // for moving Left and Right
        float move = Input.GetAxis("Horizontal");


        if (move != 0 && !isMoving && grounded)  // for animation
        {
            FindObjectOfType<AudioManager>().Play("Walk");
            isMoving = true;
            
            _animator.SetTrigger("walk");
            
           
            

        }

        if (move == 0 && isMoving)
        {
            isMoving = false;
            _animator.SetTrigger("idle");
        }
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
