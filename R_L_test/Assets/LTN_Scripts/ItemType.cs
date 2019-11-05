using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType : MonoBehaviour
{
    public int itemType; //item type 1 --> weapon; type 2 --> potion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
