﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour 
{
	public Transform toolGroup;
	private static int currentToolIndex;
	private static int toolEquipIndex;
	private static bool doSwitch = false;

	void Start () 
	{
		currentToolIndex = PlayerTools.GetCurrentlyEquippedToolIndex();	
	}
	
	void Update () 
	{
		if (doSwitch)
		{
			EnableTool();
		}	
	}

	public static void SwitchTool(int selectedTool)
	{
		toolEquipIndex = selectedTool;
		doSwitch = true;

		


		PlayerTools.SetCurrentlyEquippedTool(toolEquipIndex);
	}

	void HideAllTools()
	{
		for (int i = 0; i < toolGroup.childCount; i++)
		{
			toolGroup.GetChild(i).gameObject.SetActive(false);
		}
	}

	void EnableTool()
	{
		HideAllTools();
		toolGroup.GetChild(toolEquipIndex).gameObject.SetActive(true);

		// CharacterAnimator.SetEquipLocations(currentToolIndex, toolEquipIndex);
		// CharacterAnimator.SetSwitchToolAsAction();


		doSwitch = false;
		currentToolIndex = toolEquipIndex;
	}
}