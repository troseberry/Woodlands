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
}
