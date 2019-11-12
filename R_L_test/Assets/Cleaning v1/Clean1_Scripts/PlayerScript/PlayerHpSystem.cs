using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpSystem : MonoBehaviour
{
    //Statement

    public float playerMaxHp;
    public float playerHp;
    public Image healthBar;
    public Image healthBarFade;
    public float playerHpFade;
    public float betweenDifferenceHp = 0.1f;


    void Start()
    {
        playerHp = playerMaxHp;
        playerHpFade = playerHp;
    }

    private void Update()
    {
        healthBar.fillAmount = playerHp / playerMaxHp;


        while (playerHpFade > playerHp)
        {
            StartCoroutine("HealthFade");

            Debug.Log(healthBarFade.fillAmount);
        }

        if (playerHpFade < playerHp)
        {
            playerHpFade = playerHp;
        }
    }

    public void PlayerIsTakingDmg(float damageValue)       //Put every action requiered when the player is taking dmg on this fonction
    {
        playerHp -= damageValue;

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

    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");
        PlayerMovement.isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }
    private IEnumerator HealthFade()
    {
        playerHpFade -= betweenDifferenceHp;
        new WaitForSeconds(10f);
        healthBarFade.fillAmount = playerHpFade / playerMaxHp;


        yield return null;
    }

}
