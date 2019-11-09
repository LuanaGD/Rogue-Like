using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHpSystem : MonoBehaviour
{
    //Statement

    public float playerMaxHp;
    public float playerHp;

    void Start()
    {
        playerHp = playerMaxHp;
    }

    public void PlayerIsTakingDmg(float dmgTaken)       //Put every action requiered when the player is taking dmg on this fonction
    {
        playerHp -= dmgTaken;
        Debug.Log("Vous prennez " + dmgTaken + " dégats");
        Debug.Log("Vous avez " + playerHp + " points de vie");

        if (playerHp <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerIsHealing(float heal)             //Put every action requiered when the player is healed on this fonction  
    {
        playerHp += heal;

        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }

        Debug.Log("Vous récupérez " + heal + " points de vie");
        Debug.Log("Vous avez " + playerHp + " points de vie");
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");
        PlayerMovement.isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
}
