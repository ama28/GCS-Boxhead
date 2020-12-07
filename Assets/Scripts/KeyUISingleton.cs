using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyUISingleton : MonoBehaviour
{
    public static GameObject KeyUIInstance;


    // Start is called before the first frame update
    void Awake()
    {
        if (KeyUIInstance == null)
        {
            KeyUIInstance = gameObject;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
