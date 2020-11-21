using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Transform target;
    public Animator animator;

    public Int health;

    public float shootPeriod;
    private float timer;
    [SerializeField] private Transform fireball;
    public Transform fireballPosition;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;

        Vector2 dir = (target.position - transform.position).normalized;
        if (this.timer >= this.shootPeriod)
        {
            Shoot(dir);
            this.timer = 0;
        }
        //animator.SetFloat("Horizontal", dir.x);
        //animator.SetFloat("Vertical", dir.y);
    }

    void Shoot(Vector3 dir)
    {
        Transform bulletTransform = Instantiate(fireball, fireballPosition.position, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().setup(dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") health.value -= 1;
    }


}