using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Forest;
using LogBucking;
using FirewoodSplitting;

public enum LoggingActivity {NONE, FELLING, BUCKING, SPLITTING};

public class LoggingActivityPlayerBehavior : MonoBehaviour 
{
	public static LoggingActivityPlayerBehavior Instance;

	private static RigidbodyConstraints startingConstraints = RigidbodyConstraints.FreezeRotation;

	private static LoggingActivity currentActivity = LoggingActivity.NONE;

	private static bool playerIsLocked = false;
	private static bool canSnapPlayer = false;
	private static bool canPerformAction = false;

	private static Transform snapLocation;

	private static ForestTreeBehavior forestTreeToCut;
	private static int sideToCut = -1;

	private static FelledTreeBehavior felledTreeToSaw;
	private static int markToSaw;

	private static LogBehavior logToSplit;
	private static int logsRemaining;

	private int actionCounter = 0;
	
	void Start()
	{
		Instance = this;
	}

	void Update () 
	{
		if (currentActivity != LoggingActivity.NONE && canSnapPlayer)
		{
			HandleSnapLogic();
			ProcessInput();
		}

		DebugPanel.Log("Action Counter: ", "LA Player Behavior", actionCounter);
		DebugPanel.Log("Can Perform Action", "LA Player Behavior", canPerformAction);
		DebugPanel.Log("Mouse Down", "LA Player Behavior", Input.GetMouseButton(0));
	}

	public static void SetSnapInfo(bool canSnap) 
	{
		currentActivity = LoggingActivity.NONE;		
		canSnapPlayer = canSnap;
	}

	public static void SetSnapInfo(ForestTreeBehavior tree, Transform snapLoc, bool canSnap, int side)
	{
		currentActivity = LoggingActivity.FELLING;
		forestTreeToCut = tree;
		snapLocation = snapLoc;
		canSnapPlayer = canSnap;
		sideToCut = side;
	}

	public static void SetSnapInfo(FelledTreeBehavior tree, Transform snapLoc, bool canSnap, int mark)
	{
		currentActivity = LoggingActivity.BUCKING;
		felledTreeToSaw = tree;
		snapLocation = snapLoc;
		canSnapPlayer = canSnap;
		markToSaw = mark;
	}

	public static void SetSnapInfo(LogBehavior log, Transform snapLoc, bool canSnap, int qualityIndex)
	{
		currentActivity = LoggingActivity.SPLITTING;
		logToSplit = log;
		snapLocation = snapLoc;
		canSnapPlayer = canSnap;
		logsRemaining = HomesteadStockpile.GetLogsCountAtIndex(qualityIndex);
	}

	void SnapPlayer()
	{
		CharacterMotor.SetCanMove(false);
		CharacterInputController.SetCanTurn(false);
		CharacterInputController.ToggleToolsInput(false);
		canPerformAction = true;

		switch(currentActivity)
		{
			case LoggingActivity.FELLING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_FELLING);
				break;
			case LoggingActivity.BUCKING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_BUCKING);
				break;
			case LoggingActivity.SPLITTING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_SPLITTING);
				break;
		}
		transform.position = snapLocation.position;
		transform.rotation = snapLocation.rotation;

		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		playerIsLocked = true;
		
		// PlayerHud.EnableQualityGame();
		// QualityMinigame.SetMoveSpeed(currentActivity);

		// if (currentActivity == LoggingActivity.BUCKING) StartCoroutine(AutoSaw());
		// else 
		if (currentActivity == LoggingActivity.SPLITTING) StartCoroutine(AutoChopVertical());

	}

	public static void UnsnapPlayer()
	{
		PlayerHud.ToggleQualityGame(false);

		CharacterMotor.SetCanMove(true);
		CharacterInputController.SetCanTurn(true);
		CharacterInputController.InitiateLoggingState(AnimState.NONE);
		CharacterInputController.ToggleToolsInput(true);
		CharacterAnimator.ResetLoggingTriggers();

		Instance.GetComponent<Rigidbody>().constraints = startingConstraints;

		playerIsLocked = false;
	}

	void HandleSnapLogic()
	{
		bool fellingCondition = 
		(currentActivity == LoggingActivity.FELLING && !forestTreeToCut.HasFallen() /*&& forestTreeToCut.PlayerCanStore()*/ && PlayerTools.GetCurrentlyEquippedToolIndex() == 1);

		bool buckingCondition = 
		(currentActivity == LoggingActivity.BUCKING && !felledTreeToSaw.IsLocationFullyCut(markToSaw) /*&& felledTreeToSaw.PlayerCanStore()*/ && PlayerTools.GetCurrentlyEquippedToolIndex() == 2);

		bool splittingCondition = 
		(currentActivity == LoggingActivity.SPLITTING && logsRemaining > 0 /*&& logToSplit.PlayerCanStore()*/ && PlayerTools.GetCurrentlyEquippedToolIndex() == 3);

		if (Input.GetButtonDown("Interact") && canSnapPlayer)
		{
			if (fellingCondition || buckingCondition || splittingCondition)
			{
				if (!playerIsLocked)
				{
					SnapPlayer();
				}
				else
				{
					UnsnapPlayer();
				}
			}

			// if (forestTreeToCut != null)
			// {
			// 	if (!forestTreeToCut.PlayerCanStore()) Debug.Log("Full On Trees: Grade " + forestTreeToCut.GetQualityGrade().ToString());
			// }
			
			// if (felledTreeToSaw != null)
			// {
			// 	if (!felledTreeToSaw.PlayerCanStore()) Debug.Log("Full On Logs: Grade " + felledTreeToSaw.GetQualityGrade().ToString());
			// }

			// if (logToSplit != null)
			// {
			// 	if (!logToSplit.PlayerCanStore()) Debug.Log("Full On Firewood: Grade " + logToSplit.GetQualityGrade().ToString());
			// }
		}
	}

	void ProcessInput()
	{
		if (playerIsLocked)
		{
			if (Input.GetMouseButton(0) && canPerformAction)
			{
				switch(currentActivity)
				{
					case LoggingActivity.FELLING:
						ChopDiagonal();
						break;
					case LoggingActivity.BUCKING:
						Saw();
						break;
					case LoggingActivity.SPLITTING:
						// ChopVertical();
						break;
				}
			}
			else
			{
				CharacterAnimator.EndActionLoop();
			}
		}
	}

	public static bool GetCanPerformAction() { return canPerformAction; }

	public static void SetCanPerformAction(bool state) { canPerformAction = state; }

	public static LoggingActivity GetCurrentActivity() { return currentActivity; }

	#region FELLING METHODS

		void ChopDiagonal()
		{
			if (actionCounter == 0)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.HORIZONTAL_CHOP))
				{
					actionCounter = 1;
					CharacterAnimator.StartActionLoop();
					StartCoroutine(ChopDiagonalAfterAnim());
				}
			}
		}

		IEnumerator ChopDiagonalAfterAnim()
		{
			yield return new WaitForSeconds(CharacterAnimator.GetCurrentAnimState().length);
			
			forestTreeToCut.CutSide(sideToCut);
			actionCounter = 0;
		}	
	#endregion

	#region BUCKING METHODS
		void Saw()
		{
			if (actionCounter == 0)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.SAW_PUSH))
				{ 
					actionCounter = 1;
					CharacterAnimator.StartActionLoop();
					StartCoroutine(ChangeCounterAfterSaw());
				}
			}
		}

		IEnumerator ChangeCounterAfterSaw()
		{
			if (actionCounter == 1)
			{
				yield return new WaitForSeconds(0.533f); //SawSawing_Full length

				felledTreeToSaw.SawLocation(markToSaw);
				actionCounter = 0;
			}
		}
	#endregion

	#region SPLLITTING METHODS

		IEnumerator AutoChopVertical()
		{
			while (playerIsLocked)
			{
				ChopVertical();
				yield return null;
			}
			yield return null;
		}

		void ChopVertical()
		{
			if (CharacterAnimator.GetCurrentAnimState().IsName("ChopVertical_Backward") && actionCounter == 0)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.VERTICAL_CHOP))
				{
					actionCounter = 1;
					CharacterAnimator.ChopFull();
					StartCoroutine(ChopVerticalAfterAnim());
				}
			}
		}

		IEnumerator ChopVerticalAfterAnim()
		{
			QualityMinigame.StartGame();

			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("ChopVertical_Forward"));
			logToSplit.Split();
			actionCounter = 0;
		}
		
		public static void SetLogsRemaining(int logs) { logsRemaining = logs; }
		
		public static int GetLogsRemaining() { return logsRemaining; }
	#endregion
}