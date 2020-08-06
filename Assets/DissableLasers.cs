using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissableLasers : MonoBehaviour
{
    [SerializeField] GameObject parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Bullet")
        {
            parent.SetActive(false);
        }
    }
}
