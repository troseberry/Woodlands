using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory 
{
	private static int currenctCurrency = 0;
	private static int currentBuildingMaterials = 0;
	private static int currentToolParts = 0;
	private static int currentBookPages = 0;


	public static int GetCurrencyValue()
	{
		return currenctCurrency;
	}

	public static void SetCurrencyValue(int newValue)
	{
		currenctCurrency = Mathf.Clamp(newValue, 0, PlayerSkills.GetCurrencyValue());
	}

	public static void UpdateCurrencyValue(int changeValue)
	{
		currenctCurrency = Mathf.Clamp((currenctCurrency += changeValue), 0, PlayerSkills.GetCurrencyValue());
	}


	public static int GetBuildingMaterialsValue()
	{
		return currentBuildingMaterials;
	}

	public static void SetBuildingMaterialsValue(int newValue)
	{
		currentBuildingMaterials = Mathf.Clamp(newValue, 0, PlayerSkills.GetBuildingMaterialsValue());
	}

	public static void UpdateBuildingMaterialsValue(int changeValue)
	{
		currentBuildingMaterials = Mathf.Clamp((currentBuildingMaterials += changeValue), 0, PlayerSkills.GetBuildingMaterialsValue());
	}


	public static int GetToolPartsValue()
	{
		return currentToolParts;
	}

	public static void SetToolPartsValue(int newValue)
	{
		currentToolParts = Mathf.Clamp(newValue, 0, PlayerSkills.GetToolPartsValue());
	}

	public static void UpdateToolPartsValue(int changeValue)
	{
		currentToolParts = Mathf.Clamp((currentToolParts += changeValue), 0, PlayerSkills.GetToolPartsValue());
	}


	public static int GetBookPagesValue()
	{
		return currentBookPages;
	}

	public static void SetBookPagesValue(int newValue)
	{
		currentBookPages = Mathf.Clamp(newValue, 0, PlayerSkills.GetBookPagesValue());
	}

	public static void UpdateBookPagesValue(int changeValue)
	{
		currentBookPages = Mathf.Clamp((currentBookPages += changeValue), 0, PlayerSkills.GetBookPagesValue());
	}
}
