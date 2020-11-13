using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePistol : MonoBehaviour
{
    [SerializeField] private Transform pfBullet;
    private AudioSource gunshot;
    [SerializeField] private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        gunshot = player.GetComponent<AudioSource>();
        gunshot.volume = 0.5f;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 playerDir = player.GetComponent<BasicMovement>().facingDir;
            this.Shoot(playerDir);
        }
    }

    void Shoot(Vector2 moveInput)
    {
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
        gunshot.Play();
    }
}
