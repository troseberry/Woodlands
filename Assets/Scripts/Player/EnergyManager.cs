using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour 
{

	private static Dictionary<string, int> ActionEnergyCosts = new Dictionary<string, int>()
	{
		{"FellingAxeChop", 5},
		{"CrosscutSawPush", 5},
		{"CrosscutSawPull", 5},
		{"SplittingAxeChop", 5},
		{"UpkeepTask_Kitchen", 5},
		{"UpkeepTask_Bedroom", 5},
		{"UpkeepTask_Study", 5},
		{"UpkeepTask_Office", 5},
		{"UpkeepTask_Workshop", 5}
	};
}