using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrossSceneManager : MonoBehaviour
{
    public static PlayerCrossSceneManager instance;
    public bool f1keysCollected = false;

    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        if (gameObject.GetComponent<key_script>().unlock_count_normal == 5)
        {
            f1keysCollected = true;
        }
    }
}
