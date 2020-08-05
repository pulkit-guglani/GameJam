using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explodableBullet : MonoBehaviour
{
    Rigidbody2D rb;
    public float DestroyTime = 2;

    public int damage = 20;
    public GameObject hitEffect;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Explodable bullet");
        Explodable explodable;
        GameObject effect =  Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect,2);
        Destroy(gameObject);
        if (explodable = other.gameObject.GetComponent<Explodable>())
        {
            explodable.explode();
        }
        
        Destroy(gameObject,2);
    }

    
}
