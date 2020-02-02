using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MenuManager
{
    [Header("Pause Menu")]
    [SerializeField] private int pauseIndex = 0;
    [SerializeField] private bool isPaused = false;

    private void Update()
    {
        PauseInput();
    }

    private void PauseInput()
    {
        if (Input.GetButtonDown("Pause"))
            PauseButton();
    }

    public void PauseButton()
    {
        if (isPaused)
            Pause();
        else
            Unpause();
    }

    private void Pause()
    {
        if (!menuOpened)
        {
            OpenMenu(pauseIndex);
            Time.timeScale = 0f;
            isPaused = !isPaused;
        }
    }
    private void Unpause()
    {
        CloseMenus();
        Time.timeScale = 1f;
        menuOpened = false;
        isPaused = !isPaused;
    }

}
