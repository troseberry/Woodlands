using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHud : MonoBehaviour 
{
	public static PlayerHud PlayerHudReference;

	private Canvas playerCanvas;

	private float currentEnergyValue = 0f;
	private float maxEnergyValue;
	public Image energyRadial;
	public Text energyText;

	public Transform toolIconGroup;
	public Transform toolWheelGroup;

	
	void Start () 
	{
		PlayerHudReference = this;

		playerCanvas = GetComponent<Canvas>();
		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();
		ChangeToolIcon();
	}
	
	void Update () 
	{
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();

		if (Input.GetButtonDown("ToolWheel")) ToggleToolWheel();
	}

	public void ChangeToolIcon()
	{
		for (int i = 0; i < toolIconGroup.childCount; i++)
		{
			toolIconGroup.GetChild(i).gameObject.SetActive(false);
		}
		toolIconGroup.GetChild(ToolManager.GetToolToEquipIndex()).gameObject.SetActive(true);
	}

	void ToggleToolWheel()
	{
		toolWheelGroup.gameObject.SetActive(!toolWheelGroup.gameObject.activeSelf);
	}

	public void CallForToolSwitch()
	{
		string buttonName = EventSystem.current.currentSelectedGameObject.name;
		int toolToEquipIndex = 0;
		switch(buttonName)
		{
			case "Tool_02":
				toolToEquipIndex = 1;
				break;
			case "Tool_03":
				toolToEquipIndex = 2;
				break;
			case "Tool_04":
				toolToEquipIndex = 3;
				break;
		}
		CharacterInputController.HandleToolInput(toolToEquipIndex);
	}
}
