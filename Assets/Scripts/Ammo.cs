using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            DataManager.Instance.ammo += 30;
            AudioManager.PlaySound(AudioManager.Sound.Ammo, transform.position);
            Destroy(gameObject);
        }
    }
}
