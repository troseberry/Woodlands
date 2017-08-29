using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCanvas : MonoBehaviour 
{
	private Canvas playerCanvas;

	//HUD Elements
	public Text energyText, currencyText, buildingMaterialsText, toolPartsText, bookPagesText;
	public Text fellinAxeText, crosscutSawText, splittingAxeText;


	//Player Contracts
	public GameObject contractsElement;
	public GameObject[] contracts;


	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
	}
	
	void Update () 
	{
		energyText.text = PlayerInventory.GetEnergyValue().ToString();
		currencyText.text = PlayerInventory.GetCurrencyValue().ToString();
		buildingMaterialsText.text = PlayerInventory.GetBuildingMaterialsValue().ToString();
		toolPartsText.text = PlayerInventory.GetToolPartsValue().ToString();
		bookPagesText.text = PlayerInventory.GetBookPagesValue().ToString();

		fellinAxeText.text = PlayerTools.GetToolByName(ToolName.FELLING_AXE).GetLevelString(1);
		crosscutSawText.text = PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW).GetLevelString(1);
		splittingAxeText.text = PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).GetLevelString(1);

		
		if (Input.GetButtonDown("Menu Button"))
		{
			ToggleContractsMenu();
		}
	}


	public void ToggleContractsMenu()
	{
		contractsElement.SetActive(!contractsElement.activeSelf);
		if (contractsElement.activeSelf)
		{
			//probably don't need to populate every time this is opened?
			//or maybe do, to get updates from active contracts list
			PopulateContractsMenu();
		}
	}

	void PopulateContractsMenu()
	{
		List<LumberContract> lcList = PlayerContracts.GetActiveContractsList();

		for (int i = 0; i < lcList.Count; i++)
		{
			Transform contract = contracts[i].transform;

			contract.gameObject.SetActive(true);
			
			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + lcList[i].GetDifficultyRating();

			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = lcList[i].GetContractTypeAsString();
			
			contract.GetChild(2).GetChild(0).GetComponent<Text>().text = "" + lcList[i].GetEnergyRequirement();
			contract.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + lcList[i].GetDuration();

			contract.GetChild(4).GetChild(0).GetComponent<Text>().text = lcList[i].GetPayout().ToString();
		}
	}

	public void StartContract()
	{
		List<LumberContract> activeContracts = PlayerContracts.GetActiveContractsList();

		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		Debug.Log("Contract Name: " + contractName);
		int contractNumber = int.Parse(contractName.Substring(9));
		Debug.Log("Contract Number: " + contractNumber);
		ContractGameInfo.SetPayout(activeContracts[contractNumber - 1].GetPayout());

		switch(activeContracts[contractNumber - 1].GetContractType())
		{
			case ContractType.FELLING_TREES:
				SceneNavigation.ToTreeFelling();
				break;
			case ContractType.LOG_BUCKING:
				SceneNavigation.ToLogBucking();
				break;
			case ContractType.SPLITTING_LOGS:
				SceneNavigation.ToLogSplitting();
				break;
		}
	}

	public void AbandonContract()
	{
		ToggleContractsMenu();
	}
}
