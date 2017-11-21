using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AvailableContracts : MonoBehaviour 
{
	int numberToDisplay;
	private static List<LumberContract> availableContracts;
	public GameObject[] canvasObjects;

	public KeyItemInteract newspaperKeyItem;

	void Start () 
	{
		// GenerateNewContracts();
		PopulateCanvasObjcets();
	}

	public static List<LumberContract> GetAvailableContracts() { return availableContracts; }

	public static void SetAvailableContracts(List<LumberContract> contracts) { availableContracts = contracts; }
	
	void GenerateNewContracts()
	{
		numberToDisplay = PlayerRooms.GetKitchenRoomValue();
		availableContracts = new List<LumberContract>();
		for (int i = 0 ; i < numberToDisplay; i++)
		{
			// int randType;
			// int randRating;
			// float randDuration;

			LumberContract toAdd = new LumberContract(
				new LumberResourceQuantity(1, QualityGrade.F, 0, QualityGrade.F, 0, QualityGrade.F), 
				new DevResourceQuantity(50, 0, 0, 0),
				3);
			availableContracts.Add(toAdd);
		}
	}

	void PopulateCanvasObjcets()
	{
		numberToDisplay = PlayerRooms.GetKitchenRoomValue();
		
		for (int i = 0; i < numberToDisplay; i++)
		{
			Transform contract = canvasObjects[i].transform;

			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetRequiredLumber().ToString();
			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetPayout().ToString();

			// only show deadline in player's active contracts menu
			// contract.GetChild(5).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetCompletionDeadline() + " Day(s)";
		}
	}

	void RemoveFromAvailableContracts(int index)
	{
		//ideally don't remove contract obj from available contracts list until a new batch is generated.
		//want to disable/hide the buttons and visually cross out the ui object
	}


	public void SaveToPlayerContracts()
	{
		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		int contractNumber = int.Parse(contractName.Substring(9));

		PlayerContracts.AddContract(availableContracts[contractNumber - 1]);

		//visually circle the object. disable/hide the ui buttons
	}

	public void DeclineContract()
	{
		// string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		// int contractNumber = int.Parse(contractName.Substring(9));

		// RemoveFromAvailableContracts(contractNumber);

		newspaperKeyItem.CloseMenu();
	}
}
