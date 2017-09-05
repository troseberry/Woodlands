using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillName {EFFICIENCY, ACTIVE_CONTRACTS, CURRENCY, ENERGY, DEV_RESOURCES, LUMBER_TREES, LUMBER_LOGS, LUMBER_FIREWOOD};

public class Skill 
{
	protected SkillName skillName;
	protected int currentTier;
	protected int[] tierValues;
	protected DevResourceQuantity[] upgradeCosts;
	protected bool canBeUpgraded;


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

	public DevResourceQuantity[] GetDevResourceQuanties() { return upgradeCosts; }

	public void SetDevResourceQuantities(DevResourceQuantity[] newCosts) { upgradeCosts = newCosts; }

	public DevResourceQuantity GetDevResourceQuantityAtTier(int tier) { return upgradeCosts[tier - 1]; }

	public void SetDevResourceQuantityAtTier(int tier, DevResourceQuantity newCost) { upgradeCosts[tier - 1] = newCost; } 

	public bool CanBeUpgraded() { return canBeUpgraded; }
}

public class EfficiencySkill : Skill
{
	public EfficiencySkill() 
	{ 
		skillName = SkillName.EFFICIENCY;
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
	}
}

public class MaxContractsSkill : Skill
{
	public MaxContractsSkill() 
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
	}
	public MaxContractsSkill(int tier) 
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
	}
}

public class MaxCurrencySkill : Skill
{
	public MaxCurrencySkill() 
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
	}
	public MaxCurrencySkill(int tier) 
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
	}
}

public class MaxEnergySkill : Skill
{
	public MaxEnergySkill() 
	{
		skillName = SkillName.ENERGY;
		tierValues = new int[5] {20, 40, 60, 80, 100};
		currentTier = 1;
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
	public MaxEnergySkill(int tier) 
	{
		skillName = SkillName.ENERGY;
		tierValues = new int[5] {20, 40, 60, 80, 100};
		currentTier = tier; 
		upgradeCosts = new DevResourceQuantity[5] {
			new DevResourceQuantity(0, 0, 0, 0),
			new DevResourceQuantity(100, 0, 0, 0),
			new DevResourceQuantity(250, 0, 0, 0),
			new DevResourceQuantity(500, 0, 0, 0),
			new DevResourceQuantity(1000, 0, 0, 0)
		};
		canBeUpgraded = (currentTier < upgradeCosts.Length);
	}
}

public class MaxDevResourcesSkill : Skill
{
	public MaxDevResourcesSkill() 
	{
		skillName = SkillName.DEV_RESOURCES;
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
	}
	public MaxDevResourcesSkill(int tier) 
	{
		skillName = SkillName.DEV_RESOURCES;
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
	}
}


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
	}
}


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
	}
}


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
	}
}