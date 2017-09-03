//Minecraft Time Reference:
//1 minecraft Day = 20 min realtime
//10 mins of daytime, 7 mins of nighttime, 1.5 mins of both dusk and dawn
// 1 minecraft hour = 50 sec real time
// 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour 
{
	//0 to 1440
	//72 real-time seconds = 1 hour of game time

	float maxTime = 1440;

	float currentClock;

	private float clockTime;

	void Start () 
	{
		
	}
	
	void Update () 
	{
		if (currentClock < maxTime)
		{
			currentClock += Time.deltaTime;
		}
		else if (currentClock == maxTime || currentClock < 0)
		{
			currentClock = 0;
		}
	}
}
