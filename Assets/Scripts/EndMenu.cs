using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject endMenuUI;
    public GameObject player;

    public void Resume()
    {
        endMenuUI.SetActive(false);
        Cursor.visible = false;
        player.GetComponent<BasicMovement>().enabled = true;
        Time.timeScale = 1f;
    }

    public void showEnd()
    {
        endMenuUI.SetActive(true);
        Cursor.visible = true;
        player.GetComponent<BasicMovement>().enabled = false;
        Time.timeScale = 0f;
    }

    public void ToMainMenu()
    {
        InitializeData();
        SceneManager.LoadScene("MainMenu");
    }

    void InitializeData()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        KeyScore.bossKeys = 0;
        KeyScore.stairKeys = 0;
    }
}
