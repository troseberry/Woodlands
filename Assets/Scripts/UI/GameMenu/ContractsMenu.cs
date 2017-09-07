using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContractsMenu : MonoBehaviour 
{
	private bool menuActive = false;

	private List<LumberContract> activeContracts;
	public GameObject[] contracts;

	void Start () 
	{
		activeContracts = PlayerContracts.GetActiveContractsList();
	}

	public void OpenMenu()
	{
		menuActive = true;
		gameObject.SetActive(true);
		PopulateContractsMenu();
	}

	public void CloseMenu()
	{
		menuActive = false;
		gameObject.SetActive(false);
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
		int contractIndex = int.Parse(contractName.Substring(9)) - 1;
		LumberContract currentContract = activeContracts[contractIndex];

		if (currentContract.GetRequiredLumber().HasInStockpile())
		{
			currentContract.GetRequiredLumber().SubtractFromStockpile();
			currentContract.GetPayout().AddToInventory();
			contracts[contractIndex].SetActive(false);
		}	
	}

	public void AbandonContract()
	{
		// ToggleContractsMenu();
	}
}
