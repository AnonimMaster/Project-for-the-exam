using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
	public PlayerController Player;
	bool collisonOccured = false;

	void Start()
	{
		Player = FindObjectOfType<PlayerController>();
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collisonOccured)
			return;
		if (collision.gameObject.tag == "Player")
		{
			collisonOccured = true;
			Player.Damage();
			Invoke("Reset", 1f);
		}
	}

	void Reset()
	{
		collisonOccured = false;
	}
}
