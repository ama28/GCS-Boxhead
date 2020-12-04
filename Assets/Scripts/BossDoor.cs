using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossDoor : MonoBehaviour
{
    public GameObject player;
    private key_script script;
    public int count;
    public int total;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<key_script>();
        total = script.unlock_count_boss;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && keyScore.bossKeys >= script.unlock_count_boss)
        {
            SceneManager.LoadScene("Boss");
            Destroy(other.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("UI"));
        }
    }
}
