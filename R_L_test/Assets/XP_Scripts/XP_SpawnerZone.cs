using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_SpawnerZone : MonoBehaviour
{

    //Statement - Start

    public GameObject trigger;
    public Transform[] points ;
    public GameObject[] ennemiesInScene;


        //Pour la Liste
    public List<GameObject> enemies = new List<GameObject>();
    int randEnemy;

    //Statement - End

    private void Awake()
    {
        //récupérer les points de spawn dans la zone.
        points = new Transform[transform.childCount];

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }





    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            for (int i = 0; i < points.Length; i++)
            {
                //Augmenter la Range en fonction du nombre d'ennemis.
                randEnemy = Random.Range(0, 2);
                //Faire apparaitre un ennemi aléatoire en fonction du nombre sortie à la position du waypoint.
                Instantiate(enemies[randEnemy], points[i].transform.position, transform.rotation);
                
            }
            trigger.SetActive(false);
        }

        ennemiesInScene = GameObject.FindGameObjectsWithTag("Ennemie");
        Debug.Log(ennemiesInScene);
    }





    private void Update()
    {
        //Si la liste d'ennemies est vide alors Salle clean.
        if (ennemiesInScene == null)
        {
            trigger.SetActive(true);
        }
    }
       
}
