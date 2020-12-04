using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class floor2transition : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor2trans") && collision.gameObject.GetComponent<floor2door>().doorID == 1)
        {
            SceneManager.LoadScene("floor_2");
            transform.position = new Vector3(21, -11, 0);
        }
        else if (collision.gameObject.CompareTag("floor2trans") && collision.gameObject.GetComponent<floor2door>().doorID == 2)
        {
            SceneManager.LoadScene("floor_2");
            transform.position = new Vector3(-34, -48, 0);
        }
        else if (collision.gameObject.CompareTag("floor2trans") && collision.gameObject.GetComponent<floor2door>().doorID == 3)
        {
            SceneManager.LoadScene("floor_1");
            transform.position = new Vector3(8, -10, 0);
        }
        else if (collision.gameObject.CompareTag("floor2trans") && collision.gameObject.GetComponent<floor2door>().doorID == 4)
        {
            SceneManager.LoadScene("floor_1");
            transform.position = new Vector3(-42, -25, 0);
        }
    }
}
