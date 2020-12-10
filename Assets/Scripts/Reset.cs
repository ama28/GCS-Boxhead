using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    public GameObject EndPanel;
    public string startScene;
    private GameObject player;
    // Start is called before the first frame update
    public void OnDeath()
    {
        EndPanel.SetActive(true);
        player = GameObject.Find("Player");
        
        Time.timeScale = 0; 
        Cursor.visible = true;
    }

    public void RestartGame()
    {
        if(player) {
            Destroy(player);
        }
        Time.timeScale = 1;
        DataManager.Instance.Initialize();
        EndPanel.SetActive(false);
        SceneManager.LoadScene(startScene);
        KeyScoreNew.bossKeys = 0;
        KeyScoreNew.stairKeys = 0;
        Cursor.visible = true;
    }
}
