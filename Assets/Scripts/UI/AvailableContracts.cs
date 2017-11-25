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
	public Transform contractsContent;

	public KeyItemInteract newspaperKeyItem;

	void Start () 
	{
		GenerateNewContracts();
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
			LumberResourceQuantity lumberRequired = new LumberResourceQuantity(true);
			LumberContract toAdd = new LumberContract(
				lumberRequired, 
				lumberRequired.GenerateDevResourcePayout(),
				3);
			availableContracts.Add(toAdd);
		}
	}

	void PopulateCanvasObjcets()
	{
		numberToDisplay = PlayerRooms.GetKitchenRoomValue();

		for (int i = 0; i < contractsContent.childCount; i++)
		{
			contractsContent.GetChild(i).gameObject.SetActive(i < numberToDisplay);
		}
		
		for (int j = 0; j < numberToDisplay; j++)
		{
			contractsContent.GetChild(j).GetChild(0).GetComponent<Text>().text = availableContracts[j].GetCompletionDeadline().ToString();
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: ?";
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = availableContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = availableContracts[j].GetPayout().ToString();
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
		EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(7).GetComponent<Button>().interactable = false;
		EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;
	}

	public void DeclineContract()
	{
		// string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		// int contractNumber = int.Parse(contractName.Substring(9));

		// RemoveFromAvailableContracts(contractNumber);
		EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(6).GetComponent<Button>().interactable = false;
		EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

		// newspaperKeyItem.CloseMenu();
	}
}
