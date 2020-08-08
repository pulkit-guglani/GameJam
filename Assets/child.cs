using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class child : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("trigger hua");
        if (other.gameObject.name.Contains("dart")) 
        {
           GameOver.Instance.ShowGameOverScreen("you shot your past self");
        }
    }
}
