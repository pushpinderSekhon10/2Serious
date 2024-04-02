using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthPurchaseBehaviour : PurchaseBehaviour
{
    public HealthSystem healthSystem;
    public GameObject player_character;
    public PlayerBehaviour playerBehaviour;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = player_character.GetComponent<HealthSystem>();
        playerBehaviour = player_character.GetComponent<PlayerBehaviour>();
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            updateResource();
        }
    }

    //public TMP_Text displayHealthCapacity;

    public override void updateResource()
    {
        score = playerBehaviour.score;
        if (score >= 10)
           
        {
            playerBehaviour.score = score - 10;
            if (true)
            {
                
                healthSystem.health += 3;


                playerBehaviour.numHealthIncreases++;
                if (playerBehaviour.numHealthIncreases < 10)
                {
                    playerBehaviour.shopHeader.text = playerBehaviour.numHealthIncreases.ToString() + " x Health Increase Purchased";
                }
                else
                {
                    playerBehaviour.shopHeader.text = playerBehaviour.numHealthIncreases.ToString() + " x Health Increases Purchased!";
                }
                //player.displayHealthCapacity.text = player.healthCapacity.ToString();
                //player.displayScore.text = player.score.ToString();
            }
            //else {
            //    playerBehaviour.shopHeader.text = "Health too high!";
            //}
        }
        else
        {
            playerBehaviour.shopHeader.text = "Insufficient Funds!";
        }
    }
}
