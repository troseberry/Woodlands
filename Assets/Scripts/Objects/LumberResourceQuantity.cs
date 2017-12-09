// this is pretty homogenous
// what if you want resource quantities that have multiple of the same 
// resource but at different quality grades
// like both A-Grade and C-Grade logs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public enum QualityGrade {A, B, C, D, F};		//Hash Code: 0 - 4 

[Serializable]
public class LumberResourceQuantity 
{
	private int trees;
	private int logs;
	private int firewood;

	private QualityGrade treeGrade;
	private QualityGrade logGrade;
	private QualityGrade firewoodGrade;

	public LumberResourceQuantity(int t, QualityGrade tGrade, int l, QualityGrade lGrade, int f, QualityGrade fGrade)
	{
		trees = t;
		treeGrade = tGrade;

		logs = l;
		logGrade = lGrade;

		firewood = f;
		firewoodGrade = fGrade;
	}

	public LumberResourceQuantity(bool doRandom, int typeCount)
	{
		trees = 0;
		treeGrade = QualityGrade.F;

		logs = 0;
		logGrade = QualityGrade.F;

		firewood = 0;
		firewoodGrade = QualityGrade.F;

		if (doRandom)
		{
			trees = UnityEngine.Random.Range(1, PlayerSkills.GetMaxLumberTreesValue());
			int fellingAxeGrade = (PlayerTools.GetToolByName(ToolName.FELLING_AXE).GetTierQualityGradeEquivalent());
			treeGrade = (QualityGrade) UnityEngine.Random.Range(4, fellingAxeGrade);

			if (typeCount >= 2)
			{
				logs = UnityEngine.Random.Range(3, PlayerSkills.GetMaxLumberLogsValue());
				logs = logs - (logs % 3);
				int crosscutSawGrade = (PlayerTools.GetToolByName(ToolName.CROSSCUT_SAW).GetTierQualityGradeEquivalent());
				logGrade = (QualityGrade) UnityEngine.Random.Range(4, crosscutSawGrade);
			}

			if (typeCount == 3)
			{
				firewood = UnityEngine.Random.Range(2, PlayerSkills.GetMaxLumberFirewoodValue());
				firewood = firewood - (firewood % 2);
				int splittingAxeGrade = (PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).GetTierQualityGradeEquivalent());
				firewoodGrade = (QualityGrade) UnityEngine.Random.Range(4, splittingAxeGrade);
			}
		}
	}

	public void SetTrees(int newT) { trees = newT; }

	public int GetTrees() { return trees; }

	public void SetTreeGrade(QualityGrade newGrade) { treeGrade = newGrade; }

	public QualityGrade GetTreeGrade() { return treeGrade; }

	public void SetLogs(int newL) { logs = newL; }

	public int GetLogs() { return logs; }

	public void SetLogGrade(QualityGrade newGrade) { logGrade = newGrade; }

	public QualityGrade GetLogGrade() { return logGrade; }

	public void SetFirewood(int newF) { firewood = newF; }

	public int GetFirewood() { return firewood; }

	public void SetFirewoodGrade(QualityGrade newGrade) { firewoodGrade = newGrade; }

	public QualityGrade GetFirewoodGrade() { return firewoodGrade; }


	public bool HasInStockpile()
	{
		bool hasTrees = HomesteadStockpile.GetTreesCountAtGrade(treeGrade) >= trees;
		bool hasLogs = HomesteadStockpile.GetLogsCountAtGrade(logGrade) >= logs;
		bool hasFirewood = HomesteadStockpile.GetFirewoodCountAtGrade(firewoodGrade) >= firewood;

		return hasTrees && hasLogs && hasFirewood;
	}

	public void SubtractFromStockpile()
	{
		HomesteadStockpile.UpdateTreesCountAtGrade(treeGrade, -trees);
		HomesteadStockpile.UpdateLogsCountAtGrade(logGrade, -logs);
		HomesteadStockpile.UpdateFirewoodCountAtGrade(firewoodGrade, -firewood);
	}


	public override string ToString()
	{
		return "T: " + trees + " (" + treeGrade + ")"
		+ " | L: " + logs + " (" + logGrade + ")"
		+ " | F: "  + firewood + " (" + firewoodGrade + ")";
	}

	public string StringWithoutQuality()
	{
		return "T: " + trees + " | L: " + logs + " | F: "  + firewood;
	}

	public DevResourceQuantity GenerateDevResourcePayout()
	{
		int totalLumber = trees + logs + firewood;

		int currency = Mathf.RoundToInt(totalLumber /4);
		totalLumber -= currency;
		currency = (5 - (currency % 5)) + currency;

		// Debug.Log("Total After Currency: " + totalLumber);

		float percOne = 1 / UnityEngine.Random.Range(1, 100);
		float percTwo = 1 / UnityEngine.Random.Range(percOne, 100);
		float percThree = 1 / UnityEngine.Random.Range(percTwo, 100);

		// Debug.Log("Percent One: " + percOne);
		// Debug.Log("Percent Two: " + percTwo);
		// Debug.Log("Percent Three: " + percThree);


		int materials = Mathf.RoundToInt(totalLumber * percOne);
		if (materials > 0) materials = (5 - (materials % 5)) + materials;

		int parts = Mathf.RoundToInt(totalLumber * percTwo);
		if (parts > 0) parts = (5 - (parts % 5)) + parts;

		int pages = Mathf.RoundToInt(totalLumber * percThree);
		if (pages > 0) pages = (5 - (pages % 5)) + pages;

		return new DevResourceQuantity(currency, materials, parts, pages);
	}
}

