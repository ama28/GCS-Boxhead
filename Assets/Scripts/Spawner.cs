using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use by attaching to some game object to spawn zombie/devil prefabs, helpful for testing

public class Spawner : MonoBehaviour
{

    public float period;
    public float devilRate;

    [SerializeField] private Transform zombie;
    [SerializeField] private Transform devil;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        this.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        if (this.timer >= period)
        {
            if (Random.Range(0f, 1.0f) < devilRate)
            {
                Instantiate(devil, transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(zombie, transform.position, Quaternion.identity);
            }
            this.timer = 0;
        }
    }
}
