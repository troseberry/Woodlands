using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour 
{
	public KeyItemInteract sleepPrompt;

	public void SleepToMorning()
	{
		sleepPrompt.CloseMenu();
		PlayerEnergy.RestoreEnergyPercentage(DetermineSleepDuration());
		TimeManager.ProgressToMorningTime();
	}

	float DetermineSleepDuration()
	{
		float startTime = TimeManager.GetCurrentTime();

		if (startTime % 30 >= 15)
		{
			startTime = (startTime - (startTime % 30)) + 30;
		}
		else
		{
			startTime -= (startTime % 30);
		}

		float sleepDuration = 0;
		if (startTime < TimeManager.morningTime) 
		{ 
			sleepDuration = (TimeManager.morningTime - startTime) / 60;
		}
		else
		{
			sleepDuration = ((1440 - startTime) + TimeManager.morningTime) / 60;
		}
		sleepDuration = Mathf.Clamp(sleepDuration, 0, PlayerRooms.GetBedRoomValue());

		// Debug.Log("Sleep Start Time: " + startTime);
		// Debug.Log("Sleep Duration: " + sleepDuration);

		return sleepDuration;
	}

}
