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

    //call this to initialize shield
    void InitiateShieldPowerUp()
    {
        shieldPowerIsOn = true;
        Debug.Log("Shield is now ON!");
    }

    void TakeDamage(int damage)
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
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
}
