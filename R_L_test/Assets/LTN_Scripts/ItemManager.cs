using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private int itemSlots; //les slots vides de base

    public GameObject[] inventory;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;


    private bool chooseOne = false;
    private bool chooseTwo = false;
    private bool chooseThree = false;
    private bool chooseNone = false;
    private bool choiceMade = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChoiceOption()
    {

        Debug.Log("Which item is chosen, Item A (press 1) or item B (press 2) or none (press 3)");

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            itemSlots++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            itemSlots++;
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            GetComponent<ItemType>().DestroyItem();
        }

        if(itemSlots > 3)
        {
            Debug.Log("Inventory full, which item slot will be replaced? (press 1, 2 or 3)");
            /*if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                chooseOne = true;

            }*/
        }
    }
}
