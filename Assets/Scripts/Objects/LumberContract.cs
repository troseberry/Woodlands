using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[Serializable]
public class LumberContract 
{
	private LumberResourceQuantity requiredLumber;
	private DevResourceQuantity payout;
	private int completionDeadline;

	public LumberContract() {}

	public LumberContract(LumberResourceQuantity lumber, DevResourceQuantity pay, int deadline)
	{
		requiredLumber = lumber;
		payout = pay;
		completionDeadline = deadline;
	}

	public LumberResourceQuantity GetRequiredLumber() { return requiredLumber; }

	public void SetRequiredLumber(LumberResourceQuantity lumber) { requiredLumber = lumber; }

	public DevResourceQuantity GetPayout() { return payout; }

	public void SetPayout(DevResourceQuantity pay) { payout = pay; }

	public int GetCompletionDeadline() { return completionDeadline; }

	public void SetCompletionDeadline(int deadline) { completionDeadline = deadline;}

	public override string ToString()
	{
		return "Contract Payout " + payout.ToString();
	}
}
