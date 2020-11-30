using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    private Transform target;
    public Animator animator;
    public GameObject Neck;
    public Int health;

    public float Neckspeed;

    public float shootPeriod;
    private float timer;
    [SerializeField] private Transform fireball;
    public Transform fireballPosition;

    public Vector3 newDirection;

    public bool inRange;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Swipe", inRange);

        this.timer += Time.deltaTime;


        float neckROT = Neckspeed * Time.deltaTime;

        Vector2 dir = (target.position - transform.position).normalized;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, neckROT, 0.0f);



        Neck.transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(dir)+90);



        if (this.timer >= this.shootPeriod)
        {
            Shoot(dir);
            this.timer = 0;
        }
       
        
    }

    void Shoot(Vector3 dir)
    {
        Transform bulletTransform = Instantiate(fireball, fireballPosition.position, Quaternion.identity);
        bulletTransform.GetComponent<Fireball>().setup(dir);
    }


    public float getAngleFromVector(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {

            inRange = true;


        }
     
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))

        {

            inRange = false;


        }

    }

}