using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneRequirements : MonoBehaviour
{
    private RoomTemplates roomTemp;
    private NewRoomSpawner roomSpawner;

    public bool sceneVerified;

    // Start is called before the first frame update
    void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        roomSpawner = GameObject.FindGameObjectWithTag("SpawnRoomPoint").GetComponent<NewRoomSpawner>();
        SceneChecker();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChecker()
    {
        if (roomTemp.rooms.Count <= 16 && roomSpawner.spawned == true && sceneVerified == false)
        {
            SceneManager.LoadScene("LTN_GoodProcedural", LoadSceneMode.Single);
            Debug.Log("Requirements not met");
        }
        else if (roomTemp.rooms.Count >= 16 && roomSpawner.spawned == false && sceneVerified == false)
        {
            Debug.Log("Requirements met");
        }

        sceneVerified = true;
    }

    public void SceneReset()
    {
        SceneManager.LoadScene("LTN_GoodProcedural", LoadSceneMode.Single);
    }

}
