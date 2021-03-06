﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneLife : MonoBehaviour
{
	public PlayerData Data;
	bool colliderOccured = false;

	public void Collection()
	{
		if (Data.Life < Data.MaxLife)
		{
			Data.Life++;
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (colliderOccured)
			return;
		if (collider.gameObject.tag == "Player")
		{
			colliderOccured = true;
			Collection();
			Invoke("Reset", 0.01f);
		}
	}

	void Reset()
	{
		colliderOccured = false;
	}
}
