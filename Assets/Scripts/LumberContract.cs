using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContractType {FELLING_TREES, LOG_BUCKING, SPLITTING_LOGS};

public class LumberContract 
{
	private ContractType contractType;
	private int difficultyRating;
	private int energyRequirement;
	private ToolName requiredToolName;
	private float duration;

	private DevResourceQuantity payout;

	private int completionDeadline;


	public LumberContract() {}

	public LumberContract(ContractType type, int difficulty, int energy, float dur, DevResourceQuantity pay, int deadline)
	{
		contractType = type;
		difficultyRating = difficulty;
		energyRequirement = energy;
		duration = dur;
		payout = pay;
		completionDeadline = deadline;

		switch(type)
		{
			case ContractType.FELLING_TREES:
				requiredToolName = ToolName.FELLING_AXE;
				break;
			case ContractType.LOG_BUCKING:
				requiredToolName = ToolName.CROSSCUT_SAW;
				break;
			case ContractType.SPLITTING_LOGS:
				requiredToolName = ToolName.SPLITTING_AXE;
				break;
		}
	}

	public string GetContractTypeAsString()
	{
		switch(contractType)
		{
			case ContractType.FELLING_TREES:
				return "Tree Felling";
			case ContractType.LOG_BUCKING:
				return "Log Bucking";
			case ContractType.SPLITTING_LOGS:
				return "Log Splitting";
		}
		return "Invalid Contract";
	}

	public ContractType GetContractType() { return contractType; }

	public void SetContractType(ContractType type) { contractType = type; }

	public int GetDifficultyRating() { return difficultyRating; }
	
	public void SetDifficultyRating(int rating) { difficultyRating = rating; }

	public int GetEnergyRequirement() { return energyRequirement; }

	public void SetEnergyRequirement(int energy) { energyRequirement = energy; }

	public ToolName GetRequiredToolName() { return requiredToolName; }

	public string GetRequiredToolNameAsString()
	{
		switch(requiredToolName)
		{
			case ToolName.FELLING_AXE:
				return "Felling Axe";
			case ToolName.CROSSCUT_SAW:
				return "Crosscut Saw";
			case ToolName.SPLITTING_AXE:
				return "Splitting Axe";
		}
		return "Invalid Tool";
	}

	public float GetDuration() { return duration; }

	public void SetDuration(float dur) { duration = dur; }

	public DevResourceQuantity GetPayout() { return payout; }

	public void SetPayout(DevResourceQuantity pay) { payout = pay; }

	public int GetCompletionDeadline() { return completionDeadline; }

	public void SetCompletionDeadline(int deadline) { completionDeadline = deadline;}

	public override string ToString()
	{
		return "Level " + difficultyRating + " " + GetContractTypeAsString();
	}
}
