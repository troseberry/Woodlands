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


	private int overallDifficulty;
	private int difficultyGrade;
	private int difficultyTypeCount;
	private int difficultyRangeMax;

	public LumberContract() {}

	public LumberContract(LumberResourceQuantity lumber, DevResourceQuantity pay, int deadline, ContractStatus startStatus)
	{
		requiredLumber = lumber;
		payout = pay;
		completionDeadline = deadline;
		status = startStatus;
	}

	public LumberContract(int grade, int typeCount, int rangeMax)
	{

	}

	public LumberContract(int difficulty)
	{
		//basically need to write a polynomial solver to calculate possible values for g, t, and r when only d is known.
		//difficulty = grade + (typeCount * rangeVal)

		//d = g + tr;
		//tr = d - g;
		//g = d / tr;
		//t = (d - g) / r;
		//r = (d - g) / t;

		int grade = 0;
		int typeCount = 0;
		int rangeMax = 0;

		grade = UnityEngine.Random.Range(1, 6);
		difficulty -= grade;

		rangeMax = UnityEngine.Random.Range(1, 17);
		rangeMax = Mathf.Clamp(rangeMax, 1, difficulty);
		difficulty = difficulty / rangeMax;

		typeCount = UnityEngine.Random.Range(1, 4);
		typeCount = Mathf.Clamp(typeCount, 1, difficulty);
		difficulty -= typeCount;

		
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

public class ContractDifficulty
{
	private int difficulty;

	public int grade { get; set; }
	public int typeCount { get; set; }
	public int rangeMax { get; set; }

	public ContractDifficulty(int g, int t, int r)
	{
		grade = g;
		typeCount = t;
		rangeMax = r;

		difficulty = grade + (typeCount * rangeMax);
	}
}