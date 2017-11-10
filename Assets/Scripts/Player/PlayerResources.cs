using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerResources 
{
	private static int currenctCurrency = 0;
	private static int currentBuildingMaterials = 0;
	private static int currentToolParts = 0;
	private static int currentBookPages = 0;


	public static int GetCurrentCurrencyValue()
	{
		return currenctCurrency;
	}

	public static void SetCurrentCurrencyValue(int newValue)
	{
		currenctCurrency = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxCurrencyValue());
	}

	public static void UpdateCurrentCurrencyValue(int changeValue)
	{
		currenctCurrency = Mathf.Clamp((currenctCurrency += changeValue), 0, PlayerSkills.GetMaxCurrencyValue());
	}


	public static int GetCurrentBuildingMaterialsValue()
	{
		return currentBuildingMaterials;
	}

	public static void SetCurrentBuildingMaterialsValue(int newValue)
	{
		currentBuildingMaterials = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxBuildingMaterialsValue());
	}

	public static void UpdateCurrentBuildingMaterialsValue(int changeValue)
	{
		currentBuildingMaterials = Mathf.Clamp((currentBuildingMaterials += changeValue), 0, PlayerSkills.GetMaxBuildingMaterialsValue());
	}


	public static int GetCurrentToolPartsValue()
	{
		return currentToolParts;
	}

	public static void SetCurrentToolPartsValue(int newValue)
	{
		currentToolParts = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxToolPartsValue());
	}

	public static void UpdateCurrentToolPartsValue(int changeValue)
	{
		currentToolParts = Mathf.Clamp((currentToolParts += changeValue), 0, PlayerSkills.GetMaxToolPartsValue());
	}


	public static int GetCurrentBookPagesValue()
	{
		return currentBookPages;
	}

	public static void SetCurrentBookPagesValue(int newValue)
	{
		currentBookPages = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxBookPagesValue());
	}

	public static void UpdateCurrentBookPagesValue(int changeValue)
	{
		currentBookPages = Mathf.Clamp((currentBookPages += changeValue), 0, PlayerSkills.GetMaxBookPagesValue());
	}


	public static string GetPlayerResourcesAsString()
	{
		return "C: " + currenctCurrency + " | BM: " + currentBuildingMaterials + " | TP: " + currentToolParts + " | BP: " + currentBookPages;
	}
}
