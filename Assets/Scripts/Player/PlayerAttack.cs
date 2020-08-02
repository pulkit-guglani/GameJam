using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject BulletPrefab;
    void Update()
    {
        // for Tranquilizers
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        }

    }
}
