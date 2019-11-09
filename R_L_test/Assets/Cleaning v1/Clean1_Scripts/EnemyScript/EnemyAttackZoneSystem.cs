using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZoneSystem : MonoBehaviour
{
    public List<GameObject> playerInRangList = new List<GameObject>();


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerInRangList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            playerInRangList.Remove(collision.gameObject);
        }
    }

    public void DealDamageToPlayer(float damage)
    {
        for (int i = 0; i < playerInRangList.Count; i++)
        {
            playerInRangList[i].GetComponent<PlayerHpSystem>().PlayerIsTakingDmg(damage);
        }
    }
}
