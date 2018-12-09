using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;
using TMPro;
public class UIOverMenu : MonoBehaviour 
{
	[SerializeField] GameObject content;
	[SerializeField] TextMeshProUGUI txtScore;
	/**************************************************/
	protected void Awake () 
	{
		
	}

	protected void Start () 
	{
		
	}

	protected void OnEnable () 
	{
		GameManager.OnGameOver += OnGameOver;
	}

	protected void OnDisable () 
	{
		GameManager.OnGameOver -= OnGameOver;
	}

	public void OnClickButtonPlay () 
	{
		GameManager.Inst.PlayGame();
		content.SetActive(false);
	}
	/**************************************************/
	private void OnGameOver(int score)
	{
		content.SetActive(true);
		txtScore.text = score.ToString();
	}
}
