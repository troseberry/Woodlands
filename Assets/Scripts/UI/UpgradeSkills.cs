using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSkills : MonoBehaviour 
{

	public void UpgradeEfficiency()
	{
		if (PlayerSkills.GetEfficiencySkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetEfficiencyTier();

			if (PlayerSkills.GetEfficiencySkill().GetResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetEfficiencyTier(currentTier + 1);
				PlayerSkills.GetEfficiencySkill().GetResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetEfficiencySkill().GetResourceQuantityAtTier(currentTier + 1));
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

			if (PlayerSkills.GetContractsSkill().GetResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetContractsTier(currentTier + 1);
				PlayerSkills.GetContractsSkill().GetResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetContractsSkill().GetResourceQuantityAtTier(currentTier + 1));
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

			if (PlayerSkills.GetCurrencySkill().GetResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetCurrencyTier(currentTier + 1);
				PlayerSkills.GetCurrencySkill().GetResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetCurrencySkill().GetResourceQuantityAtTier(currentTier + 1));
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

			if (PlayerSkills.GetEnergySkill().GetResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetEnergyTier(currentTier + 1);
				PlayerSkills.GetEnergySkill().GetResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetEnergySkill().GetResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX ENERGY");
		}
	}

	public void UpgradeResources()
	{
		if (PlayerSkills.GetResourcesSkill().CanBeUpgraded())
		{
			int currentTier = PlayerSkills.GetResourcesTier();

			if (PlayerSkills.GetResourcesSkill().GetResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				PlayerSkills.SetResourcesTier(currentTier + 1);
				PlayerSkills.GetResourcesSkill().GetResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + PlayerSkills.GetResourcesSkill().GetResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: MAX RESOURCES");
		}
	}
}
