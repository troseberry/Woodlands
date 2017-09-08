using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourcesMenu : MonoBehaviour 
{
	private bool menuActive = false;

	private Text currencyValue, buildingMaterialsValue, toolPartsValue, bookPagesValue, treesValue, logsValue, firewoodValue;
	public GameObject currencyGroup, buildingMaterialsGroup, toolPartsGroup, bookPagesGroup, treesGroup, logsGroup, firewoodGroup;


	void Start () 
	{
		currencyValue = currencyGroup.transform.GetChild(1).GetComponent<Text>();
		buildingMaterialsValue = buildingMaterialsGroup.transform.GetChild(1).GetComponent<Text>();
		toolPartsValue = toolPartsGroup.transform.GetChild(1).GetComponent<Text>();
		bookPagesValue = bookPagesGroup.transform.GetChild(1).GetComponent<Text>();

		treesValue = treesGroup.transform.GetChild(1).GetComponent<Text>();
		logsValue = logsGroup.transform.GetChild(1).GetComponent<Text>();
		firewoodValue = firewoodGroup.transform.GetChild(1).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (menuActive)
		{
			currencyValue.text = "" + PlayerInventory.GetCurrencyValue();
			buildingMaterialsValue.text = "" + PlayerInventory.GetBuildingMaterialsValue();
			toolPartsValue.text = "" + PlayerInventory.GetToolPartsValue();
			bookPagesValue.text = "" + PlayerInventory.GetBookPagesValue();

			treesValue.text = HomesteadStockpile.GetTreesCountAsString();
			logsValue.text = HomesteadStockpile.GetLogsCountAsString();
			firewoodValue.text = HomesteadStockpile.GetFirewoodCountAsString();
		}
	}


	public void OpenMenu()
	{
		menuActive = true;
		gameObject.SetActive(true);
	}

	public void CloseMenu()
	{
		menuActive = false;
		gameObject.SetActive(false);
	}
}
