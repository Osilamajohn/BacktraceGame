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
    public AudioSource punch;
    public AudioSource specialSound;

    public GameObject special;

    GameObject[] enemies;

    public float specialRange = 6f;



    public float specialCooldown = 8f;
    float specialPassed;

    void Start()
    {
        animator = GetComponent<Animator>();
        timePassed = Mathf.Infinity;

        playerHit = GameObject.Find("hit").GetComponent<playerHit>();
        specialPassed = Mathf.Infinity;
        special.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        enemies = GameObject.FindGameObjectsWithTag("enemy");

        animator.SetBool("canAttack", false);

        if (attackCount >= 3)
        {
            attackCount = 0;
        }


        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            attackCount += 1;
            punch.Play();
            animator.SetInteger("attackCount", attackCount);
            animator.SetBool("canAttack", true);
            canAttack = false;


            if(playerHit.enemyInSight != null)
            {
                if(playerHit.enemyInSight.name != "MainBossWithAnimations")
                {
                    playerHit.enemyInSight.GetComponent<minionMain>().EnemyHealth -= playerDamage;
                } else
                {
                    playerHit.enemyInSight.GetComponent<BossMain>().bossHealth -= playerDamage;
                }
                
            }

            StartCoroutine(EnableAttacking());

        }



        if(Input.GetMouseButtonDown(1) && specialPassed >= specialCooldown)
        {
            special.SetActive(true);
            specialSound.Play();
            StartCoroutine(specialTiming());
            specialPassed = 0;
            animator.SetTrigger("special");

            foreach(GameObject enemy in enemies)
            {
                if(Vector3.Distance(transform.position, enemy.transform.position) < specialRange)
                {
                    if(enemy.GetComponent<minionMain>() != null)
                    {
                        if (playerHit.enemyInSight.name != "MainBossWithAnimations")
                        {
                            enemy.GetComponent<minionMain>().EnemyHealth -= 30;
                        } else
                        {
                            enemy.GetComponent<BossMain>().bossHealth -= 30;
                        }
                            
                    }
                    
                }
            }


        }

        specialPassed += Time.deltaTime;

        



    }

    IEnumerator EnableAttacking()
    {
        yield return new WaitForSeconds(waitingTime);
        canAttack = true;
        
    }

    IEnumerator specialTiming()
    {
        yield return new WaitForSeconds(5);
        special.SetActive(false);
    }


}
