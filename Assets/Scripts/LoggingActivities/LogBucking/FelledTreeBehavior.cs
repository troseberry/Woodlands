using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogBucking
{
	public class FelledTreeBehavior : MonoBehaviour 
	{
		private QualityGrade qualityGrade;
		private FelledTreeSnapSpot[] snapSpots;

		private FelledTreePileBehavior associatedFelledTreePile;
		public FirewoodSplitting.LogPileBehavior associatedLogPile;

		public ShowTreeCuts[] sawProgressCuts;
		public GameObject[] logMarks;

		//left most side first
		int[] locationStrokeCounts = new int[2] {0, 0,};
		bool[] locationFullySawed = new bool[2] {false, false};

		void Start()
		{
			switch(transform.parent.name)
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
			snapSpots = transform.GetComponentsInChildren<FelledTreeSnapSpot>();
			associatedFelledTreePile = transform.GetComponentInParent<FelledTreePileBehavior>();
			
			
		}
		
		public void SawLocation(int loc)
		{
			if (locationStrokeCounts[loc] == 0)
			{
				logMarks[loc].SetActive(false);
			}


			if (locationStrokeCounts[loc] < 10)
			{
				int cut01 = loc == 0 ? 0 : 2;
				int cut02 = loc== 0 ? 1 : 3;

				locationStrokeCounts[loc] ++;
				sawProgressCuts[cut01].CutFace(3);
				sawProgressCuts[cut02].CutFace(3);
			}

			if (locationStrokeCounts[loc] == 10) SawThrough(loc);
		}

		void SawThrough(int loc)
		{
			snapSpots[loc].enabled = false;
			// LoggingActivityPlayerBehavior.UnsnapPlayer();
			LoggingActivityPlayerBehavior.Instance.UnsnapAfterSaw();
			locationFullySawed[loc] = true;

			if (locationFullySawed[0] && locationFullySawed[1])
			{
				HomesteadStockpile.UpdateLogsCountAtGrade(qualityGrade, 3);
				HomesteadStockpile.UpdateTreesCountAtGrade(qualityGrade, -1);
				
				Invoke("PhaseOutLogs", 1.0f);
			}
		}

		void PhaseOutLogs()
		{
			if (HomesteadStockpile.GetTreesCountAtGrade(qualityGrade) > 0)
			{
				Invoke("ResetInteractableFelledTree", 1.0f);
			}
			else
			{
				transform.parent.GetComponentInChildren<LoggingActivityInteractPrompt>().HideUI();
			}
			associatedLogPile.UpdateLogPile();
			gameObject.SetActive(false);
		}

		public void ResetInteractableFelledTree()
		{
			for (int i = 0; i < 4; i++)
			{
				sawProgressCuts[i].ResetToDefault();
			}
			locationStrokeCounts = new int[2] {0, 0,};
			locationFullySawed = new bool[2] {false, false};

			logMarks[0].SetActive(true);
			logMarks[1].SetActive(true);

			associatedFelledTreePile.UpdateFelledTreePile();

			gameObject.SetActive(true);
		}

		public bool IsLocationFullyCut(int loc)
		{
			return locationFullySawed[loc];
		}
	}
}