﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.GetComponent<BasicMovement>().enabled = true;
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.GetComponent<BasicMovement>().enabled = false;
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void ToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
