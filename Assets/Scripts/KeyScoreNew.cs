using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyScoreNew : MonoBehaviour
{
    public static int bossKeys = 0;
    public static int stairKeys = 0;
    Text score; 
    public static bool f1keysCollected;
    public string sceneName;
    // Start is called before the first frame update
    void Awake()
    {
        score = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string name = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);
        if (name == "floor_1")
        {
            score.text = stairKeys + "/5";
        }
        else if (name == "floor_2")
        {

            score.text = bossKeys + "/4";
        } else {
            score.text = stairKeys + "/" + bossKeys;
        }

        if(stairKeys >= 5)
        {
            f1keysCollected = true;
        }
    }

  
}

