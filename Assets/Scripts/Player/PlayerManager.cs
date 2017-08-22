using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour 
{
	void Start () 
	{
		//eventually, load save data

		PlayerTools.AddTool(new Tool(ToolName.FELLING_AXE, 2));
		PlayerTools.AddTool(new Tool(ToolName.CROSSCUT_SAW));
		PlayerTools.AddTool(new Tool(ToolName.SPLITTING_AXE));

		PlayerContracts.AddContract(new LumberContract(ContractType.FELLING_TREES, 1, 10, 180f, new ResourceQuantity(100, 0, 0, 0), 3));
		PlayerContracts.AddContract(new LumberContract(ContractType.LOG_BUCKING, 1, 10, 180f, new ResourceQuantity(100, 0, 0, 0), 3));
		PlayerContracts.AddContract(new LumberContract(ContractType.SPLITTING_LOGS, 1, 10, 180f, new ResourceQuantity(100, 0, 0, 0), 3));

	}
	
	void Update () 
	{
		DebugPanel.Log("Energy: ", PlayerInventory.GetEnergyValue());
		DebugPanel.Log("Currency: ", PlayerInventory.GetCurrencyValue());
		DebugPanel.Log("Building Materials: ", PlayerInventory.GetBuildingMaterialsValue());
		DebugPanel.Log("Tool Parts: ", PlayerInventory.GetToolPartsValue());
		DebugPanel.Log("Book Pages: ", PlayerInventory.GetBookPagesValue());
		DebugPanel.Log("Efficiency: ", PlayerSkills.GetMaxEfficiencyValue());


		

		DebugPanel.Log("Contracts Tier: ", PlayerSkills.GetContractsTier());
		// DebugPanel.Log("Contracts Max: ", PlayerSkills.GetMaxContractsValue());

		DebugPanel.Log("Currency Tier: ", PlayerSkills.GetCurrencyTier());
		// DebugPanel.Log("Currency Max: ", PlayerSkills.GetMaxCurrencyValue());

		DebugPanel.Log("Efficiency Tier: ", PlayerSkills.GetEfficiencyTier());
		// DebugPanel.Log("Efficiency Max: ", PlayerSkills.GetMaxEfficiencyValue());

		DebugPanel.Log("Energy Tier: ", PlayerSkills.GetEnergyTier());
		// DebugPanel.Log("Energy Max: ", PlayerSkills.GetMaxEnergyValue());

		DebugPanel.Log("Resources Tier: ", PlayerSkills.GetResourcesTier());
		// DebugPanel.Log("Resources Max: ", PlayerSkills.GetMaxResourcesValue());


		DebugPanel.Log("Tools 1: ", PlayerTools.GetOwnedToolsList()[0]);
		DebugPanel.Log("Tools 2: ", PlayerTools.GetOwnedToolsList()[1]);
		DebugPanel.Log("Tools 3: ", PlayerTools.GetOwnedToolsList()[2]);

		DebugPanel.Log("BedRoom Tier: ", PlayerRooms.GetBedRoomTier());
		DebugPanel.Log("Kitchen Tier: ", PlayerRooms.GetKitchenRoomTier());
		DebugPanel.Log("Office Tier: ", PlayerRooms.GetOfficeRoomTier());
		DebugPanel.Log("Study Tier: ", PlayerRooms.GetStudyRoomTier());
		DebugPanel.Log("Workshop Tier: ", PlayerRooms.GetWorkshopRoomTier());


		// DebugPanel.Log("Contracts List: ", PlayerContracts.GetContractAtIndex(0));
	}
}
