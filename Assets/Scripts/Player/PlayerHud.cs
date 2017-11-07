using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHud : MonoBehaviour 
{
	private Canvas playerCanvas;

	private float currentEnergyValue = 0f;
	private float maxEnergyValue;
	public Image energyRadial;
	public Text energyText;

	private int toolEquipIndex;
	public Transform toolIconGroup;
	private bool doChangeTool = false;

	
	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();

		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();

		toolEquipIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
		// ChangeToolImage();
		ToolManager.SwitchTool(toolEquipIndex);
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(toolEquipIndex).gameObject.SetActive(true);
		
		doChangeTool = false;
	}
	
	void Update () 
	{
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();

		CheckSwitchToolsInput();
		if (doChangeTool) ChangeToolImage();


		if (CharacterAnimator.GetCurrentAnimState().IsName("Back_EmptyToTool") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_EmptyToTool"))
		{
			Debug.Log("Equip");
			ToolManager.EquipTool(toolEquipIndex);
		}

		if (CharacterAnimator.GetCurrentAnimState().IsName("Back_ToolToEmpty") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_ToolToEmpty"))
		{
			Debug.Log("Unequip");
			ToolManager.UnequipTool();
		}

		if (CharacterAnimator.GetCurrentAnimState().IsName("Back_ToolUnequip_Half") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_ToolUnequip_Half"))
		{
			Debug.Log("Unequip");
			ToolManager.UnequipTool();
		}

		if (CharacterAnimator.GetCurrentAnimState().IsName("Back_ToolEquip_Half") || CharacterAnimator.GetCurrentAnimState().IsName("Waist_ToolEquip_Half"))
		{
			Debug.Log("Equip");
			ToolManager.EquipTool(toolEquipIndex);
		}

		Debug.Log("Back Unequip: " + CharacterAnimator.GetCurrentAnimState().IsName("Back_ToolUnequip_Half"));
		Debug.Log("Waist Unequip: "+ CharacterAnimator.GetCurrentAnimState().IsName("Waist_ToolUnequip_Half"));
	}

	void CheckSwitchToolsInput()
	{
		if (Input.GetButtonDown("Tool_01"))
		{
			toolEquipIndex = 0;
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_02"))
		{
			toolEquipIndex = 1;
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_03"))
		{
			toolEquipIndex = 2;
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_04"))
		{
			toolEquipIndex = 3;
			doChangeTool = true;
		}
	}

	void ChangeToolImage()
	{
		int startLoc = 0;
		if (PlayerTools.GetCurrentlyEquippedToolIndex() > 0) startLoc = (PlayerTools.GetCurrentlyEquippedToolIndex() == 2) ? 2 : 1;
		Debug.Log("Start Loc: " + startLoc);
		Debug.Log("PTools: " + PlayerTools.GetCurrentlyEquippedToolIndex());

		int endLoc = 0;
		if (toolEquipIndex > 0) endLoc = (toolEquipIndex == 2) ? 2 : 1;

		CharacterAnimator.SetEquipLocations(startLoc, endLoc);
		CharacterAnimator.SetSwitchToolAsAction();


		// ToolManager.SwitchTool(toolEquipIndex);
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(toolEquipIndex).gameObject.SetActive(true);
		
		doChangeTool = false;
	}
}
