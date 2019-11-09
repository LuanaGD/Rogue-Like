using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RES_EnemyMoovement : MonoBehaviour
{

    // Statement - Start

    public bool isEnnemyMoovAvailable;
    public float speed;
    public Vector3 moove;
    public Rigidbody2D ennemyRgb;
    public Transform playerTransform;
    public GameObject[] playerList;
    public float horizontalMoove;      
    public float verticalMoove;




    void Start()
    {
        isEnnemyMoovAvailable = true;
        ennemyRgb = GetComponent<Rigidbody2D>();
        playerList = GameObject.FindGameObjectsWithTag("Player");
        playerTransform = playerList[0].transform;
        
    }

    
    void FixedUpdate()
    {

        horizontalMoove = playerTransform.position.x - transform.position.x;
        verticalMoove = playerTransform.position.y - transform.position.y;
        moove = new Vector3(horizontalMoove , verticalMoove, 0 );
        moove.Normalize();

        if (isEnnemyMoovAvailable == true)
        {
            ennemyRgb.velocity = moove * speed * Time.fixedDeltaTime;
        }

     

    }
}
