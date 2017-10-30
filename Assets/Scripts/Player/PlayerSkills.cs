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

	public static int GetEfficiencyTier() { return efficiencySkill.GetCurrentTier(); }
	
	public static void SetEfficiencyTier(int newTier) { efficiencySkill.SetCurrentTier(newTier); }

	public static int GetEfficiencyValue()
	{
		return efficiencySkill.GetTierValueAtIndex(efficiencySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextEfficiencyUpgradeCosts() 
	{ 
		if (efficiencySkill.CanBeUpgraded())
		{
			return efficiencySkill.GetDevResourceQuantityAtTier(GetEfficiencyTier() + 1); 
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextEfficiencyUpgradeCostsAsString() 
	{ 
		if (efficiencySkill.CanBeUpgraded())
		{
			return efficiencySkill.GetDevResourceQuantityAtTier(GetEfficiencyTier() + 1).ToString(); 
		}
		return "MAXED";
	}




	//change these to get/set activeContracts in method names
	public static ActiveContractsSkill GetContractsSkill() { return contractsSkill; }

	public static int GetContractsTier() { return contractsSkill.GetCurrentTier(); }
	
	public static void SetContractsTier(int newTier) { contractsSkill.SetCurrentTier(newTier); }

	public static int GetActiveContractsValue() 
	{
		return contractsSkill.GetTierValueAtIndex(contractsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextContractsUpgradeCosts() 
	{
		if (contractsSkill.CanBeUpgraded())
		{
			return contractsSkill.GetDevResourceQuantityAtTier(GetContractsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextContractsUpgradeCostsAsString()
	{
		if (contractsSkill.CanBeUpgraded())
		{
			return contractsSkill.GetDevResourceQuantityAtTier(GetContractsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static CurrencySkill GetCurrencySkill() { return currencySkill; }

	public static int GetCurrencyTier() { return currencySkill.GetCurrentTier(); }
	
	public static void SetCurrencyTier(int newTier) { currencySkill.SetCurrentTier(newTier); }

	public static int GetCurrencyValue() 
	{
		return currencySkill.GetTierValueAtIndex(currencySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextCurrencyUpgradeCosts()
	{
		if (currencySkill.CanBeUpgraded())
		{
			return currencySkill.GetDevResourceQuantityAtTier(GetCurrencyTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextCurrencyUpgradeCostsAsString()
	{
		if (currencySkill.CanBeUpgraded())
		{
			return currencySkill.GetDevResourceQuantityAtTier(GetCurrencyTier() + 1).ToString(); 
		}
		return "MAXED";
	}




	public static EnergySkill GetEnergySkill() { return energySkill; }

	public static int GetEnergyTier() { return energySkill.GetCurrentTier(); }
	
	public static void SetEnergyTier(int newTier) { energySkill.SetCurrentTier(newTier); }

	public static int GetEnergyValue() 
	{
		return energySkill.GetTierValueAtIndex(energySkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextEnergyUpgradeCosts() 
	{ 
		if (energySkill.CanBeUpgraded())
		{
			return energySkill.GetDevResourceQuantityAtTier(GetEnergyTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextEnergyUpgradeCostsAsString() 
	{
		if (energySkill.CanBeUpgraded())
		{
			return energySkill.GetDevResourceQuantityAtTier(GetEnergyTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static BuildingMaterialsSkill GetBuildingMaterialsSkill() { return buildingMaterialsSkill; }

	public static int GetBuildingMaterialsTier() { return buildingMaterialsSkill.GetCurrentTier(); }
	
	public static void SetBuildingMaterialsTier(int newTier) { buildingMaterialsSkill.SetCurrentTier(newTier); }

	public static int GetBuildingMaterialsValue() 
	{
		return buildingMaterialsSkill.GetTierValueAtIndex(buildingMaterialsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextBuildingMaterialsUpgradeCosts() 
	{ 
		if (buildingMaterialsSkill.CanBeUpgraded())
		{
			return buildingMaterialsSkill.GetDevResourceQuantityAtTier(GetBuildingMaterialsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextBuildingMaterialsUpgradeCostsAsString() 
	{
		if (buildingMaterialsSkill.CanBeUpgraded())
		{
			return buildingMaterialsSkill.GetDevResourceQuantityAtTier(GetBuildingMaterialsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static ToolPartsSkill GetToolPartsSkill() { return toolPartsSkill; }

	public static int GetToolPartsTier() { return toolPartsSkill.GetCurrentTier(); }
	
	public static void SetToolPartsTier(int newTier) { toolPartsSkill.SetCurrentTier(newTier); }

	public static int GetToolPartsValue() 
	{
		return toolPartsSkill.GetTierValueAtIndex(toolPartsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextToolPartsUpgradeCosts() 
	{ 
		if (toolPartsSkill.CanBeUpgraded())
		{
			return toolPartsSkill.GetDevResourceQuantityAtTier(GetToolPartsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextToolPartsUpgradeCostsAsString() 
	{
		if (toolPartsSkill.CanBeUpgraded())
		{
			return toolPartsSkill.GetDevResourceQuantityAtTier(GetToolPartsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static BookPagesSkill GetBookPagesSkill() { return bookPagesSkill; }

	public static int GetBookPagesTier() { return bookPagesSkill.GetCurrentTier(); }
	
	public static void SetBookPagesTier(int newTier) { bookPagesSkill.SetCurrentTier(newTier); }

	public static int GetBookPagesValue() 
	{
		return bookPagesSkill.GetTierValueAtIndex(bookPagesSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextBookPagesUpgradeCosts() 
	{ 
		if (bookPagesSkill.CanBeUpgraded())
		{
			return bookPagesSkill.GetDevResourceQuantityAtTier(GetBookPagesTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextBookPagesUpgradeCostsAsString() 
	{
		if (bookPagesSkill.CanBeUpgraded())
		{
			return bookPagesSkill.GetDevResourceQuantityAtTier(GetBookPagesTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberTreesSkill GetLumberTreesSkill() { return lumberTreesSkill; }

	public static int GetLumberTreesTier() { return lumberTreesSkill.GetCurrentTier(); }
	
	public static void SetLumberTreesTier(int newTier) { lumberTreesSkill.SetCurrentTier(newTier); }

	public static int GetLumberTreesValue() 
	{
		return lumberTreesSkill.GetTierValueAtIndex(lumberTreesSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberTreesUpgradeCosts() 
	{
		if (lumberTreesSkill.CanBeUpgraded()) 
		{
			return lumberTreesSkill.GetDevResourceQuantityAtTier(GetLumberTreesTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberTreesUpgradeCostsAsString() 
	{
		if (lumberTreesSkill.CanBeUpgraded())
		{
			return lumberTreesSkill.GetDevResourceQuantityAtTier(GetLumberTreesTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberLogsSkill GetLumberLogsSkill() { return lumberLogsSkill; }

	public static int GetLumberLogsTier() { return lumberLogsSkill.GetCurrentTier(); }
	
	public static void SetLumberLogsTier(int newTier) { lumberLogsSkill.SetCurrentTier(newTier); }

	public static int GetLumberLogsValue() 
	{
		return lumberLogsSkill.GetTierValueAtIndex(lumberLogsSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberLogsUpgradeCosts() 
	{ 
		if (lumberLogsSkill.CanBeUpgraded())
		{
			return lumberLogsSkill.GetDevResourceQuantityAtTier(GetLumberLogsTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberLogsUpgradeCostsAsString() 
	{
		if (lumberLogsSkill.CanBeUpgraded())
		{
			return lumberLogsSkill.GetDevResourceQuantityAtTier(GetLumberLogsTier() + 1).ToString();
		}
		return "MAXED";
	}




	public static LumberFirewoodSkill GetLumberFirewoodSkill() { return lumberFirewoodSkill; }

	public static int GetLumberFirewoodTier() { return lumberFirewoodSkill.GetCurrentTier(); }
	
	public static void SetLumberFirewoodTier(int newTier) { lumberFirewoodSkill.SetCurrentTier(newTier); }

	public static int GetLumberFirewoodValue() 
	{
		return lumberFirewoodSkill.GetTierValueAtIndex(lumberFirewoodSkill.GetCurrentTier() - 1);
	}

	public static DevResourceQuantity GetNextLumberFirewoodUpgradeCosts() 
	{ 
		if (lumberFirewoodSkill.CanBeUpgraded())
		{
			return lumberFirewoodSkill.GetDevResourceQuantityAtTier(GetLumberFirewoodTier() + 1);
		}
		return new DevResourceQuantity(0, 0, 0, 0);
	}

	public static string GetNextLumberFirewoodUpgradeCostsAsString() 
	{
		if (lumberFirewoodSkill.CanBeUpgraded())
		{
			return lumberFirewoodSkill.GetDevResourceQuantityAtTier(GetLumberFirewoodTier() + 1).ToString();
		}
		return "MAXED";
	}
}
