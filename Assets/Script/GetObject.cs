using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetObject : MonoBehaviour{

    public float SelectedTime =0f;
    public static ArrayList SelectedFoodList = new ArrayList();
    private GetObject GetTemp;
    private Inventory inventory;
    private Item item;
    private CustomerController CC;
    private AudioManager audioManager;

    // Use this for initialization
    void Start () {
        GetTemp = GetComponent<GetObject>();
        inventory = FindObjectOfType<Inventory>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnDisable()
    {
        SelectedTime = 0f;
    }

    // Update is called once per frame
    public void Update () {

        SelectedTime += Time.deltaTime;

        if (SelectedTime >= 3f)
        {
            GetTemp.enabled = false;
            string temp = FoodManager.PassObjcetName();
            Debug.Log("The selection is :"+ temp);
            if (temp == "remove")
            {
                audioManager.Play("Remove");
                inventory.RemoveItem();
            }
            else if (temp == "submit")
            {
                CC = FindObjectOfType<CustomerController>();
                CC.CheckFood();
                inventory.RemoveAllItem();
            }
            else
            {
                audioManager.Play("Select");

                if (temp == "TestFood")
                {
                    item = Resources.Load<Item>("fish");
                    Debug.Log(item);
                    inventory.AddItem(item);
                }
                if (temp == "TestFood2")
                {
                    item = Resources.Load<Item>("coin");
                    Debug.Log(item);
                    inventory.AddItem(item);
                }
            }
        }
	}
    public static void PutFood(string SelectedFood) 
    {
        Debug.Log("The selection putting in to the list :" + SelectedFood);
        SelectedFoodList.Add(SelectedFood);
    }

    public static void RemoveFood()
    {
        SelectedFoodList.RemoveAt(SelectedFoodList.Count - 1);
    }

    public static void ShowFood()
    {
        foreach(var item in SelectedFoodList)
        {
            Debug.Log("Item in the list:" + item);
        }
        SelectedFoodList.Clear();
    }

}
