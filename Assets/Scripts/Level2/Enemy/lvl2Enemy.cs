using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2Enemy : MonoBehaviour
{

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position += Vector3.right*Time.deltaTime;
        //anim.SetTrigger("Walk");
    }
    // Update is called once per frame
   
}
