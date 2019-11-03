using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealTestHealth : MonoBehaviour
{
    public GameObject Player;
    public float healAmount = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player.GetComponent<PlayerManager>().PlayerIsHealing(healAmount);
    }
}
