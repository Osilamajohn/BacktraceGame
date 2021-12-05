using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    Animator animator;
    public float waitingTime = 1f;
    float timePassed;
    Transform patata;

    int attackCount = 0;
    bool canAttack = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        timePassed = Mathf.Infinity;
      
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("canAttack", false);

        if (attackCount >= 3)
        {
            attackCount = 0;
        }


        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            attackCount += 1;
            animator.SetInteger("attackCount", attackCount);
            animator.SetBool("canAttack", true);
            canAttack = false;

            StartCoroutine(EnableAttacking());

        }




    }

    IEnumerator EnableAttacking()
    {
        yield return new WaitForSeconds(waitingTime);
        canAttack = true;
        
    }
}
