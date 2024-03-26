using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HealthPurchaseBehaviour : PurchaseBehaviour
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
            if (player.currentHealth + 10 <= player.healthCapacity)
            {
                player.score -= 10;
                player.currentHealth += 10;
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
