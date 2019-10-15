using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGeneration : MonoBehaviour
{
    public Transform[] roomSpawner;
    public GameObject[] rooms;

    public int direction;
    public float moveAmount;

    // Start is called before the first frame update
    void Start()
    {
        int randRoomSpawn = Random.Range(0, roomSpawner.Length);
        transform.position = roomSpawner[randRoomSpawn].position;
        int randRoomType = Random.Range(0, rooms.Length);
        Instantiate(rooms[randRoomType], transform.position, Quaternion.identity);

        direction = Random.Range(1, 6);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void MovPos()
    {
        if (direction == 1 || direction == 2) //move right
        {
            Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
            transform.position = newPos;
        }
        else if (direction == 3 || direction == 4) //move left
        {
            Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
            transform.position = newPos;
        }

        Instantiate(rooms[0], transform.position, Quaternion.identity);
        direction = Random.Range(1, 5);
    }
}
