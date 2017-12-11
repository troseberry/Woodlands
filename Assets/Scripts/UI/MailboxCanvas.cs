using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MailboxCanvas : MonoBehaviour 
{
	private List<LumberContract> activeContracts;
	public Transform contractsContent;

	private static List<int> contractsToRemove = new List<int>();
	
	private bool doUpdate = true;

	void Update () 
	{
		if (GetComponent<Canvas>().enabled && doUpdate)
		{
			activeContracts = PlayerContracts.GetActiveContractsList();
			ShowContracts();
			doUpdate = false;
		}
		else if (!GetComponent<Canvas>().enabled && !doUpdate)
		{
			doUpdate = true;

			for (int i = contractsToRemove.Count - 1; i >= 0; i--)
			{
				activeContracts.RemoveAt(contractsToRemove[i]);
			}
			contractsToRemove.Clear();
			PlayerContracts.SetActiveContractsList(activeContracts);
		}
	}

	public void OpenMenu()
	{
		GetComponent<Canvas>().enabled = true;
	}

	public void CloseMenu()
	{
		GetComponent<Canvas>().enabled = false;
	}

	void MarkContractForRemoval(int contractIndex) { contractsToRemove.Add(contractIndex); }

	public void ShowContracts()
	{
		
		// activeContracts.Sort(delegate(LumberContract one, LumberContract two)
		// {
		// 	if (one.CanBeCompleted() && two.CanBeCompleted()) return 0;
		// 	else if (one.CanBeCompleted()) return -1;
		// 	else if (two.CanBeCompleted()) return 1;
		// 	else return one.CompareByCompletion(two);
		// });
		
		for (int i = 0; i < contractsContent.childCount; i++)
		{
			contractsContent.GetChild(i).gameObject.SetActive(i < activeContracts.Count);
		}

		for (int j = 0; j < activeContracts.Count; j++)
		{
			contractsContent.GetChild(j).GetChild(0).GetComponent<Text>().text = activeContracts[j].GetCompletionDeadline().ToString();
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: " + activeContracts[j].GetRequiredLumber().GetTreeGrade();
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = activeContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = activeContracts[j].GetPayout().ToString();

			contractsContent.GetChild(j).GetChild(6).GetComponent<Button>().interactable = activeContracts[j].CanBeCompleted();
			contractsContent.GetChild(j).GetChild(6).GetChild(0).GetComponent<Text>().text = "Turn In";
		}
	}

	void UpdateCompletionStatus()
	{
		for (int i = 0; i < activeContracts.Count; i++)
		{
			contractsContent.GetChild(i).GetChild(6).GetComponent<Button>().interactable = activeContracts[i].CanBeCompleted();
		}
	}

	public void TurnInContract()
	{
		string contractName = EventSystem.current.currentSelectedGameObject.transform.parent.name;

		int contractNumber = int.Parse(contractName.Substring(9));

		activeContracts[contractNumber - 1].GetRequiredLumber().SubtractFromStockpile();
		activeContracts[contractNumber - 1].GetPayout().AddToInventory();

		contractsContent.GetChild(contractNumber - 1).GetChild(6).GetComponent<Button>().interactable = false;
		contractsContent.GetChild(contractNumber - 1).GetChild(6).GetChild(0).GetComponent<Text>().text = "Completed";

		//do more visually to the contract object to show it has been turned in
		MarkContractForRemoval(contractNumber - 1);

		UpdateCompletionStatus();
	}
}