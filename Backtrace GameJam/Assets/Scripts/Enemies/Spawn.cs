using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject minions; //Array of enemy prefabs.
    private float spawnDelay = 20f;
    private float spawnTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        //Start calling the Spawn function repeatedly after a delay.
        InvokeRepeating("SpawnEnemy", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        //Instantiate a random enemy.
        Instantiate(minions, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
