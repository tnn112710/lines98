using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

public class UIMainMenu : MonoBehaviour 
{
	[SerializeField] GameObject content;
	/**************************************************/
	protected void Awake () 
	{
		
	}

	protected void Start () 
	{
		
	}

	protected void OnEnable () 
	{
		
	}

	protected void OnDisable () 
	{
		
	}

	public void OnClickButtonPlay () 
	{
		GameManager.Inst.PlayGame();
		content.SetActive(false);
	}
	/**************************************************/
}
