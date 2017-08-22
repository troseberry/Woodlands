using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AvailableContracts : MonoBehaviour 
{
	int numberToDisplay;
	List<LumberContract> availableContracts;
	public GameObject[] canvasObjects;

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
				new ResourceQuantity(50, 0, 0, 0), 3);

			availableContracts.Add(toAdd);
		}
	}


	void PopulateCanvasObjcets()
	{
		for (int i = 0; i < canvasObjects.Length; i++)
		{
			Transform contract = canvasObjects[i].transform;
			
			contract.GetChild(0).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetContractTypeAsString();
			contract.GetChild(1).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetDifficultyRating();
			contract.GetChild(2).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetEnergyRequirement();
			contract.GetChild(3).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetRequiredToolNameAsString();
			contract.GetChild(4).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetDuration();
			contract.GetChild(5).GetChild(0).GetComponent<Text>().text = availableContracts[i].GetPayout().ToString();
			contract.GetChild(6).GetChild(0).GetComponent<Text>().text = "" + availableContracts[i].GetCompletionDeadline();
		}
	}

	public void TransitionToContractScene()
	{
		//SceneManager.LoadScene("TreeFelling");
	}
}
