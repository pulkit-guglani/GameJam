using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScenes2 : MonoBehaviour
{

    [SerializeField] Image[] image;
    [SerializeField] Animator animator;
    [SerializeField]
    private float timeBetweenImageChange;

    private int currentImage;
    [SerializeField] private Image dark;
    [SerializeField] private SpriteRenderer bg;
    [SerializeField] private SpriteRenderer player;
    [SerializeField] public GameObject MainMenu;

    void Start()
    {
        currentImage = 0;
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        while (currentImage < image.Length-1)
        {
            yield return new WaitForSeconds(timeBetweenImageChange);
            ChangeImage();
        }
        yield return new WaitForSeconds(2f);
        
        image[currentImage].gameObject.SetActive(false);
        image[currentImage].transform.parent.gameObject.SetActive(false);
        bg.gameObject.SetActive(true);
        StartCoroutine(DarkImageFadeInAndOut());
        player.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        StartCoroutine(CameraZoom());
        yield return new WaitForSeconds(4);

            StartCoroutine(ShowMainMenu());
      
       
        
        
    }

    private IEnumerator ShowMainMenu()
    { 
        MainMenu.SetActive(true);
        var localScale = MainMenu.transform.localScale;
        while (localScale.x > 0.5f)
        {
            localScale -=  localScale*Time.deltaTime*0.2f;
            MainMenu.transform.localScale = localScale;
            yield return null;
        }
       
        yield return null;
    }

    public void ChangeImage()
    {
        StartCoroutine(DarkImageFadeInAndOut());
        image[currentImage].gameObject.SetActive(false);
        image[currentImage+1].gameObject.SetActive(true);
        currentImage++;
        
    }

    IEnumerator DarkImageFadeInAndOut()
    {
        Color color = dark.color;
        color = new Color(color.r,color.g,color.b,1);
        dark.color = color;
        while (true)
        {
            dark.color =new Color(color.r,color.g,color.b,dark.color.a - Time.deltaTime);
            if (dark.color.a < 0.1f)
            {
                break;
            }

            yield return null;
        }
      //  dark.CrossFadeAlpha(0.9f,0.5f,true);
        //yield return new WaitForSeconds(0.5f);
       // dark.CrossFadeAlpha(0.1f,0.5f,true);
        yield return null;
    }

    IEnumerator CameraZoom()
    {
        while (  Camera.main.orthographicSize > 4)
        {
            Camera.main.orthographicSize -= Time.deltaTime*0.2f;
            yield return null;
        }

        yield return null;
        

    }
}
