using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class LogBuckingTreeBehavior : MonoBehaviour 
	{
		private QualityGrade qualityGrade;
		private LogBucking.LogSnapSpot[] snapSpots;

		private TreePileBehavior associatedTreePile;

		// public ShowTreeCuts[] sawProgressCuts;

		//left most side first
		int[] locationStrokeCounts = new int[2] {0, 0,};
		bool[] locationFullySawed = new bool[2] {false, false};

		void Start()
		{
			switch(GetComponent<DisplayGradeUI>().GetGradeString())
			{
				case "GradeA":
					qualityGrade = QualityGrade.A;
					break;
				case "GradeB":
					qualityGrade = QualityGrade.B;
					break;
				case "GradeC":
					qualityGrade = QualityGrade.C;
					break;
				case "GradeD":
					qualityGrade = QualityGrade.D;
					break;
				case "GradeF":
					qualityGrade = QualityGrade.F;
					break;
			}
			snapSpots = transform.GetComponentsInChildren<LogBucking.LogSnapSpot>();

			associatedTreePile = transform.GetComponentInParent<TreePileBehavior>();
		}
		
		public void SawLocation(int loc)
		{
			if (locationStrokeCounts[loc] < 4)
			{
				locationStrokeCounts[loc] ++;
				// sawProgressCuts[loc].CutFace(1);
			}
			else
			{
				SawThrough(loc);
			}
		}

		void SawThrough(int loc)
		{
			snapSpots[loc].enabled = false;
			LogBuckingPlayerBehavior.LogBuckingPBRef.UnsnapPlayer();
			locationFullySawed[loc] = true;

			if (locationFullySawed[0] && locationFullySawed[1])
			{
				HomesteadStockpile.UpdateLogsCountAtGrade(qualityGrade, 2);
				HomesteadStockpile.UpdateTreesCountAtGrade(qualityGrade, -1);
				associatedTreePile.UpdateTreePile();
				ResetInteractableVarialbes();
			}
			else
			{
				HomesteadStockpile.UpdateLogsCountAtGrade(qualityGrade, 1);
			}
		}

		public void ResetInteractableVarialbes()
		{
			locationStrokeCounts = new int[2] {0, 0,};
			locationFullySawed = new bool[2] {false, false};
		}

		public bool IsLocationFullyCut(int loc)
		{
			return locationFullySawed[loc];
		}
	}
}