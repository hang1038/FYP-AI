using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public const int numItemSlots = 4;

    public Image[] itemImages = new Image[numItemSlots];

    public Item[] items = new Item[numItemSlots];

    public void AddItem(Item itemToAdd)
    {
        for(int i = 0; i < items.Length ; i++)
        {
            if(items[i] == null)
            {
                items[i] = itemToAdd;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return;
            }
        }

    }

    public void RemoveAllItem()
    {
        for (int i = 0; i < items.Length; i++)
        {
                items[i] = null;
                itemImages[i].sprite = null;
                itemImages[i].enabled = false;
        }

    }

    public void RemoveItem()
    {
        for (int i = 3; i >= 0; i--)
        {
            if (items[i] != null)
            {
                items[i] = null;
                itemImages[i].sprite = null ;
                itemImages[i].enabled = false;
                return;
            }
        }

    }

    public Item[] GetItemInList()
    {
        Item[] temp = items;
        return temp;
    }


}
