using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills 
{
	private static EfficiencySkill efficiencySkill = new EfficiencySkill(); 
	private static MaxContractsSkill contractsSkill = new MaxContractsSkill();
	private static MaxCurrencySkill currencySkill = new MaxCurrencySkill(5);
	private static MaxEnergySkill energySkill = new MaxEnergySkill();
	private static MaxDevResourcesSkill resourceSkill = new MaxDevResourcesSkill();


	public static EfficiencySkill GetEfficiencySkill() { return efficiencySkill; }

	public static int GetEfficiencyTier() { return efficiencySkill.GetCurrentTier(); }
	
	public static void SetEfficiencyTier(int newTier) { efficiencySkill.SetCurrentTier(newTier); }

	public static int GetMaxEfficiencyValue()
	{
		return efficiencySkill.GetTierValueAtIndex(efficiencySkill.GetCurrentTier() - 1);
	}


	public static MaxContractsSkill GetContractsSkill() { return contractsSkill; }

	public static int GetContractsTier() { return contractsSkill.GetCurrentTier(); }
	
	public static void SetContractsTier(int newTier) { contractsSkill.SetCurrentTier(newTier); }

	public static int GetMaxContractsValue() 
	{
		return contractsSkill.GetTierValueAtIndex(contractsSkill.GetCurrentTier() - 1);
	}


	public static MaxCurrencySkill GetCurrencySkill() { return currencySkill; }

	public static int GetCurrencyTier() { return currencySkill.GetCurrentTier(); }
	
	public static void SetCurrencyTier(int newTier) { currencySkill.SetCurrentTier(newTier); }

	public static int GetMaxCurrencyValue() 
	{
		return currencySkill.GetTierValueAtIndex(currencySkill.GetCurrentTier() - 1);
	}


	public static MaxEnergySkill GetEnergySkill() { return energySkill; }

	public static int GetEnergyTier() { return energySkill.GetCurrentTier(); }
	
	public static void SetEnergyTier(int newTier) { energySkill.SetCurrentTier(newTier); }

	public static int GetMaxEnergyValue() 
	{
		return energySkill.GetTierValueAtIndex(energySkill.GetCurrentTier() - 1);
	}


	public static MaxDevResourcesSkill GetDevResourcesSkill() { return resourceSkill; }

	public static int GetDevResourcesTier() { return resourceSkill.GetCurrentTier(); }
	
	public static void SetDevResourcesTier(int newTier) { resourceSkill.SetCurrentTier(newTier); }

	public static int GetMaxDevResourcesValue() 
	{
		return resourceSkill.GetTierValueAtIndex(resourceSkill.GetCurrentTier() - 1);
	}
}
