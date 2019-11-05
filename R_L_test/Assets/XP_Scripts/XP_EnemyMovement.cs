using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_EnemyMovement : MonoBehaviour
{
    
        public Transform player;
        public Rigidbody2D rb;
        private Vector2 movement;
        public float moveSpeed = 2f;
        public Vector2 direction;
        public GameObject[] playerlist;

        private bool boxTrigger = false;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerlist = GameObject.FindGameObjectsWithTag("Player");
            player = playerlist[0].transform;
        }






        void Update()
        {
            direction = player.transform.position - transform.position;
            Debug.Log(direction);
            direction.Normalize();
            movement = direction;
        }
        private void FixedUpdate()
        {
            if (boxTrigger == false)
            {
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            }

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                boxTrigger = true;
                Debug.Log("trigger");
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                boxTrigger = false;
                movement = player.transform.position - transform.position;
            }
        } 

 }



