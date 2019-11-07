using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerSource
{
    
    void Start()
    {
        isPlayerAttackAvailable = true;
        playerRgb.GetComponent<Rigidbody2D>();

        for (int i = 0; i < attackDirectionList.Length; i++)
        {
            attackDirectionList[i].GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    
    void FixedUpdate()
    {
        if (Input.GetAxis("Attack") > 0 || Input.GetButtonDown("KeyboardAttack"))
        {
            if (isPlayerAttackAvailable == true)
            {
                StartCoroutine("StartPlayerAttack");
                Debug.Log("Vous attaquer");
            }
        }
    }

    IEnumerator StartPlayerAttack()
    {

        attackDirection = PlayerSource.direction;
        isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isPlayerAttackAvailable = false;
        Debug.Log(attackDirection);

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

}
