using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XP_PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerMaxHp ;
    private float playerHp;


    public Image healthBar;



    // Start is called before the first frame update
    void Start()
    {
       
        // Resets health to full on game load
       

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            DealDamage(6);
            Debug.Log("Il vous reste " + playerHp);
        }

        healthBar.fillAmount =  playerHp / playerMaxHp;

    }
    void DealDamage(float damageValue)
    {
        // Deduct the damage dealt from the character's health
        playerHp -= damageValue;

        if (playerHp <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);

        }
    }
}
