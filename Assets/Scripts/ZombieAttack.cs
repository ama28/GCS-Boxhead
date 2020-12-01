using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    private GameObject player;
    public int damage;
    private AudioSource audio;
    public AudioClip playerHurtNoise;
    public bool IsTrig;

    void Start() {
        audio = this.GetComponent(typeof(AudioSource)) as AudioSource;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            audio.volume = 0.5f;
            audio.clip = playerHurtNoise;
            audio.pitch = 1 + Random.Range(-0.1f, 0.1f);
            audio.Play();
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (IsTrig == true)
            {
                Debug.Log("hit!");
                player = other.gameObject;
                audio.volume = 0.5f;
                audio.clip = playerHurtNoise;
                audio.pitch = 1 + Random.Range(-0.1f, 0.1f);
                audio.Play();
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
