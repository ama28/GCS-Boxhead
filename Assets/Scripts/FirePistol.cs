using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    [SerializeField] private GameObject player;

    [SerializeField] private Sprite Pistol;
    [SerializeField] private Sprite Minigun;
    [SerializeField] private Sprite Shotgun;


    public GameObject BlowBackEffectPistol;
  
    public Animator animator;

    public bool Shooter;

    public bool delayOn;



    public int gunNum;

    public Vector2 playerDir;

    float interval;
    BasicMovement playerMovement;

    public Transform MiniGunPos;

    public Transform ShotGunPos;

    private SpriteRenderer GunSprites;

   
    // Update is called once per frame
    private void Awake()
    {
        GunSprites = this.GetComponent<SpriteRenderer>();

   
    }

    void Update()
    {

      gunNum =  player.GetComponent<BasicMovement>().MainGunNum;

        animator.SetBool("Shot", Shooter);


        if (gunNum == 1)
        {
            //Turning on and off the visuals for the guns
            GunSprites.sprite = Pistol;
            BlowBackEffectPistol.transform.position = this.transform.position;
        }

        if (gunNum == 2)
        {
            //Turning on and off the visuals for the guns
            GunSprites.sprite = Minigun;
            BlowBackEffectPistol.transform.position = MiniGunPos.position;
        }

        if (gunNum == 3)
        {
            //Turning on and off the visuals for the guns
            GunSprites.sprite = Shotgun;
            BlowBackEffectPistol.transform.position = ShotGunPos.position;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 playerDir = playerMovement.facingDir;

            

            if (gunNum == 1)
            {
               
                if (delayOn == false)
                {
                    delayOn = true;
                    
                    //this.Shoot(playerDir);
                    StartCoroutine(PistolSpark(playerDir));
                }
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

        if (gunNum == 2)
        {
                if (Input.GetKey(KeyCode.Space))
            {
                Shooter = true;
                Vector2 playerDir = playerMovement.facingDir;

                interval += Time.deltaTime;
                if (interval > 0.05f)
                {
                    Shooter = true;
                    BlowBackEffectPistol.SetActive(true);
                    MachineSpark(playerDir);
                    interval = 0;
                }
            }
        }
    }

    private void OnEnable()
    {
        delayOn = false;
        interval = 0;
        playerMovement = player.GetComponent<BasicMovement>();
    }

    IEnumerator PistolSpark(Vector2 moveInput)
    {
        Shooter = true;
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        AudioManager.PlaySound(AudioManager.Sound.Pistol, transform.position);
        BlowBackEffectPistol.transform.position = this.transform.position;
        BlowBackEffectPistol.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        delayOn = false;
        BlowBackEffectPistol.SetActive(false);
        Shooter = false;


    }

    void MachineSpark(Vector2 moveInput)
    {

        
        Transform bulletTransform = Instantiate(pfBullet, MiniGunPos.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        AudioManager.PlaySound(AudioManager.Sound.Uzi, transform.position);
        BlowBackEffectPistol.SetActive(false);
        Shooter = false;
    }

    IEnumerator ShotSpark(Vector2 shot1, Vector2 shot2, Vector2 shot3)
    {

        Shooter = true;
        BlowBackEffectPistol.SetActive(true);
        Transform bulletTransform1 = Instantiate(pfBullet, ShotGunPos.position, Quaternion.identity);
        bulletTransform1.GetComponent<Bullet>().setup(shot1);

        Transform bulletTransform2 = Instantiate(pfBullet, ShotGunPos.position, Quaternion.identity);
        bulletTransform2.GetComponent<Bullet>().setup(shot2);

        Transform bulletTransform3 = Instantiate(pfBullet, ShotGunPos.position, Quaternion.identity);
        bulletTransform3.GetComponent<Bullet>().setup(shot3);
        AudioManager.PlaySound(AudioManager.Sound.Pistol, transform.position);
        


        yield return new WaitForSeconds(0.1f);
        BlowBackEffectPistol.SetActive(false);
        Shooter = false;



    }


}
