using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCopy1 : MonoBehaviour
{
// aman
   // Rigidbody2D rb;
   // Animator anim;
    public Transform player;
    public int health = 20;
    
    // for Attacking
    public float awarenessRange;
    float disToPlayer;
    public Transform shootPoint;
   // public float attackRange;
    public GameObject bulletPrefab;

    public int BulletSpeed = 15;
    public float attackRate = 1;

    public Transform targetPosition;
  //  float attackTime;

    //public float bulletSpeed;
    // public Rigidbody2D weapon;
   // public Transform weaponPivot;


    public GameObject Gun;
    private SpriteRenderer sprite;
    private bool isShooting;
    private Animator _animator;
    


    void Start()
    {
        _animator = GetComponent<Animator>();
        /*rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();*/
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(startMovement());

    }

    // Update is called once per frame
    void Update()
    {
        disToPlayer = Vector3.Distance(transform.position, player.position);

        /*if (disToPlayer <= awarenessRange)
        {
            Attack();
        }*/

       
            if (disToPlayer <= awarenessRange)
            {


                if (!isShooting)
                {
                    isShooting = true;
                    AttackSimple();
                }

            
                Gun.transform.right = player.position - Gun.transform.position;
            }
            
        
        

    }
    
    IEnumerator startMovement()
    {

       
        yield return new WaitForSeconds(3);
        _animator.SetTrigger("walk");
       var rb = GetComponent<Rigidbody2D>();
       rb.velocity = new Vector2(1.5f,0);
        while (transform.position.x < targetPosition.position.x )
        {
            yield return null;
            
        }
        rb.velocity = Vector2.zero;
        // play snatch animation
        _animator.SetTrigger("idle");
        // play walk animation ( left )
        
        yield return null;
    }

    void AttackSimple()
    {
        
        StartCoroutine(ShootBullet());
        
    }

    IEnumerator ShootBullet()
    {
        Gun.transform.right = player.position - Gun.transform.position;
        while (true)
        {
           
          //  Gun.transform.LookAt(pos);
            disToPlayer = Vector3.Distance(transform.position, player.position);
            if (disToPlayer > awarenessRange)
            {
               if (disToPlayer > awarenessRange)
                {
                    isShooting = false;
                    break;
                }
            }
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position,Gun.transform.rotation,Gun.transform);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * BulletSpeed;
            bullet.layer = LayerMask.NameToLayer("weapon");
            // (bullet.transform.rotation.eulerAngles.normalized)
            bullet.transform.localScale *= 5;
            yield return new WaitForSeconds(attackRate);
        }
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Lgi h goli ");
        string name = other.gameObject.name;
        if ((name.Contains("dart") || name.Contains("bullet")) )
        {
            WinLevel.Instance.ShowWinLevelCanvas();
        }
    }

    /*void Attack()
    {
        Vector2 playerDir = player.position - transform.position;
        
        float angle = Mathf.Atan2(playerDir.y, playerDir.x) * Mathf.Rad2Deg;

        //weapon.rotation = angle;
        weaponPivot.rotation = Quaternion.Euler(0f, 0f, angle);

        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (Time.time > attackTime + attackRate)
        {
            RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, playerDir, attackRange);
            if (hit.transform == player)
            {
                Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
                //bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2( bulletSpeed,0));

            }
            attackTime = Time.time;
        }

    }*/
}
