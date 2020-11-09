using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOnHit : MonoBehaviour
{
    public Int health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") health.value -= 1;
    }
}
