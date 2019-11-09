using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackZoneSystem : MonoBehaviour
{
    public List<GameObject> enemyInRangList = new List<GameObject>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRangList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInRangList.Remove(collision.gameObject);
        }
    }

    public void DealDamageToEnemy(float damage)
    {
        for (int i = 0; i < enemyInRangList.Count; i++)
        {
            enemyInRangList[i].GetComponent<EnemyHealthSystem>().EnemyIsTakingDamage(damage);
        }
    }
}
