using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_copy_level_3 : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
       var Name = other.gameObject.name;
        if (Name.Contains("dart"))
        {
            WinLevel.Instance.ShowWinLevelCanvas();
        }
        else if (Name.Contains("Explodable"))
        {
            GameOver.Instance.ShowGameOverScreen("You killed your past self");
        }
    }
}
