using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    //Statement - Health System Gestion

    public float playerMaxHp;
    public float playerHp;

    //Statement - Moovement System

    public bool isPlayerMoovAvailable;
    public float speed;
    public Vector3 moove;
    public Rigidbody2D playerRgb;
    public float horizontalMoove;       //these variables exist just to check joystick value with a Debug.Log
    public float verticalMoove;         //look upward

    void Start()
    {
        playerHp = playerMaxHp;
        isPlayerMoovAvailable = true;
    }
   
    void FixedUpdate()
    {

        //classic moovement gestion with left joystick: start

        horizontalMoove = Input.GetAxis("Horizontal");
        verticalMoove = Input.GetAxis("Vertical");
        
        moove = new Vector3(horizontalMoove, verticalMoove, 0);



        if (isPlayerMoovAvailable == true)
        {
            playerRgb.velocity = moove * speed * Time.fixedDeltaTime;
        }

        //classic moovement gestion with left joystick: end

    }

    // Health System

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

    public void PlayerIsHealing(float heal)             //Put every action requiered when the player is healed  
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
        isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
}

