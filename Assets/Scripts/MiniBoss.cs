using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniBoss: MonoBehaviour
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
        
        
        if (boss.died == true)
        {
            enabled = false;
            StartCoroutine(bossKilledText());
        }
    }

    

    IEnumerator bossKilledText()
    {
        Debug.Log("success");
        // Call your method here
        text.text = "Boss Killed - Proceed to next level!";

        Debug.Log("Text Set, 5 seconds to be called");

        // Wait for five seconds
        yield return new WaitForSeconds(5f);

        Debug.Log("WaitFor5Seconds Complete");

        text.text = "";

        PlayerBehaviour.bossKilled = true;

    }


}