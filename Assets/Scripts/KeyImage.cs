using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyImage : MonoBehaviour
{
    public GameObject normalKeyDisplay;
    public GameObject bossKeyDisplay;


    string sceneName;
    void Awake()
    {
        SceneManager.activeSceneChanged += ChangedActiveScene;
    }

    void ChangedActiveScene(Scene current, Scene next)
    {
        sceneName = next.name;

        if (sceneName == "floor_1")
        {
            normalKeyDisplay.SetActive(true);
            bossKeyDisplay.SetActive(false);
        }
        else if (sceneName == "floor_2")
        {
            normalKeyDisplay.SetActive(false);
            bossKeyDisplay.SetActive(true);
        }
        else
        {
            normalKeyDisplay.SetActive(false);
            bossKeyDisplay.SetActive(false);
        }
    }
}
