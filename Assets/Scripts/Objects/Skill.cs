using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillName {EFFICIENCY, ACTIVE_CONTRACTS, CURRENCY, ENERGY, BUILDING_MATERIALS, TOOL_PARTS, BOOK_PAGES, LUMBER_TREES, LUMBER_LOGS, LUMBER_FIREWOOD};

[Serializable]
public class Skill 
{
	protected SkillName skillName;
	protected int currentTier;
	protected int[] tierValues;
	protected DevResourceQuantity[] upgradeCosts;
	protected bool canBeUpgraded;
	protected string description;
	protected string tierDescriptiveString;


	public Skill() {}

	public Skill(SkillName name, int[] values, DevResourceQuantity[] costs)
	{
		skillName = name;
		currentTier = 1;
		tierValues = values;
		upgradeCosts = costs;
	}

	public Skill(SkillName name, int tier, int[] values, DevResourceQuantity[] costs)
	{
		skillName = name;
		currentTier = tier;
		tierValues = values;
		upgradeCosts = costs;
	}


	public SkillName GetSkillName() { return skillName; }

	public void SetSkillName(SkillName name) { skillName = name; }

	public int GetCurrentTier() { return currentTier; }

	public void SetCurrentTier(int newTier)
	{
		currentTier = newTier;
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}

	public int[] GetTierValues() { return tierValues; }

	public void SetTierValues(int[] newValues) { tierValues = newValues; }

	public int GetTierValueAtIndex(int index) { return tierValues[index]; }

	public void SetTierValueAtIndex(int index, int newValue) { tierValues[index] = newValue; }

	public string GetTierDescriptiveString() { return String.Format(tierDescriptiveString, tierValues[currentTier - 1]); }

	public DevResourceQuantity[] GetDevResourceQuanties() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; } 

	public bool CanBeUpgraded() { return canBeUpgraded; }

	public string GetSkillDescription() { return description; }
}

[Serializable]
public class EfficiencySkill : Skill
{
	public EfficiencySkill() 
	{ 
		skillName = SkillName.EFFICIENCY;
		//speed/time multiplier
		tierValues = new int[5] {1, 2, 3, 4, 5};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		}; 
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "How much effort (in the form of axe swings and saw moves) must be given to completing Logging Activities";
		tierDescriptiveString = "Efficiency level {0}";
	}
	public EfficiencySkill(int tier) 
	{
		skillName = SkillName.EFFICIENCY;
		tierValues = new int[5] {1, 2, 3, 4, 5};
		currentTier = tier; 
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "How much effort (in the form of axe swings and saw moves) must be given to completing Logging Activities.";
		tierDescriptiveString = "Efficiency level {0}";
	}
}

[Serializable]
public class ActiveContractsSkill : Skill
{
	public ActiveContractsSkill() 
	{
		skillName = SkillName.ACTIVE_CONTRACTS;
		tierValues = new int[5] {1, 3, 5, 8, 10};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "The maximum number of contracts that can be in progress at one time.";
		tierDescriptiveString = "{0} Active contract maximum";
	}
	public ActiveContractsSkill(int tier) 
	{
		skillName = SkillName.ACTIVE_CONTRACTS;
		tierValues = new int[5] {1, 3, 5, 8, 10};	
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "The maximum number of contracts that can be in progress at one time.";
		tierDescriptiveString = "{0} Active contract maximum";
	}
}

[Serializable]
public class CurrencySkill : Skill
{
	public CurrencySkill() 
	{
		skillName = SkillName.CURRENCY;
		tierValues = new int[5] {500, 1000, 2500, 5000, 10000};
		currentTier = 1; 
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Currency pouch capacity";
		tierDescriptiveString = "{0} coins";
	}
	public CurrencySkill(int tier) 
	{
		skillName = SkillName.CURRENCY;
		tierValues = new int[5] {500, 1000, 2500, 5000, 10000};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Currency pouch capacity";
		tierDescriptiveString = "{0} coins";
	}
}

[Serializable]
public class EnergySkill : Skill
{
	public EnergySkill() 
	{
		skillName = SkillName.ENERGY;
		// tierValues = new int[5] {20, 40, 60, 80, 100};
		tierValues = new int[5] {50, 100, 150, 200, 250};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum energy level";
		tierDescriptiveString = "{0} Energy";
	}
	public EnergySkill(int tier) 
	{
		skillName = SkillName.ENERGY;
		// tierValues = new int[5] {20, 40, 60, 80, 100};
		tierValues = new int[5] {50, 100, 150, 200, 250};
		currentTier = tier; 
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum energy level";
		tierDescriptiveString = "{0} Energy";
	}
}

[Serializable]
public class BuildingMaterialsSkill : Skill
{
	public BuildingMaterialsSkill() 
	{
		skillName = SkillName.BUILDING_MATERIALS;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for building materials";
		tierDescriptiveString = "{0} Materials";
	}
	public BuildingMaterialsSkill(int tier) 
	{
		skillName = SkillName.BUILDING_MATERIALS;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for building materials";
		tierDescriptiveString = "{0} Materials";
	}
}

[Serializable]
public class ToolPartsSkill : Skill
{
	public ToolPartsSkill() 
	{
		skillName = SkillName.TOOL_PARTS;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for tool parts";
		tierDescriptiveString = "{0} Parts";
	}
	public ToolPartsSkill(int tier) 
	{
		skillName = SkillName.TOOL_PARTS;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for tool parts";
		tierDescriptiveString = "{0} Parts";
	}
}

[Serializable]
public class BookPagesSkill : Skill
{
	public BookPagesSkill() 
	{
		skillName = SkillName.BOOK_PAGES;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for book pages";
		tierDescriptiveString = "{0} Pages";
	}
	public BookPagesSkill(int tier) 
	{
		skillName = SkillName.BOOK_PAGES;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum inventory capacity for book pages";
		tierDescriptiveString = "{0} Pages";
	}
}


[Serializable]
public class LumberTreesSkill : Skill
{
	public LumberTreesSkill() 
	{
		skillName = SkillName.LUMBER_TREES;
		tierValues = new int[5] {5, 10, 25, 50, 100};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for felled trees";
		tierDescriptiveString = "{0} Felled trees";
	}
	public LumberTreesSkill(int tier) 
	{
		skillName = SkillName.LUMBER_TREES;
		tierValues = new int[5] {5, 10, 25, 50, 100};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for felled trees";
		tierDescriptiveString = "{0} Felled trees";
	}
}


[Serializable]
public class LumberLogsSkill : Skill
{
	public LumberLogsSkill() 
	{
		skillName = SkillName.LUMBER_LOGS;
		tierValues = new int[5] {25, 50, 100, 250, 500};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for logs";
		tierDescriptiveString = "{0} Logs";
	}
	public LumberLogsSkill(int tier) 
	{
		skillName = SkillName.LUMBER_LOGS;
		tierValues = new int[5] {25, 50, 100, 250, 500};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for logs";
		tierDescriptiveString = "{0} Logs";
	}
}


[Serializable]
public class LumberFirewoodSkill : Skill
{
	public LumberFirewoodSkill() 
	{
		skillName = SkillName.LUMBER_FIREWOOD;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for firewood";
		tierDescriptiveString = "{0} Firewood";
	}
	public LumberFirewoodSkill(int tier) 
	{
		skillName = SkillName.LUMBER_FIREWOOD;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = tier;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
		description = "Maximum stockpile capacity for firewood";
		tierDescriptiveString = "{0} Firewood";
	}
}