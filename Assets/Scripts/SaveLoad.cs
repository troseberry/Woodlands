/*
Any time a change is made to save load that affects what is being saved, the gameSave.dat file need to be 
deleted so new variables will be loaded correctly. Otherwise the save data won't contain the information
and will through null ref exceptions when trying to retrieve it.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//don't think this needs to inherit from monobehaviour?
public class SaveLoad : MonoBehaviour 
{

	public static void Save()
	{
		BinaryFormatter data = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/gameSave.dat");

		SaveableData saveData = new SaveableData();

		//-----------------------Setting Save Data---------------------------------------------
		saveData.activeContracts = PlayerContracts.GetActiveContractsList();

		saveData.currentEnergy = PlayerEnergy.GetCurrentEnergyValue();

		saveData.currentCurrency = PlayerResources.GetCurrentCurrencyValue();
		saveData.currentBuildingMaterials = PlayerResources.GetCurrentBuildingMaterialsValue();
		saveData.currentToolParts = PlayerResources.GetCurrentToolPartsValue();
		saveData.currentBookPages = PlayerResources.GetCurrentBookPagesValue();

		saveData.homesteadTreesCount = HomesteadStockpile.GetAllTreesCount();
		saveData.homesteadLogsCount = HomesteadStockpile.GetAllLogsCount();
		saveData.homesteadFirewoodCount = HomesteadStockpile.GetAllFirewoodCount();

		saveData.ownedTools = PlayerTools.GetOwnedToolsList();
		//-----------------------Done Setting Data---------------------------------------------
		data.Serialize(file, saveData);
		file.Close();
		Debug.Log("Saved here: " + Application.persistentDataPath);
	}

	public static void Load()
	{
		if (File.Exists(Application.persistentDataPath + "/gameSave.dat"))
		{
			Debug.Log("Loading...");

			BinaryFormatter data = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/gameSave.dat", FileMode.Open);
			SaveableData loadData = (SaveableData) data.Deserialize(file);
			file.Close();

			//-----------------------Loading Data---------------------------------
			PlayerContracts.SetActiveContractsList(loadData.activeContracts);

			PlayerEnergy.SetCurrentEnergyValue(loadData.currentEnergy);

			PlayerResources.SetCurrentCurrencyValue(loadData.currentCurrency);
			PlayerResources.SetCurrentBuildingMaterialsValue(loadData.currentBuildingMaterials);
			PlayerResources.SetCurrentToolPartsValue(loadData.currentToolParts);
			PlayerResources.SetCurrentBookPagesValue(loadData.currentBookPages);

			HomesteadStockpile.SetAllTreesCount(loadData.homesteadTreesCount);
			HomesteadStockpile.SetAllLogsCount(loadData.homesteadLogsCount);
			HomesteadStockpile.SetAllFirewoodCount(loadData.homesteadFirewoodCount);

			PlayerTools.SetOwnedToolsList(loadData.ownedTools);
			//-----------------------Done Loading----------------------------------
		}
		else {
			Save();
		}
	}
}