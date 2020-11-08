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

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

            Vector2 dir = (transform.position - target.position).normalized;
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
        }

        if (CurrentHP <= 0) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") CurrentHP -= 1;
        healthbar.fillAmount = CurrentHP / MaxHP;
    }
}

