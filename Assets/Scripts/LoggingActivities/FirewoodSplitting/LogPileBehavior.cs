using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogPileBehavior : MonoBehaviour 
	{
		private QualityGrade qualityGrade;

		public GameObject interactableLog;
		public Transform logPileGroup;

		void Start () 
		{
			switch(name)
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
			UpdateLogPile();
		}

		public void UpdateLogPile()
		{
			int logsCount = HomesteadStockpile.GetLogsCountAtGrade(qualityGrade);

			interactableLog.SetActive(logsCount > 0);

			for (int i = 0; i < logPileGroup.childCount; i++)
			{
				logPileGroup.GetChild(i).gameObject.SetActive(logsCount > (15 - i));
			}
		}
	}
}