using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckerColliding : MonoBehaviour
{
    public bool isColliding;
       
    // Start is called before the first frame update
    void Start()
    {
        GetColliding();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnRoomPoint"))
        {
            isColliding = true;
        }
        else
        {
            isColliding = false;
        }
    }

    public bool GetColliding()
    {
        return isColliding;
    }
}
