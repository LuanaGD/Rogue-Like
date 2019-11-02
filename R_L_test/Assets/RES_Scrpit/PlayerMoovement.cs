using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour
{
    //Statement  

    public bool isPlayerMoovAvailable;
    public float speed;
    public Vector3 moove;
    public Rigidbody2D playerRgb;
    public float horizontalMoove;       //these variables exist just to check joystick value with a Debug.Log
    public float verticalMoove;         //look upward


    void Start()
    {
        isPlayerMoovAvailable = true;
    }

    void FixedUpdate()
    {

        //classic moovement gestion with left joystick: start

        horizontalMoove = Input.GetAxis("Horizontal");          
        verticalMoove = Input.GetAxis("Vertical");              
        moove = new Vector3(horizontalMoove, verticalMoove, 0);

        

        if (isPlayerMoovAvailable == true)
        {
            playerRgb.velocity = moove * speed * Time.fixedDeltaTime;
        }

        //classic moovement gestion with left joystick: end

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isPlayerMoovAvailable = false;
            Debug.Log("Space pressed");
            playerRgb.velocity = new Vector3(0, 0, 0);
        }

    }
}
