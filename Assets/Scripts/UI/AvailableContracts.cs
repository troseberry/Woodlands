using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AvailableContracts : MonoBehaviour 
{
	public static AvailableContracts AvailableContractsReference;

	private static List<LumberContract> availableContracts;
	private static int totalNumberToDisplay;
	private static int freeContractSpaces = 0;

	public Transform contractsContent;
	private static List<int> contractsToRemove = new List<int>();

	public KeyItemInteract newspaperKeyItem;

	void Start () 
	{
		AvailableContractsReference = this;
		PopulateCanvasObjcets();
	}
	

	public static List<LumberContract> GetAvailableContracts() { return availableContracts; }

	public static void SetAvailableContracts(List<LumberContract> contracts) { availableContracts = contracts; }
	
	void MarkContractForRemoval(int contractIndex) { contractsToRemove.Add(contractIndex); }


	public void PopulateCanvasObjcets()
	{
		totalNumberToDisplay = PlayerRooms.GetKitchenRoomValue();

		for (int i = 0; i < contractsContent.childCount; i++)
		{
			contractsContent.GetChild(i).gameObject.SetActive(i < totalNumberToDisplay);
		}
		
		//This shows newwest contracts last. consider starting at end of list and going backward to show newest first
		for (int j = 0; j < totalNumberToDisplay; j++)
		{
			contractsContent.GetChild(j).GetChild(0).GetComponent<Text>().text = availableContracts[j].GetCompletionDeadline().ToString();
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: ?";
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = availableContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = availableContracts[j].GetPayout().ToString();

			contractsContent.GetChild(j).GetChild(6).GetComponent<Button>().interactable = true;
			contractsContent.GetChild(j).GetChild(7).GetComponent<Button>().interactable = true;
		}
	}

	public static void GenerateNewContracts()
	{
		for (int i = contractsToRemove.Count - 1; i >= 0; i--)
		{
			availableContracts.RemoveAt(contractsToRemove[i]);
		}
		contractsToRemove.Clear();
		
		totalNumberToDisplay = PlayerRooms.GetKitchenRoomValue();
		freeContractSpaces = totalNumberToDisplay - availableContracts.Count;

		for (int j = 0; j < freeContractSpaces; j++)
		{
			LumberResourceQuantity lumberRequired = new LumberResourceQuantity(true);
			LumberContract toAdd = new LumberContract(
				lumberRequired, 
				lumberRequired.GenerateDevResourcePayout(),
				3);
			availableContracts.Add(toAdd);
		}

		if (SceneManager.GetActiveScene().name.Equals("MainCabin")) AvailableContractsReference.PopulateCanvasObjcets();
	}

	public void SaveToPlayerContracts()
	{
		if (PlayerContracts.CanAdd())
		{
			string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
			int contractNumber = int.Parse(contractName.Substring(9));

			LumberContract toAdd = availableContracts[contractNumber - 1];
			PlayerContracts.AddContract(new LumberContract(toAdd.GetRequiredLumber(), toAdd.GetPayout(), toAdd.GetCompletionDeadline()));
			MarkContractForRemoval(contractNumber - 1);

			EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(7).GetComponent<Button>().interactable = false;
			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

			//visually show contract has been accpet (circle object)
		}
		else
		{
			//notify the player of full active contract inventory
		}
	}

	public void DeclineContract()
	{
		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;
		int contractNumber = int.Parse(contractName.Substring(9));

		EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(6).GetComponent<Button>().interactable = false;
		EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

		MarkContractForRemoval(contractNumber - 1);
		//want to disable/hide the buttons and visually cross out the ui object
	}

	public static void ProgressAllContractDeadlines()
	{
		for (int i =0; i < availableContracts.Count; i++)
		{
			availableContracts[i].DecrementDeadline();
		}
	}
}
