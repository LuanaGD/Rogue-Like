using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rgb;
    public float horizontalMoove;
    public float verticalMoove;
    public Vector3 moove;


    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMoove = Input.GetAxis("Horizontal");
        verticalMoove = Input.GetAxis("Vertical");
        moove = new Vector3 (horizontalMoove,verticalMoove,0);

        rgb.velocity = moove * speed * Time.fixedDeltaTime;
        
    }
}
