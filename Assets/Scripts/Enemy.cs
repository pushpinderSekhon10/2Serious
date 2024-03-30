using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float health = 3;
    [SerializeField] GameObject weapon;

    [Header("Combat")]
    [SerializeField] public float attackCD = 1f;
    [SerializeField] public float attackRange = 1f;
    [SerializeField] public float aggroRange = 4f;
    [SerializeField] public String attackType;

    public bool died = false;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    HealthSystem playerDied;


    float timePassed;
    float newDestinationCD = 0.5f;
   
    
    void Start()
    {
        player = GameObject.FindWithTag("DemoPlayer");
        playerDied = player.GetComponent<HealthSystem>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");

        if (health <= 0)
        {
            Die();
            died = true;
        }
    }

    public bool Die()
    {
        //Destroy(this.gameObject);
        
        animator.SetTrigger("death");
        
        GetComponent<CapsuleCollider>().enabled = false;
        
        agent.isStopped = true;
        agent.SetDestination(transform.position);
        
        enabled = false;

        EnemyDamageDealer damageDealer = weapon.GetComponentInChildren<EnemyDamageDealer>();
        damageDealer.enabled = false;

        return true;
        
    }
    
    public void AttackingBehaviour(String attackType)
    {
        animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);

        if (playerDied.deathProperty == true)
        {

            return;
        }

        if (timePassed >= attackCD)
        {
            //Debug.Log("Distance to player: " + Vector3.Distance(player.transform.position, transform.position));

            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {

                animator.SetTrigger(attackType);
                timePassed = 0;


            }
        }

        timePassed += Time.deltaTime;


        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);

        }

        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);
    }

    void Update()
    {
        /*animator.SetFloat("speed", agent.velocity.magnitude / agent.speed);
        
        if (playerDied.deathProperty == true)
        {
            
            return;
        }

        if (timePassed >= attackCD)
        {
            //Debug.Log("Distance to player: " + Vector3.Distance(player.transform.position, transform.position));

            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                
                animator.SetTrigger("attack");
                timePassed = 0;

                
            }
        }
        
        timePassed += Time.deltaTime;


        if (newDestinationCD <= 0 && Vector3.Distance(player.transform.position, transform.position) <= aggroRange)
        {
            newDestinationCD = 0.5f;
            agent.SetDestination(player.transform.position);
            
        }

        newDestinationCD -= Time.deltaTime;
        transform.LookAt(player.transform);*/

        AttackingBehaviour("attack");
    }

    public void StartDealDamage()
    {
        weapon.GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        weapon.GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
