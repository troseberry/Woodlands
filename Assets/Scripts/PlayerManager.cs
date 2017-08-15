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

		PlayerContracts.AddContract(new LumberContract(ContractType.FELLING_TREES, 1, 10, 180f, 100, 3));
		PlayerContracts.AddContract(new LumberContract(ContractType.LOG_BUCKING, 1, 10, 180f, 100, 3));
		PlayerContracts.AddContract(new LumberContract(ContractType.SPLITTING_LOGS, 1, 10, 180f, 100, 3));

	}
	
	void Update () 
	{
		// DebugPanel.Log("Energy: ", PlayerInventory.GetEnergyValue());
		// DebugPanel.Log("Currency: ", PlayerInventory.GetCurrencyValue());
		// DebugPanel.Log("Lumber: ", PlayerInventory.GetLumberValue());
		// DebugPanel.Log("Hardware: ", PlayerInventory.GetHardwareValue());


		// DebugPanel.Log("Efficiency Tier: ", PlayerSkills.GetEfficiencyTier());
		// DebugPanel.Log("Efficiency Max: ", PlayerSkills.GetMaxEfficiencyValue());

		// DebugPanel.Log("Contracts Tier: ", PlayerSkills.GetContractsTier());
		// DebugPanel.Log("Contracts Max: ", PlayerSkills.GetMaxContractsValue());

		// DebugPanel.Log("Currency Tier: ", PlayerSkills.GetCurrencyTier());
		// DebugPanel.Log("Currency Max: ", PlayerSkills.GetMaxCurrencyValue());

		// DebugPanel.Log("Energy Tier: ", PlayerSkills.GetEnergyTier());
		// DebugPanel.Log("Energy Max: ", PlayerSkills.GetMaxEnergyValue());

		// DebugPanel.Log("Resources Tier: ", PlayerSkills.GetResourcesTier());
		// DebugPanel.Log("Resources Max: ", PlayerSkills.GetMaxResourcesValue());


		DebugPanel.Log("Tools 1: ", PlayerTools.GetOwnedToolsList()[0]);
		DebugPanel.Log("Tools 2: ", PlayerTools.GetOwnedToolsList()[1]);
		DebugPanel.Log("Tools 3: ", PlayerTools.GetOwnedToolsList()[2]);

		// if (Input.GetButtonDown("Debug"))
		// {
		// 	Debug.Log("Debug Key Press");
		// 	PlayerTools.RemoveTool(ToolName.FELLING_AXE);
		// }


		// DebugPanel.Log("Contracts List: ", PlayerContracts.GetContractAtIndex(0));
		// if (Input.GetButtonDown("Debug"))
		// {
		// 	Debug.Log("Debug Key Press");
		// 	PlayerContracts.RemoveContractAtIndex(0);
		// }
	}
}
