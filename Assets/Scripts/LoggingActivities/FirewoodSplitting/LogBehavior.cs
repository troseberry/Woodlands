using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogBehavior : MonoBehaviour 
	{
		private QualityGrade qualityGrade;
		private LogPileBehavior associatedLogPile;

		private bool hasBeenSplit = false;

		void Start () 
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
			associatedLogPile = transform.GetComponentInParent<LogPileBehavior>();
		}

		public bool HasBeenSplit() { return hasBeenSplit; }

		public void Split()
		{
			ApplySplitForce();

			hasBeenSplit = true;
			HomesteadStockpile.UpdateFirewoodCountAtGrade(qualityGrade, 2);
			HomesteadStockpile.UpdateLogsCountAtGrade(qualityGrade, -1);

			Invoke("PhaseOutFirewood", 1.0f);
		}

		void ApplySplitForce()
		{

		}

		void PhaseOutFirewood()
		{
			if (HomesteadStockpile.GetLogsCountAtGrade(qualityGrade) > 0)
			{
				Invoke("ResetInteractableLog", 1.0f);
			}
			else
			{
				transform.parent.GetComponentInChildren<DisplayGradeUI>().HideUI();
			}
			gameObject.SetActive(false);
		}

		public void ResetInteractableLog()
		{
			hasBeenSplit = false;
			associatedLogPile.UpdateLogPile();
			gameObject.SetActive(true);
		}
	}
}