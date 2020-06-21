using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public ItemState[] Cells;

    public void AddItem(BaseItemData Item, int Count)
    {

        Item.PutToInventory(this, Count);
    }

    public void RemoveItem(BaseItemData Item, int Count)
    {
        Item.RemoveToInventory(this, Count);
    }

    public ItemState PutNewItem(BaseItemData item, int count)
    {
        var state = FindEmptyCell();
        if (state == null)
        {
            Debug.Log("Инвентарь полон");
            return null;
        }
        state.Data = item;
        state.Count = count;
        return state;
    }

    public int FindItem(BaseItemData Item)
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].Data == Item)
            {
                return i;
            }
        }
        return -1;
    }

    public ItemState FindEmptyCell()
    {
        for (int i = 0; i < Cells.Length; i++)
        {
            if (Cells[i].Data == null)
            {
                return Cells[i];
            }
        }
        return null;
    }
}
