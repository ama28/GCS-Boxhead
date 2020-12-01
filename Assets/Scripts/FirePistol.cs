using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    [SerializeField] private GameObject player;

    public GameObject BlowBackEffect;

    public Animator animator;

    public bool Shooter;

    public bool delayOn;


    public int gunNum;

    public Vector2 playerDir;

    public bool RapidOn;
    public bool Shootvalve;

    // Update is called once per frame
    void Update()
    {

      gunNum =  player.GetComponent<BasicMovement>().MainGunNum;

        animator.SetBool("Shot", Shooter);

        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 playerDir = player.GetComponent<BasicMovement>().facingDir;

            

            if (gunNum == 1)
            {
                if (delayOn == false)
                {
                    delayOn = true;
                    
                    //this.Shoot(playerDir);
                    StartCoroutine(PistolSpark(playerDir));
                }
            }

            if (gunNum == 2)
            {

                RapidOn = true;
            }

            if (gunNum == 3)
            {

                float arcX;
                float arcY;

                if (playerDir.x == 1 || playerDir.x == -1 && playerDir.y == 0)
                {
                    arcX = 0;
                    arcY = 0.5f;
                }

                else
                {
                    arcX = 0.5f;
                    arcY = 0;
                }

                StartCoroutine(ShotSpark(new Vector2(playerDir.x, playerDir.y), new Vector2(playerDir.x + arcX, playerDir.y + arcY), new Vector2(playerDir.x - arcX, playerDir.y - arcY)));

            }
        }

        

        if (Input.GetKeyUp(KeyCode.Space))
        {

            RapidOn = false;

        }


        if (Shootvalve == false)
        {
            if (RapidOn == true)
            {
                Vector2 playerDir = player.GetComponent<BasicMovement>().facingDir;
                StartCoroutine(MachineSpark(playerDir));
            }

        }
    }

    private void OnEnable()
    {
        delayOn = false;
    }

    IEnumerator PistolSpark(Vector2 moveInput)
    {
        Shooter = true;
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        AudioManager.PlaySound(AudioManager.Sound.Pistol, transform.position);

        BlowBackEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        delayOn = false;
        BlowBackEffect.SetActive(false);
        Shooter = false;


    }

    IEnumerator MachineSpark(Vector2 moveInput)
    {
        Shootvalve = true;
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        AudioManager.PlaySound(AudioManager.Sound.Uzi, transform.position);

        
        yield return new WaitForSeconds(0.05f);
        Shootvalve = false;
        
        


    }

    IEnumerator ShotSpark(Vector2 shot1, Vector2 shot2, Vector2 shot3)
    {
        
        Transform bulletTransform1 = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform1.GetComponent<Bullet>().setup(shot1);

        Transform bulletTransform2 = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform2.GetComponent<Bullet>().setup(shot2);

        Transform bulletTransform3 = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform3.GetComponent<Bullet>().setup(shot3);
        AudioManager.PlaySound(AudioManager.Sound.Pistol, transform.position);
        


        yield return new WaitForSeconds(0.1f);
        




    }


}
