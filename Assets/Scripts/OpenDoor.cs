using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    KeyScript k;
    // Start is called before the first frame update
    void Start()
    {
        k = GameObject.FindWithTag("Player").GetComponent<KeyScript>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (KeyScore.stairKeys == k.unlock_count_normal)
        {

            Destroy(gameObject);
        }
    }
}
