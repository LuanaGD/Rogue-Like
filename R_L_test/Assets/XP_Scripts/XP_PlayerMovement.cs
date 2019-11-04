using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 movement;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;


   
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
