using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_Dash : MonoBehaviour
{
    //Statement Start

    //Variable about Dash

    


    //Direction
    //Statement End


    
   

    /*private void Start()
    {
        dashCooldown = initialDashCooldown;
        dashTime = initialDashTime;
        playerRgb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
       
    Dash();
      
    }
    private void Dash()
    {
        horizontalMoove = Input.GetAxis("Horizontal");
        verticalMoove = Input.GetAxis("Vertical");
        

        if(isDashing == false)
        {
            if (dashCooldown <=0)
            {
               
                if (Input.GetKeyDown(KeyCode.Space) && (playerRgb.velocity.x != 0 || playerRgb.velocity.y != 0))
                {
                    isDashing = true;
                }

            }
            else
            {

                dashCooldown -= Time.fixedDeltaTime;
                if(dashCooldown <= 0)
                {
                    dashCooldown = 0;
                }

            }
        }
        else
        {
            if(dashTime <= 0)
            {

                isDashing = false;
                dashTime = initialDashTime;
                dashCooldown = initialDashCooldown;
                playerRgb.velocity = Vector2.zero;

            }
            else
            {

                dashTime -= Time.deltaTime;
                playerRgb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * dashSpeed;

            }
                   
        }
    }*/
}
