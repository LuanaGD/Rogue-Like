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

    public void PlayerIsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        playerHp -= damageValue;
        Debug.Log("Vous prennez " + damageValue + " dégats");
        Debug.Log("Vous avez " + playerHp + " points de vie");

        if (playerHp <= 0)
        {
            PlayerDeath();
        }
    }

    public void PlayerIsHealing(float healValue)             //Put every action requiered when the player is healed on this fonction  
    {
        playerHp += healValue;

        if (playerHp > playerMaxHp)
        {
            playerHp = playerMaxHp;
        }

        Debug.Log("Vous récupérez " + healValue + " points de vie");
        Debug.Log("Vous avez " + playerHp + " points de vie");
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");
        PlayerMovement.isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
}
