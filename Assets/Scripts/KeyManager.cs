using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerCrossSceneManager>().f1keysCollected == false)
        {
            DontDestroyOnLoad(this);
        }
        else { Destroy(gameObject); }
    }
}
