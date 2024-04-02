using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DamagePurchaseBehaviour : PurchaseBehaviour
{

    //public TMP_Text displayDamage;
    public GameObject damage_object;
    public DamageDealer damageDealer;

    // Start is called before the first frame update
    void Start()
    {
        damageDealer = damage_object.GetComponent<DamageDealer>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            updateResource();
        }
    }

    public override void updateResource()
    {
        if (player.score >= 10)
        {

            player.score -= 10;
            //player.currentDamage += 15;
            player.numDamageIncreases++;
            damageDealer.weaponDamage += 1;
            
            if (player.numDamageIncreases < 10)
            {
                player.shopHeader.text = player.numDamageIncreases.ToString() + " x Damage Increase Purchased";
            }
            else
            {
                player.shopHeader.text = player.numDamageIncreases.ToString() + " x Damage Increases Purchased!";
            }
            //player.displayDamage.text = player.currentDamage.ToString();
            //player.displayScore.text = player.score.ToString();
        }
        else
        {
            player.shopHeader.text = "Insufficient Funds!";
        }
    }
}