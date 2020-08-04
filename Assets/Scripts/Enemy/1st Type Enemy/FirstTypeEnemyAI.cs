using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FirstTypeEnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public Transform player;

    // for Calculating distance between enemy and player
    public float awarenessRange;
    float disToPlayer;

    // for Chasing
    public bool chaseEnabled;
    public float chaseSpeed;
    


    // for attacking
    public float attackRange;
    public Transform shootPoint;
    public int damage;
    public float attackForce;
    public GameObject bulletPrefab;
    bool facingRight;

    // for Attack Rate
    public float attackRate;
    float attackTime;
    public Transform weapon;

    bool invisiblePlayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
  
    }

    // Update is called once per frame
    void Update()
    {
        invisiblePlayer = FindObjectOfType<PlayerAbilities>().invisibilityEnabled;

        //Debug.Log(invisiblePlayer);

        if(player != null && !invisiblePlayer)
        {
            disToPlayer = Vector3.Distance(transform.position, player.position);

            if(disToPlayer < awarenessRange && disToPlayer > attackRange && chaseEnabled)
            {
                Chase();
            }
            else if (disToPlayer <= attackRange)
            {
                Attack();
            }
        }
        
    }

    void Attack()
    {
        Vector3 playerDir = player.position - transform.position;

        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

        weapon.rotation = Quaternion.Euler(0, 0, angle); 

        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, playerDir, attackRange);
        
        if(transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;

        }
        else if(transform.position.x > player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }

        if (Time.time > attackTime + attackRate)
        {
            if (hit.transform == player)
            {
                GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);

                if (facingRight)
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(attackForce, 0));
                }
                else
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-attackForce, 0));
                }

                //FindObjectOfType<PlayerHealth>().TakeDamage(damage);

                attackTime = Time.time;
            }
        }

    }


    void Chase()
    {
        if (transform.position.x < player.position.x)
        {
            rb.velocity = new Vector2(chaseSpeed, 0);
            transform.eulerAngles = new Vector3(0, 0, 0);
            facingRight = true;

        }
        else if (transform.position.x > player.position.x)
        {
            rb.velocity = new Vector2(-chaseSpeed, 0);
            transform.eulerAngles = new Vector3(0, 180, 0);
            facingRight = false;
        }


    }
}
