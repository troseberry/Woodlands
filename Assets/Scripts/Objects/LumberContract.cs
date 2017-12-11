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

	public LumberContract() {}

	public LumberContract(LumberResourceQuantity lumber, DevResourceQuantity pay, int deadline, ContractStatus startStatus)
	{
		requiredLumber = lumber;
		payout = pay;
		completionDeadline = deadline;
		status = startStatus;
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
