using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContracts 
{
	private static List<LumberContract> activeContracts = new List<LumberContract>();


	public static List<LumberContract> GetActiveContractsList() { return activeContracts; }

	public static void SetActiveContractsList(List<LumberContract> newContracts) { activeContracts = newContracts; }

	public static void AddContract(LumberContract toAdd)
	{
		if (activeContracts.Count < PlayerSkills.GetMaxActiveContractsValue()) activeContracts.Add(toAdd);
	}

	public static bool CanAdd() { return activeContracts.Count < PlayerSkills.GetMaxActiveContractsValue(); }

	public static void RemoveContractAtIndex(int index) { activeContracts.RemoveAt(index); }

	public static LumberContract GetContractAtIndex(int index) { return activeContracts[index]; }
	
	public static void ProgressAllContractDeadlines()
	{
		List<int> expiredContracts = new List<int>();

		for (int i = 0; i < activeContracts.Count; i++)
		{
			activeContracts[i].DecrementDeadline();
			if (activeContracts[i].IsExpired()) expiredContracts.Add(i);
		}

		// currently just going to remove from active contracts list
		// should probably just mark as expired and let the player handle removing

		// for (int j = expiredContracts.Count - 1; j >= 0; j--)
		// {
		// 	activeContracts.RemoveAt(expiredContracts[j]);
		// }
	}
}
