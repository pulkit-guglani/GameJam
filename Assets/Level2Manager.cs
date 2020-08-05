using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator lift;
    [SerializeField] private GameObject enemy;

    private void Start()
    {
        StartCoroutine(OpenLift());
    }

    IEnumerator OpenLift()
    {
        yield return new WaitForSeconds(4);
        lift.SetTrigger("open");
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(enemy, transform);
        }
        yield return null;
    }
}
