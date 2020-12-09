using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{

    // Start is called before the first frame update
    private void Awake()
    {
        if (keyScore.f1keysCollected == false)
        {
            DontDestroyOnLoad(gameObject);
        }
        else { Destroy(gameObject); }
    }
}
