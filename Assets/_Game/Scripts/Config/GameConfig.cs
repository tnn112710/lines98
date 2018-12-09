using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using Attributes;

[CreateAssetMenu]
public class GameConfig : ScriptableObject 
{
	[BoxGroup("Board Setup")]
	public int RowCount = 9;
	[BoxGroup("Board Setup")]
	public int ColCount = 9;
	[BoxGroup("Board Setup")][ReadOnly] 
	public int TotalBlocks;
	[BoxGroup("Conditions")]
	public int InitBallCount = 10;
	[BoxGroup("Conditions")]
	public int PrepareBallCount = 3;
	[BoxGroup("Conditions")]
	public float MaxTime = 120;
	
	[BoxGroup("Spawning")]
	public bool CanSpawnGhost = true;
	[BoxGroup("Spawning")][EnableIf("CanSpawnGhost")][Range(0f,1f)]
	public float GhostChance = 0.1f;

	[BoxGroup("Spawning")]
	public bool CanSpawnRainbow = true;
	[BoxGroup("Spawning")][EnableIf("CanSpawnRainbow")][Range(0f,1f)]
	public float RainbowChance = 0.1f;

	[BoxGroup("Spawning")]
	public bool CanSpawnBomb = true;
	[BoxGroup("Spawning")][EnableIf("CanSpawnBomb")][Range(0f,1f)]
	public float BombChance = 0.05f;

	[BoxGroup("Spawning")]
	public bool CanSpawnStone = true;
	[BoxGroup("Spawning")][EnableIf("CanSpawnStone")][Range(0f,1f)]
	public float StoneChance = 0.05f;

	void OnValidate() 
	{	
		if (RowCount > 14) RowCount = 14;
		if (RowCount < 5)	RowCount = 5;
		if (ColCount > 10) ColCount = 10;
		if (ColCount < 5)	ColCount = 5;
		TotalBlocks = RowCount * ColCount;

		if (InitBallCount > TotalBlocks)	
			InitBallCount = TotalBlocks;
		if (PrepareBallCount > 6) PrepareBallCount = 6;
		if (PrepareBallCount < 1)	PrepareBallCount = 1;
	}
}
