﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : PlayerSource
{
    
    void Start()
    {
        playerRgb.GetComponent<Rigidbody2D>();

        //Moovement System

        isPlayerMoovAvailable = true;
        direction = 0;

        //Dash System

        isPlayerDashAvailable = true;
    }


    void FixedUpdate()
    {
        horizontalMoove = Input.GetAxis("Horizontal");
        verticalMoove = Input.GetAxis("Vertical");

        moove = new Vector3(horizontalMoove, verticalMoove, 0);
        if (Input.GetKeyDown(KeyCode.Y) && isPlayerDashAvailable == true)
        {
            StartCoroutine(SmoothDash(moove));
        }

        if (isPlayerMoovAvailable == true)
        {
            playerRgb.velocity = moove * speed * Time.fixedDeltaTime;
        }

        if (moove != null)
        {
            if (Mathf.Abs(horizontalMoove) > Mathf.Abs(verticalMoove))
            {
                if (horizontalMoove > 0)
                {
                    direction = 0;      //right
                }
                else if (horizontalMoove < 0)
                {
                    direction = 1;      //left
                }
            }
            else
            {

                if (verticalMoove > 0)
                {
                    direction = 2;      //up
                }
                else if (verticalMoove < 0)
                {
                    direction = 3;      //down
                }
            }
        }

       Debug.Log(direction);
    }

    IEnumerator SmoothDash(Vector3 direction)
    {
        Debug.Log("on entre dans la coroutine");
        float timer = 0.0f;
        isPlayerDashAvailable = false;
        isPlayerMoovAvailable = false;

        while (timer < dashTime)
        {
            playerRgb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);
            timer += Time.deltaTime;
            yield return null;
        }

        playerRgb.velocity = Vector3.zero;

        yield return new WaitForSeconds(dashCooldown);
        isPlayerDashAvailable = true;
        isPlayerMoovAvailable = true;
        
    }
}
