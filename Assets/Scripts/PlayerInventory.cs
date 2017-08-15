using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
	private static int currentEnergy = 0;
	private static int currenctCurrency = 0;
	private static int currentLumber = 0;
	private static int currentHardware = 0;


	public static int GetEnergyValue()
	{
		return currentEnergy;
	}

	public static void SetEnergyValue(int newValue)
	{
		currentEnergy = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxEnergyValue());
	}

	public static void UpdateEnergyValue(int changeValue)
	{
		currentEnergy = Mathf.Clamp((currentEnergy += changeValue), 0, PlayerSkills.GetMaxEnergyValue());
	}


	public static int GetCurrencyValue()
	{
		return currenctCurrency;
	}

	public static void SetCurrencyValue(int newValue)
	{
		currenctCurrency = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxCurrencyValue());
	}

	public static void UpdateCurrencyValue(int changeValue)
	{
		currenctCurrency = Mathf.Clamp((currenctCurrency += changeValue), 0, PlayerSkills.GetMaxCurrencyValue());
	}


	public static int GetLumberValue()
	{
		return currentLumber;
	}

	public static void SetLumberValue(int newValue)
	{
		currentLumber = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxResourcesValue());
	}

	public static void UpdateLumberValue(int changeValue)
	{
		currentLumber = Mathf.Clamp((currentLumber += changeValue), 0, PlayerSkills.GetMaxResourcesValue());
	}


	public static int GetHardwareValue()
	{
		return currentHardware;
	}

	public static void SetHardwareValue(int newValue)
	{
		currentHardware = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxResourcesValue());
	}

	public static void UpdateHardwareValue(int changeValue)
	{
		currentHardware = Mathf.Clamp((currentHardware += changeValue), 0, PlayerSkills.GetMaxResourcesValue());
	}
}
