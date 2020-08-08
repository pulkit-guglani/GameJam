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
    private Animator _animator;
    public Animator childAnimator;

    private void Start()
    {
        rb = enemy.GetComponent<Rigidbody2D>();
        _animator = enemy.GetComponent<Animator>();
        StartCoroutine(startMovement());
    }

    IEnumerator startMovement()
    {
      
        
        rb.velocity = new Vector2(2,0);
        while (enemy.transform.position.x < targetPosition.position.x )
        {
            yield return null;
            
        }
        rb.velocity = Vector2.zero;
        // play snatch animation
        _animator.SetTrigger("snatch");
        yield return new WaitForSeconds(1);
        
        rb.velocity = new Vector2(-2,0);
        enemy.GetComponent<SpriteRenderer>().flipX = true;
        _animator.SetTrigger("run");
        childAnimator.SetTrigger("jump");
        childAnimator.GetComponent<SpriteRenderer>().flipX = true;
        // play walk animation ( left )
        
        yield return null;
    }
    
}
