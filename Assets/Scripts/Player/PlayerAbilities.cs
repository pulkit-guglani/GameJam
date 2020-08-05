﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    // for Invisiblity
    Material material;
    private bool isDissolving;
    float fade = 1f;

    [HideInInspector]
    public bool invisibilityEnabled;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        Invisible();

    }

    void Invisible()
    {
        if (isDissolving)
        {

            fade = Mathf.Clamp01(fade - Time.deltaTime);
            material.SetFloat("_Fade", fade);
        }
        else
        {

            fade = Mathf.Clamp01(fade + Time.deltaTime);
            material.SetFloat("_Fade", fade);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
           MakeInvisible();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
           MakeVisible();
        }

    }

    public void MakeInvisible()
    {
        isDissolving = true;
        invisibilityEnabled = true;
    }
    public void MakeVisible()
    {
        isDissolving = false;
        invisibilityEnabled = false;
    }
}
