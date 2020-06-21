using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Chest : CollectionsItems
{
	public InventoryController Inventory;
	[SerializeField] private BaseItemData Key;
	public override void Collection()
	{
		if (Inventory.FindItem(Key) != -1)
		{
			Inventory.RemoveItem(Key, 1);
			Data.Score += 250;
			Destroy(this.gameObject);
		}
		else
		{
			var random = Random.Range(0f, 1f);
			if (random >= 0.5f)
			{
				Data.Life--;
				Data.Score -= (int)(25 * random * 10);
			}
			else
			{
				Data.Score += 250;
			}
			Destroy(this.gameObject);
		}
		
	}
}
