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
    private float timeTillNextAttack;
    [SerializeField] private Transform fireball;
    [SerializeField] private Transform zombie;
    public Transform fireballPosition;

    public Vector3 newDirection;

    public bool inRange;
    private Zombie[] zombies;
    private bool dead = false;

    void Start()
    {
        zombies = new Zombie[3];
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = 0;
        //the script starts deactivated until it gets activated by the cutscene
        this.enabled = false;
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

        if (this.timer >= timeTillNextAttack && !dead)
        {
            int attack = Random.Range(0, 3);
            switch (attack) {
                case 0:
                    timeTillNextAttack = 6f;
                    StartCoroutine(FireballBursts());
                    break;
                case 1:
                    timeTillNextAttack = 6f;
                    StartCoroutine(FireballAngles());
                    break;
                case 2:
                    timeTillNextAttack = 3.5f;
                    StartCoroutine(SpawnZombies());
                    break;
            }
            timer = 0;
            
        }
       
        
    }

    IEnumerator FireballBursts() {
        Vector2 dir;
        for(int i = 0; i < 4; i++) {
            dir = (target.position - transform.position).normalized;
            Shoot(dir);
            yield return new WaitForSeconds(0.3f);
            dir = (target.position - transform.position).normalized;
            Shoot(dir);
            yield return new WaitForSeconds(0.3f);
            dir = (target.position - transform.position).normalized;
            Shoot(dir);
            yield return new WaitForSeconds(0.6f);
        }
    }

    IEnumerator FireballAngles() {
        Vector2 dir;
        for(int i = 0; i < 6; i++) {
            dir = (target.position - transform.position).normalized;
            Shoot(dir);
            Vector2 newdir = Rotate(dir, 30);
            Shoot(newdir);
            newdir = Rotate(dir, -30);
            Shoot(newdir);
            yield return new WaitForSeconds(0.6f);
        }
    }

    IEnumerator SpawnZombies() {
        Vector3 spawnPos = transform.position - (new Vector3(0, 5f, 0));
        zombies[0] = Instantiate(zombie, spawnPos, Quaternion.identity).gameObject.GetComponent<Zombie>();
        zombies[1] = Instantiate(zombie, spawnPos - (new Vector3(2f, 0, 0)), Quaternion.identity).gameObject.GetComponent<Zombie>();
        zombies[2] = Instantiate(zombie, spawnPos + (new Vector3(2f, 0, 0)), Quaternion.identity).gameObject.GetComponent<Zombie>();
        yield return null;
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

    public void Die() {
        StopAllCoroutines();
        dead = true;
        inRange = true;
        for(int i = 0; i < zombies.Length; i++) {
            if(zombies[i] != null && !zombies[i].Equals(null)) {
                zombies[i].enabled = false;
            }
        }
    }

    public void Disappear() {
        for(int i = 0; i < zombies.Length; i++) {
            if(zombies[i] != null && !zombies[i].Equals(null)) {
                Destroy(zombies[i].gameObject);
            }
        }
    }

    public static Vector2 Rotate(Vector2 v, float deltaDeg)
    {
        float delta = Mathf.Deg2Rad * deltaDeg;
        return new Vector2(
            v.x * Mathf.Cos(delta) - v.y * Mathf.Sin(delta),
            v.x * Mathf.Sin(delta) + v.y * Mathf.Cos(delta)
        );
    }

}