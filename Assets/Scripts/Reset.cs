using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public GameObject EndPanel;
    public string startScene;
    // Start is called before the first frame update
    public void OnDeath()
    {
        EndPanel.SetActive(true);
        Time.timeScale = 0; 
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        DataManager.Instance.Initialize();
        EndPanel.SetActive(false);
        SceneManager.LoadScene(startScene);
        KeyScore.bossKeys = 0;
        KeyScore.stairKeys = 0;
        Cursor.visible = true;
    }
}
