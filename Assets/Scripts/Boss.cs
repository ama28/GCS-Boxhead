using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Transform target;
    public Animator animator;

    public Image healthbar;

    public float MaxHP;
    private float CurrentHP;

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

        Vector2 dir = (target.position - transform.position).normalized;
        if (this.timer >= this.shootPeriod)
        {
            Shoot(dir);
            this.timer = 0;
        }
        //animator.SetFloat("Horizontal", dir.x);
        //animator.SetFloat("Vertical", dir.y);
        if (CurrentHP <= 0) Destroy(gameObject);
    }

    void Shoot(Vector3 dir)
    {
        Transform bulletTransform = Instantiate(fireball, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().setup(dir);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") CurrentHP -= 1;
        healthbar.fillAmount = CurrentHP / MaxHP;
    }


}