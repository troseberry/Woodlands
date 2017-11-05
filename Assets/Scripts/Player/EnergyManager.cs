using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnergyAction {HORIZONTAL_CHOP, SAW_PUSH, SAW_PULL, VERTICAL_CHOP, UPKEEP_KITCHEN, UPKEEP_BEDROOM,
UPKEEP_STUDY, UPKEEP_OFFICE, UPKEEP_WORKSHOP};

public class EnergyManager : MonoBehaviour 
{
	private static int currentEnergyValue = 100;
	private static Dictionary<EnergyAction, int> ActionEnergyCosts = new Dictionary<EnergyAction, int>()
	{
		{EnergyAction.HORIZONTAL_CHOP, 1},
		{EnergyAction.SAW_PUSH, 1},
		{EnergyAction.SAW_PULL, 1},
		{EnergyAction.VERTICAL_CHOP, 1},
		{EnergyAction.UPKEEP_KITCHEN, 1},
		{EnergyAction.UPKEEP_BEDROOM, 1},
		{EnergyAction.UPKEEP_STUDY, 1},
		{EnergyAction.UPKEEP_OFFICE, 1},
		{EnergyAction.UPKEEP_WORKSHOP, 1}
	};

	public static int GetCurrentEnergyValue()
	{
		return currentEnergyValue;
	}

	public static void SetCurrentEnergyValue(int newValue)
	{
		currentEnergyValue = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxEnergyValue());
	}

	public static void UpdateCurrentEnergyValue(int changeValue)
	{
		currentEnergyValue = Mathf.Clamp((currentEnergyValue += changeValue), 0, PlayerSkills.GetMaxEnergyValue());
	}

	public static bool ConsumeEnergy(EnergyAction actionToPerform)
	{
		int actionEnergyValue = ActionEnergyCosts[actionToPerform];
		if (currentEnergyValue >= actionEnergyValue)
		{
			currentEnergyValue -= actionEnergyValue;
			return true;
		}
		return false;
	}

	public static void FullyRestoreEnergy()
	{
		currentEnergyValue = PlayerSkills.GetMaxEnergyValue();
	}
}