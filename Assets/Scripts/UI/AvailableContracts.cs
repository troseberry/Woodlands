using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class AvailableContracts : MonoBehaviour 
{
	public static AvailableContracts AvailableContractsReference;

	private static List<LumberContract> availableContracts;

	private static float averageContractDifficulty;
	private static List<int> pastGeneratedContractDifficulties;

	private static int totalNumberToDisplay;
	private static int freeContractSpaces = 0;
	public Transform contractsContent;

	private static List<int> contractsToRemove = new List<int>();

	public Canvas kitchenMenu;
	private bool didPopulate = false;

	void Start () 
	{
		AvailableContractsReference = this;
	}

	void Reset()
	{
		contractsContent = transform.GetChild(0).GetChild(0).GetChild(0);
		kitchenMenu = transform.parent.GetComponent<Canvas>();
	}

	void Update() 
	{
		if (kitchenMenu.enabled && !didPopulate)
		{
			PopulateCanvasObjcets();
			didPopulate = true;
		}
		if (!kitchenMenu.enabled && didPopulate) didPopulate = false;
	}
	

	public static List<LumberContract> GetAvailableContracts() { return availableContracts; }

	public static void SetAvailableContracts(List<LumberContract> contracts) { availableContracts = contracts; }

	public static float GetAverageContractDifficulty() { return averageContractDifficulty; }

	public static void SetAverageContractDifficulty(float difficulty) { averageContractDifficulty = difficulty; }

	public static List<int> GetPastGeneratedContractDifficuties () { return pastGeneratedContractDifficulties; }

	public static void SetPastGeneratedContractDifficulties(List<int> difficulties) { pastGeneratedContractDifficulties = difficulties; }

	public static List<int> GetContractsToRemove() { return contractsToRemove; }

	public static void SetContractsToRemove(List<int> toRemove) { contractsToRemove = toRemove; }
	
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
		
		//This shows newest contracts last. consider starting at end of list and going backward to show newest first
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
		Debug.Log("To Remove Count: " + contractsToRemove.Count);
		if (contractsToRemove.Count > 0)
		{
			for (int i = contractsToRemove.Count - 1; i >= 0; i--)
			{
				Debug.Log("Remove #: " + i);
				availableContracts.RemoveAt(contractsToRemove[i]);
			}
			contractsToRemove.Clear();
		}
		
		totalNumberToDisplay = PlayerRooms.GetKitchenRoomValue();
		freeContractSpaces = totalNumberToDisplay - availableContracts.Count;

		for (int j = 0; j < freeContractSpaces; j++)
		{
			int difficulty = GenerateDifficulty();
			LumberContract toAdd = new LumberContract(difficulty);

			// Debug.Log("C" + j + ": " + toAdd.GetDifficulty().difficulty + ", " + toAdd.GetDifficulty().GetQualityGradeInt());

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
			PlayerContracts.AddContract(new LumberContract(toAdd.GetRequiredLumber(), toAdd.GetPayout(), toAdd.GetCompletionDeadline(), ContractStatus.ACTIVE, toAdd.GetDifficulty()));

			MarkContractForRemoval(contractNumber - 1, ContractStatus.ACTIVE);

			EventSystem.current.currentSelectedGameObject.transform.parent.GetChild(7).GetComponent<Button>().interactable = false;
			EventSystem.current.currentSelectedGameObject.GetComponent<Button>().interactable = false;

			//visually show contract has been accpeted (circle object)
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



	public static float CalculateStandardDeviation(List<int> values)
	{
		float newAverage = 0;

		for (int i = 0; i < values.Count; i++)
		{
			newAverage += Mathf.Pow((values[i] - averageContractDifficulty), 2);
		}
		newAverage = newAverage / values.Count;

		return Mathf.Sqrt(newAverage);
	}

	public static int GenerateDifficulty()
	{
		float stddev = CalculateStandardDeviation(pastGeneratedContractDifficulties);
		float randomPercentage = Random.value;
		int diff = 0;

		if (randomPercentage <= 0.68f)
		{
			diff = Mathf.RoundToInt(UnityEngine.Random.Range(averageContractDifficulty - stddev, (averageContractDifficulty + stddev) + 1));
		}
		else if ( randomPercentage < 0.96f)
		{
			diff = Mathf.RoundToInt(UnityEngine.Random.Range(averageContractDifficulty - (2 * stddev), (averageContractDifficulty + (2 * stddev)) + 1));
		}
		else
		{
			diff = Mathf.RoundToInt(UnityEngine.Random.Range(averageContractDifficulty - (3 * stddev), (averageContractDifficulty + (3 * stddev)) + 1));
		}

		return Mathf.Clamp(diff, 2, 53);
	}

	public static void AdjustContractDifficulty(int newDifficulty)
	{
		pastGeneratedContractDifficulties.Add(newDifficulty);
		
		if (pastGeneratedContractDifficulties.Count > 25) pastGeneratedContractDifficulties.RemoveAt(0);

		averageContractDifficulty =  (float) pastGeneratedContractDifficulties.Average();
		averageContractDifficulty = Mathf.Clamp(averageContractDifficulty, 2, 53);
	}
}
