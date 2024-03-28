using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{

    public int score;
        //, xpPoints, currentDamage, currentHealth, healthCapacity;

    void Start()
    {

    }

    void Update()
    {

    }

    public void updateScore(int scoreInc)
    {
        this.score += scoreInc;
    }

    public void updateHealth(int healthInc)
    {
        //if ((currentHealth + healthInc) <= healthCapacity)
        {   
            //this.currentHealth += healthInc;
        }
        //if (currentHealth <= 0)
        {
            //Destroy(this);
        }
    }

    public void updateHealthCapacity(int healthCapInc)
    {
        //this.healthCapacity += healthCapInc;
    }

    public void updateXP(int xpInc)
    {
        //this.xpPoints += xpInc;
    }

}
