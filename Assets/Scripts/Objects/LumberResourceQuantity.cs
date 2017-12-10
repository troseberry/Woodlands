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
				firewood = firewood - (firewood % 6);
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
		DevResourceQuantity treeRate = FelledTreeExchangeRates[treeGrade.GetHashCode()];
		DevResourceQuantity logRate = LogExchangeRates[logGrade.GetHashCode()];
		DevResourceQuantity firewoodRate = FirewoodExchangeRates[firewoodGrade.GetHashCode()];

		int currency = (treeRate.GetCurrency() * trees) + (logRate.GetCurrency() * logs) + (firewoodRate.GetCurrency() * firewood);
		int materials = 0;
		int parts = 0;
		int pages = 0;

		int[] resourceIndexes =
		{
			UnityEngine.Random.Range(1, 4),
			UnityEngine.Random.Range(1, 4),
			UnityEngine.Random.Range(1, 4),
		};
		
		int [] lumberPayouts = 
		{
			treeRate.GetResourceAtIndex(resourceIndexes[0]) * trees,
			logRate.GetResourceAtIndex(resourceIndexes[1]) * (logs / 3),
			firewoodRate.GetResourceAtIndex(resourceIndexes[2]) * (firewood / 6),
		};
		
		for (int i = 0; i < resourceIndexes.Length; i++)
		{
			if (resourceIndexes[i] == 1) materials += lumberPayouts[i];
			else if (resourceIndexes[i] == 2) parts += lumberPayouts[i];
			else if (resourceIndexes[i] == 3) pages += lumberPayouts[i];
		}


		return new DevResourceQuantity(currency, materials, parts, pages);
	}

	private static DevResourceQuantity[] FelledTreeExchangeRates = new DevResourceQuantity[5]
	{
		// per 1 felled tree
		new DevResourceQuantity(50, 5, 3, 10),	// A
		new DevResourceQuantity(25, 4, 2, 8),
		new DevResourceQuantity(15, 3, 2, 6),
		new DevResourceQuantity(10, 2, 1, 4),
		new DevResourceQuantity(5, 1, 1, 2),	// F
	};

	private static DevResourceQuantity[] LogExchangeRates = new DevResourceQuantity[5]
	{
		// per 3 logs
		new DevResourceQuantity(80, 3, 5, 15),
		new DevResourceQuantity(40, 2, 4, 12),
		new DevResourceQuantity(20, 2, 3, 9),
		new DevResourceQuantity(10, 1, 2, 6),
		new DevResourceQuantity(5, 1, 1, 3),
	};

	private static DevResourceQuantity[] FirewoodExchangeRates = new DevResourceQuantity[5]
	{
		// per 6 firewood
		new DevResourceQuantity(160, 3, 10, 25),
		new DevResourceQuantity(80, 2, 8, 20),
		new DevResourceQuantity(40, 2, 6,15),
		new DevResourceQuantity(20, 1, 4, 10),
		new DevResourceQuantity(10, 1, 2, 5),
	};
}

