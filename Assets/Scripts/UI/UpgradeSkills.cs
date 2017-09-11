using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSkills : MonoBehaviour 
{

	private Text contractsCosts, currencyCosts, devResourcesCosts, efficiencyCosts, energyCosts, lumberResourcesCosts;

	void Start()
	{
		contractsCosts = transform.GetChild(0).GetChild(1).GetComponent<Text>();
		currencyCosts = transform.GetChild(1).GetChild(1).GetComponent<Text>();
		devResourcesCosts = transform.GetChild(2).GetChild(1).GetComponent<Text>();
		efficiencyCosts = transform.GetChild(3).GetChild(1).GetComponent<Text>();
		energyCosts = transform.GetChild(4).GetChild(1).GetComponent<Text>();
		lumberResourcesCosts = transform.GetChild(5).GetChild(1).GetComponent<Text>();

		UpdateSkillsResources();
		
	}

	public void UpdateSkillsResources()
	{
		contractsCosts.text = PlayerSkills.GetNextContractsUpgradeCostsAsString();
		currencyCosts.text = PlayerSkills.GetNextCurrencyUpgradeCostsAsString();
		devResourcesCosts.text = PlayerSkills.GetNextDevResourcesUpgradeCostsAsString();
		efficiencyCosts.text = PlayerSkills.GetNextEfficiencyUpgradeCostsAsString();
		energyCosts.text = PlayerSkills.GetNextEnergyUpgradeCostsAsString();
		// lumberResourcesCosts.text
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

	//change to upgrade dev resources
	public void UpgradeDevResources()
	{
		if (PlayerSkills.GetDevResourcesSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetDevResourcesTier();

			if (PlayerSkills.GetDevResourcesSkill().GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetDevResourcesTier(currentTier + 1);
				PlayerSkills.GetDevResourcesSkill().GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetDevResourcesSkill().GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX DEV RESOURCES");
		}
	}


	//will probably split these up into 3 for each lumber resources
	public void UpgradeLumberResources()
	{

	}
}
