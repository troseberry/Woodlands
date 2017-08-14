using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ContractType {FELLING_TREES, LOG_BUCKING, SPLITTING_LOGS};

public class LumberContract 
{
	private ContractType contractType;
	private int difficultyRating;
	private int energyRequirement;
	private ToolName requiredTool;
	private float duration;

	private int payout;			//for now this is just an int for currency. later should be dictionary of (resource name,count) pairs

	private int completionDeadline;


	public LumberContract() {}

	public LumberContract(ContractType type, int difficulty, int energy, float dur, int pay, int deadline)
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
				requiredTool = ToolName.FELLING_AXE;
				break;
			case ContractType.LOG_BUCKING:
				requiredTool = ToolName.CROSSCUT_SAW;
				break;
			case ContractType.SPLITTING_LOGS:
				requiredTool = ToolName.SPLITTING_AXE;
				break;
		}
	}


	public ContractType GetContractType() { return contractType; }

	public void SetContractType(ContractType type) { contractType = type; }

	public int GetDifficultyRating() { return difficultyRating; }
	
	public void SetDifficultyRating(int rating) { difficultyRating = rating; }

	public int GetEnergyRequirement() { return energyRequirement; }

	public void SetEnergyRequirement(int energy) { energyRequirement = energy; }

	public ToolName GetRequiredTool() { return requiredTool; }

	public float GetDuration() { return duration; }

	public void SetDuration(float dur) { duration = dur; }

	public int GetPayout() { return payout; }

	public void SetPayout(int pay) { payout = pay; }

	public int GetCompletionDeadline() { return completionDeadline; }

	public void SetCompletionDeadline(int deadline) { completionDeadline = deadline;}
}
