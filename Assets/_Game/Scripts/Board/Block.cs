using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Block : MonoBehaviour 
{
	public int Row { get; set;}
	public int Col { get; set;}

	public Ball CurrentBall { get; set;}

	public List<Block> Adjacents;
	public Block PathPrevBlock;
	public static Action UnSelectAll;

	[SerializeField] GameObject ballPrefab;
	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] SpriteRenderer movingRenderer;

	/**************************************************/
	protected void Awake () 
	{
		
	}

	protected void Start () 
	{
		movingRenderer.enabled = false;
	}

	protected void OnEnable () 
	{
		UnSelectAll += UnSelect;
	}

	protected void OnDisable () 
	{
		UnSelectAll -= UnSelect;
	}

	protected void Update () 
	{
		
	}
	/**************************************************/
	public bool IsOccupied
	{
		get { return CurrentBall != null;}
	}
	/**************************************************/
	public void Init(int row, int col)
	{
		CurrentBall = null;
		Row = row;
		Col = col;
		gameObject.name = "Block ("+ row + ", " + col + ")";
	}

	public void FindAdjacents()
	{
		Adjacents = Board.Inst.GetAdjacents(this);
	}
	public void CreateBallAtBlock(PrepareBall prepare)
	{
		if (CurrentBall != null)
			Debug.LogError("A Ball already occupied this " + gameObject.name);
		Board.Inst.EmptyBlocks.Remove(this);
		CurrentBall = ballPrefab.Spawn(transform.position, Quaternion.identity, Vector3.one, this.transform).GetComponent<Ball>();
		CurrentBall.Init(prepare);
	}

	private bool preventUnselected = false;
	private void OnMouseDown()
	{
		if (GameManager.Inst.State != GameManager.GameState.Playing)
			return;
		preventUnselected = true;
		UnSelectAll.Raise();
		if (IsOccupied)
		{
			if (CurrentBall.Type == Ball.BallType.Stone)
				return;
			CurrentBall.State = Ball.BallState.Selected;
			Board.Inst.SelectedBlock = this;
		}
		else
		{
			Board.Inst.MoveBallToTarget(this);
		}
	}
	private void UnSelect()
	{
		if (preventUnselected)
		{
			preventUnselected = false;
			return;
		}
		if (IsOccupied)
			CurrentBall.State = Ball.BallState.Idle;
	}

	public void RemoveBall()
	{
		Board.Inst.EmptyBlocks.Add(this);
		CurrentBall = null;
	}
	public void SetBall(Ball ball)
	{
		Board.Inst.EmptyBlocks.Remove(this);
		CurrentBall = ball;
		ball.transform.position = this.transform.position;
	}

	public IEnumerator AnimatingPath(Sprite sprite)
	{
		movingRenderer.enabled = true;
		movingRenderer.sprite = sprite;
		yield return Utilities.DelayUtils.Scaled.WAIT_A_SEC;
		movingRenderer.enabled = false;
	}

	public void DestroyBall()
	{
		StartCoroutine(DestroyingBall());
	}
	private IEnumerator DestroyingBall()
	{
		CurrentBall.State = Ball.BallState.Destroy;
		Ball temp = CurrentBall;
		RemoveBall();
		yield return DelayUtils.Scaled.WAIT_ONE_THIRD_SEC;
		temp.gameObject.Despawn();
		
	}

}