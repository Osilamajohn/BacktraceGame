using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    Animator animator;
    public float waitingTime = 1f;
    float timePassed;
    Transform patata;
    public Transform collisionPoint;
    public float radius = 1;

    int attackCount = 0;
    bool canAttack = true;
    playerHit playerHit;
    public int playerDamage = 10;

    void Start()
    {
        animator = GetComponent<Animator>();
        timePassed = Mathf.Infinity;

        playerHit = GameObject.Find("hit").GetComponent<playerHit>();
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


            if(playerHit.enemyInSight != null)
            {
                playerHit.enemyInSight.GetComponent<minionMain>().EnemyHealth -= playerDamage;
            }

            StartCoroutine(EnableAttacking());

        }



        Debug.Log(playerHit.enemyInSight.name);



    }

    IEnumerator EnableAttacking()
    {
        yield return new WaitForSeconds(waitingTime);
        canAttack = true;
        
    }
}
