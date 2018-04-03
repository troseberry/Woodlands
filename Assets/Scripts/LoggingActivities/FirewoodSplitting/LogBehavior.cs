using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogBehavior : MonoBehaviour 
	{
		private QualityGrade maxQualityGrade;

		private LogPileBehavior associatedLogPile;

		public Rigidbody[] firewoodPieces;

		private bool hasBeenSplit = false;

		void Start () 
		{
			switch(transform.parent.name)
			{
				case "GradeA":
					maxQualityGrade = QualityGrade.A;
					break;
				case "GradeB":
					maxQualityGrade = QualityGrade.B;
					break;
				case "GradeC":
					maxQualityGrade = QualityGrade.C;
					break;
				case "GradeD":
					maxQualityGrade = QualityGrade.D;
					break;
				case "GradeF":
					maxQualityGrade = QualityGrade.F;
					break;
			}
			associatedLogPile = transform.GetComponentInParent<LogPileBehavior>();
		}

		// public bool PlayerCanStore()
		// {
		// 	return HomesteadStockpile.GetFirewoodCountAtGrade(qualityGrade) < PlayerSkills.GetMaxLumberFirewoodValue();
		// }

		// public QualityGrade GetQualityGrade() { return qualityGrade; }

		public bool HasBeenSplit() { return hasBeenSplit; }

		public void Split()
		{
			ApplySplitForce();

			hasBeenSplit = true;

			int toolGradeEquivalent = PlayerTools.GetToolByName(ToolName.SPLITTING_AXE).GetCurrentTier() - 1;
			int maxGradeNumber = 10 % ((int) maxQualityGrade + 6);
			int gatheredQualityNumber = Mathf.Clamp(toolGradeEquivalent, toolGradeEquivalent, maxGradeNumber);
			gatheredQualityNumber = 10 % (gatheredQualityNumber + 6);

			QualityGrade gatheredQuality = (QualityGrade) gatheredQualityNumber;

			HomesteadStockpile.UpdateFirewoodCountAtGrade(gatheredQuality, 2);
			HomesteadStockpile.UpdateLogsCountAtGrade(maxQualityGrade, -1);

			if (HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade) <= 0)
			{
				LoggingActivityPlayerBehavior.SetLogsRemaining(HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade));
				LoggingActivityPlayerBehavior.UnsnapPlayer();
			}

			Invoke("PhaseOutFirewood", 1.0f);
		}

		void ApplySplitForce()
		{
			// Vector3 randomLeft = new Vector3(firewoodPieces[0].transform.position.x, 
			// 								Random.Range(firewoodPieces[0].transform.position.y + 0.25f, firewoodPieces[0].transform.position.y - 0.25f), 
			// 								Random.Range(firewoodPieces[0].transform.position.z + 0.125f, firewoodPieces[0].transform.position.z - 0.125f));
											
			// Vector3 randomRight = new Vector3(firewoodPieces[1].transform.position.x, 
			// 								Random.Range(firewoodPieces[0].transform.position.y + 0.25f, firewoodPieces[0].transform.position.y - 0.25f), 
			// 								Random.Range(firewoodPieces[0].transform.position.z + 0.125f, firewoodPieces[0].transform.position.z - 0.125f));

			firewoodPieces[0].constraints = RigidbodyConstraints.None;
			firewoodPieces[1].constraints = RigidbodyConstraints.None;

			// firewoodPieces[0].AddForceAtPosition(transform.right * -3, randomLeft, ForceMode.Impulse);
			// firewoodPieces[1].AddForceAtPosition(transform.right * 3, randomRight, ForceMode.Impulse);

			firewoodPieces[0].AddForce(transform.right * -3, ForceMode.Impulse);
			firewoodPieces[1].AddForce(transform.right * 3, ForceMode.Impulse);
		}

		void PhaseOutFirewood()
		{
			if (HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade) > 0)
			{
				Invoke("ResetInteractableLog", 1.0f);
			}
			else
			{
				transform.parent.GetComponentInChildren<LoggingActivityInteractPrompt>().HideUI();
			}
			gameObject.SetActive(false);
		}

		public void ResetInteractableLog()
		{
			hasBeenSplit = false;
			associatedLogPile.UpdateLogPile();

			firewoodPieces[0].constraints = RigidbodyConstraints.FreezeAll;
			firewoodPieces[1].constraints = RigidbodyConstraints.FreezeAll;

			firewoodPieces[0].transform.localPosition = new Vector3(-0.0625f, 0, 0);
			firewoodPieces[1].transform.localPosition = new Vector3(0.0625f, 0, 0);

			firewoodPieces[0].transform.eulerAngles = new Vector3(-180, 270, 0);
			firewoodPieces[1].transform.eulerAngles = new Vector3(-180, 270, 0);

			gameObject.SetActive(true);
		}
	}
}