using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KeyBehaviour : PurchaseBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject characterObject = GameObject.FindWithTag("DemoPlayer");
        //player = characterObject.GetComponent<PlayerBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            updateResource();
        }
    }

    public override void updateResource()
    {
        Debug.Log("Hello");
        //player.currentDamage += 30;
        //player.healthCapacity += 20;
        //player.currentHealth = player.healthCapacity;
        Destroy(gameObject);

            //player.displayDamage.text = player.currentDamage.ToString();
            //player.displayScore.text = player.score.ToString();

    }

}
