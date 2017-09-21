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
	public InputField secondaryCommmandInputField;

	private string command = "";
	private int commandValue = 0;
	private int secondaryCommandValue = 0;
	

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
		if (secondaryCommmandInputField.text.Length != 0) secondaryCommandValue = int.Parse(secondaryCommmandInputField.text);

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


			case "Active Contracts Tier":
				PlayerSkills.SetContractsTier(commandValue);
				break;
			case "Currency Tier":
				PlayerSkills.SetCurrencyTier(commandValue);
				break;
			case "Efficiency Tier":
				PlayerSkills.SetEfficiencyTier(commandValue);
				break;
			case "Energy Tier":
				PlayerSkills.SetEnergyTier(commandValue);
				break;
			case "Building Materials Tier":
				PlayerSkills.SetBuildingMaterialsTier(commandValue);
				break;
			case "Tool Parts Tier":
				PlayerSkills.SetToolPartsTier(commandValue);
				break;
			case "Book Pages Tier":
				PlayerSkills.SetBookPagesTier(commandValue);
				break;


			case "Bedroom Tier":
				PlayerRooms.SetBedRoomTier(commandValue);
				break;
			case "Kitchen Tier":
				PlayerRooms.SetKitchenRoomTier(commandValue);
				break;
			case "Office Tier":
				PlayerRooms.SetOfficeRoomTier(commandValue);
				break;
			case "Study Tier":
				PlayerRooms.SetStudyRoomTier(commandValue);
				break;
			case "Workshop Tier":
				PlayerRooms.SetWorkshopRoomTier(commandValue);
				break;


			case "Lumber Trees Value":
				HomesteadStockpile.SetTreesCountAtIndex(secondaryCommandValue, commandValue);
				break;
			case "Lumber Logs Value":
				HomesteadStockpile.SetLogsCountAtIndex(secondaryCommandValue, commandValue);
				break;
			case "Lumber Firewood Value":
				HomesteadStockpile.SetFirewoodCountAtIndex(secondaryCommandValue, commandValue);
				break;


			case "Lumber Trees Tier":
				PlayerSkills.SetLumberTreesTier(commandValue);
				break;
			case "Lumber Logs Tier":
				PlayerSkills.SetLumberLogsTier(commandValue);
				break;
			case "Lumber Firewood Tier":
				PlayerSkills.SetLumberFirewoodTier(commandValue);
				break;
		}
	}
}
