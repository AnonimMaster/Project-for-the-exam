using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLife : CollectionsItems
{
	public override void Collection()
	{
		if (Data.Life++ <= Data.MaxLife)
		{
			Data.Life++;
			Destroy(this.gameObject);
		}
	}
}
