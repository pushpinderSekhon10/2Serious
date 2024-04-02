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
    //[SerializeField] GameObject barrier;


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
            enabled = false;
            StartCoroutine(bossKilledText());
        }
    }

    string randomAttack()
    {
        int randomNumber = UnityEngine.Random.Range(0, 3);

        string[] attacks = {"attack1", "attack2", "attack3" };

        return attacks[randomNumber];
    }

    IEnumerator bossKilledText()
    {
        // Call your method here
        displayUserText.text = "Boss Killed - Proceed to next level!";

        Debug.Log("Text Set, 5 seconds to be called");

        // Wait for five seconds
        yield return new WaitForSeconds(5f);

        Debug.Log("WaitFor5Seconds Complete");

        displayUserText.text = "";

        PlayerBehaviour.bossKilled = true;

    }


}
