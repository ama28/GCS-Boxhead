using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private Transform pfBullet;
    private Vector3 pToMouse;
    private Vector3 bulletStart;
    public float HP = 10000; //temporary (need to add HP code from David)

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        //movement is already done in BasicMovement.cs
        //transform.position += (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)) * spd * Time.deltaTime;
        Vector2 playerDir = gameObject.GetComponent<BasicMovement>().facingDir;
        if (Input.GetKeyDown(KeyCode.Space))
            this.Shoot(playerDir);
    }

    void Shoot(Vector2 moveInput)
    {
        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
        bulletTransform.GetComponent<Bullet>().setup(moveInput);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Fireball") this.HP -= 1;
    }
}

//public class PlayerController : MonoBehaviour
//{

//    [SerializeField] private Transform pfBullet;
//    private Vector3 pToMouse;
//    private Vector3 bulletStart;
//    public float HP = 10000; //temporary (need to add HP code from David)

//    // Start is called before the first frame update
//    void Start()
//    {

//    }


//    // Update is called once per frame
//    void Update()
//    {
//        //movement is already done in BasicMovement.cs
//        //transform.position += (new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)) * spd * Time.deltaTime;
//        this.pToMouse = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
//        if (Input.GetKeyDown(KeyCode.Space))
//            this.Shoot();
//    }

//    void Shoot()
//    {
//        Transform bulletTransform = Instantiate(pfBullet, transform.position, Quaternion.identity);
//        bulletTransform.GetComponent<Bullet>().setup(pToMouse);
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Fireball") this.HP -= 1;
//    }
//}
