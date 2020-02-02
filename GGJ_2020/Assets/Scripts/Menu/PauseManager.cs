using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MenuManager
{
    [Header("Pause Menu")]
    [SerializeField] private int pauseIndex = 0;
    [SerializeField] private bool isPaused = false;

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            isPaused = !isPaused;

            if (isPaused)
                Pause();
            else
                Unpause();
        }
    }

    private void Pause()
    {
        OpenMenu(pauseIndex);
        Time.timeScale = 0f;
    }
    private void Unpause()
    {
        CloseMenus();
        Time.timeScale = 1f;
    }

}
