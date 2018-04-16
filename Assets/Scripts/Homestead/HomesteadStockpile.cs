using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomesteadStockpile 
{
	//0 - 5 = F - A
	private static int[] trees = new int[5]{0, 0, 5, 0, 0};
	private static int[] logs = new int[5]{0, 5, 0, 0, 0};
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
		return "F: " + trees[0] + " | D: " + trees[1] + " | C: " + trees[2] + " | B: " + trees[3] + " | A: " + trees[4];
	}

	public static void SetTreesCountAtGrade(QualityGrade grade, int newValue)
	{
		trees[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberTreesValue());
	}

	public static void SetTreesCountAtIndex(int index, int newValue)
	{
		trees[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberTreesValue());
	}

	public static void UpdateTreesCountAtGrade(QualityGrade grade, int changeValue)
	{
		trees[grade.GetHashCode()] = Mathf.Clamp((trees[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetMaxLumberTreesValue());
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
		return "F: " + logs[0] + " | D: " + logs[1] + " | C: " + logs[2] + " | B: " + logs[3] + " | A: " + logs[4];
	}

	public static void SetLogsCountAtGrade(QualityGrade grade, int newValue)
	{
		logs[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberLogsValue());
	}

	public static void SetLogsCountAtIndex(int index, int newValue)
	{
		logs[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberLogsValue());
	}

	public static void UpdateLogsCountAtGrade(QualityGrade grade, int changeValue)
	{
		logs[grade.GetHashCode()] = Mathf.Clamp((logs[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetMaxLumberLogsValue());
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
		return "F: " + firewood[0] + " | D: " + firewood[1] + " | C: " + firewood[2] + " | B: " + firewood[3] + " | A: " + firewood[4];
	}

	public static void SetFirewoodCountAtGrade(QualityGrade grade, int newValue)
	{
		firewood[grade.GetHashCode()] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberFirewoodValue());
	}

	public static void SetFirewoodCountAtIndex(int index, int newValue)
	{
		firewood[index] = Mathf.Clamp(newValue, 0, PlayerSkills.GetMaxLumberFirewoodValue());
	}

	public static void UpdateFirewoodCountAtGrade(QualityGrade grade, int changeValue)
	{
		firewood[grade.GetHashCode()] = Mathf.Clamp((firewood[grade.GetHashCode()] += changeValue), 0, PlayerSkills.GetMaxLumberFirewoodValue());
	}
}
