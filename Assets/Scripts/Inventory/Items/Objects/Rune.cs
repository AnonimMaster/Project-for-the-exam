using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rune : CollectionsItems
{
	public override void Collection()
	{
		Data.MaxJump++;
		Data.CountJump = Data.MaxJump;
		Destroy(this.gameObject);
	}
}
