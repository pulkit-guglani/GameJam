using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
       // transform.GetChild(0).GetComponent<ParticleSystem>().Stop(true);
        StartCoroutine(BlastMine());

    }

    private IEnumerator BlastMine()
    {
        yield return new WaitForSeconds(15);
        transform.GetChild(0).gameObject.SetActive(true);
        AudioManager.Instance.Play("mine");
        transform.GetChild(0).GetComponent<ParticleSystem>().Play(true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
        GameOver.Instance.ShowGameOverScreen("All enemies got killed in blast");
        Destroy(gameObject);
    }

    // Update is called once per frame
   
}
