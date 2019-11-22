using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCorrector : MonoBehaviour
{
    private RoomID roomType;

    public LayerMask roomMask;
    public bool corrected;

    // Start is called before the first frame update
    void Start()
    {
        roomType = GameObject.FindGameObjectWithTag("SpawnRoomPoint").GetComponent<RoomID>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Corrector();
    }

    public void Corrector()
    {
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, roomMask);
        if (corrected == false)
        {
            if (roomType.roomID == 5 && (roomDetection.GetComponent<RoomID>().roomID != 2 || roomDetection.GetComponent<RoomID>().roomID != 3))
            {
                Debug.Log("It works");
            }
            if (roomType.roomID == 6 && (roomDetection.GetComponent<RoomID>().roomID != 4 || roomDetection.GetComponent<RoomID>().roomID != 3))
            {
                Debug.Log("It works");
            }
            if (roomType.roomID == 7 && (roomDetection.GetComponent<RoomID>().roomID != 1 || roomDetection.GetComponent<RoomID>().roomID != 3))
            {
                Debug.Log("It works");
            }
            if (roomType.roomID == 8 && (roomDetection.GetComponent<RoomID>().roomID != 1 || roomDetection.GetComponent<RoomID>().roomID != 4))
            {
                Debug.Log("It works");
            }
            if (roomType.roomID == 9 && (roomDetection.GetComponent<RoomID>().roomID != 4 || roomDetection.GetComponent<RoomID>().roomID != 2))
            {
                Debug.Log("It works");
            }
            if (roomType.roomID == 10 && (roomDetection.GetComponent<RoomID>().roomID != 1 || roomDetection.GetComponent<RoomID>().roomID != 2))
            {
                Debug.Log("It works");
            }

            corrected = true;
        }
    }
}
