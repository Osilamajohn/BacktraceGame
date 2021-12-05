using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameManager.instance.collected += 1;

            if(GameManager.instance.health <= 100)
            {
                GameManager.instance.health += 10;
            }
            
            Destroy(gameObject);
        }
    }
}
