using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject particles;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            particles.GetComponent<ParticleSystem>().Play();
            DataManager.Instance.changeHealth(3);
            AudioManager.PlaySound(AudioManager.Sound.HealthPickup, transform.position);
            Destroy(gameObject, particles.GetComponent<ParticleSystem>().startLifetime);
        }
    }
}
