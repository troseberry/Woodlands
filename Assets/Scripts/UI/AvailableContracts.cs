﻿using System.Collections;
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
	
	static void MarkContractForRemoval(int contractIndex, ContractStatus status) 
	{
		contractsToRemove.Add(contractIndex);
		switch (status)
		{
			case ContractStatus.ACTIVE:
				availableContracts[contractIndex].SetStatus(ContractStatus.ACTIVE);
				break;
			case ContractStatus.DECLINED:
				availableContracts[contractIndex].SetStatus(ContractStatus.DECLINED);
				break;
			case ContractStatus.EXPIRED:
				availableContracts[contractIndex].SetStatus(ContractStatus.EXPIRED);
				break;
		}
	}


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
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: " + availableContracts[j].GetRequiredLumber().GetTreeGrade();
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = availableContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = availableContracts[j].GetPayout().ToString();

			contractsContent.GetChild(j).GetChild(6).GetComponent<Button>().interactable = (availableContracts[j].GetStatus() == ContractStatus.AVAILABLE);
			contractsContent.GetChild(j).GetChild(7).GetComponent<Button>().interactable = (availableContracts[j].GetStatus() == ContractStatus.AVAILABLE);
		}
	}

	public static void GenerateNewContracts()
	{
		if (contractsToRemove.Count > 0)
		{
			for (int i = contractsToRemove.Count - 1; i >= 0; i--)
			{
				// Debug.Log("Index: " + i);
				availableContracts.RemoveAt(contractsToRemove[i]);
			}
			contractsToRemove.Clear();
		}
		
		totalNumberToDisplay = PlayerRooms.GetKitchenRoomValue();
		freeContractSpaces = totalNumberToDisplay - availableContracts.Count;

		for (int j = 0; j < freeContractSpaces; j++)
		{
			LumberResourceQuantity lumberRequired = new LumberResourceQuantity(2);
			LumberContract toAdd = new LumberContract(
				lumberRequired, 
				lumberRequired.GenerateDevResourcePayout(),
				3,
				ContractStatus.AVAILABLE);
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
			PlayerContracts.AddContract(new LumberContract(toAdd.GetRequiredLumber(), toAdd.GetPayout(), toAdd.GetCompletionDeadline(), ContractStatus.ACTIVE));

			MarkContractForRemoval(contractNumber - 1, ContractStatus.ACTIVE);

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

		MarkContractForRemoval(contractNumber - 1, ContractStatus.DECLINED);
		//visually cross out the ui object
	}

	public static void ProgressAllContractDeadlines()
	{
		if (availableContracts.Count > 0)
		{
			for (int i =0; i < availableContracts.Count; i++)
			{
				availableContracts[i].DecrementDeadline();
				if (availableContracts[i].IsExpired()) MarkContractForRemoval(i, ContractStatus.EXPIRED);
			}
		}
	}
}
