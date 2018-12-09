using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class Ball : MonoBehaviour 
{
	public enum BallState { Idle = 0, Selected, Destroy}
	public enum BallColor { Blue = 0, Green, Orange, Red, Violet, Yellow, Count}
	public enum BallType { Normal = 0, Ghost, Rainbow, Bomb, Stone, Count}
	
	/**************************************************/
	private BallState state;
	public BallColor Color { get; set;}
	public BallType Type { get; set;}

	
	[SerializeField] Animator animator;

	[SerializeField] SpriteRenderer spriteRenderer;
	[SerializeField] Sprite[] spriteNormal;
	[SerializeField] Sprite spriteGhost;
	[SerializeField] Sprite spriteRainbow;
	[SerializeField] Sprite spriteBomb;
	[SerializeField] Sprite spriteStone;

	/**************************************************/
	protected void Awake () 
	{
		
	}

	protected void Start () 
	{
		
	}

	protected void OnEnable () 
	{
		State = BallState.Idle;
	}
	/**************************************************/
	public BallState State 
	{ 
		get { return state;}
		set
		{
			state = value;
			switch (state)
			{
				case BallState.Idle:
					animator.SetTrigger("Idle");
					break;
				case BallState.Selected:
					animator.SetTrigger("Selected");
					break;
				case BallState.Destroy:
					animator.SetTrigger("Destroy");
					break;

			}
		}
	}
	
	public Sprite SpriteImg
	{
		get {return spriteRenderer.sprite;}
	}
	public void Init(PrepareBall prepare)
	{
		this.Type = prepare.Type;
		this.Color = prepare.Color;

		if (Type == BallType.Normal)
			spriteRenderer.sprite = spriteNormal[(int)this.Color];
		else if (Type == BallType.Ghost)
			spriteRenderer.sprite = spriteGhost;
		else if (Type == BallType.Rainbow)
			spriteRenderer.sprite = spriteRainbow;
		else if (Type == BallType.Bomb)
			spriteRenderer.sprite = spriteBomb;
		else if (Type == BallType.Stone)
			spriteRenderer.sprite = spriteStone;
	}

}


[Serializable]
public class PrepareBall
{
	public Ball.BallColor Color { get; set;}
	public Ball.BallType Type { get; set;}
	public PrepareBall(GameConfig config)
	{
		float rnd1 = UnityEngine.Random.Range(0f,1f);
		if (rnd1 < config.GhostChance)
		{
			if (config.CanSpawnGhost)
				Type = Ball.BallType.Ghost;
			else
				Type = Ball.BallType.Normal;
		}
		else if (rnd1 < config.GhostChance + config.RainbowChance)
		{
			if (config.CanSpawnRainbow)
				Type = Ball.BallType.Rainbow;
			else
				Type = Ball.BallType.Normal;
		}
		else if (rnd1 < config.GhostChance + config.RainbowChance + config.BombChance)
		{
		 	if (config.CanSpawnBomb)
				Type = Ball.BallType.Bomb;
			else
				Type = Ball.BallType.Normal;
		}
		else if (rnd1 < config.GhostChance + config.RainbowChance + config.BombChance + config.StoneChance)
		{
			if (config.CanSpawnStone)
				Type = Ball.BallType.Stone;
			else
				Type = Ball.BallType.Normal;
		}
		else
			Type = Ball.BallType.Normal;

		if (Type == Ball.BallType.Normal)
		{
			int rnd2 = UnityEngine.Random.Range(0, (int)Ball.BallColor.Count);
			this.Color = (Ball.BallColor) rnd2;
		}
	}

}
