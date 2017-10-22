using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FirewoodSplitting
{
	public class LogBehavior : MonoBehaviour 
	{
		private QualityGrade qualityGrade;
		private LogPileBehavior associatedLogPile;

		public Rigidbody[] firewoodPieces;

		private bool hasBeenSplit = false;

		void Start () 
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
			associatedLogPile = transform.GetComponentInParent<LogPileBehavior>();
		}

		public bool HasBeenSplit() { return hasBeenSplit; }

		public void Split()
		{
			ApplySplitForce();

			hasBeenSplit = true;
			HomesteadStockpile.UpdateFirewoodCountAtGrade(qualityGrade, 2);
			HomesteadStockpile.UpdateLogsCountAtGrade(qualityGrade, -1);

			if (HomesteadStockpile.GetLogsCountAtGrade(qualityGrade) <= 0)
			{
				LoggingActivityPlayerBehavior.SetLogsRemaining(HomesteadStockpile.GetLogsCountAtGrade(qualityGrade));
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
			if (HomesteadStockpile.GetLogsCountAtGrade(qualityGrade) > 0)
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

			firewoodPieces[0].transform.eulerAngles = new Vector3(-180, 180, 0);
			firewoodPieces[1].transform.eulerAngles = new Vector3(-180, 180, 0);

			gameObject.SetActive(true);
		}
	}
}