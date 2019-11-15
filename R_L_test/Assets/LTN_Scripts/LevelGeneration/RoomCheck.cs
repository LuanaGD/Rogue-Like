using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    private RoomID idRoom;

    public bool checkDown;
    public bool checkUp;
    public bool checkRight;
    public bool checkLeft;

    public GameObject roomToDestroy;
    public GameObject collisionCheck;
    public CheckerColliding collideCheck;
    public RoomTemplates rTemplate;

    // Start is called before the first frame update
    void Start()
    {
        idRoom = GameObject.FindGameObjectWithTag("SpawnRoomPoint").GetComponent<RoomID>();
        collideCheck = GameObject.FindGameObjectWithTag("Check").GetComponent<CheckerColliding>();
        rTemplate = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();

        /*checkDown = transform.GetChild(2).gameObject.GetComponent<CheckerColliding>().GetColliding(); //chercher emplacement (transform).GetChild(index de l'enfant).gameObject(pour choper le type gameObjet et pas le transform).GetComponent<scriptcherché>.fonction cherchée;
        checkUp = transform.GetChild(3).gameObject.GetComponent<CheckerColliding>().GetColliding();
        checkRight = transform.GetChild(1).gameObject.GetComponent<CheckerColliding>().GetColliding();
        checkLeft = transform.GetChild(0).gameObject.GetComponent<CheckerColliding>().GetColliding();*/
    }

    // Update is called once per frame
    void Update()
    {
        checkDown = transform.GetChild(2).gameObject.GetComponent<CheckerColliding>().GetColliding(); //chercher emplacement (transform).GetChild(index de l'enfant).gameObject(pour choper le type gameObjet et pas le transform).GetComponent<scriptcherché>.fonction cherchée;
        checkUp = transform.GetChild(3).gameObject.GetComponent<CheckerColliding>().GetColliding();
        checkRight = transform.GetChild(1).gameObject.GetComponent<CheckerColliding>().GetColliding();
        checkLeft = transform.GetChild(0).gameObject.GetComponent<CheckerColliding>().GetColliding();
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnRoomPoint"))
        {
            if(checkDown == true && checkRight == true)
            {
                Instantiate(rTemplate.twoOpenings[4], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if(checkDown == true && checkLeft == true)
            {
                Instantiate(rTemplate.twoOpenings[2], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if(checkDown == true && checkUp == true)
            {
                Instantiate(rTemplate.twoOpenings[3], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if(checkUp == true && checkRight == true)
            {
                Instantiate(rTemplate.twoOpenings[5], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if(checkUp == true && checkLeft == true)
            {
                Instantiate(rTemplate.twoOpenings[1], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if(checkRight == true && checkLeft == true)
            {
                Instantiate(rTemplate.twoOpenings[0], transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
        }
    }*/

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnRoomPoint"))
        {
            /*if(collision.GetComponent<RoomCheck>().checkDown && collision.GetComponent<RoomCheck>().checkUp) //check entre une downRoom et une autre room
            {
                Debug.Log("Rooms found Down-UP");
                Destroy(roomToDestroy);
            }
            if (collision.GetComponent<RoomCheck>().checkDown && collision.GetComponent<RoomCheck>().checkRight)
            {
                Debug.Log("Rooms found down-RIGHT");
                Instantiate(collisionCheck, transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if (collision.GetComponent<RoomCheck>().checkDown && collision.GetComponent<RoomCheck>().checkLeft)
            {
                Debug.Log("Rooms found down-LEFT");
                Instantiate(collisionCheck, transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if (collision.GetComponent<RoomCheck>().checkUp && collision.GetComponent<RoomCheck>().checkRight)
            {
                Debug.Log("Rooms found up-RIGHT");
                Instantiate(collisionCheck, transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if (collision.GetComponent<RoomCheck>().checkUp && collision.GetComponent<RoomCheck>().checkLeft)
            {
                Debug.Log("Rooms found up-LEFT");
                Instantiate(collisionCheck, transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }
            else if (collision.GetComponent<RoomCheck>().checkRight && collision.GetComponent<RoomCheck>().checkLeft)
            {
                Debug.Log("Rooms found Right-LEFT");
                Instantiate(collisionCheck, transform.position, Quaternion.identity);
                Destroy(roomToDestroy);
            }

        }
    }*/
}
