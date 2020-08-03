using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject creditPanel;
    //add settings panel

    int currentSceneBuildIndex;
    int nextSceneBuildIndex;

    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false);
        currentSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        nextSceneBuildIndex = currentSceneBuildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            PauseGame();
        }

        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    private void PauseGame()
    {
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        LoadLevel(1);
    }

    public void StartNextLevel()
    {
        LoadLevel(nextSceneBuildIndex);
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
