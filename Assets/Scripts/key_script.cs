using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_script : MonoBehaviour
{
    public int unlock_count_normal;
    public int unlock_count_boss;

    public int normal_key_count;
    public int boss_key_count;

    public GameObject[] stair_doors;

    private void Start()
    {
        stair_doors = GameObject.FindGameObjectsWithTag("door");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "normalkey")
        {
            keyScore.stairKeys += 1;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "boss_key")
        {
            keyScore.bossKeys += 1;
            Destroy(collision.gameObject);
        }
    }

}
