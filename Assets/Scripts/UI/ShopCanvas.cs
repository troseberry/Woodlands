using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour 
{
	public Transform roomUpgradesGroup;
	public GameObject additionsGroup;
	public GameObject clothesGroup;

	private static bool updateRooms = false;
	private static bool updateClothes = false;
	private static bool updateHomesteadAdditions = false;

	private Text currentDevResources;

	void Start()
	{
		currentDevResources = transform.Find("CurrentDevResources").GetComponent<Text>();
		UpdateRoomsInfo();
		SelectRoomUpgrades();
	}

	void Update()
	{
		if (updateRooms) UpdateRoomsInfo();
		if (updateHomesteadAdditions) UpdateAdditionsInfo();

		if (GetComponent<Canvas>().enabled) UpdatePlayerResources();
	}

	void UpdatePlayerResources()
	{
		currentDevResources.text = PlayerResources.GetPlayerResourcesAsString();
	}

	void TurnOffAll()
	{
		roomUpgradesGroup.gameObject.SetActive(false);
		additionsGroup.SetActive(false);
		clothesGroup.SetActive(false);
	}

	public void SelectRoomUpgrades()
	{
		TurnOffAll();
		roomUpgradesGroup.gameObject.SetActive(true);
	}

	public void SelectHomesteadAdditions()
	{
		TurnOffAll();
		additionsGroup.SetActive(true);
		UpdateAdditionsInfo();
	}

	public void SelectClothes()
	{
		TurnOffAll();
		clothesGroup.SetActive(true);
	}

	
	public static void TriggerRoomsInfoUpdate() { updateRooms = true; }
	
	void UpdateRoomsInfo()
	{
		roomUpgradesGroup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerRooms.GetBedRoomTier().ToString();
		roomUpgradesGroup.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = PlayerRooms.GetNextBedRoomUpgradeCostsAsString();

		roomUpgradesGroup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerRooms.GetKitchenRoomTier().ToString();
		roomUpgradesGroup.transform.GetChild(1).GetChild(1).GetComponent<Text>().text = PlayerRooms.GetNextKitchenUpgradeCostsAsString();

		roomUpgradesGroup.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerRooms.GetOfficeRoomTier().ToString();
		roomUpgradesGroup.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = PlayerRooms.GetNextOfficeUpgradeCostsAsString();

		roomUpgradesGroup.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerRooms.GetStudyRoomTier().ToString();
		roomUpgradesGroup.transform.GetChild(3).GetChild(1).GetComponent<Text>().text = PlayerRooms.GetNextStudyUpgradeCostsAsString();

		roomUpgradesGroup.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerRooms.GetWorkshopRoomTier().ToString();
		roomUpgradesGroup.transform.GetChild(4).GetChild(1).GetComponent<Text>().text = PlayerRooms.GetNextWorkshopUpgradeCostsAsString();

		updateRooms = false;
	}

	void UpdateAdditionsInfo()
	{
		// should disable these or throw an overlay over them if they've already been unlocked
		
		additionsGroup.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerAdditions.GetCoffeeMakerAddition().GetPurchaseCosts().ToString();
		additionsGroup.transform.GetChild(0).GetChild(4).gameObject.SetActive(PlayerAdditions.GetCoffeeMakerAddition().GetIsUnlocked());

		additionsGroup.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerAdditions.GetFireplaceAddition().GetPurchaseCosts().ToString();
		additionsGroup.transform.GetChild(1).GetChild(4).gameObject.SetActive(PlayerAdditions.GetFireplaceAddition().GetIsUnlocked());

		additionsGroup.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerAdditions.GetFrontPorchAddition().GetPurchaseCosts().ToString();
		additionsGroup.transform.GetChild(2).GetChild(4).gameObject.SetActive(PlayerAdditions.GetFrontPorchAddition().GetIsUnlocked());

		additionsGroup.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerAdditions.GetWoodworkingBenchAddition().GetPurchaseCosts().ToString();
		additionsGroup.transform.GetChild(3).GetChild(4).gameObject.SetActive(PlayerAdditions.GetWoodworkingBenchAddition().GetIsUnlocked());

		updateHomesteadAdditions = false;
	}

	public static void TriggerAdditionsInfoUpdate()
	{
		updateHomesteadAdditions = true;
	}
}
