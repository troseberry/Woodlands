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

	public static void SetTreesCountAtGrade(QualityGrade grade, int newValue)
	{
		trees[grade.GetHashCode()] = newValue;
	}

	public static void UpdateTreesCountAtGrade(QualityGrade grade, int changeValue)
	{
		trees[grade.GetHashCode()] += changeValue;
	}



	public static int[] GetAllLogsCount() { return logs; }

	public static void SetAllLogsCount(int[] newValue) { logs = newValue; }

	public static int GetLogsCountAtGrade(QualityGrade grade)
	{
		return logs[grade.GetHashCode()];
	}

	public static void SetLogsCountAtGrade(QualityGrade grade, int newValue)
	{
		logs[grade.GetHashCode()] = newValue;
	}

	public static void UpdateLogsCountAtGrade(QualityGrade grade, int changeValue)
	{
		logs[grade.GetHashCode()] += changeValue;
	}



	public static int[] GetAllFirewoodCount() { return firewood; }

	public static void SetAllFirewoodCount(int[] newValue) { firewood = newValue; }

	public static int GetFirewoodCountAtGrade(QualityGrade grade)
	{
		return firewood[grade.GetHashCode()];
	}

	public static void SetFirewoodCountAtGrade(QualityGrade grade, int newValue)
	{
		firewood[grade.GetHashCode()] = newValue;
	}

	public static void UpdateFirewoodCountAtGrade(QualityGrade grade, int changeValue)
	{
		firewood[grade.GetHashCode()] += changeValue;
	}
}
