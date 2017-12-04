// In-game time passes at a rate of 1 min per sec
// 24hr game period == 1440 game time seconds (60 * 24)
// To fit this 24 game time hrs into 20 real time minutes (1200 real time seconds): 
// 				1200 real time seconds / 1440 game time seconds = ~0.833333 real time seconds per game second
// 0.83 repeated is the rate to scale Time.detlaTime by in Update

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour 
{
	private static bool _paused;
	public static bool paused { get{ return _paused;} }

	private static float currentTime;
	private static float dayLength = 1440f;

	private static bool didDailyGeneration = false;

	private const float morningTime = 480f;

	
	void Start()
	{
		currentTime = 720f;
	}

	void Update () 
	{
		// Debug.Log("Did Daily Generation: " + didDailyGeneration);
		if (currentTime < dayLength)
		{
			currentTime += (Time.deltaTime / 0.8333f);
		}
		else if (currentTime >= dayLength)
		{
			currentTime -= dayLength;
			//currentTime = (currentTime % dayLength);
		}
		else if (currentTime < 0)
		{
			currentTime = 0f;
		}

		HandleDailyTaskLogic();
	}

	public static void PauseGame()
	{
		_paused = true;
		CharacterInputController.SetCanTurn(false);
		Time.timeScale = 0f;
	}

	public static void UnpauseGame()
	{
		_paused = false;
		CharacterInputController.SetCanTurn(true);
		Time.timeScale = 1.0f;
	}

	public static float GetCurrentTime() { return currentTime; }

	public static void SetCurrentTime(float newTime) { currentTime = newTime; }

	public static void ProgressTimeByHours(float hoursToPass)
	{
		float timeBeforeSkip = currentTime;
		currentTime += (60 * hoursToPass);

		HandleDailyTaskLogic();
	}

	public static void ProgressTimeByMinutes(float minsToPass)
	{
		currentTime += minsToPass;
	}


	static void HandleDailyTaskLogic()
	{
		if (didDailyGeneration)
		{
			if (currentTime >= 0  && currentTime < morningTime) didDailyGeneration = false;
		}
		else
		{
			if (currentTime >= morningTime) ExecuteDailyTasks();
		}
	}

	static void ExecuteDailyTasks()
	{
		//Do this before generting new so new contracts don't get accidentally decremented
		PlayerContracts.ProgressAllContractDeadlines();
		AvailableContracts.ProgressAllContractDeadlines();

		AvailableContracts.GenerateNewContracts();
		didDailyGeneration = true;

		Debug.Log("Finished Daily Tasks");
	}
}