using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private Enemy boss;

    [SerializeField] GameObject bossWeapon;

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    HealthSystem playerDied;

    float timePassed;
    float newDestinationCD = 0.5f;

    void Start()
    {
        GameObject bossGameObject = GameObject.FindGameObjectWithTag("Boss");
        boss = bossGameObject.GetComponent<Enemy>();
        boss.health = 10;
        boss.attackCD = 1;
        boss.aggroRange = 10;
        boss.attackRange = 5;

        player = GameObject.FindWithTag("DemoPlayer");
        playerDied = player.GetComponent<HealthSystem>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        boss.AttackingBehaviour(randomAttack());

    }

    void Die()
    {
        boss.Die();
    }

    void TakeDamage(float damageAmount)
    {
        boss.TakeDamage(damageAmount);
    }

    public void StartDealDamage()
    {
        bossWeapon.GetComponentInChildren<EnemyDamageDealer>().StartDealDamage();
    }

    public void EndDealDamage()
    {
        bossWeapon.GetComponentInChildren<EnemyDamageDealer>().EndDealDamage();
    }

    string randomAttack()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);

        string[] attacks = {"attack1", "attack2", "attack3" };

        return attacks[randomNumber];
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, boss.attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, boss.aggroRange);
    }
}
