using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomesteadStockpile 
{
	//0 - 5 = F - A
	private static int[] trees = new int[5];
	private static int[] logs = new int[5];
	private static int[] firewood = new int[5];


	public static int[] GetAllTreesCount() { return trees; }

	public static void SetAllTreesCount(int[] newValue) { trees = newValue; }

	public static int GetTreesCountAtGrade(QualityGrade grade)
	{
		return trees[grade.GetHashCode()];
	}

	public static int GetTreesCountAtIndex(int index)
	{
		return trees[index];
	}

	public static string GetTreesCountAsString()
	{
		return "A: " + trees[4] + " | B: " + trees[3] + " | C: " + trees[2] + " | D: " + trees[1] + " | F: " + trees[0];
	}

	public static void SetTreesCountAtGrade(QualityGrade grade, int newValue)
	{
		trees[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberTreesValue());
	}

	public static void SetTreesCountAtIndex(int index, int newValue)
	{
		trees[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberTreesValue());
	}

	public static void UpdateTreesCountAtGrade(QualityGrade grade, int changeValue)
	{
		trees[grade.GetHashCode()] = Mathf.Clamp((trees[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetLumberTreesValue());
	}



	public static int[] GetAllLogsCount() { return logs; }

	public static void SetAllLogsCount(int[] newValue) { logs = newValue; }

	public static int GetLogsCountAtGrade(QualityGrade grade)
	{
		return logs[grade.GetHashCode()];
	}

	public static int GetLogsCountAtIndex(int index)
	{
		return logs[index];
	}

	public static string GetLogsCountAsString()
	{
		return "A: " + logs[4] + " | B: " + logs[3] + " | C: " + logs[2] + " | D: " + logs[1] + " | F: " + logs[0];
	}

	public static void SetLogsCountAtGrade(QualityGrade grade, int newValue)
	{
		logs[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberLogsValue());
	}

	public static void SetLogsCountAtIndex(int index, int newValue)
	{
		logs[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberLogsValue());
	}

	public static void UpdateLogsCountAtGrade(QualityGrade grade, int changeValue)
	{
		logs[grade.GetHashCode()] = Mathf.Clamp((logs[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetLumberLogsValue());
	}



	public static int[] GetAllFirewoodCount() { return firewood; }

	public static void SetAllFirewoodCount(int[] newValue) { firewood = newValue; }

	public static int GetFirewoodCountAtGrade(QualityGrade grade)
	{
		return firewood[grade.GetHashCode()];
	}

	public static int GetFirewoodCountAtIndex(int index)
	{
		return firewood[index];
	}

	public static string GetFirewoodCountAsString()
	{
		return "A: " + firewood[4] + " | B: " + firewood[3] + " | C: " + firewood[2] + " | D: " + firewood[1] + " | F: " + firewood[0];
	}

	public static void SetFirewoodCountAtGrade(QualityGrade grade, int newValue)
	{
		firewood[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberFirewoodValue());
	}

	public static void SetFirewoodCountAtIndex(int index, int newValue)
	{
		firewood[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetLumberFirewoodValue());
	}

	public static void UpdateFirewoodCountAtGrade(QualityGrade grade, int changeValue)
	{
		firewood[grade.GetHashCode()] = Mathf.Clamp((firewood[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetLumberFirewoodValue());
	}
}
