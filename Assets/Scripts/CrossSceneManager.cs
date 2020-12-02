using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossSceneManager : MonoBehaviour
{
    public static CrossSceneManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this);

        //if (Instance == null)
        //{
        //    Instance = this;
        //    DontDestroyOnLoad(this);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
