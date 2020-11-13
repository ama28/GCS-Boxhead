using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyfollow : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private Transform target;
    public Animator animator;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

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
    }
}
