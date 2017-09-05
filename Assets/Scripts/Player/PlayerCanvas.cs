using System.Collections;
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
	List<LumberContract> activeContracts;

	public GameObject contractsElement;
	public GameObject[] contracts;


	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
		activeContracts = PlayerContracts.GetActiveContractsList();
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
		activeContracts = PlayerContracts.GetActiveContractsList();

		for (int i = 0; i < activeContracts.Count; i++)
		{
			Transform contract = contracts[i].transform;

			contract.gameObject.SetActive(true);

			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = activeContracts[i].GetRequiredLumber().ToString();
			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = activeContracts[i].GetPayout().ToString();
			
		}
	}

	public void CompleteContract()
	{
		activeContracts = PlayerContracts.GetActiveContractsList();

		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		Debug.Log("Contract Name: " + contractName);
		int contractIndex = int.Parse(contractName.Substring(9)) - 1;
		Debug.Log("Contract Index: " + contractIndex);
		LumberContract currentContract = activeContracts[contractIndex];

		if (currentContract.GetRequiredLumber().HasInStockpile())
		{
			Debug.Log("Has In Stockpile: True");
			currentContract.GetRequiredLumber().SubtractFromStockpile();
			currentContract.GetPayout().AddToInventory();
			contracts[contractIndex].SetActive(false);
		}	
	}

	public void AbandonContract()
	{
		ToggleContractsMenu();
	}
}
