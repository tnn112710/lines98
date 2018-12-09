using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class GameManager : MonoSingleton<GameManager> 
{
	public enum GameState {Waiting = 0, Playing}
	public static Action<int> OnGameOver;
	public static Action<int> OnScoreChange;
	public static Action<int> OnHighscoreChange;
	public static Action<int> OnTimeChange;

	[SerializeField] GameConfig config;

	public GameState State {get; set;}

	private const string KEY_HIGH_SCORE = "Highscore";
	/**************************************************/
	private int score;
	private int highScore;
	private float currentTime;
	/**************************************************/
	protected void Awake () 
	{
		
	}

	protected void Start () 
	{
		HighScore = PlayerPrefs.GetInt(KEY_HIGH_SCORE, 0);
		State = GameState.Waiting;
	}

	protected void OnEnable () 
	{
		
	}

	protected void OnDisable () 
	{
		
	}

	protected void Update () 
	{
		if (State == GameState.Playing)
		{
			CurrentTime -= Time.deltaTime;
			OnTimeChange.Raise((int)CurrentTime);
			if (CurrentTime <= 0)
			{
				GameOver();
			}
		}
	}
	/**************************************************/
	public int Score
	{
		get { return score;}
		set
		{
			score = value;
			if (score < 0) score = 0;
			if (score > HighScore)
				HighScore = score;
			OnScoreChange.Raise(score);
		}
	}
	public int HighScore
	{
		get { return highScore;}
		set
		{
			highScore = value;
			PlayerPrefs.SetInt(KEY_HIGH_SCORE, highScore);
			OnHighscoreChange.Raise(highScore);
		}
	}
	public float CurrentTime
	{
		get { return currentTime;}
		set
		{
			currentTime = value;
		}
	}
	/**************************************************/
	public void PlayGame()
	{
		State = GameState.Playing;
		CurrentTime = config.MaxTime;
		Score = 0;
		Board.Inst.ClearOldGame();
		Board.Inst.InitNewGame();
	}
	public void GameOver()
	{
		State = GameState.Waiting;
		OnGameOver.Raise(Score);
		
	}
}
