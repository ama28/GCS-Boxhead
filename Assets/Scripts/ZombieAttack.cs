using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private GameObject player;
    public int damage;
    public AudioClip playerHurtNoise;
    public bool IsTrig;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (IsTrig == true)
            {
                Debug.Log("hit!");
                player = other.gameObject;
                AudioManager.PlaySound(AudioManager.Sound.HumanHurt, transform.position);       
            }
        }
    }

    private void Update()
    {
        if (DataManager.Instance.getTime() <= 0 && player != null)
        {
            DataManager.Instance.changeHealth(-damage);
            DataManager.Instance.ResetTimer();
            Debug.Log(DataManager.Instance.getHealth());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player = null;
    }

    public void ResetAttack()
    {
        player = null;
    }
}
