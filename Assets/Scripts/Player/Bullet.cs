using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D rb;
    public float DestroyTime = 0.4f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb.velocity = transform.right * bulletSpeed;

        rb.velocity = transform.right * bulletSpeed;
        Destroy(gameObject, DestroyTime);

    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        // checking tag for Ground
        if (col.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
