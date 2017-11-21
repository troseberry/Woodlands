/*
Any time a change is made to save load that affects what is being saved, the gameSave.dat file need to be 
deleted so new variables will be loaded correctly. Otherwise the save data won't contain the information
and will through null ref exceptions when trying to retrieve it.
This was happening with hash tables. Unsure if it still occurs with serialized saveable data objects
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
	private static int currentSaveSlot;
	private static string[] saveSlotStrings = {"/gameSave_01.dat", "/gameSave_02.dat", "/gameSave_03.dat"};

	public static void Save()
	{
		Debug.Log("Save Slot: " + currentSaveSlot);
		BinaryFormatter data = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + saveSlotStrings[currentSaveSlot - 1]);

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

		saveData.efficiencySkill = PlayerSkills.GetEfficiencySkill();
		saveData.contractsSkill = PlayerSkills.GetContractsSkill();
		saveData.currencySkill = PlayerSkills.GetCurrencySkill();
		saveData.energySkill = PlayerSkills.GetEnergySkill();
		saveData.buildingMaterialsSkill = PlayerSkills.GetBuildingMaterialsSkill();
		saveData.toolPartsSkill = PlayerSkills.GetToolPartsSkill();
		saveData.bookPagesSkill = PlayerSkills.GetBookPagesSkill();
		saveData.lumberTreesSkill = PlayerSkills.GetLumberTreesSkill();
		saveData.lumberLogsSkill = PlayerSkills.GetLumberLogsSkill();
		saveData.lumberFirewoodSkill = PlayerSkills.GetLumberFirewoodSkill();

		saveData.bedRoom = PlayerRooms.GetBedRoom();
		saveData.kitchenRoom = PlayerRooms.GetKitchenRoom();
		saveData.officeRoom = PlayerRooms.GetOfficeRoom();
		saveData.studyRoom = PlayerRooms.GetStudyRoom();
		saveData.workshopRoom = PlayerRooms.GetWorkshopRoom();
		//-----------------------Done Setting Data---------------------------------------------
		data.Serialize(file, saveData);
		file.Close();
		Debug.Log("Saved here: " + Application.persistentDataPath);
	}

	public static void Load()
	{
		if (File.Exists(Application.persistentDataPath + saveSlotStrings[currentSaveSlot - 1]))
		{
			Debug.Log("Loading...");

			BinaryFormatter data = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + saveSlotStrings[currentSaveSlot - 1], FileMode.Open);
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

			PlayerSkills.SetEfficiencySkill(loadData.efficiencySkill);
			PlayerSkills.SetContractsSkill(loadData.contractsSkill);
			PlayerSkills.SetCurrencySkill(loadData.currencySkill);
			PlayerSkills.SetEnergySkill(loadData.energySkill);
			PlayerSkills.SetBuildingMaterialsSkill(loadData.buildingMaterialsSkill);
			PlayerSkills.SetToolPartsSkill(loadData.toolPartsSkill);
			PlayerSkills.SetBookPagesSkill(loadData.bookPagesSkill);
			PlayerSkills.SetLumberTreesSkill(loadData.lumberTreesSkill);
			PlayerSkills.SetLumberLogsSkill(loadData.lumberLogsSkill);
			PlayerSkills.SetLumberFirewoodSkill(loadData.lumberFirewoodSkill);

			PlayerRooms.SetBedRoom(loadData.bedRoom);
			PlayerRooms.SetKitchenRoom(loadData.kitchenRoom);
			PlayerRooms.SetOfficeRoom(loadData.officeRoom);
			PlayerRooms.SetStudyRoom(loadData.studyRoom);
			PlayerRooms.SetWorkshopRoom(loadData.workshopRoom);
			//-----------------------Done Loading----------------------------------
		}
		else {
			Save();
		}
	}

	public static void CreateNewSave()
	{
		Debug.Log("Creating New Save in Slot: " + currentSaveSlot);
		BinaryFormatter data = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + saveSlotStrings[currentSaveSlot - 1]);

		SaveableData saveData = new SaveableData();

		//-----------------------Setting Save Data---------------------------------------------
		saveData.activeContracts = new List<LumberContract>();

		saveData.ownedTools = new List<Tool>()
		{
			new Tool(ToolName.EMPTY_HANDS),
			new Tool(ToolName.FELLING_AXE),
			new Tool(ToolName.CROSSCUT_SAW),
			new Tool(ToolName.SPLITTING_AXE)
		};

		saveData.efficiencySkill = new EfficiencySkill();
		saveData.contractsSkill = new ActiveContractsSkill();
		saveData.currencySkill = new CurrencySkill();
		saveData.energySkill = new EnergySkill();
		saveData.buildingMaterialsSkill = new BuildingMaterialsSkill();
		saveData.toolPartsSkill = new ToolPartsSkill();
		saveData.bookPagesSkill = new BookPagesSkill();
		saveData.lumberTreesSkill = new LumberTreesSkill();
		saveData.lumberLogsSkill = new LumberLogsSkill();
		saveData.lumberFirewoodSkill = new LumberFirewoodSkill();

		saveData.bedRoom = new BedRoom();
		saveData.kitchenRoom = new KitchenRoom();
		saveData.officeRoom = new OfficeRoom();
		saveData.studyRoom = new StudyRoom();
		saveData.workshopRoom = new WorkshopRoom();

		saveData.currentEnergy = PlayerSkills.GetMaxEnergyValue();

		saveData.currentCurrency = 0;
		saveData.currentBuildingMaterials = 0;
		saveData.currentToolParts = 0;
		saveData.currentBookPages = 0;

		saveData.homesteadTreesCount = new int[5] {0, 0, 0, 0, 0};
		saveData.homesteadLogsCount = new int[5] {0, 0, 0, 0, 0};
		saveData.homesteadFirewoodCount = new int[5] {0, 0, 0, 0, 0};
		//-----------------------Done Setting Data---------------------------------------------
		data.Serialize(file, saveData);
		file.Close();
		Debug.Log("Finished Saving");
	}

	public static void Delete (int selectedSaveSlot)
	{
		File.Delete(Application.persistentDataPath + saveSlotStrings[selectedSaveSlot - 1]);
	}

	public static bool DoesSaveExist (int selectedSaveSlot)
	{
		return File.Exists(Application.persistentDataPath + saveSlotStrings[selectedSaveSlot - 1]);
	}

	public static int GetCurrentSaveSlot() { return currentSaveSlot; }

	public static void SetCurrentSaveSlot(int slot) { currentSaveSlot = slot; }
}