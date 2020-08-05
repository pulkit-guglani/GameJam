using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;

    public float bulletSpeed = 40;
    [SerializeField] PlayerHealth playerHealth;
    private PlayerController _controller;


    private void Start()
    {
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(playerHealth.isDead) { return; }
        // for Tranquilizers
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity =  transform.right * (bulletSpeed * (_controller.movingRight? 1 : -1));
        }

    }
}
