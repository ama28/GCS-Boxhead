using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector3 shootDir;
    public float moveSpeed = 80f;
    public float timeAlive = 5f;

    public void setup(Vector3 dir)
    {
        this.shootDir = dir;
        transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(shootDir)-90);
        Destroy(gameObject, timeAlive);
    }

    public void Update()
    {
        transform.position += shootDir * moveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") Destroy(gameObject);
    }


    //return abs degrees angle from vector (float)
    public float getAngleFromVector(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
