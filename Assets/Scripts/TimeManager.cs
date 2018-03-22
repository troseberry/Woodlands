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

	public float timeSpeed = 1f;

	private static float currentTime;
	private static float dayLength = 1440f;

	private static bool didDailyGeneration = false;

	public const float morningTime = 480f;
	public const float sleepTime = 1320f;

	
	void Start()
	{
		// currentTime = 720f;
	}

	void Update () 
	{
		// Debug.Log("Did Daily Generation: " + didDailyGeneration);
		if (currentTime < dayLength)
		{
			currentTime += (Time.deltaTime / 0.8333f) * timeSpeed;
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

	public static float GetCurrentTime() { return currentTime; }

	public static void SetCurrentTime(float newTime) { currentTime = newTime; }

	public static bool IsInSleepTimeFrame()
	{ 
		return (currentTime >= sleepTime || currentTime < morningTime);
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

	public static void ProgressTimeByHours(float hoursToPass)
	{
		currentTime += (60 * hoursToPass);
	}

	public static void ProgressTimeByMinutes(float minsToPass)
	{
		currentTime += minsToPass;
	}

	public static void ProgressToMorningTime()
	{
		currentTime = morningTime;
		ExecuteDailyTasks();
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
		//Do this before generating new so new contracts don't get accidentally decremented
		PlayerContracts.ProgressAllContractDeadlines();
		AvailableContracts.ProgressAllContractDeadlines();

		AvailableContracts.GenerateNewContracts();

		Debug.Log("Holding Here?");

		MenuManager.currentMenuManager.UpdateMenusAtStartOfDay();

		didDailyGeneration = true;

		Debug.Log("Finished Daily Tasks");
		Debug.Log("Average Difficulty: " + AvailableContracts.GetAverageContractDifficulty());
		Debug.Log("Standard Dev: " + AvailableContracts.CalculateStandardDeviation(AvailableContracts.GetPastGeneratedContractDifficuties()));
	}
}