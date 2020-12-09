using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyImage : MonoBehaviour
{
    public Sprite normalKey;
    public Sprite bossKey;

    public Image keySprite;

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
            keySprite.sprite = normalKey;
        }
        else if (sceneName == "floor_2")
        {
            keySprite.sprite = bossKey;
        }
        else
        {
            keySprite.enabled = false;
        }
    }
}
