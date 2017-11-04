using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour 
{
	public GameObject menuObject;
	private bool menuOpen = false;
	private bool doMove = false;

	private float moveTime = 0f;
	Vector3 openPosition = new Vector3(-665, 0, 0);
	Vector3 closedPosition = new Vector3(-1365, 0, 0);

	public Transform contractsGroup;
	public Transform resourcesGroup;
	public Transform skillsGroup;
	public Transform roomsGroup;

	Text buildingMaterialsCount;
	Text toolPartsCount;
	Text bookPagesCount;
	Text felledTreesCount;
	Text logsCount;
	Text firewoodCount;

	public Transform contractsContent;

	void Start () 
	{
		buildingMaterialsCount = resourcesGroup.GetChild(0).GetChild(0).GetComponent<Text>();
		toolPartsCount = resourcesGroup.GetChild(1).GetChild(0).GetComponent<Text>();
		bookPagesCount = resourcesGroup.GetChild(2).GetChild(0).GetComponent<Text>();
		felledTreesCount = resourcesGroup.GetChild(3).GetChild(0).GetComponent<Text>();
		logsCount = resourcesGroup.GetChild(4).GetChild(0).GetComponent<Text>();
		firewoodCount = resourcesGroup.GetChild(5).GetChild(0).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Tab Menu"))
		{
			doMove = true;
		}

		if (doMove)
		{
			if (!menuOpen)
			{
				StartCoroutine(OpenMenu());
			}
			else
			{
				StartCoroutine(CloseMenu());
			}
		}
	}

	IEnumerator OpenMenu()
	{
		UpdateContracts();
		
		moveTime += Time.deltaTime/0.15f;
		menuObject.transform.localPosition = Vector3.Lerp(closedPosition, openPosition, moveTime);

		if(menuObject.transform.localPosition.x >= -665)
		{
			moveTime = 0f;
			menuOpen = true;
			doMove = false;
		}
		yield return null;
		
	}

	IEnumerator CloseMenu()
	{
		moveTime += Time.deltaTime/0.15f;
		menuObject.transform.localPosition = Vector3.Lerp(openPosition, closedPosition, moveTime);

		if(menuObject.transform.localPosition.x <= -1365)
		{
			moveTime = 0f;
			menuOpen = false;
			doMove = false;
		}
		yield return null;
	}

	void UpdateContracts()
	{
		List<LumberContract> activeContracts = PlayerContracts.GetActiveContractsList();
		int activeCount = activeContracts.Count;

		for (int i = activeCount; i < contractsContent.childCount; i++)
		{
			contractsContent.GetChild(i).gameObject.SetActive(false);
		}

		for (int j = 0; j < activeCount; j++)
		{
			contractsContent.GetChild(j).GetChild(0).GetComponent<Text>().text = activeContracts[j].GetCompletionDeadline().ToString();
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: ?";
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = activeContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = activeContracts[j].GetPayout().ToString();
		}
	}

	void UpdateResources()
	{
		buildingMaterialsCount.text = PlayerInventory.GetBuildingMaterialsValue().ToString();
		toolPartsCount.text = PlayerInventory.GetToolPartsValue().ToString();
		bookPagesCount.text = PlayerInventory.GetBookPagesValue().ToString();

		felledTreesCount.text = HomesteadStockpile.GetTreesCountAsString();
		logsCount.text = HomesteadStockpile.GetLogsCountAsString();
		firewoodCount.text = HomesteadStockpile.GetFirewoodCountAsString();
	}

	void CloseAllTabs()
	{
		contractsGroup.gameObject.SetActive(false);
		resourcesGroup.gameObject.SetActive(false);
		skillsGroup.gameObject.SetActive(false);
		roomsGroup.gameObject.SetActive(false);
	}

	public void OpenContractsTab()
	{
		CloseAllTabs();
		UpdateContracts();
		contractsGroup.gameObject.SetActive(true);
	}

	public void OpenResourcesTab()
	{
		CloseAllTabs();
		UpdateResources();
		resourcesGroup.gameObject.SetActive(true);
	}

	public void OpenSkillsTab()
	{
		CloseAllTabs();
		skillsGroup.gameObject.SetActive(true);
	}

	public void OpenRoomsTab()
	{
		CloseAllTabs();
		roomsGroup.gameObject.SetActive(true);
	}
}