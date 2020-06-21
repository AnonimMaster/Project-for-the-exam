using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseItemData : ScriptableObject
{
    public Sprite Icon;
    public string Title;
    public string Description;

    public virtual void PutToInventory(InventoryController Inventory, int Count)
    {

        for (int i = 0; i < Count; i++)
        {
            var state = Inventory.PutNewItem(this, 1);
            if (state == null)
            {
                return;
            }
        }
    }

    public virtual void RemoveToInventory(InventoryController Inventory, int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            var CellID = Inventory.FindItem(this);
            if (CellID >= 0)
            {
                if (Inventory.Cells[CellID].Count > 1)
                {
                    Inventory.Cells[CellID].Count--;
                }
                else
                {
                    Inventory.Cells[CellID].Count--;
                    Inventory.Cells[CellID].Data = null;
                }

            }
            else
            {
                Debug.Log("Предмет не найден");
            }
        }
    }
}
