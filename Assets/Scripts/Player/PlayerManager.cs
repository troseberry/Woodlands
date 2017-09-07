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

		if (PlayerContracts.GetActiveContractsList().Count == 0)
		{
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(1, QualityGrade.F, 0, QualityGrade.F, 0, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(0, QualityGrade.F, 4, QualityGrade.F, 0, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
			PlayerContracts.AddContract(new LumberContract(
				new LumberResourceQuantity(0, QualityGrade.F, 0, QualityGrade.F, 8, QualityGrade.F), 
				new DevResourceQuantity(100, 0, 0, 0), 
				3));
		}

	}
	
	void Update () 
	{	
		DebugPanel.Log("Lumber Trees (F): ", HomesteadStockpile.GetTreesCountAtIndex(0));
		DebugPanel.Log("Lumber Logs (F): ", HomesteadStockpile.GetLogsCountAtIndex(0));
		DebugPanel.Log("Lumber Firewood (F): ", HomesteadStockpile.GetFirewoodCountAtIndex(0));


		DebugPanel.Log("Lumber Trees Tier: ", PlayerSkills.GetLumberTreesTier());
		DebugPanel.Log("Lumber Logs Tier: ", PlayerSkills.GetLumberLogsTier());
		DebugPanel.Log("Lumber Firewood Tier: ", PlayerSkills.GetLumberFirewoodTier());
	}
}
