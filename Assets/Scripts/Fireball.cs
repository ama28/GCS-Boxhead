using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Rigidbody2D body;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    private GameObject spriteChild;
    public AudioClip playerHurtNoise;
    private Vector3 dir;
    private float travelledDistance = 0;
    public float moveSpeed = 80f;
    public float timeAlive = 30f;

    public GameObject FireEffect;

    public void setup(Vector3 dir)
    {
        this.dir = dir.normalized;
        transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(dir) - 90);
        body = this.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        collider = this.GetComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        renderer = this.GetComponentInChildren(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteChild = renderer.gameObject;

        Destroy(gameObject, timeAlive);
    }

    public void Update()
    {
        float d = moveSpeed * Time.deltaTime;
        travelledDistance += d;
        transform.position += dir * d;
        spriteChild.transform.rotation *= Quaternion.Euler(Vector3.forward * 20);
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
            StartCoroutine(fireEffect());
            DataManager.Instance.changeHealth(-20);
            
        }
        StartCoroutine(fireEffect());
    }

    //return abs degrees angle from vector (float)
    public float getAngleFromVector(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }

    IEnumerator fireEffect()
    {
        
        FireEffect.SetActive(true);
        renderer.enabled = false;
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);

    }

   }
