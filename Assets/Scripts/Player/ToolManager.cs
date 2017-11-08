using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour 
{
	public Transform toolGroup;
	private static int currentToolIndex;
	private static int toolToEquipIndex;
	private static bool doSwitch = false;
	private static bool doUnequipOnly = false;

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
	}

	void HideAllTools()
	{
		for (int i = 0; i < toolGroup.childCount; i++)
		{
			toolGroup.GetChild(i).gameObject.SetActive(false);
		}

		if (doUnequipOnly) doUnequipOnly = false;
	}

	public static bool GetDoSwitch() { return doSwitch; }

	public static void SetToolToEquipIndex(int index) { toolToEquipIndex = index; }

	public static int GetToolToEquipIndex() { return toolToEquipIndex; }

	void HandleToolAnimatorChecks()
	{
		if (CharacterAnimator.GetCurrentAnimState().IsName("Back_Equip") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_Equip"))
		{
			EquipTool(toolToEquipIndex);
		}
		else if (CharacterAnimator.GetCurrentAnimState().IsName("Back_Unequip") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_Unequip"))
		{
			toolToEquipIndex = 0;
			UnequipTool();
		}
		else if (CharacterAnimator.GetCurrentAnimState().IsName("BackToBack_Unequip") || CharacterAnimator.GetCurrentAnimState().IsName("WaistToWaist_Unequip"))
		{
			UnequipTool();
			StartCoroutine(DelayedEquipTool(toolToEquipIndex));
		}
		else if (CharacterAnimator.GetCurrentAnimState().IsName("BackToWaist_Unequip") || CharacterAnimator.GetCurrentAnimState().IsName("WaistToBack_Unequip"))
		{
			UnequipTool();
			StartCoroutine(DelayedEquipTool(toolToEquipIndex));
		}
	}
}