﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevResourceQuantity 
{
	private int currency;
	private int buildingMaterials;
	private int toolParts;
	private int bookPages;

	public DevResourceQuantity(int cur, int mat, int parts, int pages)
	{
		currency = cur;
		buildingMaterials = mat;
		toolParts = parts;
		bookPages = pages;
	}

	public void SetCurrency(int newCur) { currency = newCur; }

	public int GetCurrency() { return currency; }

	public void SetMaterials(int newMat) { buildingMaterials = newMat; }

	public int GetMaterials() { return buildingMaterials; }

	public void SetToolParts(int newParts) { toolParts = newParts; }

	public int GetToolParts() { return toolParts; }

	public void SetBookPages(int newPages) { bookPages = newPages; }

	public int GetBookPages() { return bookPages; }

	//returns true if inventory quanitites are greater than or equal to the resource quantity
	public bool HasInInventory()
	{
		bool hasCurrency = PlayerResources.GetCurrentCurrencyValue() >= currency;
		bool hasMaterials = PlayerResources.GetCurrentBuildingMaterialsValue() >= buildingMaterials;
		bool hasParts = PlayerResources.GetCurrentToolPartsValue() >= toolParts;
		bool hasPages = PlayerResources.GetCurrentBookPagesValue() >= bookPages;

		return hasCurrency && hasMaterials && hasParts && hasPages;
	}

	public void AddToInventory()
	{
		PlayerResources.UpdateCurrentCurrencyValue(currency);
		PlayerResources.UpdateCurrentBuildingMaterialsValue(buildingMaterials);
		PlayerResources.UpdateCurrentToolPartsValue(toolParts);
		PlayerResources.UpdateCurrentBookPagesValue(bookPages);
	}

	public void SubtractFromInventory()
	{
		PlayerResources.UpdateCurrentCurrencyValue(-currency);
		PlayerResources.UpdateCurrentBuildingMaterialsValue(-buildingMaterials);
		PlayerResources.UpdateCurrentToolPartsValue(-toolParts);
		PlayerResources.UpdateCurrentBookPagesValue(-bookPages);
	}


	public override string ToString()
	{
		return "C: " + currency + " | BM: " + buildingMaterials + " | TP: " + toolParts + " | BP: " + bookPages;
	}
}
