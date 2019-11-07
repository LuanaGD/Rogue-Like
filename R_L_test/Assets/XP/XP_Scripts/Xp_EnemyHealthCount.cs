using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Xp_EnemyHealthCount : MonoBehaviour
{

    public float startHealth = 40f;
    private float health;
    

    public Image healthBar;



    // Start is called before the first frame update
    void Start()
    {
        
        // Resets health to full on game load
        health = startHealth;

    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(6);
            Debug.Log("Il vous reste " + health);
        }
        healthBar.fillAmount =  health / startHealth;
    }

    void DealDamage (float damageValue)
    {
        // Deduct the damage dealt from the character's health
        health -= damageValue;

        if (health <= 0)
        {
            Debug.Log("Dead");
            Destroy(gameObject);
            
        }
    }

   

}
