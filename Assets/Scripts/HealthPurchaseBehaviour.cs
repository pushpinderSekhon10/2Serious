using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthPurchaseBehaviour : PurchaseBehaviour
{
    public HealthSystem healthSystem;
    public GameObject player_character;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = player_character.GetComponent<HealthSystem>();
       
          
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
        if (player.score >= 10)
        {
            if (player.currentHealth + 10 <= player.healthCapacity)
            {
                player.score -= 10;
                player.currentHealth += 10;
                healthSystem.health += 10;
                
                
                player.numHealthIncreases++;
                if (player.numHealthIncreases < 2)
                {
                    player.shopHeader.text = player.numHealthIncreases.ToString() + " x Health Increase Purchased";
                }
                else
                {
                    player.shopHeader.text = player.numHealthIncreases.ToString() + " x Health Increases Purchased!";
                }
                //player.displayHealthCapacity.text = player.healthCapacity.ToString();
                //player.displayScore.text = player.score.ToString();
            }
            else {
                player.shopHeader.text = "Health too high!";
            }
        }
        else
        {
            player.shopHeader.text = "Insufficient Funds!";
        }
    }
}
