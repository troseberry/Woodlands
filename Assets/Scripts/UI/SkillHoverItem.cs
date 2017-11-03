using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillHoverItem : MonoBehaviour 
{
	private Skill associatedSkill;

	private Text skillName;
	private Text tierNumber;
	private Text skillDescription;
	private Text tierValue;

	public Transform toolTipGroup;

	void Start () 
	{
		switch(name)
		{
			case "Energy":
				associatedSkill = PlayerSkills.GetEnergySkill();
				break;
			case "Currency":
				associatedSkill = PlayerSkills.GetCurrencySkill();
				break;
			case "ActiveContracts":
				associatedSkill = PlayerSkills.GetContractsSkill();
				break;
			case "Efficiency":
				associatedSkill = PlayerSkills.GetEfficiencySkill();
				break;
			case "BuildingMaterials":
				associatedSkill = PlayerSkills.GetBuildingMaterialsSkill();
				break;
			case "ToolParts":
				associatedSkill = PlayerSkills.GetToolPartsSkill();
				break;
			case "BookPages":
				associatedSkill = PlayerSkills.GetBookPagesSkill();
				break;
			case "FelledTrees":
				associatedSkill = PlayerSkills.GetLumberTreesSkill();
				break;
			case "Logs":
				associatedSkill = PlayerSkills.GetLumberLogsSkill();
				break;
			case "Firewood":
				associatedSkill = PlayerSkills.GetLumberFirewoodSkill();
				break;
		}

		skillName = toolTipGroup.GetChild(0).GetComponent<Text>();
		tierNumber = toolTipGroup.GetChild(1).GetComponent<Text>();
		skillDescription = toolTipGroup.GetChild(2).GetComponent<Text>();
		tierValue = toolTipGroup.GetChild(3).GetComponent<Text>();
	}

	public void DisplayToolTip()
	{
		skillName.text = associatedSkill.GetSkillName().ToString();
		tierNumber.text = "Tier " + associatedSkill.GetCurrentTier().ToString();
		skillDescription.text = associatedSkill.GetSkillDescription();
		tierValue.text = associatedSkill.GetTierDescriptiveString();

		toolTipGroup.gameObject.SetActive(true);
	}

	public void HideToolTip()
	{
		toolTipGroup.gameObject.SetActive(false);
	}
}