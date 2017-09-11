using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour 
{
	public GameObject toolsGroup;
	public GameObject roomUpgradesGroup;
	public GameObject homeImprovementsGroup;
	public GameObject clothesGroup;

	private Text bedroomResources, kitchenResources, officeResources,studyResources, workshopResources;


	void Start()
	{
		bedroomResources = roomUpgradesGroup.transform.GetChild(0).GetChild(1).GetComponent<Text>();
		kitchenResources = roomUpgradesGroup.transform.GetChild(1).GetChild(1).GetComponent<Text>();
		officeResources = roomUpgradesGroup.transform.GetChild(2).GetChild(1).GetComponent<Text>();
		studyResources = roomUpgradesGroup.transform.GetChild(3).GetChild(1).GetComponent<Text>();
		workshopResources = roomUpgradesGroup.transform.GetChild(4).GetChild(1).GetComponent<Text>();

		SelectRoomUpgrades();
	}



	void TurnOffAll()
	{
		toolsGroup.SetActive(false);
		roomUpgradesGroup.SetActive(false);
		homeImprovementsGroup.SetActive(false);
		clothesGroup.SetActive(false);
	}

	public void SelectTools()
	{
		TurnOffAll();
		toolsGroup.SetActive(true);
	}

	public void SelectRoomUpgrades()
	{
		TurnOffAll();
		roomUpgradesGroup.SetActive(true);
		UpdateRoomResources();
	}

	public void SelectHomeImprovements()
	{
		TurnOffAll();
		homeImprovementsGroup.SetActive(true);
	}

	public void SelectClothes()
	{
		TurnOffAll();
		clothesGroup.SetActive(true);
	}

	
	void UpdateRoomResources()
	{
		bedroomResources.text = PlayerRooms.GetNextBedRoomUpgradeCostsAsString();
		kitchenResources.text = PlayerRooms.GetNextKitchenUpgradeCostsAsString();
		officeResources.text = PlayerRooms.GetNextOfficeUpgradeCostsAsString();
		studyResources.text = PlayerRooms.GetNextStudyUpgradeCostsAsString();
		workshopResources.text = PlayerRooms.GetNextWorkshopUpgradeCostsAsString();
	}
}
