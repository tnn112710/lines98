using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using TMPro;

public class UIHud : MonoBehaviour 
{
	[SerializeField] TextMeshProUGUI txtScore;
	[SerializeField] TextMeshProUGUI txtHighScore;
	[SerializeField] TextMeshProUGUI txtTime;
	[SerializeField] Image[] imgPrepareBalls;
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
		GameManager.OnScoreChange += UpdateScore;
		GameManager.OnHighscoreChange += UpdateHighScore;
		Board.OnPrepareBallsChange += UpdatePrepareBalls;
		GameManager.OnTimeChange += UpdateTime;
	}

	protected void OnDisable () 
	{
		GameManager.OnScoreChange -= UpdateScore;
		GameManager.OnHighscoreChange -= UpdateHighScore;
		Board.OnPrepareBallsChange -= UpdatePrepareBalls;
		GameManager.OnTimeChange -= UpdateTime;
	}
	/**************************************************/
	private void UpdateScore(int score)
	{
		txtScore.text = score.ToString();
	}
	private void UpdateHighScore(int score)
	{
		txtHighScore.text = score.ToString();
	}
	private void UpdatePrepareBalls(List<PrepareBall> balls)
	{
		for (int i = 0; i < balls.Count; i++)
		{
			imgPrepareBalls[i].gameObject.SetActive(true);
			if (balls[i].Type == Ball.BallType.Normal)
				imgPrepareBalls[i].sprite = spriteNormal[(int)balls[i].Color];
			else if (balls[i].Type == Ball.BallType.Ghost)
				imgPrepareBalls[i].sprite = spriteGhost;
			else if (balls[i].Type == Ball.BallType.Rainbow)
				imgPrepareBalls[i].sprite = spriteRainbow;
			else if (balls[i].Type == Ball.BallType.Bomb)
				imgPrepareBalls[i].sprite = spriteBomb;
			else if (balls[i].Type == Ball.BallType.Stone)
				imgPrepareBalls[i].sprite = spriteStone;
		}
		for (int i = balls.Count; i < imgPrepareBalls.Length; i++)
		{
			imgPrepareBalls[i].gameObject.SetActive(false);
		}
	}
	private void UpdateTime(int time)
	{
		txtTime.text = time.ToString();
	}
}
