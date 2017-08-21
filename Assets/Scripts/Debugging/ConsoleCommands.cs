using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class ConsoleCommands : MonoBehaviour 
{
	private FreeLookCam cameraControl;

	public Canvas consoleCanvas;
	private bool isConsoleOpen = false;

	public  Dropdown commandDropdown;
	public InputField commandInputField;

	private string command = "";
	private int commandValue = 0;
	

	void Start()
	{
		cameraControl = GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>();
	}

	
	void Update () 
	{
		if (Input.GetButtonDown("Console"))
		{
			if (!isConsoleOpen)
			{
				OpenConsole();
			}
			else
			{
				CloseConsole();
			}
		}
	}

	void OpenConsole()
	{
		consoleCanvas.enabled = true;
		cameraControl.enabled = false;
		isConsoleOpen = true;
	}

	void CloseConsole()
	{
		consoleCanvas.enabled = false;
		cameraControl.enabled = true;
		isConsoleOpen = false;
	}

	public void ExecuteCommand()
	{
		command = commandDropdown.options[commandDropdown.value].text;
		commandValue = int.Parse(commandInputField.text);

		Debug.Log("Command: " + command);
		Debug.Log("Value: " + commandValue);

		switch(command)
		{
			case "Currency Value":
				PlayerInventory.SetCurrencyValue(commandValue);
				break;
			case "Energy Value":
				PlayerInventory.SetEnergyValue(commandValue);
				break;	
			case "Building Materials Value":
				PlayerInventory.SetBuildingMaterialsValue(commandValue);
				break;
			case "Tool Parts Value":
				PlayerInventory.SetToolPartsValue(commandValue);
				break;
			case "Book Pages Value":
				PlayerInventory.SetBookPagesValue(commandValue);
				break;


			case "Max Contracts Tier":
				PlayerSkills.SetContractsTier(commandValue);
				break;
			case "Max Currency Tier":
				PlayerSkills.SetCurrencyTier(commandValue);
				break;
			case "Efficiency Tier":
				PlayerSkills.SetEfficiencyTier(commandValue);
				break;
			case "Max Energy Tier":
				PlayerSkills.SetEnergyTier(commandValue);
				break;
			case "Max Resources Tier":
				PlayerSkills.SetResourcesTier(commandValue);
				break;
		}
	}
}
