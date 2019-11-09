using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackZoneSystem : MonoBehaviour
{
    public List<GameObject> playerInRangList = new List<GameObject>();

    //can be delete when Animator is operational (as all function that inpact the sprite renderer)

    public SpriteRenderer sRenderer;
    public Sprite dangerSign;
    public Sprite sword;

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        sRenderer.sprite = sword;
        sRenderer.enabled = false;
        
    }


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


    public void LaunchAttack(float damage, float dangerTime)
    {
        StartCoroutine(Attack(damage, dangerTime));
    }

    IEnumerator Attack(float damage, float dangerTime)
    {
        sRenderer.sprite = dangerSign;
        sRenderer.enabled = true;

        yield return new WaitForSeconds(dangerTime);

        sRenderer.sprite = sword;

        for (int i = 0; i < playerInRangList.Count; i++)
        {
            playerInRangList[i].GetComponent<PlayerHpSystem>().PlayerIsTakingDmg(damage);
        }

        yield return new WaitForSeconds(0.3f);

        sRenderer.enabled = false;
    }
}
