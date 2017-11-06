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
		ChangeToolImage();
	}
	
	void Update () 
	{
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();

		CheckSwitchToolsInput();
		if (doChangeTool) ChangeToolImage();
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
		ToolManager.SwitchTool(toolEquipIndex);
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(toolEquipIndex).gameObject.SetActive(true);
	}
}
