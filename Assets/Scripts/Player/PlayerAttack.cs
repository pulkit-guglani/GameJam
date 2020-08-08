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
    public GameObject ExplodableGunEffect;
    public GameObject explodableBullet;
    public GameObject dart;
    public int selectedWeapon = 1;

    private void Start()
    {
        
        _controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedWeapon = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedWeapon = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedWeapon = 4;
        }
        
        
        if(playerHealth.isDead) { return; }
        // for Tranquilizers
        if (Input.GetButtonDown("Fire1"))
        {
            if (tranquilizer && selectedWeapon == 1)
            {
                GameObject bullet = Instantiate(dart, firePoint.position, firePoint.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");
              
                bullet.GetComponent<Rigidbody2D>().velocity = transform.right *
                                                              (bulletSpeed * (_controller.movingRight ? 1 : -1));
                bullet.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (this.bullet && selectedWeapon == 5)
            {
                GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");

                bullet.GetComponent<Rigidbody2D>().velocity = transform.right *
                                                              (bulletSpeed * (_controller.movingRight ? 1 : -1));
            }

            if (magneticGun && selectedWeapon == 2)
            {
                magneticGun = false;
                GameObject magnet = Instantiate(MagneticGunEffect, firePoint.position + firePoint.right,
                    Quaternion.identity, firePoint);
                magnet.GetComponent<Rigidbody2D>().velocity = firePoint.right * 2;
                EGA_Laser[] lasers = FindObjectsOfType<EGA_Laser>();
                Destroy(lasers[0].gameObject, 1);
                Destroy(lasers[1].gameObject, 1);
                
                Destroy(magnet, 4);

            }

            if (blastGun && selectedWeapon == 3)
            {
                GameObject bullet = Instantiate(explodableBullet, firePoint.position, firePoint.rotation);
                FindObjectOfType<AudioManager>().Play("Shoot");

                bullet.GetComponent<Rigidbody2D>().velocity =
                    transform.right * (bulletSpeed * (_controller.movingRight ? 1 : -1));
            }
        }
    }

}

