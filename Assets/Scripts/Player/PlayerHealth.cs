using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{  
    [SerializeField] HealthBar healthBar;
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;

    private bool shieldPowerIsOn = false;

    public bool isDead { get; private set; }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if(isDead) { return; }

        if (Input.GetKeyDown(KeyCode.U))     //Damage Condition Instead of Space bar
        {
            TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            InitiateShieldPowerUp();
        }
    }

    public void InitiateShieldPowerUp()
    {
        shieldPowerIsOn = true;
        Debug.Log("Shield is now ON!");
    }

    public void TakeDamage(int damage)
    {
        if(currentHealth <= 0)
        {
            print("Player Dead!");
            isDead = true;
            return; 
        }

        if (shieldPowerIsOn)
        {
            // disable shield visualization
            shieldPowerIsOn = false;
            Debug.Log("Shield is now OFF!");
        }
        else
        {
            Debug.Log("current health of player is :" + currentHealth);
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage(collision.gameObject.GetComponent<Bullet>().damage);
        }
    }
}
