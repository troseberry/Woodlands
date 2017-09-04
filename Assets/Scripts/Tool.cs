﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ToolName {FELLING_AXE, CROSSCUT_SAW, SPLITTING_AXE};


public class Tool 
{	
	private ToolName toolName;
	private int currentTier;
	private ContractType associatedContractType;
	private DevResourceQuantity[] upgradeCosts;
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
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
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
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
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

	public void SetToolName(ToolName name) { toolName = name; }

	public int GetCurrentTier() { return currentTier; }

	public void SetCurrentTier(int newTier)
	{
		currentTier = newTier;
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public ContractType GetAssociatedContractType() { return associatedContractType; }

	public DevResourceQuantity[] GetDevResourceQuanties() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; } 

	public bool CanBeUpgraded() { return canBeUpgraded; }
	
	
	public bool CanPerformAction(LumberContract contract)
	{
		return currentTier >= contract.GetDifficultyRating();
	}

	public override string ToString()
	{
		return "Level " + currentTier + " " + GetToolNameAsString();
	}

	public string GetLevelString(int abbreviated)
	{
		if (abbreviated == 0)
		{
			return "Level: " + currentTier;
		}
		else if (abbreviated == 1)
		{
			return "LVL: " + currentTier;
		}
		else
		{
			return "Tool Lvl Err";
		}
	}

}
