using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] downRooms;
    public GameObject[] upRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject[] twoOpenings;
    public GameObject[] threeOpenings;
    public GameObject[] roomClosing;
 
    public GameObject leftClosing;
    public GameObject rightClosing;
    public GameObject upClosing;
    public GameObject downClosing;

    public GameObject closedRoom;

    public List<GameObject> rooms;

    public float waitTime;
    public float checkTime;
    public bool spawnBoss;
    public GameObject boss;

    private SceneRequirements sceneCleaner;

    // Start is called before the first frame update
    void Start()
    {
        sceneCleaner = GameObject.FindGameObjectWithTag("Check").GetComponent<SceneRequirements>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTime <= 0 && spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(rooms.Count > 14 && i == rooms.Count - 1)
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

        if(checkTime <= 0 && spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if(rooms.Count < 16 && checkTime < waitTime && spawnBoss == false || rooms.Count < 16 && spawnBoss == false || rooms.Count > 16 && spawnBoss == false || rooms.Count < 16 && spawnBoss == true && checkTime < waitTime)
                {
                    sceneCleaner.SceneReset();
                }
            }
        }
        else
        {
            checkTime -= Time.deltaTime;
        }
    }
}
