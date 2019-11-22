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
    private RoomID idRoom;
    private RoomCheck roomCheck;
    private int rand;
    public bool spawned;

    public GameObject closing;

    public float waitTime = 4f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        idRoom = GameObject.FindGameObjectWithTag("SpawnRoomPoint").GetComponent<RoomID>();
        roomCheck = GameObject.FindGameObjectWithTag("Check").GetComponent<RoomCheck>();
        Invoke("Spawn", 0.5f);
    }

    // Update is called once per frame
    public void Spawn() //création des salles "normales"
    {
        if (spawned == false && templates.rooms.Count < 13)
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

        else if (spawned == false && templates.rooms.Count >= 13) //créations des sallez fermées qui permettent de ne pas déboucher sur du vide
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

    void OnTriggerEnter2D(Collider2D collision) //création de salles spéciales
    {
        if (collision.CompareTag("SpawnRoomPoint"))
        {
            if (collision.GetComponent<NewRoomSpawner>().spawned == false && spawned == false) //création des salles dans des cas spéciaux (2 directions)
            {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            /*else if (collision.GetComponent<NewRoomSpawner>().spawned == true && spawned == true) // c'est le roomspawner qui instancie le closing, et pas la room. Le POLISHER
            {
                Debug.Log("COLLIDE");

                if(openingDirection == 1 && (idRoom.roomID != 1 || idRoom.roomID != 5 || idRoom.roomID != 8 || idRoom.roomID != 10))
                {
                    closing.transform.gameObject.SetActive(true);
                }
                else if (openingDirection == 2 && (idRoom.roomID != 2 || idRoom.roomID != 7 || idRoom.roomID != 8 || idRoom.roomID != 9))
                {
                    closing.transform.gameObject.SetActive(true);
                }
                else if (openingDirection == 3 && (idRoom.roomID != 3 || idRoom.roomID != 6 || idRoom.roomID != 8 || idRoom.roomID != 9))
                {
                    closing.transform.gameObject.SetActive(true);
                }
                else if (openingDirection == 4 && (idRoom.roomID != 4 || idRoom.roomID != 5 || idRoom.roomID != 6 || idRoom.roomID != 7))
                {
                    closing.transform.gameObject.SetActive(true);
                }
                else if(idRoom.roomID == 0 || idRoom.roomID == 11)
                {

                }
                Destroy(gameObject);
            }*/
            spawned = true;
        }
        else if (collision.CompareTag("StartSpawn"))
        {
            Destroy(gameObject);
            spawned = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider other)
    {
        if (other.CompareTag("SpawnRoomPoint"))
        {
            Debug.Log("works");

            if (openingDirection == 1)
            {
                Instantiate(templates.roomClosing[1], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                Instantiate(templates.roomClosing[2], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                Instantiate(templates.roomClosing[3], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                Instantiate(templates.roomClosing[4], transform.position, Quaternion.identity);
            }
        }
    }*/

    public bool GetSpawned()
    {
        return spawned;
    }

    /*public void DestroyClosed()
    {
        GameObject[] roomToReplace;
        roomToReplace = GameObject.FindGameObjectsWithTag("ClosedRoom");

        foreach(GameObject closedR in roomToReplace) 
        {
            Destroy(closedR);
        }
        
    }*/

}