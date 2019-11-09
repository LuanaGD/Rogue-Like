using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Statement

    public static bool isPlayerAttackAvailable;
    public float attackSpeed;
    public GameObject[] attackDirectionList;
    public int attackDirection;
    public float playerDamage;
    

    void Start()
    {
        isPlayerAttackAvailable = true;

        attackDirectionList = new GameObject[4];
        attackDirectionList = GameObject.FindGameObjectsWithTag("AttackDirection");

        for (int i = 0; i < attackDirectionList.Length; i++)
        {
            attackDirectionList[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

  
    void Update()
    {
        if (Input.GetAxis("Attack") > 0 || Input.GetButtonDown("KeyboardAttack"))
        {           
            if (isPlayerAttackAvailable == true && PlayerMovement.isPlayerDashing == false)
            {
                StartCoroutine("LaunchPlayerAttack");
            }                  
        }
    }

    IEnumerator LaunchPlayerAttack()
    {

        attackDirection = GetComponent<PlayerMovement>().playerDirection;
        PlayerMovement.isPlayerMoovAvailable = false;
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isPlayerAttackAvailable = false;

        attackDirectionList[attackDirection].GetComponent<AttackZoneSystem>().LaunchAttack(playerDamage);

        PlayerMovement.isPlayerMoovAvailable = true;

        yield return new WaitForSeconds(attackSpeed);

        isPlayerAttackAvailable = true;
    }
}
