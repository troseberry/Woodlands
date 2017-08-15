using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolName {FELLING_AXE, CROSSCUT_SAW, SPLITTING_AXE};


public class Tool 
{	
	private ToolName toolName;
	private int currentTier;
	private ContractType associatedContractType;

	public Tool() {}

	public Tool(ToolName name)
	{
		toolName = name;
		currentTier = 1;
		switch(name)
		{
			case ToolName.FELLING_AXE:
				associatedContractType = ContractType.FELLING_TREES;
				break;
			case ToolName.CROSSCUT_SAW:
				associatedContractType = ContractType.LOG_BUCKING;
				break;
			case ToolName.SPLITTING_AXE:
				associatedContractType = ContractType.SPLITTING_LOGS;
				break;
		}
	}

	public Tool(ToolName name, int tier)
	{
		toolName = name;
		currentTier = tier;
		switch(name)
		{
			case ToolName.FELLING_AXE:
				associatedContractType = ContractType.FELLING_TREES;
				break;
			case ToolName.CROSSCUT_SAW:
				associatedContractType = ContractType.LOG_BUCKING;
				break;
			case ToolName.SPLITTING_AXE:
				associatedContractType = ContractType.SPLITTING_LOGS;
				break;
		}
	}

	public ToolName GetToolName() { return toolName; }

	public string GetToolNameAsString()
	{
		switch(toolName)
		{
			case ToolName.FELLING_AXE:
				return "Felling Axe";
			case ToolName.CROSSCUT_SAW:
				return "Crosscut Saw";
			case ToolName.SPLITTING_AXE:
				return "Splitting Axe";
		}
		return "Invalid Tool";
	}

	public int GetCurrentTier() { return currentTier; }

	public void SetCurrentTier(int newTier) { currentTier = newTier; }

	public ContractType GetAssociatedContractType() { return associatedContractType; }
	
	public bool CanPerformAction(LumberContract contract)
	{
		return currentTier >= contract.GetDifficultyRating();
	}

	public override string ToString()
	{
		return "Level " + currentTier + " " + GetToolNameAsString();
	}

}
