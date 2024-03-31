using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private Enemy boss;
    public TMP_Text displayUserText;

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
            StartCoroutine(displayBossKilledForFiveSeconds());
            displayUserText.text = "";
        }
    }

    string randomAttack()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);

        string[] attacks = {"attack1", "attack2", "attack3" };

        return attacks[randomNumber];
    }

    IEnumerator displayBossKilledForFiveSeconds()
    {
        // Call your method here
        displayUserText.text = "Boss Killed - Proceed to next level!";

        // Wait for five seconds
        yield return new WaitForSeconds(5f);

        // After five seconds, you can perform any other actions here
        // For example, you can call another method or do something else
    }



}
