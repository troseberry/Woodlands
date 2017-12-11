using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class GameMenu : MonoBehaviour 
{
	private CharacterInputController characterInputController;
	private FreeLookCam characterCameraController;

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
	public Transform toolsGroup;

	Text currencyCount;
	Text buildingMaterialsCount;
	Text toolPartsCount;
	Text bookPagesCount;
	Text felledTreesCount;
	Text logsCount;
	Text firewoodCount;

	public Transform contractsContent;

	void Start () 
	{
		characterInputController = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInputController>();
		characterCameraController = GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>();

		currencyCount = resourcesGroup.GetChild(0).GetChild(0).GetComponent<Text>();
		buildingMaterialsCount = resourcesGroup.GetChild(1).GetChild(0).GetComponent<Text>();
		toolPartsCount = resourcesGroup.GetChild(2).GetChild(0).GetComponent<Text>();
		bookPagesCount = resourcesGroup.GetChild(3).GetChild(0).GetComponent<Text>();
		felledTreesCount = resourcesGroup.GetChild(4).GetChild(0).GetComponent<Text>();
		logsCount = resourcesGroup.GetChild(5).GetChild(0).GetComponent<Text>();
		firewoodCount = resourcesGroup.GetChild(6).GetChild(0).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Game Menu"))
		{
			doMove = true;
		}

		if (doMove)
		{
			if (!menuOpen)
			{
				MenuManager.currentMenuManager.CloseKeyItemCanvases();

				StartCoroutine(OpenMenu());
			}
			else
			{
				StartCoroutine(CloseMenu());
			}
		}

		if (menuOpen)
		{
			//probably also update contracts as well
			UpdateResources();
		}
	}

	public bool IsMenuOpen() { return menuOpen; }

	IEnumerator OpenMenu()
	{
		characterInputController.enabled = false;
		characterCameraController.enabled = false;

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
		characterInputController.enabled = true;
		characterCameraController.enabled = true;

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

	public void ImmediatelyCloseMenu()
	{
		characterInputController.enabled = true;
		characterCameraController.enabled = true;

		menuObject.transform.localPosition = closedPosition;

		moveTime = 0f;
		menuOpen = false;
		doMove = false;

	}

	void UpdateContracts()
	{
		List<LumberContract> activeContracts = PlayerContracts.GetActiveContractsList();
		int activeCount = activeContracts.Count;
		
		for (int i = 0; i < contractsContent.childCount; i++)
		{
			contractsContent.GetChild(i).gameObject.SetActive(i < activeCount);
		}

		for (int j = 0; j < activeCount; j++)
		{
			contractsContent.GetChild(j).GetChild(0).GetComponent<Text>().text = activeContracts[j].GetCompletionDeadline().ToString();
			contractsContent.GetChild(j).GetChild(1).GetComponent<Text>().text = "Quality Grade: " + activeContracts[j].GetRequiredLumber().GetTreeGrade();
			contractsContent.GetChild(j).GetChild(2).GetComponent<Text>().text = activeContracts[j].GetRequiredLumber().StringWithoutQuality();
			contractsContent.GetChild(j).GetChild(3).GetComponent<Text>().text = activeContracts[j].GetPayout().ToString();
		}
	}

	void UpdateResources()
	{
		currencyCount.text = PlayerResources.GetCurrentCurrencyValue().ToString();
		buildingMaterialsCount.text = PlayerResources.GetCurrentBuildingMaterialsValue().ToString();
		toolPartsCount.text = PlayerResources.GetCurrentToolPartsValue().ToString();
		bookPagesCount.text = PlayerResources.GetCurrentBookPagesValue().ToString();

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
		toolsGroup.gameObject.SetActive(false);
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

	public void OpenToolsTab()
	{
		CloseAllTabs();
		toolsGroup.gameObject.SetActive(true);
	}
}