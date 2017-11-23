using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour 
{
	public Text clockText;
	private string formattedClock = "";
	
	void Update () 
	{
		float currentClock = TimeManager.GetCurrentTime();

		formattedClock = string.Format("{0:00}:{1:00}", Mathf.Floor(currentClock / 60), Mathf.Floor(currentClock % 60));
		clockText.text = formattedClock;
	}
}
