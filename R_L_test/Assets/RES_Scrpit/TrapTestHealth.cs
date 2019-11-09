using UnityEngine;

public class TrapTestHealth : MonoBehaviour
{
    public GameObject Player;
    public float trapDmg = 30;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.GetComponent<PlayerManager>().PlayerIsTakingDmg(trapDmg);
        }
            
    }
}
