using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvas : MonoBehaviour 
{
	public Transform roomUpgradesGroup;
	public GameObject homeImprovementsGroup;
	public GameObject clothesGroup;

	private static bool updateRooms = false;
	private static bool updateClothes = false;
	private static bool updateHomesteadImprovements = false;


	void Start()
	{
		UpdateRoomsInfo();
		SelectRoomUpgrades();
	}

	void Update()
	{
		if (updateRooms) UpdateRoomsInfo();
	}


	void TurnOffAll()
	{
		roomUpgradesGroup.gameObject.SetActive(false);
		homeImprovementsGroup.SetActive(false);
		clothesGroup.SetActive(false);
	}

	public void SelectRoomUpgrades()
	{
		TurnOffAll();
		roomUpgradesGroup.gameObject.SetActive(true);
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
}
