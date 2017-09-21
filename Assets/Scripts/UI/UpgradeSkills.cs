using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkills : MonoBehaviour 
{

	private Text contractsCosts, currencyCosts, efficiencyCosts, energyCosts, buildingMaterialsCosts, toolPartsCosts, bookPagesCosts, lumberTreesCosts, lumberLogsCosts, lumberFirewoodCosts;

	void Start()
	{
		contractsCosts = transform.GetChild(0).GetChild(1).GetComponent<Text>();
		currencyCosts = transform.GetChild(1).GetChild(1).GetComponent<Text>();
		efficiencyCosts = transform.GetChild(2).GetChild(1).GetComponent<Text>();
		energyCosts = transform.GetChild(3).GetChild(1).GetComponent<Text>();
		buildingMaterialsCosts = transform.GetChild(4).GetChild(1).GetComponent<Text>();
		toolPartsCosts = transform.GetChild(5).GetChild(1).GetComponent<Text>();
		bookPagesCosts = transform.GetChild(6).GetChild(1).GetComponent<Text>();
		lumberTreesCosts = transform.GetChild(7).GetChild(1).GetComponent<Text>();
		lumberLogsCosts = transform.GetChild(8).GetChild(1).GetComponent<Text>();
		lumberFirewoodCosts = transform.GetChild(9).GetChild(1).GetComponent<Text>();

		UpdateSkillsResources();
		
	}

	void UpdateSkillsResources()
	{
		contractsCosts.text = PlayerSkills.GetNextContractsUpgradeCostsAsString();
		currencyCosts.text = PlayerSkills.GetNextCurrencyUpgradeCostsAsString();
		efficiencyCosts.text = PlayerSkills.GetNextEfficiencyUpgradeCostsAsString();
		energyCosts.text = PlayerSkills.GetNextEnergyUpgradeCostsAsString();


		buildingMaterialsCosts.text = PlayerSkills.GetNextBuildingMaterialsUpgradeCostsAsString();
		toolPartsCosts.text = PlayerSkills.GetNextToolPartsUpgradeCostsAsString();
		bookPagesCosts.text = PlayerSkills.GetNextBookPagesUpgradeCostsAsString();

		lumberTreesCosts.text = PlayerSkills.GetNextLumberTreesUpgradeCostsAsString();
		lumberLogsCosts.text = PlayerSkills.GetNextLumberLogsUpgradeCostsAsString();
		lumberFirewoodCosts.text = PlayerSkills.GetNextLumberFirewoodUpgradeCostsAsString();
	}

	public void UpgradeEfficiency()
	{
		if (PlayerSkills.GetEfficiencySkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetEfficiencyTier();

			if (PlayerSkills.GetEfficiencySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetEfficiencyTier(currentTier + 1);
				PlayerSkills.GetEfficiencySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetEfficiencySkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: EFFICIENCY");
		}
	}

	public void UpgradeContracts()
	{
		if (PlayerSkills.GetContractsSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetContractsTier();

			if (PlayerSkills.GetContractsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetContractsTier(currentTier + 1);
				PlayerSkills.GetContractsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetContractsSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX CONTRACTS");
		}
	}

	public void UpgradeCurrency()
	{
		if(PlayerSkills.GetCurrencySkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetCurrencyTier();

			if (PlayerSkills.GetCurrencySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrencyTier(currentTier + 1);
				PlayerSkills.GetCurrencySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetCurrencySkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX CURRENCY");
		}
	}

	public void UpgradeEnergy()
	{
		if (PlayerSkills.GetEnergySkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetEnergyTier();

			if (PlayerSkills.GetEnergySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetEnergyTier(currentTier + 1);
				PlayerSkills.GetEnergySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetEnergySkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX ENERGY");
		}
	}

	public void UpgradeBuildingMaterials()
	{
		if (PlayerSkills.GetBuildingMaterialsSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetBuildingMaterialsTier();

			if (PlayerSkills.GetBuildingMaterialsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetBuildingMaterialsTier(currentTier + 1);
				PlayerSkills.GetBuildingMaterialsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetBuildingMaterialsSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX BUILDING MATERIALS");
		}
	}

	public void UpgradeToolParts()
	{
		if (PlayerSkills.GetToolPartsSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetToolPartsTier();

			if (PlayerSkills.GetToolPartsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetToolPartsTier(currentTier + 1);
				PlayerSkills.GetToolPartsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetToolPartsSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX TOOL PARTS");
		}
	}

	public void UpgradeBookPages()
	{
		if (PlayerSkills.GetBookPagesSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetBookPagesTier();

			if (PlayerSkills.GetBookPagesSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetBookPagesTier(currentTier + 1);
				PlayerSkills.GetBookPagesSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetBookPagesSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX BOOK PAGES");
		}
	}


	public void UpgradeLumberTrees()
	{
		if (PlayerSkills.GetLumberTreesSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetLumberTreesTier();

			if (PlayerSkills.GetLumberTreesSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetLumberTreesTier(currentTier + 1);
				PlayerSkills.GetLumberTreesSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetLumberTreesSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX LUMBER TREES");
		}
	}

	public void UpgradeLumberLogs()
	{
		if (PlayerSkills.GetLumberLogsSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetLumberLogsTier();

			if (PlayerSkills.GetLumberLogsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetLumberLogsTier(currentTier + 1);
				PlayerSkills.GetLumberLogsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetLumberLogsSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX LUMBER LOGS");
		}
	}

	public void UpgradeLumberFirewood()
	{
		if (PlayerSkills.GetLumberFirewoodSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetLumberFirewoodTier();

			if (PlayerSkills.GetLumberFirewoodSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetLumberFirewoodTier(currentTier + 1);
				PlayerSkills.GetLumberFirewoodSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetLumberFirewoodSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX LUMBER FIREWOOD");
		}
	}
}
