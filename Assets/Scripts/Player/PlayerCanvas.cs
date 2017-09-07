//Change this to PlayerHud
//Change unity _PlayerCanvas to just be PlayerHud

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerCanvas : MonoBehaviour 
{
	private Canvas playerCanvas;

	//HUD Elements
	public Text currencyText, buildingMaterialsText, toolPartsText, bookPagesText;


	//Player Contracts
	private List<LumberContract> activeContracts;
	public GameObject contractsElement;
	public GameObject[] contracts;


	void Start () 
	{
		playerCanvas = GetComponent<Canvas>();
		activeContracts = PlayerContracts.GetActiveContractsList();
	}
	
	void Update () 
	{
		currencyText.text = PlayerInventory.GetCurrencyValue().ToString();
		buildingMaterialsText.text = PlayerInventory.GetBuildingMaterialsValue().ToString();
		toolPartsText.text = PlayerInventory.GetToolPartsValue().ToString();
		bookPagesText.text = PlayerInventory.GetBookPagesValue().ToString();
	}
}
