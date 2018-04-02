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
		CharacterInputController.ToggleCameraInput(false);
		isConsoleOpen = true;
	}

	void CloseConsole()
	{
		consoleCanvas.enabled = false;
		CharacterInputController.ToggleCameraInput(true);
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
				PlayerResources.SetCurrentCurrencyValue(commandValue);
				break;
			case "Energy Value":
				PlayerEnergy.SetCurrentEnergyValue(commandValue);
				break;	
			case "Building Materials Value":
				PlayerResources.SetCurrentBuildingMaterialsValue(commandValue);
				break;
			case "Tool Parts Value":
				PlayerResources.SetCurrentToolPartsValue(commandValue);
				break;
			case "Book Pages Value":
				PlayerResources.SetCurrentBookPagesValue(commandValue);
				break;


			case "Active Contracts Tier":
				PlayerSkills.SetCurrentContractsTier(commandValue);
				break;
			case "Currency Tier":
				PlayerSkills.SetCurrentCurrencyTier(commandValue);
				break;
			case "Efficiency Tier":
				PlayerSkills.SetCurrentEfficiencyTier(commandValue);
				break;
			case "Energy Tier":
				PlayerSkills.SetCurrentEnergyTier(commandValue);
				break;
			case "Building Materials Tier":
				PlayerSkills.SetCurrentBuildingMaterialsTier(commandValue);
				break;
			case "Tool Parts Tier":
				PlayerSkills.SetCurrentToolPartsTier(commandValue);
				break;
			case "Book Pages Tier":
				PlayerSkills.SetCurrentBookPagesTier(commandValue);
				break;


			case "Felling Axe Tier":
				PlayerTools.GetToolByName(ToolName.FELLING_AXE).SetCurrentTier(commandValue);
				break;
			case "Crosscut Saw Tier":
				PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW).SetCurrentTier(commandValue);
				break;
			case "Splitting Axe Tier":
				PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).SetCurrentTier(commandValue);
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
				PlayerSkills.SetCurrentLumberTreesTier(commandValue);
				break;
			case "Lumber Logs Tier":
				PlayerSkills.SetCurrentLumberLogsTier(commandValue);
				break;
			case "Lumber Firewood Tier":
				PlayerSkills.SetCurrentLumberFirewoodTier(commandValue);
				break;


			case "Skip To Time":
				TimeManager.SetCurrentTime((float) commandValue);
				break;

			case "Clear Active Contracts":
				PlayerContracts.SetActiveContractsList(new List<LumberContract>());
				break;
			case "Clear Available Contracts":
				AvailableContracts.SetAvailableContracts(new List<LumberContract>());
				break;
		}
	}
}
