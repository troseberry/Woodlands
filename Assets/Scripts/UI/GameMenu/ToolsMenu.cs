using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ToolsMenu : MonoBehaviour 
{
	private bool menuActive = false;

	private Text fellingAxeTier, crosscutSawTier, splittingAxeTier;

	// private Text fellingAxeValue, crosscutSawValue, splittingAxeValue;

	public GameObject fellingAxeGroup, crosscutSawGroup, splittingAxeGroup;

	void Start () 
	{
		fellingAxeTier = fellingAxeGroup.transform.GetChild(1).GetComponent<Text>();
		crosscutSawTier = crosscutSawGroup.transform.GetChild(1).GetComponent<Text>();
		splittingAxeTier = splittingAxeGroup.transform.GetChild(1).GetComponent<Text>();
	}
	
	void Update () 
	{
		if (menuActive)
		{
			fellingAxeTier.text = "Tier: " + PlayerTools.GetToolByName(ToolName.FELLING_AXE).GetCurrentTier();
			// fellingAxeValue.text = "Capacity: " + PlayerSkills.GetEfficiencyValue();

			crosscutSawTier.text = "Tier: " + PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW).GetCurrentTier();
			// crosscutSawValue.text = "Capacity: " + PlayerSkills.GetActiveContractsValue();
			
			splittingAxeTier.text = "Tier: " + PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).GetCurrentTier();
			// splittingAxeValue.text = "Capacity: " + PlayerSkills.GetCurrencyValue();
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
