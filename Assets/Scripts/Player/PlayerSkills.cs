using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills 
{
	private static EfficiencySkill efficiencySkill = new EfficiencySkill(); 
	private static ActiveContractsSkill contractsSkill = new ActiveContractsSkill();
	private static CurrencySkill currencySkill = new CurrencySkill(5);
	private static EnergySkill energySkill = new EnergySkill(5);
	private static BuildingMaterialsSkill buildingMaterialsSkill = new BuildingMaterialsSkill();
	private static ToolPartsSkill toolPartsSkill = new ToolPartsSkill();
	private static BookPagesSkill bookPagesSkill = new BookPagesSkill();
	private static LumberTreesSkill lumberTreesSkill = new LumberTreesSkill();
	private static LumberLogsSkill lumberLogsSkill = new LumberLogsSkill();
	private static LumberFirewoodSkill lumberFirewoodSkill = new LumberFirewoodSkill();



	public static EfficiencySkill GetEfficiencySkill() { return efficiencySkill; }

	public static int GetCurrentEfficiencyTier() { return efficiencySkill.GetCurrentTier(); }
	
	public static void SetCurrentEfficiencyTier(int newTier) { efficiencySkill.SetCurrentTier(newTier); }

	public static int GetMaxEfficiencyValue()
	{
		return efficiencySkill.GetTierValueAtIndex(efficiencySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextEfficiencyUpgradeCosts() 
	{ 
		if (efficiencySkill.CanBeUpgraded())
		{
			return efficiencySkill.GetDevResourceQuantityAtTier(GetCurrentEfficiencyTier() + 1); 
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextEfficiencyUpgradeCostsAsString() 
	{ 
		if (efficiencySkill.CanBeUpgraded())
		{
			return efficiencySkill.GetDevResourceQuantityAtTier(GetCurrentEfficiencyTier() + 1).ToString(); 
		}
		return "MAXED";
	}




	//change these to get/set activeContracts in method names
	public static ActiveContractsSkill GetContractsSkill() { return contractsSkill; }

	public static int GetCurrentContractsTier() { return contractsSkill.GetCurrentTier(); }
	
	public static void SetCurrentContractsTier(int newTier) { contractsSkill.SetCurrentTier(newTier); }

	public static int GetMaxActiveContractsValue() 
	{
		return contractsSkill.GetTierValueAtIndex(contractsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextContractsUpgradeCosts() 
	{
		if (contractsSkill.CanBeUpgraded())
		{
			return contractsSkill.GetDevResourceQuantityAtTier(GetCurrentContractsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextContractsUpgradeCostsAsString()
	{
		if (contractsSkill.CanBeUpgraded())
		{
			return contractsSkill.GetDevResourceQuantityAtTier(GetCurrentContractsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static CurrencySkill GetCurrencySkill() { return currencySkill; }

	public static int GetCurrentCurrencyTier() { return currencySkill.GetCurrentTier(); }
	
	public static void SetCurrentCurrencyTier(int newTier) { currencySkill.SetCurrentTier(newTier); }

	public static int GetMaxCurrencyValue() 
	{
		return currencySkill.GetTierValueAtIndex(currencySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextCurrencyUpgradeCosts()
	{
		if (currencySkill.CanBeUpgraded())
		{
			return currencySkill.GetDevResourceQuantityAtTier(GetCurrentCurrencyTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextCurrencyUpgradeCostsAsString()
	{
		if (currencySkill.CanBeUpgraded())
		{
			return currencySkill.GetDevResourceQuantityAtTier(GetCurrentCurrencyTier() + 1).ToString(); 
		}
		return "MAXED";
	}




	public static EnergySkill GetEnergySkill() { return energySkill; }

	public static int GetCurrentEnergyTier() { return energySkill.GetCurrentTier(); }
	
	public static void SetCurrentEnergyTier(int newTier) { energySkill.SetCurrentTier(newTier); }

	public static int GetMaxEnergyValue() 
	{
		return energySkill.GetTierValueAtIndex(energySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextEnergyUpgradeCosts() 
	{ 
		if (energySkill.CanBeUpgraded())
		{
			return energySkill.GetDevResourceQuantityAtTier(GetCurrentEnergyTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextEnergyUpgradeCostsAsString() 
	{
		if (energySkill.CanBeUpgraded())
		{
			return energySkill.GetDevResourceQuantityAtTier(GetCurrentEnergyTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static BuildingMaterialsSkill GetBuildingMaterialsSkill() { return buildingMaterialsSkill; }

	public static int GetCurrentBuildingMaterialsTier() { return buildingMaterialsSkill.GetCurrentTier(); }
	
	public static void SetCurrentBuildingMaterialsTier(int newTier) { buildingMaterialsSkill.SetCurrentTier(newTier); }

	public static int GetMaxBuildingMaterialsValue() 
	{
		return buildingMaterialsSkill.GetTierValueAtIndex(buildingMaterialsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextBuildingMaterialsUpgradeCosts() 
	{ 
		if (buildingMaterialsSkill.CanBeUpgraded())
		{
			return buildingMaterialsSkill.GetDevResourceQuantityAtTier(GetCurrentBuildingMaterialsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextBuildingMaterialsUpgradeCostsAsString() 
	{
		if (buildingMaterialsSkill.CanBeUpgraded())
		{
			return buildingMaterialsSkill.GetDevResourceQuantityAtTier(GetCurrentBuildingMaterialsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static ToolPartsSkill GetToolPartsSkill() { return toolPartsSkill; }

	public static int GetCurrentToolPartsTier() { return toolPartsSkill.GetCurrentTier(); }
	
	public static void SetCurrentToolPartsTier(int newTier) { toolPartsSkill.SetCurrentTier(newTier); }

	public static int GetMaxToolPartsValue() 
	{
		return toolPartsSkill.GetTierValueAtIndex(toolPartsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextToolPartsUpgradeCosts() 
	{ 
		if (toolPartsSkill.CanBeUpgraded())
		{
			return toolPartsSkill.GetDevResourceQuantityAtTier(GetCurrentToolPartsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextToolPartsUpgradeCostsAsString() 
	{
		if (toolPartsSkill.CanBeUpgraded())
		{
			return toolPartsSkill.GetDevResourceQuantityAtTier(GetCurrentToolPartsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static BookPagesSkill GetBookPagesSkill() { return bookPagesSkill; }

	public static int GetCurrentBookPagesTier() { return bookPagesSkill.GetCurrentTier(); }
	
	public static void SetCurrentBookPagesTier(int newTier) { bookPagesSkill.SetCurrentTier(newTier); }

	public static int GetMaxBookPagesValue() 
	{
		return bookPagesSkill.GetTierValueAtIndex(bookPagesSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextBookPagesUpgradeCosts() 
	{ 
		if (bookPagesSkill.CanBeUpgraded())
		{
			return bookPagesSkill.GetDevResourceQuantityAtTier(GetCurrentBookPagesTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextBookPagesUpgradeCostsAsString() 
	{
		if (bookPagesSkill.CanBeUpgraded())
		{
			return bookPagesSkill.GetDevResourceQuantityAtTier(GetCurrentBookPagesTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberTreesSkill GetLumberTreesSkill() { return lumberTreesSkill; }

	public static int GetCurrentLumberTreesTier() { return lumberTreesSkill.GetCurrentTier(); }
	
	public static void SetCurrentLumberTreesTier(int newTier) { lumberTreesSkill.SetCurrentTier(newTier); }

	public static int GetMaxLumberTreesValue() 
	{
		return lumberTreesSkill.GetTierValueAtIndex(lumberTreesSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberTreesUpgradeCosts() 
	{
		if (lumberTreesSkill.CanBeUpgraded()) 
		{
			return lumberTreesSkill.GetDevResourceQuantityAtTier(GetCurrentLumberTreesTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberTreesUpgradeCostsAsString() 
	{
		if (lumberTreesSkill.CanBeUpgraded())
		{
			return lumberTreesSkill.GetDevResourceQuantityAtTier(GetCurrentLumberTreesTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberLogsSkill GetLumberLogsSkill() { return lumberLogsSkill; }

	public static int GetCurrentLumberLogsTier() { return lumberLogsSkill.GetCurrentTier(); }
	
	public static void SetCurrentLumberLogsTier(int newTier) { lumberLogsSkill.SetCurrentTier(newTier); }

	public static int GetMaxLumberLogsValue() 
	{
		return lumberLogsSkill.GetTierValueAtIndex(lumberLogsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberLogsUpgradeCosts() 
	{ 
		if (lumberLogsSkill.CanBeUpgraded())
		{
			return lumberLogsSkill.GetDevResourceQuantityAtTier(GetCurrentLumberLogsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberLogsUpgradeCostsAsString() 
	{
		if (lumberLogsSkill.CanBeUpgraded())
		{
			return lumberLogsSkill.GetDevResourceQuantityAtTier(GetCurrentLumberLogsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberFirewoodSkill GetLumberFirewoodSkill() { return lumberFirewoodSkill; }

	public static int GetCurrentLumberFirewoodTier() { return lumberFirewoodSkill.GetCurrentTier(); }
	
	public static void SetCurrentLumberFirewoodTier(int newTier) { lumberFirewoodSkill.SetCurrentTier(newTier); }

	public static int GetMaxLumberFirewoodValue() 
	{
		return lumberFirewoodSkill.GetTierValueAtIndex(lumberFirewoodSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberFirewoodUpgradeCosts() 
	{ 
		if (lumberFirewoodSkill.CanBeUpgraded())
		{
			return lumberFirewoodSkill.GetDevResourceQuantityAtTier(GetCurrentLumberFirewoodTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberFirewoodUpgradeCostsAsString() 
	{
		if (lumberFirewoodSkill.CanBeUpgraded())
		{
			return lumberFirewoodSkill.GetDevResourceQuantityAtTier(GetCurrentLumberFirewoodTier() + 1).ToString();
		}
		return "MAXED";
	}
}
