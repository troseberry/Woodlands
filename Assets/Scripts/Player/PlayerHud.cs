using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHud : MonoBehaviour 
{
	private Canvas playerCanvas;

	private float energyValue = 0f;
	public Image energyRadial;
	public Text energyText;

	private int toolEquipIndex;
	public Transform toolIconGroup;

	
	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
		toolEquipIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
		ChangeToolImage();
	}
	
	void Update () 
	{
		energyValue = (float) EnergyManager.GetCurrentEnergyValue()/100f;
		energyRadial.fillAmount = energyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, energyValue);
		energyText.text = (energyValue * 100).ToString();

		CheckSwitchToolsInput();
	}

	void CheckSwitchToolsInput()
	{
		if (Input.GetButtonDown("Tool_01"))
		{
			PlayerTools.SetCurrentlyEquippedTool(ToolName.EMPTY_HANDS);
			toolEquipIndex = 0;
			ChangeToolImage();
		}
		else if (Input.GetButtonDown("Tool_02"))
		{
			PlayerTools.SetCurrentlyEquippedTool(ToolName.FELLING_AXE);
			toolEquipIndex = 1;
			ChangeToolImage();
		}
		else if (Input.GetButtonDown("Tool_03"))
		{
			PlayerTools.SetCurrentlyEquippedTool(ToolName.CROSSCUT_SAW);
			toolEquipIndex = 2;
			ChangeToolImage();
		}
		else if (Input.GetButtonDown("Tool_04"))
		{
			PlayerTools.SetCurrentlyEquippedTool(ToolName.SPLITTING_AXE);
			toolEquipIndex = 3;
			ChangeToolImage();
		}
	}

	void ChangeToolImage()
	{
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(toolEquipIndex).gameObject.SetActive(true);
	}
}
