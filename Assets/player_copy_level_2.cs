using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_copy_level_2 : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("dart"))
        {
            WinLevel.Instance.ShowWinLevelCanvas();
        }
    }
}
