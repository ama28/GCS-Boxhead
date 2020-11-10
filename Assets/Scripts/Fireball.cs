using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    private Vector3 dir;
    private float travelledDistance = 0;
    public float moveSpeed = 80f;
    public float timeAlive = 30f;

    public void setup(Vector3 dir)
    {
        this.dir = dir.normalized;
        transform.eulerAngles = new Vector3(0, 0, getAngleFromVector(dir) - 90);
        Destroy(gameObject, timeAlive);
    }

    public void Update()
    {
        float d = moveSpeed * Time.deltaTime;
        travelledDistance += d;
        transform.position += dir * d;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Wall"){
            Destroy(gameObject, 0.15f);
            DataManager.Instance.changeHealth(-20);
        }
    }

    //return abs degrees angle from vector (float)
    public float getAngleFromVector(Vector3 dir)
    {
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
}
