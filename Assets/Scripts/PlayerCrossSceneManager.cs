using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrossSceneManager : MonoBehaviour
{
    public static GameObject PlayerInstance;


    // Start is called before the first frame update
    void Awake()
    {
        if (PlayerInstance == null)
        {
            PlayerInstance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
