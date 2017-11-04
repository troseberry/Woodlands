// this is pretty homogenous
// what if you want resource quantities that have multiple of the same 
// resource but at different quality grades
// like both A-Grade and C-Grade logs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QualityGrade {A, B, C, D, F};
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
}
