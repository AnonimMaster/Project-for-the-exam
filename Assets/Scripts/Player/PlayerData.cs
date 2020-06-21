using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data", order = 51)]
public class PlayerData : ScriptableObject
{
	public int Score;
	public int Life;
	public int MaxLife;
	public int MaxJump;
	public int CountJump;
}
