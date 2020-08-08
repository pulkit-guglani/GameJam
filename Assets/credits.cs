using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour
{
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayLiftAnimation",2);
    }

    public void PlayLiftAnimation()
    {
        GetComponent<Animator>().SetTrigger("open");
       Invoke("ShowCanvas",0.5f);
       AudioManager.Instance.Play("lift");
    }

    void ShowCanvas()
    {
        canvas.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
