using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{

    public GameObject[] objects; //Y insérer des GameObject. La longueur augmente avec les ajouts.




    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, objects.Length); //choix d'un objet random de la liste 
        Instantiate(objects[rand], transform.position, Quaternion.identity); //instancier l'objet choisi au pif, à la position de l'empty, sans rotation

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
