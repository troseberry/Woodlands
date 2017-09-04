using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AvailableContracts : MonoBehaviour 
{
	int numberToDisplay;
	List<LumberContract> availableContracts;
	public GameObject[] canvasObjects;

	public KeyItemInteract newspaperKeyItem;

	void Start () 
	{
		numberToDisplay = PlayerRooms.GetKitchenRoomValue();
		availableContracts = new List<LumberContract>();

		GenerateNewContracts();
		PopulateCanvasObjcets();

	}
	
	void GenerateNewContracts()
	{
		for (int i = 0 ; i < numberToDisplay; i++)
		{
			// int randType;
			// int randRating;
			// float randDuration;

			LumberContract toAdd = new LumberContract(
				ContractType.FELLING_TREES, 
				1, 
				25, 
				10f,
				new DevResourceQuantity(50, 0, 0, 0), 3);

			availableContracts.Add(toAdd);
		}
	}


	void PopulateCanvasObjcets()
	{
		for (int i = 0; i < canvasObjects.Length; i++)
		{
			Transform contract = canvasObjects[i].transform;

			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetDifficultyRating();

			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetContractTypeAsString();
			
			contract.GetChild(2).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetEnergyRequirement();

			// contract.GetChild(3).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetRequiredToolNameAsString();

			contract.GetChild(3).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetDuration();

			contract.GetChild(4).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetPayout().ToString();

			// only show deadline in player's active contracts menu
			// contract.GetChild(5).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetCompletionDeadline() + " Day(s)";
		}
	}

	void RemoveFromAvailableContracts(int index)
	{
		//ideally don't remove contract obj from available contracts list until a new batch is generated.
		//want to disable/hide the buttons and visually cross out the ui object
	}


	public void StartContract()
	{
		//get button number
		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		Debug.Log("Contract Name: " + contractName);
		int contractNumber = int.Parse(contractName.Substring(9));
		Debug.Log("Contract Number: " + contractNumber);
		ContractGameInfo.SetPayout(availableContracts[contractNumber - 1].GetPayout());

		SceneNavigation.ToTreeFelling();
	}

	public void SaveToPlayerContracts()
	{
		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		int contractNumber = int.Parse(contractName.Substring(9));

		PlayerContracts.AddContract(availableContracts[contractNumber - 1]);
	}

	public void DeclineContract()
	{
		// string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		// int contractNumber = int.Parse(contractName.Substring(9));

		// RemoveFromAvailableContracts(contractNumber);

		newspaperKeyItem.CloseMenu();
	}
}
