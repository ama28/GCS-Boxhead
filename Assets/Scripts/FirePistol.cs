using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    private AudioSource gunshot;
    [SerializeField] private GameObject player;

    public GameObject BlowBackEffect;

    public Animator animator;

    public bool Shooter;

    public bool delayOn;

    // Start is called before the first frame update
    void Start()
    {
        gunshot = player.GetComponent<AudioSource>();
        gunshot.volume = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Shot", Shooter);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (delayOn == false)
            {
                delayOn = true;
                Vector2 playerDir = player.GetComponent<BasicMovement>().facingDir;
                //this.Shoot(playerDir);
                StartCoroutine(CreateSpark(playerDir));
            }
            }
    }

    void Shoot(Vector2 moveInput)
    {

        
    }

    IEnumerator CreateSpark(Vector2 moveInput)
    {
        Shooter = true;
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        gunshot.Play();

        BlowBackEffect.SetActive(true);
        yield return new WaitForSeconds(0.001f);
        delayOn = false;
        BlowBackEffect.SetActive(false);
        Shooter = false;


    }

}
