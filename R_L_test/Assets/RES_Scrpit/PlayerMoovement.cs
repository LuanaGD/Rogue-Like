using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoovement : MonoBehaviour
{
    //Statement  

    public float speed;
    public Rigidbody2D playerRgb;
    public float horizontalMoove;       //these variables exist just to check joystick value on the inspector
    public float verticalMoove;         //look upward
    public Vector3 moove;

    void FixedUpdate()
    {
        //classic moovement gestion with left joystick: start

        horizontalMoove = Input.GetAxis("Horizontal");          
        verticalMoove = Input.GetAxis("Vertical");              
        moove = new Vector3(horizontalMoove, verticalMoove, 0);

        playerRgb.velocity = moove * speed * Time.fixedDeltaTime;

        //classic moovement gestion with left joystick: end

    }
}
