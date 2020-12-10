using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* IMPLEMENTS / REPLACES ENEMYFOLLOW */

public class Devil : MonoBehaviour
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

    public float shootPeriod;
    private float timer;
    [SerializeField] private Transform fireball;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CurrentHP = MaxHP;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        distanceToPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceToPlayer > 5)
        {
            animator.speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        } else {
            animator.speed = 0;
        }
        Vector2 dir = (target.position - transform.position).normalized;
        if (this.timer >= this.shootPeriod && distanceToPlayer <= 9)
        {
            Shoot(dir);
            this.timer = 0;
        }
        animator.SetFloat("Horizontal", dir.x);
        animator.SetFloat("Vertical", dir.y);
    }

    void Shoot(Vector3 dir)
    {
        Transform bulletTransform = Instantiate(fireball, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().setup(dir);
    }

    private void takeDamage(int damage) {
        CurrentHP -= damage;
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
            takeDamage(1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fireball") {
            takeDamage(1);
        }
    }

    public void setSpawn(Spawner spawnerIn) 
    {
        spawner = spawnerIn;
    }

}
