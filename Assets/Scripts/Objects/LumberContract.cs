using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum ContractStatus {ACTIVE, AVAILABLE, COMPLETE, DECLINED, EXPIRED};

[Serializable]
public class LumberContract 
{
	private LumberResourceQuantity requiredLumber;
	private DevResourceQuantity payout;
	private int completionDeadline;
	private ContractStatus status;
	private ContractDifficulty difficulty;

	public LumberContract() {}

	public LumberContract(LumberResourceQuantity lumber, DevResourceQuantity pay, int deadline, ContractStatus startStatus, ContractDifficulty diff)
	{
		requiredLumber = lumber;
		payout = pay;
		completionDeadline = deadline;
		status = startStatus;
		difficulty = diff;
	}

	public LumberContract(int difficultyNumber)
	{
		ContractDifficulty[] difficultyArray = LumberContractHelper.DifficultyDictionary[difficultyNumber];
		int randomSelection = UnityEngine.Random.Range(0, difficultyArray.Length - 1);

		difficulty = difficultyArray[randomSelection];

		requiredLumber = new LumberResourceQuantity(difficulty);
		payout = requiredLumber.GenerateDevResourcePayout();
		completionDeadline = 3;			//should generate deadline based on either difficulty or required lumber quantities
		status = ContractStatus.AVAILABLE;
	}

	public LumberResourceQuantity GetRequiredLumber() { return requiredLumber; }

	public void SetRequiredLumber(LumberResourceQuantity lumber) { requiredLumber = lumber; }

	public DevResourceQuantity GetPayout() { return payout; }

	public void SetPayout(DevResourceQuantity pay) { payout = pay; }

	public int GetCompletionDeadline() { return completionDeadline; }

	public void SetCompletionDeadline(int deadline) { completionDeadline = deadline;}

	public void DecrementDeadline()
	{
		if (completionDeadline > 0) completionDeadline -= 1;
		if (completionDeadline == 0) status = ContractStatus.EXPIRED;
	}
	
	public bool IsExpired() { return status == ContractStatus.EXPIRED; }

	public bool CanBeCompleted() { return requiredLumber.HasInStockpile(); }

	public ContractStatus GetStatus() { return status; }

	public void SetStatus (ContractStatus newStatus) { status = newStatus; }

	public ContractDifficulty GetDifficulty() { return difficulty; }

	public void SetDifficulty(ContractDifficulty diff) { difficulty = diff; }

	public override string ToString()
	{
		return "Contract Payout " + payout.ToString();
	}

	public int CompareByCompletion(LumberContract compareContract)
	{
		if (compareContract == null)
		{
			return 1;
		}
		else
		{
			return this.CanBeCompleted().CompareTo(compareContract.CanBeCompleted());
		}
	}
}

[Serializable]
public class ContractDifficulty
{
	public int difficulty { get; set; }

	public int gradeFuncVal { get; set; }
	public int typeCount { get; set; }
	public int rangeMax { get; set; }

	public ContractDifficulty(int g, int t, int r)
	{
		gradeFuncVal = g;
		typeCount = t;
		rangeMax = r;

		difficulty = gradeFuncVal + (typeCount * rangeMax);
	}

	public int GetQualityGradeInt()
	{
		return 5 - gradeFuncVal;
	}

	public QualityGrade GetQualityGrade()
	{
		return (QualityGrade) (5 - gradeFuncVal);
	}
}