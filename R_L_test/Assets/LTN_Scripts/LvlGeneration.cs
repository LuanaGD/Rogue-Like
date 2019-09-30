using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlGeneration : MonoBehaviour
{
    public Transform[] roomSpawner;
    public GameObject[] rooms;

    // Start is called before the first frame update
    void Start()
    {
        int randRoomSpawn = Random.Range(0, roomSpawner.Length);
        transform.position = roomSpawner[randRoomSpawn].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
