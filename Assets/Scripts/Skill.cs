using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillName {EFFICIENCY, MAX_CONTRACTS, MAX_CURRENCY, MAX_ENERGY, MAX_RESOURCES};

public class Skill 
{
	protected SkillName skillName;
	protected int currentTier;
	protected int[] tierValues;


	public Skill() {}

	public Skill(SkillName name, int[] values)
	{
		skillName = name;
		currentTier = 1;
		tierValues = values;
	}

	public Skill(SkillName name, int tier, int[] values)
	{
		skillName = name;
		currentTier = tier;
		tierValues = values;
	}


	public SkillName GetSkillName() { return skillName; }

	public int GetSkillTier() { return currentTier; }

	public void SetSkillTier(int newTier) { currentTier = newTier; }

	public int[] GetTierValues() { return tierValues; }

	public void SetTierValues(int[] newValues) { tierValues = newValues; }

	public int GetTierValueAtIndex(int index) { return tierValues[index]; }

	public void SetTierValueAtIndex(int index, int newValue) { tierValues[index] = newValue; }
}

public class EfficiencySkill : Skill
{
	public EfficiencySkill() 
	{ 
		skillName = SkillName.EFFICIENCY;
		tierValues = new int[5] {1, 2, 3, 4, 5};
		currentTier = 1; 
	}
	public EfficiencySkill(int tier) 
	{
		skillName = SkillName.EFFICIENCY;
		tierValues = new int[5] {1, 2, 3, 4, 5};
		currentTier = tier; 
	}
}

public class MaxContractsSkill : Skill
{
	public MaxContractsSkill() 
	{
		skillName = SkillName.MAX_CONTRACTS;
		tierValues = new int[5] {1, 3, 5, 8, 10};
		currentTier = 1;
	}
	public MaxContractsSkill(int tier) 
	{
		skillName = SkillName.MAX_CONTRACTS;
		tierValues = new int[5] {1, 3, 5, 8, 10};	
		currentTier = tier;
	}
}

public class MaxCurrencySkill : Skill
{
	public MaxCurrencySkill() 
	{
		skillName = SkillName.MAX_CURRENCY;
		tierValues = new int[5] {500, 1000, 2500, 5000, 10000};
		currentTier = 1; 
	}
	public MaxCurrencySkill(int tier) 
	{
		skillName = SkillName.MAX_CURRENCY;
		tierValues = new int[5] {500, 1000, 2500, 5000, 10000};
		currentTier = tier;
	}
}

public class MaxEnergySkill : Skill
{
	public MaxEnergySkill() 
	{
		skillName = SkillName.MAX_ENERGY;
		tierValues = new int[5] {20, 40, 60, 80, 100};
		currentTier = 1;
	}
	public MaxEnergySkill(int tier) 
	{
		skillName = SkillName.MAX_ENERGY;
		tierValues = new int[5] {20, 40, 60, 80, 100};
		currentTier = tier; 
	}
}

public class MaxResourcesSkill : Skill
{
	public MaxResourcesSkill() 
	{
		skillName = SkillName.MAX_RESOURCES;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = 1;
	}
	public MaxResourcesSkill(int tier) 
	{
		skillName = SkillName.MAX_RESOURCES;
		tierValues = new int[5] {50, 100, 250, 500, 1000};
		currentTier = tier;
	}
}
