using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    key_script k;
    // Start is called before the first frame update
    void Start()
    {
        k = GameObject.FindWithTag("Player").GetComponent<key_script>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (keyScore.stairKeys == k.unlock_count_normal)
        {

            Destroy(gameObject);
        }
    }
}
