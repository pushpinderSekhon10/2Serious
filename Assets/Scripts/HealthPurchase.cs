using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthPurchase : Purchase
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public TMP_Text displayHealthCapacity;
    
    public override void OnPointerClick(PointerEventData eventData)
    {
        if (player.score >= 10)
        {

            player.score -= 10;
            player.healthCapacity += 15;
            player.numHealthIncreases++;
            if (player.numHealthIncreases < 2)
            {
                player.shopHeader.text = player.numHealthIncreases.ToString() + " x Health Increase Purchase";
            }
            else
            {
                player.shopHeader.text = player.numHealthIncreases.ToString() + " x Health Increases Purchased!";
            }
            player.displayHealthCapacity.text = player.healthCapacity.ToString();
            player.displayScore.text = player.score.ToString();
        }
        else
        {
            player.shopHeader.text = "Insufficient Funds!";
        }
    }
}
