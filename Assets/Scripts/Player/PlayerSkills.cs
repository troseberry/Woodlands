using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills 
{
	private static EfficiencySkill efficiencySkill = new EfficiencySkill(); 
	private static ActiveContractsSkill contractsSkill = new ActiveContractsSkill();
	private static CurrencySkill currencySkill = new CurrencySkill(5);
	private static EnergySkill energySkill = new EnergySkill();
	private static DevResourcesSkill devResourceSkill = new DevResourcesSkill();
	private static LumberTreesSkill lumberTreesSkill = new LumberTreesSkill();
	private static LumberLogsSkill lumberLogsSkill = new LumberLogsSkill();
	private static LumberFirewoodSkill lumberFirewoodSkill = new LumberFirewoodSkill();



	public static EfficiencySkill GetEfficiencySkill() { return efficiencySkill; }

	public static int GetEfficiencyTier() { return efficiencySkill.GetCurrentTier(); }
	
	public static void SetEfficiencyTier(int newTier) { efficiencySkill.SetCurrentTier(newTier); }

	public static int GetMaxEfficiencyValue()
	{
		return efficiencySkill.GetTierValueAtIndex(efficiencySkill.GetCurrentTier() - 1);
	}


	public static ActiveContractsSkill GetContractsSkill() { return contractsSkill; }

	public static int GetContractsTier() { return contractsSkill.GetCurrentTier(); }
	
	public static void SetContractsTier(int newTier) { contractsSkill.SetCurrentTier(newTier); }

	public static int GetMaxContractsValue() 
	{
		return contractsSkill.GetTierValueAtIndex(contractsSkill.GetCurrentTier() - 1);
	}


	public static CurrencySkill GetCurrencySkill() { return currencySkill; }

	public static int GetCurrencyTier() { return currencySkill.GetCurrentTier(); }
	
	public static void SetCurrencyTier(int newTier) { currencySkill.SetCurrentTier(newTier); }

	public static int GetMaxCurrencyValue() 
	{
		return currencySkill.GetTierValueAtIndex(currencySkill.GetCurrentTier() - 1);
	}


	public static EnergySkill GetEnergySkill() { return energySkill; }

	public static int GetEnergyTier() { return energySkill.GetCurrentTier(); }
	
	public static void SetEnergyTier(int newTier) { energySkill.SetCurrentTier(newTier); }

	public static int GetMaxEnergyValue() 
	{
		return energySkill.GetTierValueAtIndex(energySkill.GetCurrentTier() - 1);
	}


	public static DevResourcesSkill GetDevResourcesSkill() { return devResourceSkill; }

	public static int GetDevResourcesTier() { return devResourceSkill.GetCurrentTier(); }
	
	public static void SetDevResourcesTier(int newTier) { devResourceSkill.SetCurrentTier(newTier); }

	public static int GetMaxDevResourcesValue() 
	{
		return devResourceSkill.GetTierValueAtIndex(devResourceSkill.GetCurrentTier() - 1);
	}


	public static LumberTreesSkill GetLumberTreesSkill() { return lumberTreesSkill; }

	public static int GetLumberTreesTier() { return lumberTreesSkill.GetCurrentTier(); }
	
	public static void SetLumberTreesTier(int newTier) { lumberTreesSkill.SetCurrentTier(newTier); }

	public static int GetLumberTreesValue() 
	{
		return lumberTreesSkill.GetTierValueAtIndex(lumberTreesSkill.GetCurrentTier() - 1);
	}


	public static LumberLogsSkill GetLumberLogsSkill() { return lumberLogsSkill; }

	public static int GetLumberLogsTier() { return lumberLogsSkill.GetCurrentTier(); }
	
	public static void SetLumberLogsTier(int newTier) { lumberLogsSkill.SetCurrentTier(newTier); }

	public static int GetLumberLogsValue() 
	{
		return lumberLogsSkill.GetTierValueAtIndex(lumberLogsSkill.GetCurrentTier() - 1);
	}


	public static LumberFirewoodSkill GetLumberFirewoodSkill() { return lumberFirewoodSkill; }

	public static int GetLumberFirewoodTier() { return lumberFirewoodSkill.GetCurrentTier(); }
	
	public static void SetLumberFirewoodTier(int newTier) { lumberFirewoodSkill.SetCurrentTier(newTier); }

	public static int GetLumberFirewoodValue() 
	{
		return lumberFirewoodSkill.GetTierValueAtIndex(lumberFirewoodSkill.GetCurrentTier() - 1);
	}
}
