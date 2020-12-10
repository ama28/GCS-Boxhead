using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISingleton : MonoBehaviour
{
    public static UISingleton Instance;

    private void Awake()
    {
        if (UISingleton.Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
