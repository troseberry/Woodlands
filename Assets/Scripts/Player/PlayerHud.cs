using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;

public class PlayerHud : MonoBehaviour 
{
	public static PlayerHud PlayerHudReference;

	private FreeLookCam characterCameraController;

	private Canvas playerCanvas;

	private float currentEnergyValue = 0f;
	private float maxEnergyValue;
	public Image energyRadial;
	public Text energyText;

	public Transform toolIconGroup;
	public Transform toolWheelGroup;
	private bool toolWheelIsOpen = false;
	private bool toolsDisabledInside = false;

	
	void Start () 
	{
		PlayerHudReference = this;

		characterCameraController = GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>();

		playerCanvas = GetComponent<Canvas>();
		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();

		toolIconGroup.parent.transform.parent.gameObject.SetActive(true);
		ChangeToolIcon();
	}
	
	void Update () 
	{
		maxEnergyValue = PlayerSkills.GetMaxEnergyValue();
		currentEnergyValue = (float) PlayerEnergy.GetCurrentEnergyValue()/maxEnergyValue;
		energyRadial.fillAmount = currentEnergyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, currentEnergyValue);
		energyText.text = (currentEnergyValue * maxEnergyValue).ToString();

		if (!SceneManager.GetActiveScene().name.Equals("MainCabin"))
		{
			if ((Input.GetButton("ToolWheel") && !toolWheelIsOpen) || (Input.GetButtonUp("ToolWheel") && toolWheelIsOpen))
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

		float newTurnSpeed = toolWheelIsOpen ? 0f : 1.5f;
		characterCameraController.SetTurnSpeed(newTurnSpeed);
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
}
