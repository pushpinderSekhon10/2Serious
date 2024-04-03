using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    private Enemy boss;
    public GameObject displayUserText;

    TMP_Text text;

    //[SerializeField] GameObject bossWeapon;
    //[SerializeField] GameObject barrier;


    void Start()
    {
        GameObject bossGameObject = GameObject.FindGameObjectWithTag("Boss");
        boss = bossGameObject.GetComponent<Enemy>();
        displayUserText = GameObject.FindWithTag("popup");
        text = displayUserText.GetComponent<TMP_Text>();
        

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
        text.text = "Gerard the Giant Killed, Congratulations you have been accepted to the Guild of Heros";


        Debug.Log("Text Set, 5 seconds to be called");

        // Wait for five seconds
        yield return new WaitForSeconds(5f);

        Debug.Log("WaitFor5Seconds Complete");

        text.text = "";

        PlayerBehaviour.bossKilled = true;

    }


}
