using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : PlayerSource
{
    
    void Start()
    {
        currentHp = maxHp;
        playerRgb.GetComponent<Rigidbody2D>();
    }


    // Health System

    public void PlayerIsTakingDmg(float dmgTaken)       //Put every action requiered when the player is taking dmg on this fonction
    {
        currentHp -= dmgTaken;
        Debug.Log("Vous prennez " + dmgTaken + " dégats");
        Debug.Log("Vous avez " + currentHp + " points de vie");

        if (currentHp <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerIsHealing(float heal)             //Put every action requiered when the player is healed  
    {
        currentHp += heal;

        if (currentHp > maxHp)
        {
            currentHp = maxHp;
        }

        Debug.Log("Vous récupérez " + heal + " points de vie");
        Debug.Log("Vous avez " + currentHp + " points de vie");
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");
        isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
}
