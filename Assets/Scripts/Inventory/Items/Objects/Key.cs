using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : CollectionsItems
{
	public InventoryController Inventory;
	[SerializeField] private BaseItemData key;

	public override void Collection()
	{
		Inventory.AddItem(key, 1);
		Destroy(this.gameObject);
	}
}
