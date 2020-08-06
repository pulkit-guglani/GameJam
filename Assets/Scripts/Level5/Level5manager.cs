using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5manager : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    public GameObject enemy;
    public Transform targetPosition;

    private void Start()
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        StartCoroutine(startMovement());
    }

    IEnumerator startMovement()
    {
      
        yield return new WaitForSeconds(0);
        rb.velocity = new Vector2(2,0);
        // play walk animation ( right )
        while (enemy.transform.position.x < targetPosition.position.x )
        {
            yield return null;
            
        }
        rb.velocity = Vector2.zero;
        // play snatch animation
        
        yield return new WaitForSeconds(1);
        
        rb.velocity = new Vector2(-2,0);
        
        // play walk animation ( left )
        
        yield return null;
    }
    
}
