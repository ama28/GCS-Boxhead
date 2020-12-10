using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public GameObject InstructionText;

    public void PlayGame()
    {
        SceneManager.LoadScene("floor_1");
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void InstructionsOn()
    {
        InstructionText.SetActive(true);
    }

    public void InstructionsOff()
    {
        InstructionText.SetActive(false);
    }

}
