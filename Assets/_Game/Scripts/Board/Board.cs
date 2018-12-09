using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Board : MonoSingleton<Board> 
{
	public static Action<List<PrepareBall>> OnPrepareBallsChange;
	[SerializeField] GameObject blockPrefab;
	[SerializeField] GameConfig config;

	public Block SelectedBlock {get; set;}

	private int rowCount = 9;
	private int columnCount = 9;
	private int initBallCount = 20;
	private int prepareBallCount = 3;

	public Block[,] Blocks;
	public List<Block> EmptyBlocks;
	public List<PrepareBall> PrepareBalls;



	private const float blockDistance = 0.5f;
	/**************************************************/
	protected void Awake () 
	{
		rowCount = config.RowCount;
		columnCount = config.ColCount;
		initBallCount = config.InitBallCount;
		prepareBallCount = config.PrepareBallCount;
	}

	protected void Start () 
	{
		CreateBoard();
		InitBlockAdjacents();
		
	}

	protected void OnEnable () 
	{
		
	}

	protected void OnDisable () 
	{
		
	}

	protected void Update () 
	{
		
	}
	/**************************************************/
	public int RowCount
	{
		get { return rowCount;}
	}
	public int ColumnCount
	{
		get { return columnCount;}
	}
	public bool HasEmptyBlock
	{
		get { return (EmptyBlocks.Count != 0);}
	}
	/**************************************************/
	public void ClearOldGame()
	{
		EmptyBlocks.Clear();
		foreach (var b in Blocks)
		{
			if (b.IsOccupied)
				b.CurrentBall.gameObject.Despawn();	
			b.CurrentBall = null;
			EmptyBlocks.Add(b);
		}
	}
	public void InitNewGame()
	{
		InitFirstBalls();
		CreatePrepareBalls();
	}

	public void CreateBoard()
	{
		Blocks = new Block[RowCount, ColumnCount];
		EmptyBlocks = new List<Block>();

		float xStart = -blockDistance * (float)(ColumnCount - 1) / 2;
		float yStart = -0.5f -blockDistance * (float)(RowCount - 1) / 2;
		for (int r = 0; r < RowCount; r++)
		{
			for (int c = 0; c < ColumnCount; c++)
			{
				float xPos = xStart + blockDistance * c;
				float yPos = yStart + blockDistance * r;
				Block newBlock = Instantiate(blockPrefab, new Vector2(xPos, yPos), Quaternion.identity, this.transform).GetComponent<Block>();
				newBlock.Init(r,c);
				Blocks[r,c] = newBlock;
				EmptyBlocks.Add(newBlock);
			}
		}
	}

	public void InitBlockAdjacents()
	{
		foreach (var b in Blocks)
			b.FindAdjacents();
	}

	public void InitFirstBalls()
	{
		for (int i = 0; i < initBallCount; i++)
		{
			if (!HasEmptyBlock)
				break;
			Block b = EmptyBlocks.RandomItem();
			b.CreateBallAtBlock(new PrepareBall(config));
		}
	}
	public void CreatePrepareBalls()
	{
		PrepareBalls.Clear();
		for (int i = 0; i < prepareBallCount; i++)
			PrepareBalls.Add(new PrepareBall(config));
		OnPrepareBallsChange.Raise(PrepareBalls);
	}
	public IEnumerator AddPrepareBallsToBoard()
	{
		yield return DelayUtils.Scaled.WAIT_HALF_SEC;
		foreach (var ball in PrepareBalls)
		{
			if (!HasEmptyBlock)
				break;
			Block b = EmptyBlocks.RandomItem();
			b.CreateBallAtBlock(new PrepareBall(config));
			CheckMatchAtBlock(b);
		}
		CreatePrepareBalls();
		CheckEndGame();
	}
	public Block GetBlockAt(int r, int c)
	{
		return Blocks[r,c];
	}

	public List<Block> GetAdjacents(Block b)
	{
		List<Block> result = new List<Block>();
		int next = 0;
		//up
		next = b.Row + 1;
		if (next >= 0 && next < rowCount)
			result.Add(GetBlockAt(next, b.Col));
		//down
		next = b.Row - 1;
		if (next >= 0 && next < rowCount)
			result.Add(GetBlockAt(next, b.Col));
		//right
		next = b.Col + 1;
		if (next >= 0 && next < columnCount)
			result.Add(GetBlockAt(b.Row, next));
		//left
		next = b.Col - 1;
		if (next >= 0 && next < columnCount)
			result.Add(GetBlockAt(b.Row, next));
		return result;
	}

	private List<Block> checkedList = new List<Block>();
	private Queue<Block> needToCheckList = new Queue<Block>();
	public bool GetPath(Block start, Block end, ref List<Block> result, bool isGhost = false)
	{
		if (end.IsOccupied)
			return false;

		if (result == null)
			result = new List<Block>();
		else
			result.Clear();
		checkedList.Clear();
		needToCheckList.Clear();

		bool pathFound = false;
		needToCheckList.Enqueue(start);
		checkedList.Add(start);

		while (needToCheckList.Count != 0)
		{
			Block b = needToCheckList.Dequeue();
			//Debug.Log("Checking Block " +  b.Row + "," + b.Col);
			if (b == end)
			{
				pathFound = true;
				//Debug.Log("Path Found!!!");
				break;
			}
			foreach (Block adj in b.Adjacents)
			{
				if (adj.IsOccupied && !isGhost)
					continue;
				if (checkedList.Contains(adj))
					continue;
			
				adj.PathPrevBlock = b;
				needToCheckList.Enqueue(adj);
				checkedList.Add(adj);
			}
		}

		if (!pathFound)
			return false;
		
		//find path from the end point based on recorded PathPrevBlock
		Block block = end;
		while (block != start)
		{
			result.Add(block);
			block = block.PathPrevBlock;
		}
		result.Add(start);
		result.Reverse();
		return true;
	}

	private List<Block> path = new List<Block>();
	public void MoveBallToTarget(Block target)
	{
		if (SelectedBlock != null)
		{
			if (GetPath(SelectedBlock, target, ref path, SelectedBlock.CurrentBall.Type == Ball.BallType.Ghost))
			{
				foreach (var p in path)
					StartCoroutine(p.AnimatingPath(SelectedBlock.CurrentBall.SpriteImg));
				target.SetBall(SelectedBlock.CurrentBall);
				SelectedBlock.RemoveBall();
				CheckMatchAtBlock(target);		
				StartCoroutine(AddPrepareBallsToBoard());
			}
		}
		SelectedBlock = null;
	}

	private List<Block> needToDestroyList = new List<Block>();
	private List<Block> needToDestroyExtra = new List<Block>();
	private List<Block> matchList = new List<Block>();
	public void CheckMatchAtBlock(Block block)
	{
		if (!block.IsOccupied)
			return;
		needToDestroyList.Clear();
		needToDestroyExtra.Clear();
		Block nextBlock;

		for (int i = 0; i < 4; i++)
		{
			matchList.Clear();
			int nextRow = block.Row;
			int nextCol = block.Col;
			while(true)
			{
				switch (i)
				{
					case 0:
						nextCol++;
						break;
					case 1:
						nextRow++;
						break;
					case 2:
						nextCol++;
						nextRow++;
						break;
					case 3:
						nextCol--;
						nextRow++;
						break;
				}

				if (nextCol >= ColumnCount || nextCol < 0 || nextRow >= RowCount || nextRow < 0 )
					break;
				nextBlock = GetBlockAt(nextRow, nextCol);
				if (!nextBlock.IsOccupied)
					break;
				if (nextBlock.CurrentBall.Type != block.CurrentBall.Type 
						&& nextBlock.CurrentBall.Type != Ball.BallType.Rainbow
						&& block.CurrentBall.Type != Ball.BallType.Rainbow)
					break;
				if (block.CurrentBall.Type == Ball.BallType.Normal)
				{
					if (nextBlock.CurrentBall.Color != block.CurrentBall.Color 
						&& nextBlock.CurrentBall.Type != Ball.BallType.Rainbow
						&& block.CurrentBall.Type != Ball.BallType.Rainbow)
						break;
				}
				matchList.Add(nextBlock);
			}
			nextRow = block.Row;
			nextCol = block.Col;
			while(true)
			{
				switch (i)
				{
					case 0:
						nextCol--;
						break;
					case 1:
						nextRow--;
						break;
					case 2:
						nextCol--;
						nextRow--;
						break;
					case 3:
						nextCol++;
						nextRow--;
						break;
				}
				if (nextCol >= ColumnCount || nextCol < 0 || nextRow >= RowCount || nextRow < 0 )
					break;
				nextBlock = GetBlockAt(nextRow, nextCol);
				if (!nextBlock.IsOccupied)
					break;
				if (nextBlock.CurrentBall.Type != block.CurrentBall.Type 
						&& nextBlock.CurrentBall.Type != Ball.BallType.Rainbow
						&& block.CurrentBall.Type != Ball.BallType.Rainbow)
					break;
				if (block.CurrentBall.Type == Ball.BallType.Normal)
				{
					if (nextBlock.CurrentBall.Color != block.CurrentBall.Color 
						&& nextBlock.CurrentBall.Type != Ball.BallType.Rainbow
						&& block.CurrentBall.Type != Ball.BallType.Rainbow)
						break;
				}
				matchList.Add(nextBlock);
			}
			if (matchList.Count >= 4)
			{
				foreach(var match in matchList)
				{
					if (!needToDestroyList.Contains(match))
						needToDestroyList.Add(match);
				}
			}
				
		}
		if (needToDestroyList.Count == 0)
			return;
		needToDestroyList.Add(block);

		foreach(var item in needToDestroyList)
		{
			//check for stone
			foreach (var adj in item.Adjacents)
			{
				if (adj.IsOccupied && adj.CurrentBall.Type == Ball.BallType.Stone)
					needToDestroyExtra.Add(adj);		
			}
			//check for bomb
			if (item.CurrentBall.Type == Ball.BallType.Bomb)
			{
				foreach (var adj in item.Adjacents)
				{
					if (adj.IsOccupied && !needToDestroyExtra.Contains(adj) && !needToDestroyList.Contains(adj))
						needToDestroyExtra.Add(adj);		
				}
			}
		}
		needToDestroyList.AddRange(needToDestroyExtra);

		foreach(var item in needToDestroyList)
		{
			GameManager.Inst.Score++;
			item.DestroyBall();
		}
	}
	public void CheckEndGame()
	{
		if (EmptyBlocks.Count == 0)
		{
			GameManager.Inst.GameOver();
			Debug.Log("Game Over!");
		}
	}
}
