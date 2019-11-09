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
    public float dangerTime;

    void Start()
    {
        isEnemyAttackAvailable = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine("LaunchEnemyAttack");
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

        attackDirectionList[attackDirection].GetComponent<EnemyAttackZoneSystem>().LaunchAttack(enemyDamage, dangerTime);

        thisEnemy.GetComponent<EnemyBasicMovement>().isEnnemyMoovAvailable = true;

        yield return new WaitForSeconds(attackSpeed);

        isEnemyAttackAvailable = true;
    }
}
