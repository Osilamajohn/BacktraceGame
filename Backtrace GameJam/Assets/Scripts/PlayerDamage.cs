using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    Animator animator;
    public float waitingTime = 4f;
    float timePassed;
    Transform patata;

    void Start()
    {
        animator = GetComponent<Animator>();
        timePassed = Mathf.Infinity;
      
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && timePassed >= waitingTime)
        {
            animator.SetTrigger("punch1");
            timePassed = 0;
            
        }



        timePassed += Time.deltaTime;



    }
}
