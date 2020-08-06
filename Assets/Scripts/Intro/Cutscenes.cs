using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cutscenes : MonoBehaviour
{
    [SerializeField] Image[] image;
    int currentImage;
    int nextImage;
    [SerializeField] Animator animator;
    [SerializeField]
    private float timeBetweenImageChange;

    void Start()
    {
        currentImage = 0;
        nextImage = currentImage + 1;
        StartCoroutine(StartTransition());
    }

    IEnumerator StartTransition()
    {
        while (nextImage < image.Length)
        { 
            yield return new WaitForSeconds(timeBetweenImageChange);
            ChangeImage();
        }
    }

    public void ChangeImage()
    {
        image[currentImage].gameObject.SetActive(false);
        image[nextImage].gameObject.SetActive(true);
        currentImage++;
        nextImage++;
    }
}
