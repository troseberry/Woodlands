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

	public LumberResourceQuantity(ContractDifficulty difficulty)
	{
		int[] currentRange = LumberContractHelper.GetRangeSubdivisionArrayIndexes(difficulty.rangeMax);

		if (difficulty.rangeMax > 1)
		{
			int[] previousRange = LumberContractHelper.GetRangeSubdivisionArrayIndexes(difficulty.rangeMax - 1);

			int lowerTreeBound = LumberContractHelper.FelledTreeRangeDivisions[previousRange[0]] [previousRange[1]];
			int upperTreeBound = LumberContractHelper.FelledTreeRangeDivisions[currentRange[0]] [currentRange[1]];

			trees = UnityEngine.Random.Range(upperTreeBound, lowerTreeBound);

			if (difficulty.typeCount >= 2)
			{
				int lowerLogBound = LumberContractHelper.LogRangeDivisions[previousRange[0]] [previousRange[1]];
				int upperLogBound = LumberContractHelper.LogRangeDivisions[currentRange[0]] [currentRange[1]];

				logs = UnityEngine.Random.Range(upperLogBound, lowerLogBound);
				logs = logs - (logs % 3);
			}

			if (difficulty.typeCount == 3)
			{
				int lowerFirewoodBound = LumberContractHelper.FirewoodRangeDiviions[previousRange[0]] [previousRange[1]];
				int upperFirewoodBound = LumberContractHelper.FirewoodRangeDiviions[currentRange[0]] [currentRange[1]];

				firewood = UnityEngine.Random.Range(upperFirewoodBound, lowerFirewoodBound);
				firewood = firewood - (firewood % 6);
			}
		}
		else
		{
			int upperTreeBound = LumberContractHelper.FelledTreeRangeDivisions[currentRange[0]] [currentRange[1]];
			trees = UnityEngine.Random.Range(upperTreeBound, 0);

			if (difficulty.typeCount >= 2)
			{
				int upperLogBound = LumberContractHelper.LogRangeDivisions[currentRange[0]] [currentRange[1]];

				logs = UnityEngine.Random.Range(upperLogBound, 0);
				logs = logs - (logs % 3);
			}

			if (difficulty.typeCount == 3)
			{
				int upperFirewoodBound = LumberContractHelper.FirewoodRangeDiviions[currentRange[0]] [currentRange[1]];

				firewood = UnityEngine.Random.Range(upperFirewoodBound, 0);
				firewood = firewood - (firewood % 6);
			}
		}

		treeGrade = difficulty.GetQualityGrade();
		logGrade = difficulty.GetQualityGrade();
		firewoodGrade = difficulty.GetQualityGrade();
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
		DevResourceQuantity treeRate = LumberContractHelper.FelledTreeExchangeRates[treeGrade.GetHashCode()];
		DevResourceQuantity logRate = LumberContractHelper.LogExchangeRates[logGrade.GetHashCode()];
		DevResourceQuantity firewoodRate = LumberContractHelper.FirewoodExchangeRates[firewoodGrade.GetHashCode()];

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
}


