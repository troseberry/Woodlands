using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkills : MonoBehaviour 
{
	public Transform skillsGroup;

	void Start()
	{
		UpdateSkillsResources();	
	}

	void UpdateSkillsResources()
	{
		skillsGroup.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentContractsTier().ToString();
		skillsGroup.GetChild(0).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextContractsUpgradeCostsAsString();

		skillsGroup.GetChild(1).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentCurrencyTier().ToString();
		skillsGroup.GetChild(1).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextCurrencyUpgradeCostsAsString();

		skillsGroup.GetChild(2).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentEfficiencyTier().ToString();
		skillsGroup.GetChild(2).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextEfficiencyUpgradeCostsAsString();
		
		skillsGroup.GetChild(3).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentEnergyTier().ToString();
		skillsGroup.GetChild(3).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextEnergyUpgradeCostsAsString();

		skillsGroup.GetChild(4).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentBuildingMaterialsTier().ToString();
		skillsGroup.GetChild(4).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextBuildingMaterialsUpgradeCostsAsString();

		skillsGroup.GetChild(5).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentToolPartsTier().ToString();
		skillsGroup.GetChild(5).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextToolPartsUpgradeCostsAsString();

		skillsGroup.GetChild(6).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentBookPagesTier().ToString();
		skillsGroup.GetChild(6).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextBookPagesUpgradeCostsAsString();

		skillsGroup.GetChild(7).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentLumberTreesTier().ToString();
		skillsGroup.GetChild(7).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextLumberTreesUpgradeCostsAsString();

		skillsGroup.GetChild(8).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentLumberLogsTier().ToString();
		skillsGroup.GetChild(8).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextLumberLogsUpgradeCostsAsString();

		skillsGroup.GetChild(9).GetChild(0).GetComponent<Text>().text = PlayerSkills.GetCurrentLumberFirewoodTier().ToString();
		skillsGroup.GetChild(9).GetChild(1).GetComponent<Text>().text = PlayerSkills.GetNextLumberFirewoodUpgradeCostsAsString();
	}

	public void UpgradeEfficiency()
	{
		if (PlayerSkills.GetEfficiencySkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetCurrentEfficiencyTier();

			if (PlayerSkills.GetEfficiencySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentEfficiencyTier(currentTier + 1);
				PlayerSkills.GetEfficiencySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentContractsTier();

			if (PlayerSkills.GetContractsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentContractsTier(currentTier + 1);
				PlayerSkills.GetContractsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentCurrencyTier();

			if (PlayerSkills.GetCurrencySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentCurrencyTier(currentTier + 1);
				PlayerSkills.GetCurrencySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentEnergyTier();

			if (PlayerSkills.GetEnergySkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentEnergyTier(currentTier + 1);
				PlayerSkills.GetEnergySkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentBuildingMaterialsTier();

			if (PlayerSkills.GetBuildingMaterialsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentBuildingMaterialsTier(currentTier + 1);
				PlayerSkills.GetBuildingMaterialsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentToolPartsTier();

			if (PlayerSkills.GetToolPartsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentToolPartsTier(currentTier + 1);
				PlayerSkills.GetToolPartsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentBookPagesTier();

			if (PlayerSkills.GetBookPagesSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentBookPagesTier(currentTier + 1);
				PlayerSkills.GetBookPagesSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentLumberTreesTier();

			if (PlayerSkills.GetLumberTreesSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentLumberTreesTier(currentTier + 1);
				PlayerSkills.GetLumberTreesSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentLumberLogsTier();

			if (PlayerSkills.GetLumberLogsSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentLumberLogsTier(currentTier + 1);
				PlayerSkills.GetLumberLogsSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
			int currentTier = PlayerSkills.GetCurrentLumberFirewoodTier();

			if (PlayerSkills.GetLumberFirewoodSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrentLumberFirewoodTier(currentTier + 1);
				PlayerSkills.GetLumberFirewoodSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
				UpdateSkillsResources();
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
