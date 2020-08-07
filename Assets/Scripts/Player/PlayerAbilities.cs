using System.Collections;
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

    public Rigidbody2D rb;
    public bool canThrust = true;
    private bool _isRocketThrusting;
    [SerializeField] private AudioSource audioSourceForThrust;
   

    public ParticleSystem particle;
    void Start()
    {
        particle.Stop(true);
        material = GetComponent<SpriteRenderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        Invisible();
        if (canThrust)
        {
            ThrustCheck();
        }
    }
     private void ThrustCheck()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
        rb.AddForce(new Vector2(0,1000) * (Time.deltaTime));    
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GetComponent<Animator>().SetTrigger("idle");
            Thrust();
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ThrustOff();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddForce(Vector2.up*5);
        }
        
    }
    
    public void Thrust()
    {
        _isRocketThrusting = true;
        StopCoroutine("StartSound");
        audioSourceForThrust.Play();
        StartCoroutine("StartSound");
            
        particle.Play(true);
        particle.emissionRate = Mathf.Clamp(particle.emissionRate + 1,0,100);
        
    }
    public void ThrustOff()
    {
        _isRocketThrusting = false;
        /*_animator.SetTrigger(Input.GetKey(KeyCode.LeftArrow) ? IdleLeft : Input.GetKey(KeyCode.RightArrow)?IdleRight:IdleFront);*/
        StopCoroutine("StopSound");
        StartCoroutine(StopSound());
        particle.Stop(true,ParticleSystemStopBehavior.StopEmitting);
    }
    
    private IEnumerator StopSound()
    {
        while (true)
        {
            if (_isRocketThrusting)
            {
                yield break;
                
            }
            if (audioSourceForThrust.volume < 0.05f)
            {
                break;
            }
            audioSourceForThrust.volume -= 2*Time.deltaTime;
            yield return null;
        }

        audioSourceForThrust.mute = true;
       
        yield return null;
    }
    private IEnumerator StartSound()
    {
        StopCoroutine("StopSound");
        audioSourceForThrust.mute = false;
        while (true)
        {
            if (!_isRocketThrusting)
            {
                yield break; 
            }
            if (audioSourceForThrust.volume > 0.95f)
            {
                break;
            }
            audioSourceForThrust.volume += 4*Time.deltaTime;
            yield return null;
        }

        audioSourceForThrust.volume = 1;
        yield return null;
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
