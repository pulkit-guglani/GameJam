using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOnlyShootPlayer : MonoBehaviour
{
// aman
   // Rigidbody2D rb;
   // Animator anim;
    public Transform player;

    public bool toShootPlayer = false;
    // for Attacking
    public float awarenessRange;
    float disToPlayer;
   // public Transform shootPoint;
   // public float attackRange;
    public GameObject bulletPrefab;

    public int BulletSpeed = 15;
    public float attackRate = 1;
  //  float attackTime;

    //public float bulletSpeed;
    // public Rigidbody2D weapon;
   // public Transform weaponPivot;


    public GameObject Gun;
    private SpriteRenderer sprite;
    private bool isShooting;
    


    void Start()
    {
        /*rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();*/
        sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        disToPlayer = Vector3.Distance(transform.position, player.position);

        /*if (disToPlayer <= awarenessRange)
        {
            Attack();
        }*/

        if (toShootPlayer)
        {
            if (disToPlayer <= awarenessRange && !FindObjectOfType<PlayerAbilities>().invisibilityEnabled)
            {


                if (!isShooting)
                {
                    isShooting = true;
                    AttackSimple();
                }

            
                Gun.transform.right = player.position - Gun.transform.position;
            } 
        }
        else
        {
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
        
        

    }

    void AttackSimple()
    {
       
        sprite.flipX = Gun.transform.rotation.eulerAngles.z > 90;
        StartCoroutine(ShootBullet());
        
    }

    IEnumerator ShootBullet()
    {
        while (true)
        {
           
          //  Gun.transform.LookAt(pos);
            disToPlayer = Vector3.Distance(transform.position, player.position);
            if (disToPlayer > awarenessRange || FindObjectOfType<PlayerAbilities>().invisibilityEnabled)
            {
                if (toShootPlayer)
                {
                    isShooting = false;
                    break; 
                }
                else if (disToPlayer > awarenessRange)
                {
                    isShooting = false;
                    break;
                }
               
            }
            GameObject bullet = Instantiate(bulletPrefab, Gun.transform.position,Gun.transform.rotation,Gun.transform);
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * BulletSpeed;
            // (bullet.transform.rotation.eulerAngles.normalized)
            bullet.transform.localScale *= 5;
            yield return new WaitForSeconds(attackRate);
        }
        yield return null;
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
