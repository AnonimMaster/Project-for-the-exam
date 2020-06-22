using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CollectionsItems : MonoBehaviour
{
	public PlayerData Data;
	protected bool collisonOccured = false;
	public virtual void Collection()
	{
		Destroy(this.gameObject);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collisonOccured)
			return;
		if (collision.gameObject.tag == "Player")
		{
			collisonOccured = true;
			Collection();
			Invoke("Reset", 0.01f);
		}
	}

	void Reset()
	{
		collisonOccured = false;
	}
}
