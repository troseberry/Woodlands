using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills 
{
	private static EfficiencySkill efficiencySkill = new EfficiencySkill(); 
	private static MaxContractsSkill contractsSkill = new MaxContractsSkill();
	private static MaxCurrencySkill currencySkill = new MaxCurrencySkill();
	private static MaxEnergySkill energySkill = new MaxEnergySkill();
	private static MaxResourcesSkill resourceSkill = new MaxResourcesSkill();


	public static EfficiencySkill GetEfficiencySkill() { return efficiencySkill; }

	public static int GetEfficiencyTier() { return efficiencySkill.GetSkillTier(); }
	
	public static void SetEfficiencyTier(int newTier) { efficiencySkill.SetSkillTier(newTier); }

	public static int GetMaxEfficiencyValue()
	{
		return efficiencySkill.GetTierValueAtIndex(efficiencySkill.GetSkillTier() - 1);
	}


	public static MaxContractsSkill GetContractsSkill() { return contractsSkill; }

	public static int GetContractsTier() { return contractsSkill.GetSkillTier(); }
	
	public static void SetContractsTier(int newTier) { contractsSkill.SetSkillTier(newTier); }

	public static int GetMaxContractsValue() 
	{
		return contractsSkill.GetTierValueAtIndex(contractsSkill.GetSkillTier() - 1);
	}


	public static MaxCurrencySkill GetCurrencySkill() { return currencySkill; }

	public static int GetCurrencyTier() { return currencySkill.GetSkillTier(); }
	
	public static void SetCurrencyTier(int newTier) { currencySkill.SetSkillTier(newTier); }

	public static int GetMaxCurrencyValue() 
	{
		return currencySkill.GetTierValueAtIndex(currencySkill.GetSkillTier() - 1);
	}


	public static MaxEnergySkill GetEnergySkill() { return energySkill; }

	public static int GetEnergyTier() { return energySkill.GetSkillTier(); }
	
	public static void SetEnergyTier(int newTier) { energySkill.SetSkillTier(newTier); }

	public static int GetMaxEnergyValue() 
	{
		return energySkill.GetTierValueAtIndex(energySkill.GetSkillTier() - 1);
	}


	public static MaxResourcesSkill GetResourcesSkill() { return resourceSkill; }

	public static int GetResourcesTier() { return resourceSkill.GetSkillTier(); }
	
	public static void SetResourcesTier(int newTier) { resourceSkill.SetSkillTier(newTier); }

	public static int GetMaxResourcesValue() 
	{
		return resourceSkill.GetTierValueAtIndex(resourceSkill.GetSkillTier() - 1);
	}
}
