using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] downRooms;
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;

    public GameObject leftClosing;
    public GameObject rightClosing;
    public GameObject upClosing;
    public GameObject downClosing;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    public bool spawnBoss;
    public GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnBoss = true;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
