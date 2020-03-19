using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MenuManager
{
    [Header("Pause Menu")]
    [SerializeField] private int pauseIndex = 0;
    [SerializeField] private bool isPaused = false;

    private void Update()
    {
        PauseInput();
        if (Input.GetButtonDown("ResetStage")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            BASICBOITEMPANANIM_PLANTS.newScene = true;
        }
    }

    private void PauseInput()
    {
        if (Input.GetButtonDown("Pause"))
            PauseButton();
    }

    public void PauseButton()
    {
        if (isPaused)
            Unpause();
        else
            Pause();
    }

    private void Pause()
    {
        if (!menuOpened)
        {
            OpenMenu(pauseIndex);
            isPaused = true;
            Time.timeScale = 0f;
            
        }
    }
    private void Unpause()
    {
        CloseMenus();
        menuOpened = false;
        isPaused = false;
        Time.timeScale = 1f;
    }
}
