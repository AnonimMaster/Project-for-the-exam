using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CollectionsItems : MonoBehaviour
{
	public PlayerData Data;
	public virtual void Collection()
	{
		Data.Score++;
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Collection();
		}
	}
}
