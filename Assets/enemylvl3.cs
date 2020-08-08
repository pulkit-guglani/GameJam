using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemylvl3 : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        StartCoroutine(moveLeftRight());
    }

    IEnumerator moveLeftRight()
    {
        yield return new WaitForSeconds(Random.Range(0.5f,3.0f));
        rb.velocity = new Vector2(2,0);
        while (true)
        {
            
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().flipX = true;
            rb.velocity = new Vector2(-2,0);
            yield return new WaitForSeconds(2f);
            rb.velocity = new Vector2(2,0);
            GetComponent<SpriteRenderer>().flipX = false;
            yield return null;
        }
        
    }

    
    // Update is called once per frame
   
}
