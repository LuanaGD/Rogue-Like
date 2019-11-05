using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGeneration : MonoBehaviour
{
    public Transform[] roomSpawner;
    public GameObject[] rooms; //index 0 -> LR; 1 -> LRD; 2 -> LRU; 3 -> LRUD

    public int direction;
    public float moveAmount;

    private float timeBtwRoom;
    private float startTimeBtwRoom = 0.25f;

    public float maxX;
    public float minX;
    public float minY;

    public bool stopGeneration;

    public LayerMask room;
    [SerializeField]
    private int downCounter;

    // Start is called before the first frame update
    void Start()
    {
        int randRoomSpawn = Random.Range(0, roomSpawner.Length);
        Instantiate(rooms[0], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);


    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwRoom <= 0 && !stopGeneration)
        {
            MovPos();
            timeBtwRoom = startTimeBtwRoom;
        }
        else
        {
            timeBtwRoom -= Time.deltaTime;
        }
    }

    private void MovPos()
    {
        if (direction == 1 || direction == 2) //move right
        {
            downCounter = 0;

            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);

                if(direction == 3)
                {
                    direction = 2;
                }
                else if(direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
            
        }
        else if (direction == 3 || direction == 4) //move left
        {
            downCounter = 0;

            if (transform.position.x > minX)
            {
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 5)
        {

            downCounter++;

            if(transform.position.y >= minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {

                    if (downCounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }
                    
                }
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                //stop generation
                stopGeneration = true;
            }
        }
    }
}