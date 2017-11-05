using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContracts 
{
	private static List<LumberContract> activeContracts = new List<LumberContract>();


	public static List<LumberContract> GetActiveContractsList() { return activeContracts; }

	public static void SetActiveContractsList(List<LumberContract> newContracts) { activeContracts = newContracts; }

	//clamp this between 0 and max active contracts value
	public static void AddContract(LumberContract toAdd) { activeContracts.Add(toAdd); }

	public static void RemoveContractAtIndex(int index) { activeContracts.RemoveAt(index); }

	public static LumberContract GetContractAtIndex(int index) { return activeContracts[index]; }
	
}
