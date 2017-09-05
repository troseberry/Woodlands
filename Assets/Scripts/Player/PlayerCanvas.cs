﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCanvas : MonoBehaviour 
{
	private Canvas playerCanvas;

	//HUD Elements
	public Text currencyText, buildingMaterialsText, toolPartsText, bookPagesText;


	//Player Contracts
	public GameObject contractsElement;
	public GameObject[] contracts;


	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
	}
	
	void Update () 
	{
		currencyText.text = PlayerInventory.GetCurrencyValue().ToString();
		buildingMaterialsText.text = PlayerInventory.GetBuildingMaterialsValue().ToString();
		toolPartsText.text = PlayerInventory.GetToolPartsValue().ToString();
		bookPagesText.text = PlayerInventory.GetBookPagesValue().ToString();

		
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

			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = lcList[i].GetRequiredLumber().ToString();
			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = lcList[i].GetPayout().ToString();
			
		}
	}

	public void CompleteContract()
	{

	}
	//make this CompleteContract - enabled if the player has the right lumber resources. on click it removes them from the stockpile and gives payout
	public void StartContract()
	{
		List<LumberContract> activeContracts = PlayerContracts.GetActiveContractsList();

		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		Debug.Log("Contract Name: " + contractName);
		int contractNumber = int.Parse(contractName.Substring(9));
		Debug.Log("Contract Number: " + contractNumber);
		ContractGameInfo.SetPayout(activeContracts[contractNumber - 1].GetPayout());

		//don't need this anymore
		SceneNavigation.ToTreeFelling();
	}

	public void AbandonContract()
	{
		ToggleContractsMenu();
	}
}
