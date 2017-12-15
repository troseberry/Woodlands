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

	public LumberResourceQuantity(int difficulty)
	{
		// int[] test = DifficultyDictionary[difficulty];
	}

	public LumberResourceQuantity(int grade, int typeCount, int rangeMax)
	{
		int[] currentRange = GetRangeSubdivisionArrayIndexes(rangeMax);

		if (rangeMax > 1)
		{
			int[] previousRange = GetRangeSubdivisionArrayIndexes(rangeMax - 1);

			int lowerTreeBound = FelledTreeRangeDivisions[previousRange[0]] [previousRange[1]];
			int upperTreeBound = FelledTreeRangeDivisions[currentRange[0]] [currentRange[1]];

			trees = UnityEngine.Random.Range(upperTreeBound, lowerTreeBound);

			if (typeCount >= 2)
			{
				int lowerLogBound = LogRangeDivisions[previousRange[0]] [previousRange[1]];
				int upperLogBound = LogRangeDivisions[currentRange[0]] [currentRange[1]];

				logs = UnityEngine.Random.Range(upperLogBound, lowerLogBound);
				logs = logs - (logs % 3);
			}

			if (typeCount == 3)
			{
				int lowerFirewoodBound = FirewoodRangeDiviions[previousRange[0]] [previousRange[1]];
				int upperFirewoodBound = FirewoodRangeDiviions[currentRange[0]] [currentRange[1]];

				firewood = UnityEngine.Random.Range(upperFirewoodBound, lowerFirewoodBound);
				firewood = firewood - (firewood % 6);
			}
		}
		else
		{
			int upperTreeBound = FelledTreeRangeDivisions[currentRange[0]] [currentRange[1]];
			trees = UnityEngine.Random.Range(upperTreeBound, 0);

			if (typeCount >= 2)
			{
				int upperLogBound = LogRangeDivisions[currentRange[0]] [currentRange[1]];

				logs = UnityEngine.Random.Range(upperLogBound, 0);
				logs = logs - (logs % 3);
			}

			if (typeCount == 3)
			{
				int upperFirewoodBound = FirewoodRangeDiviions[currentRange[0]] [currentRange[1]];

				firewood = UnityEngine.Random.Range(upperFirewoodBound, 0);
				firewood = firewood - (firewood % 6);
			}
		}

		treeGrade = (QualityGrade) grade;
		logGrade = (QualityGrade) grade;
		firewoodGrade = (QualityGrade) grade;
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


	private static int[][] FelledTreeRangeDivisions = 
	{
		new int[] {2, 5},
		new int[] {7, 10},
		new int[] {15, 20, 25},
		new int[] {31, 37, 43, 50},
		new int[] {60, 70, 80, 90, 100}
	};

	private static int[][] LogRangeDivisions = 
	{
		new int[] {12, 24},
		new int[] {36, 48},
		new int[] {63, 81, 99},
		new int[] {135, 171, 210, 249},
		new int[] {297, 345,396, 447, 498}
	};

	private static int[][] FirewoodRangeDiviions =
	{
		new int[] {24, 48},
		new int[] {72, 96},
		new int[] {150, 198, 246},
		new int[] {312, 372, 432, 498},
		new int[] {600, 696, 798, 900, 996}
	};

	private int[] GetRangeSubdivisionArrayIndexes(int rangeValue)
	{
		switch(rangeValue)
		{
			case 1:
				return new int[] {0, 0};
			case 2:
				return new int[] {0, 1};
			case 3:
				return new int[] {1, 0};
			case 4:
				return new int[] {1, 1};
			case 5:
				return new int[] {2, 1};
			case 6:
				return new int[] {2, 2};
			case 7:
				return new int[] {2, 3};
			case 8:
				return new int[] {3, 1};
			case 9:
				return new int[] {3, 2};
			case 10:
				return new int[] {3, 3};
			case 11:
				return new int[] {3, 4};
			case 12:
				return new int[] {4, 0};
			case 13:
				return new int[] {4, 1};
			case 14:
				return new int[] {4, 2};
			case 15:
				return new int[] {4, 3};
			case 16:
				return new int[] {4, 4};
		}
		return new int[]{-1, -1};
	}

	private Dictionary<int, int[]> DifficultyDictionary = new Dictionary<int, int[]>()
	{
		//difficulty, {grade, typeCount, rangeMax}
		{2, new int[3] {1, 1, 1}},
		{3, new int[3] {1, 1, 2}},
		
		{4, new int[3] {1, 1, 3}},
		{5, new int[3] {1, 1, 4}},
		{6, new int[3] {1, 1, 5}},
		{7, new int[3] {1, 1, 6}},
		{8, new int[3] {1, 1, 7}},
		{9, new int[3] {1, 1, 8}},
		{10, new int[3] {1, 1, 9}},
		{11, new int[3] {1, 1, 10}},
		{12, new int[3] {1, 1, 11}},
		{13, new int[3] {1, 1, 12}},
		{14, new int[3] {1, 1, 13}},
		{15, new int[3] {1, 1, 14}},
		{16, new int[3] {1, 1, 15}},
		{17, new int[3] {1, 1, 16}},

		{3, new int[3] {1, 2, 1}},
		{5, new int[3] {1, 2, 2}},
		{7, new int[3] {1, 2, 3}},
		{9, new int[3] {1, 2, 4}},
		{11, new int[3] {1, 2, 5}},
		{13, new int[3] {1, 2, 6}},
		{15, new int[3] {1, 2, 7}},
		{17, new int[3] {1, 2, 8}},
		{19, new int[3] {1, 2, 9}},
		{21, new int[3] {1, 2, 10}},
		{23, new int[3] {1, 2, 11}},
		{25, new int[3] {1, 2, 12}},
		{27, new int[3] {1, 2, 13}},
		{29, new int[3] {1, 2, 14}},
		{31, new int[3] {1, 2, 15}},
		{33, new int[3] {1, 2, 16}},

		{4, new int[3] {1, 3, 1}},
		{7, new int[3] {1, 3, 2}},
		{10, new int[3] {1, 3, 3}},
		{13, new int[3] {1, 3, 4}},
		{16, new int[3] {1, 3, 5}},
		{19, new int[3] {1, 3, 6}},
		{22, new int[3] {1, 3, 7}},
		{25, new int[3] {1, 3, 8}},
		{28, new int[3] {1, 3, 9}},
		{31, new int[3] {1, 3, 10}},
		{34, new int[3] {1, 3, 11}},
		{37, new int[3] {1, 3, 12}},
		{40, new int[3] {1, 3, 13}},
		{43, new int[3] {1, 3, 14}},
		{46, new int[3] {1, 3, 15}},
		{49, new int[3] {1, 3, 16}},



		{3, new int[3] {2, 1, 1}},
		{4, new int[3] {2, 1, 2}},
		{5, new int[3] {2, 1, 3}},
		{6, new int[3] {2, 1, 4}},
		{7, new int[3] {2, 1, 5}},
		{8, new int[3] {2, 1, 6}},
		{9, new int[3] {2, 1, 7}},
		{10, new int[3] {2, 1, 8}},
		{11, new int[3] {2, 1, 9}},
		{12, new int[3] {2, 1, 10}},
		{13, new int[3] {2, 1, 11}},
		{14, new int[3] {2, 1, 12}},
		{15, new int[3] {2, 1, 13}},
		{16, new int[3] {2, 1, 14}},
		{17, new int[3] {2, 1, 15}},
		{18, new int[3] {2, 1, 16}},

		{4, new int[3] {2, 2, 1}},
		{6, new int[3] {2, 2, 2}},
		{8, new int[3] {2, 2, 3}},
		{10, new int[3] {2, 2, 4}},
		{12, new int[3] {2, 2, 5}},
		{14, new int[3] {2, 2, 6}},
		{16, new int[3] {2, 2, 7}},
		{18, new int[3] {2, 2, 8}},
		{20, new int[3] {2, 2, 9}},
		{22, new int[3] {2, 2, 10}},
		{24, new int[3] {2, 2, 11}},
		{26, new int[3] {2, 2, 12}},
		{28, new int[3] {2, 2, 13}},
		{30, new int[3] {2, 2, 14}},
		{32, new int[3] {2, 2, 15}},
		{34, new int[3] {2, 2, 16}},

		{5, new int[3] {2, 3, 1}},
		{8, new int[3] {2, 3, 2}},
		{11, new int[3] {2, 3, 3}},
		{14, new int[3] {2, 3, 4}},
		{17, new int[3] {2, 3, 5}},
		{20, new int[3] {2, 3, 6}},
		{23, new int[3] {2, 3, 7}},
		{26, new int[3] {2, 3, 8}},
		{29, new int[3] {2, 3, 9}},
		{32, new int[3] {2, 3, 10}},
		{35, new int[3] {2, 3, 11}},
		{38, new int[3] {2, 3, 12}},
		{41, new int[3] {2, 3, 13}},
		{44, new int[3] {2, 3, 14}},
		{47, new int[3] {2, 3, 15}},
		{50, new int[3] {2, 3, 16}},



		{4, new int[3] {3, 1, 1}},
		{5, new int[3] {3, 1, 2}},
		{6, new int[3] {3, 1, 3}},
		{7, new int[3] {3, 1, 4}},
		{8, new int[3] {3, 1, 5}},
		{9, new int[3] {3, 1, 6}},
		{10, new int[3] {3, 1, 7}},
		{11, new int[3] {3, 1, 8}},
		{12, new int[3] {3, 1, 9}},
		{13, new int[3] {3, 1, 10}},
		{14, new int[3] {3, 1, 11}},
		{15, new int[3] {3, 1, 12}},
		{16, new int[3] {3, 1, 13}},
		{17, new int[3] {3, 1, 14}},
		{18, new int[3] {3, 1, 15}},
		{19, new int[3] {3, 1, 16}},

		{5, new int[3] {3, 2, 1}},
		{7, new int[3] {3, 2, 2}},
		{9, new int[3] {3, 2, 3}},
		{11, new int[3] {3, 2, 4}},
		{13, new int[3] {3, 2, 5}},
		{15, new int[3] {3, 2, 6}},
		{17, new int[3] {3, 2, 7}},
		{19, new int[3] {3, 2, 8}},
		{21, new int[3] {3, 2, 9}},
		{23, new int[3] {3, 2, 10}},
		{25, new int[3] {3, 2, 11}},
		{27, new int[3] {3, 2, 12}},
		{29, new int[3] {3, 2, 13}},
		{31, new int[3] {3, 2, 14}},
		{33, new int[3] {3, 2, 15}},
		{35, new int[3] {3, 2, 16}},

		{6, new int[3] {3, 3, 1}},
		{9, new int[3] {3, 3, 2}},
		{12, new int[3] {3, 3, 3}},
		{15, new int[3] {3, 3, 4}},
		{18, new int[3] {3, 3, 5}},
		{21, new int[3] {3, 3, 6}},
		{24, new int[3] {3, 3, 7}},
		{27, new int[3] {3, 3, 8}},
		{30, new int[3] {3, 3, 9}},
		{33, new int[3] {3, 3, 10}},
		{36, new int[3] {3, 3, 11}},
		{39, new int[3] {3, 3, 12}},
		{42, new int[3] {3, 3, 13}},
		{45, new int[3] {3, 3, 14}},
		{48, new int[3] {3, 3, 15}},
		{51, new int[3] {3, 3, 16}},



		{5, new int[3] {4, 1, 1}},
		{6, new int[3] {4, 1, 2}},
		{7, new int[3] {4, 1, 3}},
		{8, new int[3] {4, 1, 4}},
		{9, new int[3] {4, 1, 5}},
		{10, new int[3] {4, 1, 6}},
		{11, new int[3] {4, 1, 7}},
		{12, new int[3] {4, 1, 8}},
		{13, new int[3] {4, 1, 9}},
		{14, new int[3] {4, 1, 10}},
		{15, new int[3] {4, 1, 11}},
		{16, new int[3] {4, 1, 12}},
		{17, new int[3] {4, 1, 13}},
		{18, new int[3] {4, 1, 14}},
		{19, new int[3] {4, 1, 15}},
		{20, new int[3] {4, 1, 16}},

		{6, new int[3] {4, 2, 1}},
		{8, new int[3] {4, 2, 2}},
		{10, new int[3] {4, 2, 3}},
		{12, new int[3] {4, 2, 4}},
		{14, new int[3] {4, 2, 5}},
		{16, new int[3] {4, 2, 6}},
		{18, new int[3] {4, 2, 7}},
		{20, new int[3] {4, 2, 8}},
		{22, new int[3] {4, 2, 9}},
		{24, new int[3] {4, 2, 10}},
		{26, new int[3] {4, 2, 11}},
		{28, new int[3] {4, 2, 12}},
		{30, new int[3] {4, 2, 13}},
		{32, new int[3] {4, 2, 14}},
		{34, new int[3] {4, 2, 15}},
		{36, new int[3] {4, 2, 16}},

		{7, new int[3] {4, 3, 1}},
		{10, new int[3] {4, 3, 2}},
		{13, new int[3] {4, 3, 3}},
		{16, new int[3] {4, 3, 4}},
		{19, new int[3] {4, 3, 5}},
		{22, new int[3] {4, 3, 6}},
		{25, new int[3] {4, 3, 7}},
		{28, new int[3] {4, 3, 8}},
		{31, new int[3] {4, 3, 9}},
		{34, new int[3] {4, 3, 10}},
		{37, new int[3] {4, 3, 11}},
		{40, new int[3] {4, 3, 12}},
		{43, new int[3] {4, 3, 13}},
		{46, new int[3] {4, 3, 14}},
		{49, new int[3] {4, 3, 15}},
		{52, new int[3] {4, 3, 16}},



		{6, new int[3] {5, 1, 1}},
		{7, new int[3] {5, 1, 2}},
		{8, new int[3] {5, 1, 3}},
		{9, new int[3] {5, 1, 4}},
		{10, new int[3] {5, 1, 5}},
		{11, new int[3] {5, 1, 6}},
		{12, new int[3] {5, 1, 7}},
		{13, new int[3] {5, 1, 8}},
		{14, new int[3] {5, 1, 9}},
		{15, new int[3] {5, 1, 10}},
		{16, new int[3] {5, 1, 11}},
		{17, new int[3] {5, 1, 12}},
		{18, new int[3] {5, 1, 13}},
		{19, new int[3] {5, 1, 14}},
		{20, new int[3] {5, 1, 15}},
		{21, new int[3] {5, 1, 16}},

		{7, new int[3] {5, 2, 1}},
		{9, new int[3] {5, 2, 2}},
		{11, new int[3] {5, 2, 3}},
		{13, new int[3] {5, 2, 4}},
		{15, new int[3] {5, 2, 5}},
		{17, new int[3] {5, 2, 6}},
		{19, new int[3] {5, 2, 7}},
		{21, new int[3] {5, 2, 8}},
		{23, new int[3] {5, 2, 9}},
		{25, new int[3] {5, 2, 10}},
		{27, new int[3] {5, 2, 11}},
		{29, new int[3] {5, 2, 12}},
		{31, new int[3] {5, 2, 13}},
		{33, new int[3] {5, 2, 14}},
		{35, new int[3] {5, 2, 15}},
		{37, new int[3] {5, 2, 16}},

		{8, new int[3] {5, 3, 1}},
		{11, new int[3] {5, 3, 2}},
		{14, new int[3] {5, 3, 3}},
		{17, new int[3] {5, 3, 4}},
		{20, new int[3] {5, 3, 5}},
		{23, new int[3] {5, 3, 6}},
		{26, new int[3] {5, 3, 7}},
		{29, new int[3] {5, 3, 8}},
		{32, new int[3] {5, 3, 9}},
		{35, new int[3] {5, 3, 10}},
		{38, new int[3] {5, 3, 11}},
		{41, new int[3] {5, 3, 12}},
		{44, new int[3] {5, 3, 13}},
		{47, new int[3] {5, 3, 14}},
		{50, new int[3] {5, 3, 15}},
		{53, new int[3] {5, 3, 16}},
	};
}

