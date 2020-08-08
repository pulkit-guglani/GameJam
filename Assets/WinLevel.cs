using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public static WinLevel Instance;
    public GameObject winCanvas;
    public GameObject GameWinCanvas;
    
    void Start()
    {
        Instance = this;
    }


    public void ShowWinLevelCanvas()
    {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
    }

    public void GameWon()
    {
        GameWinCanvas.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("You Won");
    }
    
    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
