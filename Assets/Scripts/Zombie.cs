using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* IMPLEMENTS / REPLACES ENEMYFOLLOW */

public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform target;
    public Animator animator;
    public Image healthbar;

    public float MaxHP;
    private float CurrentHP;
    private float distanceToPlayer;
    private Spawner spawner;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector2 dir = (transform.position - target.position).normalized;
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
        }
    }

    private void takeDamage() {
        CurrentHP -= 1;
        healthbar.fillAmount = CurrentHP / MaxHP;
        if(CurrentHP > 0) {
            if(distanceToPlayer <= 14) {
                AudioManager.PlaySound(AudioManager.Sound.ZombieHurt, transform.position);
            }
        } else {
            if(distanceToPlayer <= 14) {
                AudioManager.PlaySound(AudioManager.Sound.ZombieHurt, transform.position);
                AudioManager.PlaySound(AudioManager.Sound.ZombieDeath, transform.position);
            }
            spawner.enemiesSpawned--;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") 
        {
            takeDamage();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fireball") {
            takeDamage();
        }
    }

    public void setSpawn(Spawner spawnerIn) 
    {
        spawner = spawnerIn;
    }
}

