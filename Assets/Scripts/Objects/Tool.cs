using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ToolName {EMPTY_HANDS, FELLING_AXE, CROSSCUT_SAW, SPLITTING_AXE};

[Serializable]
public class Tool 
{	
	private ToolName toolName;
	private int currentTier;
	private DevResourceQuantity[] upgradeCosts;
	private bool canBeUpgraded;
	private string description;
	private string tierDescriptiveString;

	public Tool() {}

	public Tool(ToolName name)
	{
		toolName = name;
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		if (!name.Equals(ToolName.EMPTY_HANDS)) 
		{
			canBeUpgraded = (currentTier < upgradeCosts.Length);
		}
		else
		{
			canBeUpgraded = false;
		}

		switch(name)
		{
			case ToolName.FELLING_AXE:
				description = "Efficiently cuts tree fibers; used for felling trees.";
				tierDescriptiveString = "Max quality from Tree Felling: ";
				break;
			case ToolName.CROSSCUT_SAW:
				description = "Designed to cut wood across the grain; used for cutting felled trees into logs";
				tierDescriptiveString = "Max quality from Log Bucking: ";
				break;
			case ToolName.SPLITTING_AXE:
				description = "Wedge shapped to cut with the grain of the wood; used for splitting logs.";
				tierDescriptiveString = "Max quality from Firewood Splitting: ";
				break;
		}
	}

	public Tool(ToolName name, int tier)
	{
		toolName = name;
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);

		switch(name)
		{
			case ToolName.FELLING_AXE:
				description = "Efficiently cuts tree fibers; used for felling trees.";
				tierDescriptiveString = "Max quality from Tree Felling: ";
				break;
			case ToolName.CROSSCUT_SAW:
				description = "Designed to cut wood across the grain; used for cutting felled trees into logs";
				tierDescriptiveString = "Max quality from Log Bucking: ";
				break;
			case ToolName.SPLITTING_AXE:
				description = "Wedge shapped to cut with the grain of the wood; used for splitting logs.";
				tierDescriptiveString = "Max quality from Firewood Splitting: ";
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
			case ToolName.EMPTY_HANDS:
				return "None";
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

	public string GetTierDescriptiveString()
	{
		QualityGrade tierEquivalent = QualityGrade.F;
		switch(currentTier)
		{
			case 2:
				tierEquivalent = QualityGrade.D;
				break;
			case 3:
				tierEquivalent = QualityGrade.C;
				break;
			case 4:
				tierEquivalent = QualityGrade.B;
				break;
			case 5:
				tierEquivalent = QualityGrade.A;
				break;
		}
		return tierDescriptiveString + tierEquivalent.ToString();
	}

	public DevResourceQuantity[] GetDevResourceQuanties() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; } 

	public bool CanBeUpgraded() { return canBeUpgraded; }

	public string GetToolDescription() { return description; }
	

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
