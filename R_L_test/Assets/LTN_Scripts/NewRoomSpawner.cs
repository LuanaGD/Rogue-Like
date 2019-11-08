using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewRoomSpawner : MonoBehaviour
{
    public int openingDirection;
    //1--> Has down door
    //2--> Has up door
    //3--> Has right door
    //4--> Has left Door

    private RoomTemplates templates;
    private RoomTemplates roomTemp;
    private int rand;
    private bool spawned;

    public float waitTime = 4f;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.5f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false && templates.rooms.Count <= 10)
        {
            if (openingDirection == 1)
            {
                //Need DOWN door
                rand = Random.Range(0, templates.downRooms.Length);
                Instantiate(templates.downRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                //need UP door
                rand = Random.Range(0, templates.upRooms.Length);
                Instantiate(templates.upRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                //need RIGHT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                //need LEFT door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
            }

            spawned = true;
        }

        else if(spawned == false && templates.rooms.Count >= 10)
        {
            if (openingDirection == 1)
            {
                //need DOWN room
                Instantiate(templates.downClosing, transform.position, Quaternion.identity);
            }
            if (openingDirection == 2)
            {
                //need UP room
                Instantiate(templates.upClosing, transform.position, Quaternion.identity);
            }
            if (openingDirection == 3)
            {
                //need RIGHT room
                Instantiate(templates.rightClosing, transform.position, Quaternion.identity);
            }
            if (openingDirection == 4)
            {
                //need LEFT room
                Instantiate(templates.leftClosing, transform.position, Quaternion.identity);
            }

            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("SpawnRoomPoint"))
        {
            if(collision.GetComponent<NewRoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

            spawned = true;

            Destroy(gameObject);
        }
        else if (collision.CompareTag("StartSpawn"))
        {
            Destroy(gameObject);
            spawned = true;
        }
    }
}
