using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
	public bool colliderOccured = false;
	public Transform point;
	public PlayerController Player;

	void Start()
	{
		point = GetComponent<Transform>();
		Player = FindObjectOfType<PlayerController>();
	}

	void OnTriggerEnter2D(Collider2D collider)
	{
		if (colliderOccured)
			return;
		if (collider.gameObject.tag == "Player")
		{
			colliderOccured = true;
			Player.SetSpawn(point);
			Invoke("Reset", 0.01f);
		}
	}

	void Reset()
	{
		colliderOccured = false;
	}
}
