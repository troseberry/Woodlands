using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHud : MonoBehaviour 
{
	private Canvas playerCanvas;

	private float energyValue = 0f;
	public Image energyRadial;
	public Text energyText;

	public Text currencyText, buildingMaterialsText, toolPartsText, bookPagesText;
	public Text treesText, logsText, firewoodText;


	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
	}
	
	void Update () 
	{
		energyValue = (float) EnergyManager.GetCurrentEnergyValue()/100f;
		energyRadial.fillAmount = energyValue;
		energyRadial.color = Color.Lerp(Color.red, Color.green, energyValue);
		energyText.text = (energyValue * 100).ToString();


		currencyText.text = PlayerInventory.GetCurrencyValue().ToString();
		buildingMaterialsText.text = PlayerInventory.GetBuildingMaterialsValue().ToString();
		toolPartsText.text = PlayerInventory.GetToolPartsValue().ToString();
		bookPagesText.text = PlayerInventory.GetBookPagesValue().ToString();

		treesText.text = HomesteadStockpile.GetTreesCountAsString();
		logsText.text = HomesteadStockpile.GetLogsCountAsString();
		firewoodText.text = HomesteadStockpile.GetFirewoodCountAsString();
	}
}
