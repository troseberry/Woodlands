﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

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
	public HoverTool[] toolHovers;

	private int toolWheelEquipIndex = 0;
	private bool toolWheelIsOpen = false;
	private bool toolsDisabledInside = false;

	public GameObject interactPrompt;
	private Text interactText;

	public GameObject qualityGame;

	
	void Start () 
	{
		PlayerHudReference = this;

		playerCanvas = GetComponent<Canvas>();
		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();

		toolIconGroup.parent.transform.parent.gameObject.SetActive(true);
		ChangeToolIcon();

		interactText = interactPrompt.transform.GetChild(3).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (TimeManager.paused) return;

		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();

		if (!SceneManager.GetActiveScene().name.Equals("MainCabin"))
		{
			if (((Input.GetButton("ToolWheel") && !toolWheelIsOpen) || (Input.GetButtonUp("ToolWheel") && toolWheelIsOpen)) && !MenuManager.currentMenuManager.IsInMenu())
			{
				ToggleToolWheel();
			}
		}
		else
		{
			if (!toolsDisabledInside)
			{
				toolIconGroup.parent.transform.parent.gameObject.SetActive(false);
				toolsDisabledInside = true;
			}
		}

		DebugPanel.Log("Current Tool: ", "Player HUD", PlayerTools.GetCurrentlyEquippedToolIndex());
		DebugPanel.Log("Current Tool (manager)", "Player HUD", ToolManager.GetCurrentToolIndex());
	}

	public void ChangeToolIcon()
	{
		if (toolIconGroup != null)
		{
			for (int i = 0; i < toolIconGroup.childCount; i++)
			{
				toolIconGroup.GetChild(i).gameObject.SetActive(false);
			}
			toolIconGroup.GetChild(ToolManager.GetToolToEquipIndex()).gameObject.SetActive(true);
		}
	}

	void ToggleToolWheel()
	{
		toolWheelIsOpen = !toolWheelIsOpen;
		toolWheelGroup.gameObject.SetActive(toolWheelIsOpen);

		CharacterInputController.ToggleCameraTurn(!toolWheelIsOpen);

		if (toolWheelIsOpen)
		{
			toolWheelEquipIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
		}
		else
		{
			ToolWheelSwitchExecute();
		}
	}

	public void HideToolWheel(bool executeToolSwitch)
	{
		toolWheelIsOpen = false;
		toolWheelGroup.gameObject.SetActive(toolWheelIsOpen);

		CharacterInputController.ToggleCameraTurn(!toolWheelIsOpen);

		if (executeToolSwitch) ToolWheelSwitchExecute();
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

	public void CallForToolSwitch(int index)
	{
		CharacterInputController.HandleToolInput(index);
	}

	public void ToolWheelSwitchSetup(int index)
	{
		toolWheelEquipIndex = index;

		for (int i = 0; i < toolHovers.Length; i++)
		{
			toolHovers[i].DeselectTool();
		}
	}

	public void ToolWheelSwitchExecute()
	{
		CharacterInputController.HandleToolInput(toolWheelEquipIndex);
	} 


	public static void SetInteractText(string toDisplay)
	{
		PlayerHudReference.interactText.text = toDisplay;
	}

	public static void ToggleInteractPrompt(bool state)
	{
		PlayerHudReference.interactPrompt.SetActive(state);
	}

	public static void ToggleQualityGame(bool state)
	{
		if (!state && PlayerHudReference.qualityGame.activeSelf)
		{
			QualityMinigame.EndGame();
			PlayerHudReference.StartCoroutine(PlayerHudReference.HideQualityGame());
		}
		else PlayerHudReference.qualityGame.SetActive(state);
	}

	IEnumerator HideQualityGame()
	{
		yield return new WaitForSeconds(1f);	// same as the delay QualityMinigame.EndGame()
		PlayerHudReference.qualityGame.SetActive(false);
	}
}

