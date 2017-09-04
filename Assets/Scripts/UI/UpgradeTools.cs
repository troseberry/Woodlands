using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTools : MonoBehaviour 
{

	public void UpgradeFellingAxe()
	{
		Tool fellingAxe = PlayerTools.GetToolByName(ToolName.FELLING_AXE);
		int currentTier = fellingAxe.GetCurrentTier();

		if (fellingAxe.CanBeUpgraded())
		{
			if (fellingAxe.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				//might need to reference actual PlayerTools object
				fellingAxe.SetCurrentTier(currentTier + 1);
				fellingAxe.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + fellingAxe.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: FELLING AXE");
		}
	}

	public void UpgradeCrosscutSaw()
	{
		Tool crosscutSaw = PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW);
		int currentTier = crosscutSaw.GetCurrentTier();

		if (crosscutSaw.CanBeUpgraded())
		{
			if (crosscutSaw.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				//might need to reference actual PlayerTools object
				crosscutSaw.SetCurrentTier(currentTier + 1);
				crosscutSaw.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + crosscutSaw.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: CROSSCUT SAW");
		}
	}

	public void UpgradeSplittingAxe()
	{
		Tool splittingAxe = PlayerTools.GetToolByName(ToolName.SPLITTING_AXE);
		int currentTier = splittingAxe.GetCurrentTier();

		if (splittingAxe.CanBeUpgraded())
		{
			if (splittingAxe.GetDevResourceQuantityAtTier(currentTier + 1).HasInInventory())
			{
				//might need to reference actual PlayerTools object
				splittingAxe.SetCurrentTier(currentTier + 1);
				splittingAxe.GetDevResourceQuantityAtTier(currentTier + 1).SubtractFromInventory();
			}
			else
			{
				Debug.Log("Insufficient Resources: " + splittingAxe.GetDevResourceQuantityAtTier(currentTier + 1));
			}
		}
		else
		{
			Debug.Log("Max Tier Reached: SPLITTING AXE");
		}
	}
}
