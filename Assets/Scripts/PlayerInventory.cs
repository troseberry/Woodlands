using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
	private static int currentEnergy;
	private static int currenctCurrency;
	private static int currentLumber;
	private static int currentHardware;


	public static int GetEnergyValue()
	{
		return currentEnergy;
	}

	public static void SetEnergyValue(int newValue)
	{
		//don't allow grater than max or less than 0
		currentEnergy = newValue;
	}

	public static void UpdateEnergyValue(int changeValue)
	{
		//don't allow grater than max or less than 0
		currentEnergy += changeValue;
	}


	public static int GetCurrencyValue()
	{
		return currenctCurrency;
	}

	public static void SetCurrencyValue(int newValue)
	{
		//don't allow grater than max or less than 0
		currenctCurrency = newValue;
	}

	public static void UpdateCurrencyValue(int changeValue)
	{
		//don't allow grater than max or less than 0
		currenctCurrency += changeValue;
	}


	public static int GetLumberValue()
	{
		return currentLumber;
	}

	public static void SetLumberValue(int newValue)
	{
		//don't allow grater than max or less than 0
		currentLumber = newValue;
	}

	public static void UpdateLumberValue(int changeValue)
	{
		//don't allow grater than max or less than 0//check max
		currentLumber += changeValue;
	}


	public static int GetHardwareValue()
	{
		return currentHardware;
	}

	public static void SetHardwareValue(int newValue)
	{
		//don't allow grater than max or less than 0
		currentHardware = newValue;
	}

	public static void UpdateHardwareValue(int changeValue)
	{
		//don't allow grater than max or less than 0
		currentHardware += changeValue;
	}
}
