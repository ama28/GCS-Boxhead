using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    public AudioClip playerHurtNoise;
    private Vector3 dir;
    private float travelledDistance = 0;
    public float moveSpeed = 80f;
    public float timeAlive = 30f;

    public void setup(Vector3 dir)
    {
        this.dir = dir.normalized;
        transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(dir) - 90);
        body = this.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        collider = this.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        renderer = this.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;

        Destroy(gameObject, timeAlive);
    }

    public void Update()
    {
        float d = moveSpeed * Time.deltaTime;
        travelledDistance += d;
        transform.position += dir * d;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            //audio
            AudioManager.PlaySound(AudioManager.Sound.HumanHurt, transform.position);
            collider.enabled = false;
            Destroy(body);
            renderer.enabled = false;
            DataManager.Instance.changeHealth(-20);
        }
        Destroy(gameObject, 0.5f);
    }

    //return abs degrees angle from vector (float)
    public float getAngleFromVector(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
