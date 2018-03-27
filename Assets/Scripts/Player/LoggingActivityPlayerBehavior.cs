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

	// defaults for Tree Felling
	private static bool inForwardPosition = true;
	private static bool inBackwardPosition = false;
	
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
		switch(currentActivity)
		{
			case LoggingActivity.FELLING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_FELLING);

				inForwardPosition = true;
				inBackwardPosition = false;

				Vector3 toLookAt = new Vector3 (forestTreeToCut.transform.position.x, transform.position.y, forestTreeToCut.transform.position.z);
				transform.LookAt(toLookAt);
				break;
			case LoggingActivity.BUCKING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_BUCKING);
				
				inForwardPosition = false;
				inBackwardPosition = true;

				transform.position = snapLocation.position;
				transform.rotation = snapLocation.rotation;
				break;
			case LoggingActivity.SPLITTING:
				CharacterInputController.InitiateLoggingState(AnimState.IDLE_SPLITTING);

				inForwardPosition = true;
				inBackwardPosition = false;

				transform.position = snapLocation.position;
				transform.rotation = snapLocation.rotation;
				break;
		}
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		playerIsLocked = true;
	}

	public static void UnsnapPlayer()
	{
		CharacterMotor.SetCanMove(true);
		CharacterInputController.SetCanTurn(true);
		CharacterInputController.InitiateLoggingState(AnimState.NONE);
		CharacterAnimator.ResetLoggingTriggers();

		Instance.GetComponent<Rigidbody>().constraints = startingConstraints;

		playerIsLocked = false;
	}

	void HandleSnapLogic()
	{
		bool fellingCondition = 
		(currentActivity == LoggingActivity.FELLING && !forestTreeToCut.HasFallen() && forestTreeToCut.PlayerCanStore() && PlayerTools.GetCurrentlyEquippedToolIndex() == 1);

		bool buckingCondition = 
		(currentActivity == LoggingActivity.BUCKING && !felledTreeToSaw.IsLocationFullyCut(markToSaw) && felledTreeToSaw.PlayerCanStore() && PlayerTools.GetCurrentlyEquippedToolIndex() == 2);

		bool splittingCondition = 
		(currentActivity == LoggingActivity.SPLITTING && logsRemaining > 0 && logToSplit.PlayerCanStore() && PlayerTools.GetCurrentlyEquippedToolIndex() == 3);

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

			if (forestTreeToCut != null)
			{
				if (!forestTreeToCut.PlayerCanStore()) Debug.Log("Full On Trees: Grade " + forestTreeToCut.GetQualityGrade().ToString());
			}
			
			if (felledTreeToSaw != null)
			{
				if (!felledTreeToSaw.PlayerCanStore()) Debug.Log("Full On Logs: Grade " + felledTreeToSaw.GetQualityGrade().ToString());
			}

			if (logToSplit != null)
			{
				if (!logToSplit.PlayerCanStore()) Debug.Log("Full On Firewood: Grade " + logToSplit.GetQualityGrade().ToString());
			}
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

			if (Input.GetAxis("Left Trigger") == 1 || Input.GetMouseButtonDown(0))
			{
				switch(currentActivity)
				{
					case LoggingActivity.FELLING:
						ChopDiagonal();
						break;
					case LoggingActivity.BUCKING:
						PushForward();
						break;
					case LoggingActivity.SPLITTING:
						ChopVertical();
						break;
				}
			}
			else if (Input.GetAxis("Right Trigger") == 1 || Input.GetMouseButtonDown(1))
			{
				if (currentActivity == LoggingActivity.BUCKING) PullBackward();
			}
		}
	}

	#region FELLING METHODS
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
			if (CharacterAnimator.GetCurrentAnimState().IsName("ChopIdle"))
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.HORIZONTAL_CHOP))
				{
					CharacterAnimator.ChopFull();
					StartCoroutine(ChopDiagonalAfterAnim());
				}
			}
		}

		IEnumerator ChopDiagonalAfterAnim()
		{
			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("ChopDiagonal_Forward"));
			
			forestTreeToCut.CutSide(sideToCut);
		}

		
	#endregion

	#region BUCKING METHODS
		void PushForward()
		{
			if (inBackwardPosition)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.SAW_PUSH))
				{ 
					CharacterAnimator.PushForward();

					felledTreeToSaw.SawLocation(markToSaw);
					inForwardPosition = true;
					inBackwardPosition = false;
				}
			}
		}

		void PullBackward()
		{
			if (inForwardPosition)
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.SAW_PULL)) 
				{
					CharacterAnimator.PullBackward();
					felledTreeToSaw.SawLocation(markToSaw);
					inForwardPosition = false;
					inBackwardPosition = true;
				}
			}
		}

		public void UnsnapAfterSaw()
		{
			StartCoroutine(UnsnapAfterSawAnim());
			Debug.Log("Holding Here");
		}

		IEnumerator UnsnapAfterSawAnim()
		{
			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("SawSawing_BackwardIdle"));
			Debug.Log("Backward State");
			UnsnapPlayer();
			CharacterAnimator.ResetLoggingTriggers();
		}
	#endregion

	#region SPLLITTING METHODS

		void ChopVertical()
		{
			if (CharacterAnimator.GetCurrentAnimState().IsName("ChopIdle"))
			{
				if (PlayerEnergy.ConsumeEnergy(EnergyAction.VERTICAL_CHOP))
				{
					CharacterAnimator.ChopFull();
					StartCoroutine(ChopVerticalAfterAnim());
				}
			}
		}

		IEnumerator ChopVerticalAfterAnim()
		{
			yield return new WaitUntil( () => CharacterAnimator.GetCurrentAnimState().IsName("ChopVertical_Forward"));
			logToSplit.Split();
		}
		
		public static void SetLogsRemaining(int logs) { logsRemaining = logs; }
		
		public static int GetLogsRemaining() { return logsRemaining; }
	#endregion
}