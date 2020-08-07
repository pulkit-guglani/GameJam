using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLevel5 : MonoBehaviour
{
    // Start is called before the first frame update


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "enemy")
        {
            Debug.Log("collide hua ");
            GameOver.Instance.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "lvl5enemy")
        {
            Debug.Log("trigger hua ");
            GameOver.Instance.ShowGameOverScreen();
        }
    }
}
