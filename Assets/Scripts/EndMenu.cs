using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public GameObject endMenuUI;
    public GameObject player;

    private void Update()
    {

    }

    public void Resume()
    {
        endMenuUI.SetActive(false);
        player.GetComponent<BasicMovement>().enabled = true;
        Time.timeScale = 1f;
    }

    public void showEnd()
    {
        endMenuUI.SetActive(true);
        player.GetComponent<BasicMovement>().enabled = false;
        Time.timeScale = 0f;
    }

    public void ToMainMenu()
    {
        Resume();
        SceneManager.LoadScene("MainMenu");
    }
}
