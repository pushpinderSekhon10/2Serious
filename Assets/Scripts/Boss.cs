using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private Enemy boss;

    //[SerializeField] GameObject bossWeapon;
    [SerializeField] GameObject barrier;


    void Start()
    {
        GameObject bossGameObject = GameObject.FindGameObjectWithTag("Boss");
        boss = bossGameObject.GetComponent<Enemy>();

    }


    void Update()
    {
        boss.AttackingBehaviour(randomAttack());

        if (boss.died == true)
        {
            Debug.Log("disabled");
            enabled = false;
            Destroy(barrier);
        }
    }

    string randomAttack()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);

        string[] attacks = {"attack1", "attack2", "attack3" };

        return attacks[randomNumber];
    }

}
