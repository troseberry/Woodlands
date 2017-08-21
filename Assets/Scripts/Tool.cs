using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolName {FELLING_AXE, CROSSCUT_SAW, SPLITTING_AXE};


public class Tool 
{	
	private ToolName toolName;
	private int currentTier;
	private ContractType associatedContractType;
	private ResourceQuantity[] upgradeCosts;
	private bool canBeUpgraded;

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
		upgradeCosts = new ResourceQuantity[5] {
			new ResourceQuantity(0, 0, 0, 0),
			new ResourceQuantity(100, 0, 0, 0),
			new ResourceQuantity(250, 0, 0, 0),
			new ResourceQuantity(500, 0, 0, 0),
			new ResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
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
		upgradeCosts = new ResourceQuantity[5] {
			new ResourceQuantity(0, 0, 0, 0),
			new ResourceQuantity(100, 0, 0, 0),
			new ResourceQuantity(250, 0, 0, 0),
			new ResourceQuantity(500, 0, 0, 0),
			new ResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
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

	public void SetCurrentTier(int newTier)
	{
		currentTier = newTier;
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public ContractType GetAssociatedContractType() { return associatedContractType; }

	public ResourceQuantity[] GetResourceQuanties() { return upgradeCosts; }

	public void SetResourceQuantities(ResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public ResourceQuantity GetResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetResourceQuantityAtTier(int tier, ResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; } 

	public bool CanBeUpgraded() { return canBeUpgraded; }
	
	
	public bool CanPerformAction(LumberContract contract)
	{
		return currentTier >= contract.GetDifficultyRating();
	}

	public override string ToString()
	{
		return "Level " + currentTier + " " + GetToolNameAsString();
	}

}
