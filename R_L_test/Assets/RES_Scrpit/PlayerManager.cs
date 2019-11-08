using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int direction;

    //Statement - Attack System

    public bool isPlayerAttackAvailable;
    public float attackSpeed;
    public GameObject[] attackDirectionList;
    public int attackDirection;

    //Dash
    public bool isDashing;
    public float dashSpeed = 3f;
    public float dashTime;
    public float initialDashTime = 1f;
    public float dashCooldown;
    public float initialDashCooldown = 3f;
    public AnimationCurve dashCurve;

    //heal
    public Image healthBar;



    void Start()
    {
        playerRgb.GetComponent<Rigidbody2D>();
        //Health System

        playerHp = playerMaxHp;

        //Moovement System

        isPlayerMoovAvailable = true;
        direction = 0;

        //AttackSystem

        isPlayerAttackAvailable = true;

        for (int i = 0; i < attackDirectionList.Length; i++)
        {
            attackDirectionList[i].GetComponent<SpriteRenderer>().enabled = false;
        }

        //Dash System

        isDashing = true;

       

    }
   
    void FixedUpdate()
    {

        //Moovement System

        //classic moovement gestion with left joystick

        horizontalMoove = Input.GetAxis("Horizontal");
        verticalMoove = Input.GetAxis("Vertical");
        
        moove = new Vector3(horizontalMoove, verticalMoove, 0);
        if (Input.GetAxis("Dash") > 0 && isDashing == true)
        {
            isPlayerAttackAvailable = false;
            StartCoroutine(SmoothDash(moove));
            isPlayerAttackAvailable = true;

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

        //Debug.Log(direction);

        //AttackSystem

        if (Input.GetAxis("Attack") > 0 && isDashing == false)
        {
            if (isPlayerAttackAvailable == true)
            {
                StartCoroutine("PlayerAttack");
                Debug.Log("Vous attaquer");
            }   
        }

        //Healbar Update
        healthBar.fillAmount = playerHp / playerMaxHp;

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
        healthBar.fillAmount = playerHp / playerMaxHp;
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

        healthBar.fillAmount = playerHp / playerMaxHp;
    }

    void PlayerDeath()                                  //Put every action requiered when the player is dead on this function
    {
        Debug.Log("Vous êtes mort");
        isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);

    }

    //AttackSystem

    IEnumerator PlayerAttack()
    {

        attackDirection = direction;
        isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isPlayerAttackAvailable = false;

        switch (attackDirection)          //0 = right 1 = left 2 = up 3 = down
        {
            case 0:
                attackDirectionList[0].GetComponent<SpriteRenderer>().enabled = true;
                break;

            case 1:
                attackDirectionList[1].GetComponent<SpriteRenderer>().enabled = true;
                break;

            case 2:
                attackDirectionList[2].GetComponent<SpriteRenderer>().enabled = true;
                break;

            case 3:
                attackDirectionList[3].GetComponent<SpriteRenderer>().enabled = true;
                break;

            default:
                attackDirectionList[4].GetComponent<SpriteRenderer>().enabled = true;
                break;

        }

        yield return new WaitForSeconds(0.3f);

        isPlayerMoovAvailable = true;

        switch (attackDirection)          //0 = right 1 = left 2 = up 3 = down
        {
            case 0:
                attackDirectionList[0].GetComponent<SpriteRenderer>().enabled = false;
                break;

            case 1:
                attackDirectionList[1].GetComponent<SpriteRenderer>().enabled = false;
                break;

            case 2:
                attackDirectionList[2].GetComponent<SpriteRenderer>().enabled = false;
                break;

            case 3:
                attackDirectionList[3].GetComponent<SpriteRenderer>().enabled = false;
                break;

            default:
                attackDirectionList[4].GetComponent<SpriteRenderer>().enabled = false;
                break;

        }

        yield return new WaitForSeconds(attackSpeed);
        isPlayerAttackAvailable = true;
    }


    IEnumerator SmoothDash(Vector3 direction)
    {
        isPlayerAttackAvailable = false;

        Debug.Log("on entre dans la coroutine");
        float timer = 0.0f;
        isDashing = false;
        isPlayerMoovAvailable = false;

        while (timer < dashTime)
        {
            Debug.Log("on entre dans le while");
            Debug.Log(playerRgb.velocity);
            playerRgb.velocity = direction.normalized * dashSpeed * dashCurve.Evaluate(timer / dashTime);
            Debug.Log(playerRgb.velocity);
            timer += Time.deltaTime;
            yield return null;
        }

        Debug.Log("on sort du while");

        playerRgb.velocity = Vector3.zero;


        new WaitForSeconds(dashCooldown);
        isDashing = true;
        isPlayerMoovAvailable = true;
        Debug.Log("On est à la fin de la coroutine");
        yield return new WaitForSeconds(2f);
        
       

    }
}

