using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class SceneRequirements : MonoBehaviour
{
    public RoomTemplates roomTemp;
    public NewRoomSpawner roomSpawner;

    [SerializeField]
    public string sceneName;

    [SerializeField]
    public int sceneNumber;

    // Start is called before the first frame update
    void Start()
    {
        roomTemp = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        roomSpawner.GetComponent<NewRoomSpawner>().GetSpawned(v: true);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SceneChecker()
    {
        if (roomTemp.rooms.Count <= 10 && roomSpawner.GetSpawned(v: true) == true)
        {
            
        }
        else if (roomTemp.rooms.Count >= 10 && spawned == true)
        {

        }
    }
}
