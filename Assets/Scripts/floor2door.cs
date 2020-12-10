using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floor2door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("LoadScene");
            
        }
    }

    private IEnumerator LoadScene() {
        SceneManager.LoadScene("floor_1");
            Debug.Log("A");
            GameObject player = GameObject.Find("Player");
            Debug.Log(player);
            player.transform.position = new Vector3(-42.7f, -24, 0);
            yield return null;
            Debug.Log(player.transform.position);
            Destroy(gameObject);
    }
}
