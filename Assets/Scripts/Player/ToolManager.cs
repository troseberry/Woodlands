using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToolManager : MonoBehaviour 
{
	public Transform toolGroup;
	private static int currentToolIndex;
	private static int toolToEquipIndex;
	private static bool doSwitch = false;
	private static bool doUnequipOnly = false;
	private static bool doScrollSwitch = false;

	void Start () 
	{
		currentToolIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
		EquipTool(currentToolIndex);
	}
	
	void Update () 
	{
		if (doSwitch)
		{
			EnableTool();
		}
		else if (doUnequipOnly)
		{
			HideAllTools();
		}

		HandleToolAnimatorChecks();
	}

	public static void EquipTool(int toolIndex)
	{
		toolToEquipIndex = toolIndex;
		doSwitch = true;

		PlayerTools.SetCurrentlyEquippedTool(toolToEquipIndex);
	}

	public static void UnequipTool()
	{
		doUnequipOnly = true;

		PlayerTools.SetCurrentlyEquippedTool(0);
	}

	public static IEnumerator DelayedEquipTool(int toolIndex)
	{
		yield return new WaitForSeconds(CharacterAnimator.GetCurrentAnimState().length);
		toolToEquipIndex = toolIndex;
		doSwitch = true;

		PlayerTools.SetCurrentlyEquippedTool(toolToEquipIndex);
	}

	void EnableTool()
	{
		HideAllTools();
		toolGroup.GetChild(toolToEquipIndex).gameObject.SetActive(true);

		doSwitch = false;
		currentToolIndex = toolToEquipIndex;
		
		if (doScrollSwitch) doScrollSwitch = false;
	}

	void HideAllTools()
	{
		for (int i = 0; i < toolGroup.childCount; i++)
		{
			toolGroup.GetChild(i).gameObject.SetActive(false);
		}

		if (doUnequipOnly) doUnequipOnly = false;
		if (doScrollSwitch) doScrollSwitch = false;
	}

	public static bool GetDoSwitch() { return doSwitch; }

	public static void SetToolToEquipIndex(int index) { toolToEquipIndex = index; }

	public static int GetToolToEquipIndex() { return toolToEquipIndex; }

	public static bool GetScrollSwitch() { return doScrollSwitch; }

	public static void SetScrollSwitch(bool doSwitch) { doScrollSwitch = doSwitch; }

	void HandleToolAnimatorChecks()
	{
		if (CharacterAnimator.GetEndToolFloat() == 0f)
		{
			toolToEquipIndex = 0;
			UnequipTool();
		}
		else
		{
			EquipTool(toolToEquipIndex);
		}
	}
}