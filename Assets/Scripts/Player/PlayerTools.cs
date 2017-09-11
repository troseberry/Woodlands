using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerTools 
{
	private static List<Tool> ownedTools = new List<Tool>();


	public static List<Tool> GetOwnedToolsList() { return ownedTools; }

	public static void SetOwnedToolsList(List<Tool> newList) { ownedTools = newList; }

	public static void AddTool(Tool toAdd) 
	{
		Tool check = ownedTools.Find(tool => tool.GetToolName() == toAdd.GetToolName());
		if (!ownedTools.Contains(check))
		{
			ownedTools.Add(toAdd);
		}
		else
		{
			Debug.Log("Already Own tool");
		}
	}

	public static void AddNewTool(ToolName toAdd) { ownedTools.Add(new Tool(toAdd)); }		//quick method to add brand new tool

	public static void RemoveTool(ToolName toRemove) 
	{
		Tool item = ownedTools.Find(tool => tool.GetToolName() == toRemove);
		Debug.Log("Remove Attempt: " + item);
		ownedTools.Remove(item);
	}

	public static Tool GetToolAtIndex(int index) { return ownedTools[index]; }

	public static Tool GetToolByName(ToolName toFind)
	{
		return ownedTools.Find(tool => tool.GetToolName() == toFind);
	}


	public static DevResourceQuantity GetNextUpgradeCosts(ToolName name)
	{
		Tool toUpgrade = GetToolByName(name);
		return toUpgrade.GetDevResourceQuantityAtTier(toUpgrade.GetCurrentTier() + 1);
	}

	public static string GetNextUpgradeCostsAsString(ToolName name)
	{
		Tool toUpgrade = GetToolByName(name);
		return toUpgrade.GetDevResourceQuantityAtTier(toUpgrade.GetCurrentTier() + 1).ToString();
	}
	
}
