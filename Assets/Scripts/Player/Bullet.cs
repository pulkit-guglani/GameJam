using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float DestroyTime = 2;

    public int damage = 20;
    public GameObject hitEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * bulletSpeed;

      //  rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, DestroyTime);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
      DestroyIt();
    }

    public void DestroyIt()
    {
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect,2);
        Destroy(gameObject);
    }

    /*void OnCollisionEnter2D(Collision2D col)
    {

       GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
       Destroy(effect,2);
       Destroy(gameObject);
        // checking tag for Ground
        //if (col.collider.CompareTag("Ground"))
        //{
        //    Instantiate(hitEffect, transform.position, Quaternion.identity);
        //    Destroy(gameObject);
        //}
    }*/
}
