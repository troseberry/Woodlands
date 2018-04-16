using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LumberContractHelper  
{

	public static DevResourceQuantity[] FelledTreeExchangeRates = new DevResourceQuantity[5]
	{
		// per 1 felled tree
		new DevResourceQuantity(5, 1, 1, 2),	// F
		new DevResourceQuantity(10, 2, 1, 4),
		new DevResourceQuantity(15, 3, 2, 6),
		new DevResourceQuantity(25, 4, 2, 8),
		new DevResourceQuantity(50, 5, 3, 10),	// A
	};

	public static DevResourceQuantity[] LogExchangeRates = new DevResourceQuantity[5]
	{
		// per 3 logs
		new DevResourceQuantity(5, 1, 1, 3),
		new DevResourceQuantity(10, 1, 2, 6),
		new DevResourceQuantity(20, 2, 3, 9),
		new DevResourceQuantity(40, 2, 4, 12),
		new DevResourceQuantity(80, 3, 5, 15),
	};

	public static DevResourceQuantity[] FirewoodExchangeRates = new DevResourceQuantity[5]
	{
		// per 6 firewood
		new DevResourceQuantity(10, 1, 2, 5),
		new DevResourceQuantity(20, 1, 4, 10),
		new DevResourceQuantity(40, 2, 6,15),
		new DevResourceQuantity(80, 2, 8, 20),
		new DevResourceQuantity(160, 3, 10, 25),
	};

	public static int[][] FelledTreeRangeDivisions = 
	{
		new int[] {2, 5},
		new int[] {7, 10},
		new int[] {15, 20, 25},
		new int[] {31, 37, 43, 50},
		new int[] {60, 70, 80, 90, 100}
	};

	public static int[][] LogRangeDivisions = 
	{
		new int[] {12, 24},
		new int[] {36, 48},
		new int[] {63, 81, 99},
		new int[] {135, 171, 210, 249},
		new int[] {297, 345,396, 447, 498}
	};

	public static int[][] FirewoodRangeDiviions =
	{
		new int[] {24, 48},
		new int[] {72, 96},
		new int[] {150, 198, 246},
		new int[] {312, 372, 432, 498},
		new int[] {600, 696, 798, 900, 996}
	};

	public static int[] GetRangeSubdivisionArrayIndexes(int rangeValue)
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



	public static Dictionary<int, ContractDifficulty[]> DifficultyDictionary = new Dictionary<int, ContractDifficulty[]>()
	{
		//difficulty, {grade, typeCount, rangeMax}
		{2, new ContractDifficulty[] { new ContractDifficulty (1, 1, 1) }},
		
		{3, new ContractDifficulty[]
		{
			new ContractDifficulty (0, 1, 2),
			new ContractDifficulty (0, 2, 1),
			new ContractDifficulty (1, 1, 1)
		}}, 
		
		{4, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 3),
			new ContractDifficulty(0, 3, 1),
			new ContractDifficulty(1, 1, 2),
			new ContractDifficulty(1, 2, 1),
			new ContractDifficulty(2, 1, 1)
		}},

		{5, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 4),
			new ContractDifficulty(0, 2, 2),
			new ContractDifficulty(1, 1, 3),
			new ContractDifficulty(1, 3, 1),
			new ContractDifficulty(2, 1, 2),
			new ContractDifficulty(2, 2, 1),
			new ContractDifficulty(3, 1, 1)
		}},

		{6, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 1, 5),
			new ContractDifficulty(1, 1, 4),
			new ContractDifficulty(1, 2, 2),
			new ContractDifficulty(2, 1, 3),
			new ContractDifficulty(2, 3, 1),
			new ContractDifficulty(3, 1, 2),
			new ContractDifficulty(3, 2, 1),
			new ContractDifficulty(4, 1, 1)
		}},

		{7, new ContractDifficulty[]
		{ 
			new ContractDifficulty(0, 1, 6),
			new ContractDifficulty(0, 2, 3),
			new ContractDifficulty(0, 3, 2),
			new ContractDifficulty(1, 1, 5),
			new ContractDifficulty(2, 1, 4),
			new ContractDifficulty(2, 2, 2),
			new ContractDifficulty(3, 1, 3),
			new ContractDifficulty(3, 3, 1),
			new ContractDifficulty(4, 1, 2),
			new ContractDifficulty(4, 2, 1)
		}},	

		{8, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 7),
			new ContractDifficulty(1, 1, 6),
			new ContractDifficulty(1, 2, 3),
			new ContractDifficulty(1, 3, 2),
			new ContractDifficulty(2, 1, 5),
			new ContractDifficulty(3, 1, 4),
			new ContractDifficulty(3, 2, 2),
			new ContractDifficulty(4, 1, 3),
			new ContractDifficulty(4, 3, 1)
		}},
		
		{9, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 1, 8),
			new ContractDifficulty(0, 2, 4),
			new ContractDifficulty(1, 1, 7),
			new ContractDifficulty(2, 1, 6),
			new ContractDifficulty(2, 2, 3),
			new ContractDifficulty(2, 3, 2),
			new ContractDifficulty(3, 1, 5),
			new ContractDifficulty(4, 1, 4),
			new ContractDifficulty(4, 2, 2)
		}},
		
		{10, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 1, 9),
			new ContractDifficulty(0, 3, 3),
			new ContractDifficulty(1, 1, 8),
			new ContractDifficulty(1, 2, 4),
			new ContractDifficulty(2, 1, 7),
			new ContractDifficulty(3, 1, 6),
			new ContractDifficulty(3, 2, 3),
			new ContractDifficulty(3, 3, 2),
			new ContractDifficulty(4, 1, 5)
		}},

		{11, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 10),
			new ContractDifficulty(0, 2, 5),
			new ContractDifficulty(1, 1, 9),
			new ContractDifficulty(1, 3, 3),
			new ContractDifficulty(2, 1, 8),
			new ContractDifficulty(2, 2, 4),
			new ContractDifficulty(3, 1, 7),
			new ContractDifficulty(4, 1, 6),
			new ContractDifficulty(4, 2, 3),
			new ContractDifficulty(4, 3, 2)
		}},
		
		{12, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 11),
			new ContractDifficulty(1, 1, 10),
			new ContractDifficulty(1, 2, 5),
			new ContractDifficulty(2, 1, 9),
			new ContractDifficulty(2, 3, 3),
			new ContractDifficulty(3, 1, 8),
			new ContractDifficulty(3, 2, 4),
			new ContractDifficulty(4, 1, 7)
		}},
		
		{13, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 12),
			new ContractDifficulty(0, 2, 6),
			new ContractDifficulty(0, 3, 4),
			new ContractDifficulty(1, 1, 11),
			new ContractDifficulty(2, 1, 10),
			new ContractDifficulty(2, 2, 5),
			new ContractDifficulty(3, 1, 9),
			new ContractDifficulty(3, 3, 3),
			new ContractDifficulty(4, 1, 8),
			new ContractDifficulty(4, 2, 4)
		}},	

		{14, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 13),
			new ContractDifficulty(1, 1, 12),
			new ContractDifficulty(1, 2, 6),
			new ContractDifficulty(1, 3, 4),
			new ContractDifficulty(2, 1, 11),
			new ContractDifficulty(3, 1, 10),
			new ContractDifficulty(3, 2, 5),
			new ContractDifficulty(4, 1, 9),
			new ContractDifficulty(4, 3, 3)
		}},
		
		{15, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 14),
			new ContractDifficulty(0, 2, 7),
			new ContractDifficulty(1, 1, 13),
			new ContractDifficulty(2, 1, 12),
			new ContractDifficulty(2, 2, 6),
			new ContractDifficulty(2, 3, 4),
			new ContractDifficulty(3, 1, 11),
			new ContractDifficulty(4, 1, 10),
			new ContractDifficulty(4, 2, 5)
		}},
		
		{16, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 15),
			new ContractDifficulty(0, 3, 5),
			new ContractDifficulty(1, 1, 14),
			new ContractDifficulty(1, 2, 7),
			new ContractDifficulty(2, 1, 13),
			new ContractDifficulty(3, 1, 12),
			new ContractDifficulty(3, 2, 6),
			new ContractDifficulty(3, 3, 4),
			new ContractDifficulty(4, 1, 11)
		}},
		
		{17, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 1, 16),
			new ContractDifficulty(0, 2, 8),
			new ContractDifficulty(1, 1, 15),
			new ContractDifficulty(1, 3, 5),
			new ContractDifficulty(2, 1, 14),
			new ContractDifficulty(2, 2, 7),
			new ContractDifficulty(3, 1, 13),
			new ContractDifficulty(4, 1, 12),
			new ContractDifficulty(4, 2, 6),
			new ContractDifficulty(4, 3, 4)
		}},

		{18, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 1, 16),
			new ContractDifficulty(1, 2, 8),
			new ContractDifficulty(2, 1, 15),
			new ContractDifficulty(2, 3, 5),
			new ContractDifficulty(3, 1, 14),
			new ContractDifficulty(3, 2, 7),
			new ContractDifficulty(4, 1, 13)
		}},
		
		{19, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 9),
			new ContractDifficulty(0, 3, 6),
			new ContractDifficulty(2, 1, 16),
			new ContractDifficulty(2, 2, 8),
			new ContractDifficulty(3, 1, 15),
			new ContractDifficulty(3, 3, 5),
			new ContractDifficulty(4, 1, 14),
			new ContractDifficulty(4, 2, 7)
		}},
		
		{20, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 2, 9),
			new ContractDifficulty(1, 3, 6),
			new ContractDifficulty(3, 1, 16),
			new ContractDifficulty(3, 2, 8),
			new ContractDifficulty(4, 1, 15),
			new ContractDifficulty(4, 3, 5)
		}},

		{21, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 10),
			new ContractDifficulty(2, 2, 9),
			new ContractDifficulty(2, 3, 6),
			new ContractDifficulty(4, 1, 16),
			new ContractDifficulty(4, 2, 8)
		}},
		
		{22, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 3, 7),
			new ContractDifficulty(1, 2, 10),
			new ContractDifficulty(3, 2, 9),
			new ContractDifficulty(3, 3, 6)
		}},

		{23, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 2, 11),
			new ContractDifficulty(1, 3, 7),
			new ContractDifficulty(2, 2, 10),
			new ContractDifficulty(4, 2, 9),
			new ContractDifficulty(4, 3, 6)
		}},
		
		{24, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 2, 11),
			new ContractDifficulty(2, 3, 7),
			new ContractDifficulty(3, 2, 10)
		}},

		{25, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 12),
			new ContractDifficulty(0, 3, 8),
			new ContractDifficulty(2, 2, 11),
			new ContractDifficulty(3, 3, 7),
			new ContractDifficulty(4, 2, 10)
		}},
		
		{26, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 2, 12),
			new ContractDifficulty(1, 3, 8),
			new ContractDifficulty(3, 2, 11),
			new ContractDifficulty(4, 3, 7)
		}},

		{27, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 13),
			new ContractDifficulty(2, 2, 12),
			new ContractDifficulty(2, 3, 8),
			new ContractDifficulty(4, 2, 11)
		}},
		
		{28, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 3, 9),
			new ContractDifficulty(1, 2, 13),
			new ContractDifficulty(3, 2, 12),
			new ContractDifficulty(3, 3, 8)
		}},

		{29, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 14),
			new ContractDifficulty(1, 3, 9),
			new ContractDifficulty(2, 2, 13),
			new ContractDifficulty(4, 2, 12),
			new ContractDifficulty(4, 3, 8)
		}},

		{30, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 2, 14),
			new ContractDifficulty(2, 3, 9),
			new ContractDifficulty(3, 2, 13)
		}},
		
		{31, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 15),
			new ContractDifficulty(0, 3, 10),
			new ContractDifficulty(2, 2, 14),
			new ContractDifficulty(3, 3, 9),
			new ContractDifficulty(4, 2, 13)
		}},
		
		{32, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 2, 15),
			new ContractDifficulty(1, 3, 10),
			new ContractDifficulty(3, 2, 14),
			new ContractDifficulty(4, 3, 9)
		}},
		
		{33, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 2, 16),
			new ContractDifficulty(2, 2, 15),
			new ContractDifficulty(2, 3, 10),
			new ContractDifficulty(4, 2, 14)
		}},

		{34, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 3, 11),
			new ContractDifficulty(1, 2, 16),
			new ContractDifficulty(3, 2, 15),
			new ContractDifficulty(3, 3, 10)
		}},

		{35, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 3, 11),
			new ContractDifficulty(2, 2, 16),
			new ContractDifficulty(4, 2, 15),
			new ContractDifficulty(4, 3, 10)
		}},
		
		{36, new ContractDifficulty[]
		{
			new ContractDifficulty(2, 3, 11),
			new ContractDifficulty(3, 2, 16)
		}},

		{37, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 3, 12),
			new ContractDifficulty(3, 3, 11),
			new ContractDifficulty(4, 2, 16)
		}},

		{38, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 3, 12),
			new ContractDifficulty(4, 3, 11)
		}},

		{39, new ContractDifficulty[] { new ContractDifficulty(2, 3, 12) }},

		{40, new ContractDifficulty[]
		{
			new ContractDifficulty(0, 3, 13),
			new ContractDifficulty(3, 3, 12)
		}},

		{41, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 3, 13),
			new ContractDifficulty(4, 3, 12)
		}},

		{42, new ContractDifficulty[] { new ContractDifficulty(2, 3, 13) }},

		{43, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 3, 14),
			new ContractDifficulty(3, 3, 13)
		}},

		{44, new ContractDifficulty[]
		{
			new ContractDifficulty(1, 3, 14),
			new ContractDifficulty(4, 3, 13)
		}},

		{45, new ContractDifficulty[] { new ContractDifficulty(2, 3, 14) }},

		{46, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 3, 15),
			new ContractDifficulty(3, 3, 14)
		}},

		{47, new ContractDifficulty[] 
		{
			new ContractDifficulty(1, 3, 15),
			new ContractDifficulty(4, 3, 14)
		}},

		{48, new ContractDifficulty[] { new ContractDifficulty(2, 3, 15) }},

		{49, new ContractDifficulty[] 
		{
			new ContractDifficulty(0, 3, 16),
			new ContractDifficulty(3, 3, 15)
		}},

		{50, new ContractDifficulty[] 
		{
			new ContractDifficulty(1, 3, 16),
			new ContractDifficulty(4, 3, 15)
		}},

		{51, new ContractDifficulty[] { new ContractDifficulty(2, 3, 16) }},

		{52, new ContractDifficulty[] { new ContractDifficulty(3, 3, 16) }},

		{53, new ContractDifficulty[] { new ContractDifficulty(4, 3, 16) }}
		
		};
}