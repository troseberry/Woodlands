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

		DebugPanel.Log("Action Counter: ", "Quality Game", actionCounter);
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
		
		PlayerHud.EnableQualityGame();
		QualityMinigame.SetMoveSpeed(currentActivity);

		if (currentActivity == LoggingActivity.FELLING) StartCoroutine(AutoChopDiagonal());
		else if (currentActivity == LoggingActivity.BUCKING) StartCoroutine(AutoSaw());
		else if (currentActivity == LoggingActivity.SPLITTING) StartCoroutine(AutoChopVertical());

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
			if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Right Bumper") || Input.GetButtonDown("Left Bumper"))
			{
				RotateAroundTree();
			}
		}
	}

	public static LoggingActivity GetCurrentActivity() { return currentActivity; }

	#region FELLING METHODS

		IEnumerator AutoChopDiagonal()
		{
			while (playerIsLocked)
			{
				ChopDiagonal();
				yield return null;
			}
			yield return null;
		}

		void RotateAroundTree()
		{
			if (Mathf.Approximately(transform.eulerAngles.y, 30f)) 
			{
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z + 2);
				transform.eulerAngles = new Vector3(0, 210, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 120f)) 
			{
				transform.position = new Vector3(transform.position.x + 2, 0 , transform.position.z);
				transform.eulerAngles = new Vector3(0, 300, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 210f)) 
			{
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z - 2);
				transform.eulerAngles = new Vector3(0, 30, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 300f)) 
			{
				transform.position = new Vector3(transform.position.x - 2, 0 , transform.position.z);
				transform.eulerAngles = new Vector3(0, 120, 0);
			}
		}

		void ChopDiagonal()
		{
			if (CharacterAnimator.GetCurrentAnimState().IsName("ChopDiagonal_Backward") && actionCounter == 0)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.HORIZONTAL_CHOP))
				{
					actionCounter = 1;
					CharacterAnimator.ChopFull();
					StartCoroutine(ChopDiagonalAfterAnim());
				}
			}
		}

		IEnumerator ChopDiagonalAfterAnim()
		{
			QualityMinigame.StartGame();

			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("ChopDiagonal_Forward"));
			
			forestTreeToCut.CutSide(sideToCut);
			actionCounter = 0;
			// Debug.Log("Timer: " + QualityMinigame.timer);
		}	
	#endregion

	#region BUCKING METHODS

		IEnumerator AutoSaw()
		{
			while (playerIsLocked)
			{
				PushForward();
				yield return null;
			}
			yield return null;
		}

		void PushForward()
		{
			if (CharacterAnimator.GetCurrentAnimState().IsName("Saw_Forward") && actionCounter == 0)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.SAW_PUSH))
				{ 
					actionCounter = 1;
					CharacterAnimator.PushForward();
					StartCoroutine(ChangeCounterAfterSaw());
				}
			}
		}

		IEnumerator ChangeCounterAfterSaw()
		{
			QualityMinigame.StartGame();

			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("Saw_Backward"));

			felledTreeToSaw.SawLocation(markToSaw);
			actionCounter = 0;
			Debug.Log("Timer: " + Time.time);
		}

		public void UnsnapAfterSaw()
		{
			StartCoroutine(UnsnapAfterSawAnim());
		}

		IEnumerator UnsnapAfterSawAnim()
		{
			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("Saw_Backward"));
			
			UnsnapPlayer();
			CharacterAnimator.ResetLoggingTriggers();
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