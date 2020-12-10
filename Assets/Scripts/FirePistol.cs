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

    private Camera MainCamera;

    private Vector3 camStartPos;

   
    // Update is called once per frame
    private void Awake()
    {
        GunSprites = this.GetComponent<SpriteRenderer>();
        MainCamera = player.GetComponentInChildren<Camera>();
        camStartPos = MainCamera.transform.localPosition;
    }

    public void setCameraPos(Vector3 position) {
        camStartPos = position;
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
                if(DataManager.Instance.ammo > 0 && DataManager.Instance.shotInterval > 0.56f) {
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
                    DataManager.Instance.shotInterval = 0;
                    DataManager.Instance.ammo -= 3;
                    StartCoroutine(ShotSpark(new Vector2(playerDir.x, playerDir.y), new Vector2(playerDir.x + arcX, playerDir.y + arcY), new Vector2(playerDir.x - arcX, playerDir.y - arcY)));
                } else if(DataManager.Instance.ammo <= 0){
                    AudioManager.PlaySound(AudioManager.Sound.GunEmpty, transform.position);
                }
                
            }
        }

        if (gunNum == 2)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Shooter = true;
                Vector2 playerDir = playerMovement.facingDir;

                interval += Time.deltaTime;
                if (interval > 0.07f)
                {
                    if(DataManager.Instance.ammo > 0) {
                        DataManager.Instance.ammo -= 1;
                        Shooter = true;
                        BlowBackEffectPistol.SetActive(true);
                        MachineSpark(playerDir);
                        interval = 0;
                    } else {
                        AudioManager.PlaySound(AudioManager.Sound.GunEmpty, transform.position);
                    }
                    
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
        StartCoroutine(Shake(4, .06f));
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
        StartCoroutine(Shake(1, .05f));
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
        StartCoroutine(Shake(7, 0.3f));
        AudioManager.PlaySound(AudioManager.Sound.Shotgun, transform.position);


        yield return new WaitForSeconds(0.1f);
        BlowBackEffectPistol.SetActive(false);
        Shooter = false;



    }

    IEnumerator Shake(int shakeTimes, float shakeAmount)
    {
        Vector3 newPos = camStartPos;
        for(int i = 0; i < shakeTimes; i++)
        {
            float offsetX = RandomSign() * Random.Range(0.7f, 1) * shakeAmount * 2 * ((shakeTimes - i)/shakeTimes * 0.8f + 0.3f);
            float offsetY = RandomSign() * Random.Range(0.7f, 1) * shakeAmount * 2 * ((shakeTimes - i)/shakeTimes * 0.8f + 0.3f);
            newPos.x = camStartPos.x + offsetX;
            newPos.y = camStartPos.y + offsetY;

            MainCamera.transform.localPosition = newPos;
            yield return new WaitForSeconds(0.01f);
        }
        MainCamera.transform.localPosition = camStartPos;
    }

    float RandomSign() {
        return (((float)Random.Range(0,2)) - .5f) * 2;
    }

}
