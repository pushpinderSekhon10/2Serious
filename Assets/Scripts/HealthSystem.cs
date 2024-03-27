using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthSystem : MonoBehaviour

{
    [SerializeField] float health = 100;
    Animator animator;
    NavMeshAgent agent;

    //animationStateController weaponHolder = new animationStateController();


    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        animator.SetTrigger("damage");

        if (health <= 0)
        {
            Die();
        }
    }

    public bool Die()
    {
        //GameObject weapon = weaponHolder.Weapon;

        animator.SetTrigger("death");
        
        GetComponent<CharacterController>().enabled = false;
        GetComponent<Example>().enabled = false;


        GetComponent<CapsuleCollider>().enabled = false;
        agent.isStopped = true;
        agent.SetDestination(transform.position);

        //DamageDealer damageDealer = weapon.GetComponentInChildren<DamageDealer>();
        //damageDealer.enabled = false;

        return true;
    }
}
