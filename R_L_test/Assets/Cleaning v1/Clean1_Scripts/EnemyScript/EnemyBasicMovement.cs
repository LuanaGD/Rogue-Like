using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{
    // Statement

    public bool isEnnemyMoovAvailable;
    public float speed;
    public Vector3 move;
    public Rigidbody2D ennemyRgb;
    public Transform playerTransform;
    public GameObject[] playerList;
    public float horizontalMoove;
    public float verticalMoove;

    public int enemyDirection;

    void Start()
    {
        isEnnemyMoovAvailable = true;
        ennemyRgb = GetComponent<Rigidbody2D>();
        playerList = GameObject.FindGameObjectsWithTag("Player");
        playerTransform = playerList[0].transform;

        enemyDirection = 0;
    }

    void FixedUpdate()
    {
        horizontalMoove = playerTransform.position.x - transform.position.x;
        verticalMoove = playerTransform.position.y - transform.position.y;
        move = new Vector3(horizontalMoove, verticalMoove, 0);
        move.Normalize();

        if (isEnnemyMoovAvailable == true)
        {
            ennemyRgb.velocity = move * speed * Time.fixedDeltaTime;
        }

        Direction();
    }

    public void Direction()
    {
        if (move != Vector3.zero)
        {
            if (Mathf.Abs(move.x) > Mathf.Abs(move.y))
            {
                if (move.x > 0)
                {
                    enemyDirection = 0;      //right
                }
                else if (move.x < 0)
                {
                    enemyDirection = 1;      //left
                }
            }
            else
            {

                if (move.y > 0)
                {
                    enemyDirection = 2;      //up
                }
                else if (move.y < 0)
                {
                    enemyDirection = 3;      //down
                }
            }
        }
    }
}
