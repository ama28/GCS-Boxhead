using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private GameObject player;
    public int damage;
    public bool IsTrig;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            AudioManager.PlaySound(AudioManager.Sound.HumanHurt, transform.position);       
            
        }
    }

    //Unsure what this does but it causes the gun to stop shooting so
    //I'm commenting it out - Will
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log(IsTrig);
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
