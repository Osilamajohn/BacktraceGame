using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossMain : MonoBehaviour
{

    public GameObject player;
    public Transform bossPoss;

    float attackingPassed = 0;
    float attackingWaiting;
    bool attaking = false;
    public float maxTimeAtt, minTimeAtt;
    bool moving = false;
    public float mSpeed;
    Animator animator;
    public float timeForAttack;
    bool returning = false;
    public float attackRange;
    bool attack = false;
    bool once = false;
    bool courrutineOnce = false;
    bool offReturnOnce = false;

    NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player.transform);

        if (!attaking)
        {
            attaking = true;
            attackingWaiting = Random.Range(minTimeAtt, maxTimeAtt);
        }

        if (attaking)
        {
            attackingPassed += Time.deltaTime;
        }

        if(attackingPassed >= attackingWaiting && !once)
        {
           
            moving = true;
          
        }

        if (moving == true)
        {
            navMeshAgent.destination = player.transform.position + new Vector3(-2, 0, -2);
            animator.SetBool("walking", true);
            if (!courrutineOnce)
            {
                courrutineOnce = true;
                StartCoroutine(attakingTime());
            }
            
        }
        

        if(attack)
        {
            animator.SetTrigger("attack");
            attack = false;

            if(Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position) < attackRange)
            {
                GameManager.instance.health -= 25;
            }



            StartCoroutine(returningTime());

          

        }


        if (returning)
        {
            navMeshAgent.destination = bossPoss.position;
            animator.SetBool("walking", true);

            if (!offReturnOnce)
            {
                StartCoroutine(returningOff());
            }
            
        }

        if(transform.position == bossPoss.position && returning)
        {
            returning = false;
            animator.SetBool("walking", false);

            attaking = false;
            attackingPassed = 0;

            Debug.Log("potato");
        }

        

    }


    IEnumerator attakingTime()
    {
        yield return new WaitForSeconds(timeForAttack);
        moving = false;
        attack = true;
        once = true;
        animator.SetBool("walking", false);
        navMeshAgent.destination = transform.position;
    }

    IEnumerator returningTime()
    {
        yield return new WaitForSeconds(2);
        returning = true;
    }

    IEnumerator returningOff()
    {
        yield return new WaitForSeconds(1.5f);
        returning = false;
        animator.SetBool("walking", false);

        attaking = false;
        attackingPassed = 0;
        attack = false;
        courrutineOnce = false;

        offReturnOnce = false;
        once = false;

        Debug.Log("potato");
    }
}
