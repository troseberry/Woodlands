using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SaveableData 
{
	public List<LumberContract> activeContracts;

	public int currentEnergy;

	public int currentCurrency;
	public int currentBuildingMaterials;
	public int currentToolParts;
	public int currentBookPages;

	public int[] homesteadTreesCount;
	public int[] homesteadLogsCount;
	public int[] homesteadFirewoodCount;

	public List<Tool> ownedTools;
}