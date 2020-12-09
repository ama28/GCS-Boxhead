using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
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
            KeyScore.stairKeys += 1;
            AudioManager.PlaySound(AudioManager.Sound.Key, transform.position);
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "boss_key")
        {
            KeyScore.bossKeys += 1;
            AudioManager.PlaySound(AudioManager.Sound.Key, transform.position);
            Destroy(collision.gameObject);
        }
    }

}
