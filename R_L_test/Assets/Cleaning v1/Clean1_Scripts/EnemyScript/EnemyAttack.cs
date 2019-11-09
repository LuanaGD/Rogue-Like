using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Statement

    public bool isEnemyAttackAvailable;
    public float attackSpeed;
    public GameObject[] attackDirectionList;
    public GameObject thisEnemy;
    public int attackDirection;
    public float enemyDamage;

    void Start()
    {
        isEnemyAttackAvailable = true;

        for (int i = 0; i < attackDirectionList.Length; i++)
        {
            attackDirectionList[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag != "AttackDirection")
        {
            
            if (isEnemyAttackAvailable == true)
            {
                StartCoroutine("LaunchEnemyAttack");
            }
        }
    }

    IEnumerator LaunchEnemyAttack()
    {
        
        attackDirection = thisEnemy.GetComponent<EnemyBasicMovement>().enemyDirection;
        thisEnemy.GetComponent<EnemyBasicMovement>().isEnnemyMoovAvailable = false;
        thisEnemy.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        isEnemyAttackAvailable = false;

        switch (attackDirection)          //0 = right 1 = left 2 = up 3 = down
        {
            case 0:
                attackDirectionList[0].GetComponent<SpriteRenderer>().enabled = true;
                attackDirectionList[0].GetComponent<EnemyAttackZoneSystem>().DealDamageToPlayer(enemyDamage);

                break;

            case 1:
                attackDirectionList[1].GetComponent<SpriteRenderer>().enabled = true;
                attackDirectionList[1].GetComponent<EnemyAttackZoneSystem>().DealDamageToPlayer(enemyDamage);
                break;

            case 2:
                attackDirectionList[2].GetComponent<SpriteRenderer>().enabled = true;
                attackDirectionList[2].GetComponent<EnemyAttackZoneSystem>().DealDamageToPlayer(enemyDamage);
                break;

            case 3:
                attackDirectionList[3].GetComponent<SpriteRenderer>().enabled = true;
                attackDirectionList[3].GetComponent<EnemyAttackZoneSystem>().DealDamageToPlayer(enemyDamage);
                break;

            default:
                break;

        }

        yield return new WaitForSeconds(0.3f);

        switch (attackDirection)          //0 = right 1 = left 2 = up 3 = down          Temporary switch delete when the animator is done
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
                break;

        }

        thisEnemy.GetComponent<EnemyBasicMovement>().isEnnemyMoovAvailable = true;

        yield return new WaitForSeconds(attackSpeed);

        isEnemyAttackAvailable = true;
    }
}
