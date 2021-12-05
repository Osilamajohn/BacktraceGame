using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHit : MonoBehaviour
{

    public GameObject enemyInSight;
    public float attackDistance = 4;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            Debug.Log("lol");
            enemyInSight = other.gameObject;
        }
    }


    private void Update()
    {
        if (enemyInSight != null)
        {
            if (Vector2.Distance(GameObject.FindGameObjectWithTag("Player").transform.position, enemyInSight.transform.position) > attackDistance)
            {
                enemyInSight = null;
            }
        }
    }
}

 
