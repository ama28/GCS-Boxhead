using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Use by attaching to some game object to spawn zombie/devil prefabs, helpful for testing

public class Spawner : MonoBehaviour
{

    public float period;
    public float devilRate;
    public int maxEnemies;
    public int enemiesSpawned = 0;

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
        if (this.timer >= period && enemiesSpawned < maxEnemies)
        {
            GameObject spawned;
            if (Random.Range(0f, 1.0f) < devilRate)
            {
                spawned = Instantiate(devil, transform.position, Quaternion.identity).gameObject;
                Devil script = spawned.GetComponent<Devil>();
                script.setSpawn(this);
            }
            else
            {
                spawned = Instantiate(zombie, transform.position, Quaternion.identity).gameObject;
                Zombie script = spawned.GetComponent<Zombie>();
                script.setSpawn(this);
            }
            this.timer = 0;
            enemiesSpawned++;
            
        }
    }
}
