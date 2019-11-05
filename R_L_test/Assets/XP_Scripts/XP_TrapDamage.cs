using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_TrapDamage : MonoBehaviour
{
    // Start is called before the first frame update

  
    public GameObject player;
    public float trapDmg = 30;
    public GameObject peaksOff;
    public int waitTimer = 20;

    private SpriteRenderer rend;
    public Sprite peaksOut;
    public Sprite peaksIn;

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(DealDamage());
        }
    }
    private void SwapSprite()
    {
        if (rend.sprite == peaksOut)
        {
            rend.sprite = peaksIn;
        }
        else if (rend.sprite == peaksIn)
        {
            rend.sprite = peaksOut;
        }
    }
   
    IEnumerator DealDamage()
    {
        Debug.Log("Trigger");
        player.GetComponent<PlayerManager>().PlayerIsTakingDmg(trapDmg);
        new WaitForSeconds(waitTimer);
        Debug.Log(player.GetComponent<PlayerManager>().playerHp);
        SwapSprite();
        Debug.Log("Swap");
        
        yield return null;
    }


}
