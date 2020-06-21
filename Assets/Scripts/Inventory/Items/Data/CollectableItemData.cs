using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "newItem", menuName = "Data/Items/Collection", order = 51)]
public class CollectableItemData : BaseItemData
{
    public int MaxCollectionCount;

    public override void PutToInventory(InventoryController Inventory, int Count)
    {
        var notFullCollections = Inventory.Cells.Where(
            Cell => Cell.Data != null
            && Cell.Data.GetType() == GetType()
            && Cell.Data.Title == Title
            && Cell.Count < MaxCollectionCount
        ).ToList();
        var remainingCount = Count;

        foreach (var Cell in notFullCollections)
        {
            var CountToPut = Math.Min(remainingCount, MaxCollectionCount - Cell.Count);
            Cell.Count += CountToPut;
            remainingCount -= CountToPut;

            if (remainingCount <= 0)
            {
                return;
            }
        }

        while (remainingCount > 0)
        {
            var CountToPut = Math.Min(remainingCount, MaxCollectionCount);
            var Cell = Inventory.PutNewItem(this, CountToPut);
            if (Cell == null)
            {
                return;
            }
            remainingCount -= CountToPut;
        }

    }
}
