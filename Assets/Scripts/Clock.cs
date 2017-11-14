//Minecraft Time Reference:
//1 minecraft Day = 20 min realtime
//10 mins of daytime, 7 mins of nighttime, 1.5 mins of both dusk and dawn
// 1 minecraft hour = 50 sec real time
// 

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

		formattedClock = string.Format("{0}:{1:00}", (int)currentClock / 60, currentClock % 60);
		clockText.text = formattedClock;
	}
}
