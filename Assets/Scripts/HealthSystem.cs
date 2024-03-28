using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthSystem : MonoBehaviour

{
    [SerializeField] public float health;
    Animator animator;
    NavMeshAgent agent;
    public bool death;

    //animationStateController weaponHolder = new animationStateController();
    public HealthSystem()
    {

    }

    public bool deathProperty
    {
        
        get
        {
            return death;
        }

    }


    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
  
        
    }

    
    void Update()
    {
        //health = healthPurchaseBehaviour.healthInHealthSystem;
        
        
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

    public void Die()
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

        death = true;
    }
}
