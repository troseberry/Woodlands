using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolHoverItem : MonoBehaviour 
{
	private Tool associatedTool;

	private Text toolName;
	private Text tierNumber;
	private Text toolDescription;
	private Text tierValue;

	public Transform toolTipGroup;

	void Start () 
	{
		switch(name)
		{
			case "FellingAxe":
				associatedTool = PlayerTools.GetToolByName(ToolName.FELLING_AXE);
				break;
			case "CrosscutSaw":
				associatedTool = PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW);
				break;
			case "SplittingAxe":
				associatedTool = PlayerTools.GetToolByName(ToolName.SPLITTING_AXE);
				break;
		}

		toolName = toolTipGroup.GetChild(0).GetComponent<Text>();
		tierNumber = toolTipGroup.GetChild(1).GetComponent<Text>();
		toolDescription = toolTipGroup.GetChild(2).GetComponent<Text>();
		tierValue = toolTipGroup.GetChild(3).GetComponent<Text>();
	}
	
	public void DiplayToolTip()
	{
		toolName.text = associatedTool.GetToolNameAsString();
		tierNumber.text = "Tier " + associatedTool.GetCurrentTier();
		toolDescription.text = associatedTool.GetToolDescription();
		tierValue.text = associatedTool.GetTierDescriptiveString();
		
		toolTipGroup.gameObject.SetActive(true);
	}

	public void HideToolTip()
	{
		toolTipGroup.gameObject.SetActive(false);
	}
}