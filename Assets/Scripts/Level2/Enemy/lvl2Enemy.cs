using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl2Enemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        transform.position += Vector3.right*Time.deltaTime;
    }
    // Update is called once per frame
   
}
