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
	//0 to 1440
	//72 real-time seconds = 1 hour of game time

	float maxTime = 1440;
	float currentClock = 0;

	public Text clockText;
	private string formattedClock = "";
	
	private float testClock = 0;
	private string testClockString = "";

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (currentClock < maxTime)
		{
			testClock += Time.deltaTime;
			currentClock += (Time.deltaTime / 0.72f); //this does not equate to 20 mins for a 24 hr cycle. 17:17 for a 24 hr cycle currently
		}
		else if (currentClock == maxTime || currentClock < 0)
		{
			testClock = 0;
			currentClock = 0;
		}
		formattedClock = string.Format("{0}:{1:00}", (int)currentClock / 60, currentClock % 60);
		clockText.text = formattedClock;
		DebugPanel.Log("Clock: ", formattedClock);

		testClockString = string.Format("{0}:{1:00}", (int)testClock / 60, testClock % 60);
		DebugPanel.Log("Test Clock: ", testClockString);
	}
}
