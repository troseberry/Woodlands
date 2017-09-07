using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenu : MonoBehaviour 
{
	private bool menuActive = false;

	private Text efficiencyTier, contractsTier, currencyTier, energyTier, devResourceTier, lumberTreesTier, lumberLogsTier, lumberFirewoodTier;

	private Text efficiencyValue, contractsValue, currencyValue, energyValue, devResourceValue, lumberTreesValue, lumberLogsValue, lumberFirewoodValue;

	public GameObject efficiencyGroup, contractsGroup, currencyGroup, energyGroup, devResourceGroup, lumberTreesGroup, lumberLogsGroup, lumberFirewoodGroup;


	void Start () 
	{
		efficiencyTier = efficiencyGroup.transform.GetChild(1).GetComponent<Text>();
		efficiencyValue = efficiencyGroup.transform.GetChild(2).GetComponent<Text>();

		contractsTier = contractsGroup.transform.GetChild(1).GetComponent<Text>();
		contractsValue = contractsGroup.transform.GetChild(2).GetComponent<Text>();

		currencyTier = currencyGroup.transform.GetChild(1).GetComponent<Text>();
		currencyValue = currencyGroup.transform.GetChild(2).GetComponent<Text>();

		energyTier = energyGroup.transform.GetChild(1).GetComponent<Text>();
		energyValue = energyGroup.transform.GetChild(2).GetComponent<Text>();

		devResourceTier = devResourceGroup.transform.GetChild(1).GetComponent<Text>();
		devResourceValue = devResourceGroup.transform.GetChild(2).GetComponent<Text>();

		lumberTreesTier = lumberTreesGroup.transform.GetChild(1).GetComponent<Text>();
		lumberTreesValue = lumberTreesGroup.transform.GetChild(2).GetComponent<Text>();

		lumberLogsTier = lumberLogsGroup.transform.GetChild(1).GetComponent<Text>();
		lumberLogsValue = lumberLogsGroup.transform.GetChild(2).GetComponent<Text>();

		lumberFirewoodTier = lumberFirewoodGroup.transform.GetChild(1).GetComponent<Text>();
		lumberFirewoodValue = lumberFirewoodGroup.transform.GetChild(2).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (menuActive)
		{
			efficiencyTier.text = "Tier: " + PlayerSkills.GetEfficiencyTier();
			efficiencyValue.text = "Capacity: " + PlayerSkills.GetEfficiencyValue();

			contractsTier.text = "Tier: " + PlayerSkills.GetContractsTier();
			contractsValue.text = "Capacity: " + PlayerSkills.GetActiveContractsValue();
			
			currencyTier.text = "Tier: " + PlayerSkills.GetCurrencyTier();
			currencyValue.text = "Capacity: " + PlayerSkills.GetCurrencyValue();
			
			energyTier.text = "Tier: " + PlayerSkills.GetEnergyTier();
			energyValue.text = "Capacity: " + PlayerSkills.GetEnergyValue();
			
			devResourceTier.text = "Tier: " + PlayerSkills.GetDevResourcesTier();
			devResourceValue.text = "Capacity: " + PlayerSkills.GetDevResourcesValue();

			lumberTreesTier.text = "Tier: " + PlayerSkills.GetLumberTreesTier();
			lumberTreesValue.text = "Capacity: " + PlayerSkills.GetLumberTreesValue();

			lumberLogsTier.text = "Tier: " + PlayerSkills.GetLumberLogsTier();
			lumberLogsValue.text = "Capacity: " + PlayerSkills.GetLumberLogsValue();

			lumberFirewoodTier.text = "Tier: " + PlayerSkills.GetLumberFirewoodTier();
			lumberFirewoodValue.text = "Capacity: " + PlayerSkills.GetLumberFirewoodValue();
		}
	}

	public void OpenMenu()
	{
		menuActive = true;
		gameObject.SetActive(true);
	}

	public void CloseMenu()
	{
		menuActive = false;
		gameObject.SetActive(false);
	}
}
