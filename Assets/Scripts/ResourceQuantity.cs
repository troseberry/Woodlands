using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceQuantity 
{
	int currency;
	int buildingMaterials;
	int toolParts;
	int bookPages;

	public ResourceQuantity(int cur, int mat, int parts, int pages)
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
		bool hasCurrency = PlayerInventory.GetCurrencyValue() >= currency;
		bool hasMaterials = PlayerInventory.GetBuildingMaterialsValue() >= buildingMaterials;
		bool hasParts = PlayerInventory.GetToolPartsValue() >= toolParts;
		bool hasPages = PlayerInventory.GetBookPagesValue() >= bookPages;

		return hasCurrency && hasMaterials && hasParts && hasPages;
	}

	public void AddToInventory()
	{
		PlayerInventory.UpdateCurrencyValue(currency);
		PlayerInventory.UpdateBuildingMaterialsValue(buildingMaterials);
		PlayerInventory.UpdateToolPartsValue(toolParts);
		PlayerInventory.UpdateBookPagesValue(bookPages);
	}

	public void SubtractFromInventory()
	{
		PlayerInventory.UpdateCurrencyValue(-currency);
		PlayerInventory.UpdateBuildingMaterialsValue(-buildingMaterials);
		PlayerInventory.UpdateToolPartsValue(-toolParts);
		PlayerInventory.UpdateBookPagesValue(-bookPages);
	}


	public override string ToString()
	{
		return "C: " + currency + " | BM: " + buildingMaterials + " | TP: " + toolParts + " | BP: " + bookPages;
	}
}
