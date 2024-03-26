using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamagePurchase : Purchase
{

    //public TMP_Text displayDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPointerClick(PointerEventData eventData)
    {
        if (player.score >= 10)
        {

            player.score -= 10;
            player.currentDamage += 15;
            player.numDamageIncreases++;
            if (player.numDamageIncreases < 2)
            {
                player.shopHeader.text = player.numDamageIncreases.ToString() + " x Damage Increase Purchase";
            }
            else
            {
                player.shopHeader.text = player.numDamageIncreases.ToString() + " x Damage Increases Purchased!";
            }
            player.displayDamage.text = player.currentDamage.ToString();
            player.displayScore.text = player.score.ToString();
        }
        else {
            player.shopHeader.text = "Insufficient Funds!";
        }
    }
}
