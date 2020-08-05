using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;

    public float bulletSpeed = 40;
    [SerializeField] PlayerHealth playerHealth;
    private PlayerController _controller;
    public bool magneticGun = false;
    public bool blastGun = false;
    public bool tranquilizer = true;
    public bool bullet = false;
    public GameObject MagneticGunEffect;
    public GameObject explodableBullet;

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
            if (this.bullet)
            {
                GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");

                bullet.GetComponent<Rigidbody2D>().velocity =  transform.right * (bulletSpeed * (_controller.movingRight? 1 : -1)); 
            }

            if (magneticGun)
            {
                magneticGun = false;
                GameObject magnet = Instantiate(MagneticGunEffect,firePoint.position+firePoint.right,Quaternion.identity,firePoint);
                magnet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 2;
                EGA_Laser[] lasers = FindObjectsOfType<EGA_Laser>();
                Destroy(lasers[0].gameObject,1);
                Destroy(lasers[1].gameObject,1);
                Destroy(magnet,4);
                
            }

            if (blastGun)
            {
                GameObject bullet = Instantiate(explodableBullet, firePoint.position, firePoint.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");

                bullet.GetComponent<Rigidbody2D>().velocity =  transform.right * (bulletSpeed * (_controller.movingRight? 1 : -1));
            }
          
        }

    }
}
