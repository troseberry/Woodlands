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

		// private bool hasBeenSplit = false;

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

		// public bool HasBeenSplit() { return hasBeenSplit; }

		public void ChopLog()
		{
			HomesteadStockpile.UpdateLogsCountAtGrade(maxQualityGrade, -1);
			if (HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade) > 0)associatedLogPile.UpdateLogPile();

			QualityMinigame.IncrementUngradedFirewood();
			QualityMinigame.SetLastMaxFirewoodGrade(maxQualityGrade);

			// hasBeenSplit = true;

			if (HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade) <= 0)
			{
				LoggingActivityPlayerBehavior.SetLogsRemaining(HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade));
				LoggingActivityPlayerBehavior.SetCanPerformAction(false);

				PlayerHud.ToggleQualityGame(true);
				QualityMinigame.StartGame();

				StartCoroutine(SplitAfterGrade());
			}
		}

		IEnumerator SplitAfterGrade()
		{
			yield return new WaitUntil( () => !QualityMinigame.IsGradeListEmpty());
			Split();
		}

		void Split()
		{
			ApplySplitForce();

			LoggingActivityPlayerBehavior.UnsnapPlayer();

			int qualityAverage = QualityMinigame.CalculateAverageGrade(HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade));
			qualityAverage  = Mathf.Clamp(qualityAverage, 0, maxQualityGrade.GetHashCode());

			QualityGrade gatheredQuality = (QualityGrade) qualityAverage;

			HomesteadStockpile.UpdateFirewoodCountAtGrade(gatheredQuality, QualityMinigame.GetUngradedFirewood());

			QualityMinigame.ClearUngradedFirewood();

			Debug.Log("Gathered Grade: " + gatheredQuality);

			Invoke("PhaseOutFirewood", 5f);
		}

		void ApplySplitForce()
		{
			firewoodPieces[0].constraints = RigidbodyConstraints.None;
			firewoodPieces[1].constraints = RigidbodyConstraints.None;

			firewoodPieces[0].AddForce(transform.right * -3, ForceMode.Impulse);
			firewoodPieces[1].AddForce(transform.right * 3, ForceMode.Impulse);
		}

		void PhaseOutFirewood()
		{
			// if (HomesteadStockpile.GetLogsCountAtGrade(maxQualityGrade) > 0)
			// {
			// 	Invoke("ResetInteractableLog", 1.0f);
			// }
			// else
			// {
			// 	transform.parent.GetComponentInChildren<LoggingActivityInteractPrompt>().HideUI();
			// }
			gameObject.SetActive(false);
		}

		public void ResetInteractableLog()
		{
			// hasBeenSplit = false;
			// associatedLogPile.UpdateLogPile();

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