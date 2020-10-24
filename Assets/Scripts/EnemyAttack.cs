using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
        }
    }

    private void Update()
    {
        if (DataManager.Instance.getTime() <= 0 && player != null)
        {
            Debug.Log(DataManager.Instance.getHealth());
            DataManager.Instance.changeHealth(-damage);
            DataManager.Instance.ResetTimer();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player = null;
    }
}
