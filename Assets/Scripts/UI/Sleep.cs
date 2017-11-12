using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour 
{
	public KeyItemInteract sleepPrompt;

	public void SleepToMorning()
	{
		sleepPrompt.CloseMenu();
		PlayerEnergy.FullyRestoreEnergy();
		TimeManager.ProgressTimeByHours((float)PlayerRooms.GetBedRoomValue());
	}
}
