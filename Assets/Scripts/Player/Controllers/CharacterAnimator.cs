using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimState {NONE, IDLE, IDLE_FELLING, IDLE_BUCKING, IDLE_SPLITTING, WALK, RUN, CHOP_FORWARD, CHOP_BACKWARD, SAW_FORWARD, SAW_BACWARD, UPGRADE_TOOL, UPGRADE_SKILL, UPGRADE_ROOM, INTERACT_NEWSPAPER, INTERACT_BED, INTERACT_SHOP, INTERACT_WORKBENCH, INTERACT_BOOKSHELF, SWITCH_TOOL};


public class CharacterAnimator : MonoBehaviour 
{
	private static CharacterAnimator Instance;

	private static AnimState movementState;
	private static AnimState actionState;

	private static Animator loggerAnimator;

	private static bool isGrounded = true;

	private static AnimatorStateInfo currentAnimState;

	void Start () 
	{
		Instance = this;

		movementState = AnimState.IDLE;
		actionState = AnimState.NONE;
		loggerAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		ProcessMovementState();
		ProcessActionState();
	}

	public static AnimatorStateInfo GetCurrentAnimState()
	{
		return loggerAnimator.GetCurrentAnimatorStateInfo(0);
	}

	public static AnimState GetMovementState() { return movementState; }

	public static AnimState GetActionState() { return actionState; }


	#region MOVEMENT METHODS
		public static void Idle() { loggerAnimator.SetInteger("MovementSpeed", 0); }

		public static void Walk() { loggerAnimator.SetInteger("MovementSpeed", 1); }

		public static void Run() { loggerAnimator.SetInteger("MovementSpeed", 2); }

		public static void ProcessMovementState() 
		{ 
			switch(movementState)
			{
				case AnimState.IDLE:
					Idle();
					break;
				case AnimState.WALK:
					Walk();
					break;
				case AnimState.RUN:
					Run();
					break;
			}
		}

		public static void SetMovementState(AnimState newState)
		{
			if (newState == AnimState.IDLE || newState == AnimState.WALK || newState == AnimState.RUN)
			{
				movementState = newState;
			}
			else
			{
				movementState = AnimState.IDLE;
			}
		
		}
	#endregion

	public static void ProcessActionState()
	{
		switch(actionState)
		{
			case AnimState.IDLE_FELLING:
				IdleTreeFelling();
				break;
			case AnimState.IDLE_BUCKING:
				IdleLogBucking();
				break;
			case AnimState.IDLE_SPLITTING:
				IdleFirewoodSplitting();
				break;
			case AnimState.SWITCH_TOOL:
				SwitchTool();
				break;
		}
	}


	#region LOGGING ACTIVITY METHODS
		public static void IdleTreeFelling() 
		{ 
			loggerAnimator.SetInteger("LoggingActivity", 1); 
		}

		public static void IdleLogBucking() 
		{ 
			loggerAnimator.SetInteger("LoggingActivity", 2); 
		}		

		public static void IdleFirewoodSplitting() 
		{ 
			loggerAnimator.SetInteger("LoggingActivity", 3); 
		}

		public static void SetLoggingAsAction(AnimState newState)
		{
			if (newState == AnimState.IDLE_FELLING || newState == AnimState.IDLE_BUCKING || newState == AnimState.IDLE_SPLITTING)
			{
				actionState = newState;
			}
			else
			{
				loggerAnimator.SetInteger("LoggingActivity", 0);
				actionState = AnimState.NONE;
			}
		}

		public static void ChopFull() { loggerAnimator.SetTrigger("ChopFull"); }

		public static void PushForward() { loggerAnimator.SetTrigger("PushForward"); }

		public static void PullBackward() { loggerAnimator.SetTrigger("PullBackward"); }
		
		public static void ResetLoggingTriggers()
		{
			loggerAnimator.ResetTrigger("PushForward");
			loggerAnimator.ResetTrigger("PullBackward");
		}
	#endregion

	#region TOOL METHODS
		public static void SetEquipLocations(int startingLocation, int endingLocation)
		{
			loggerAnimator.SetInteger("StartingToolLocation", startingLocation);
			loggerAnimator.SetInteger("EndingToolLocation", endingLocation);
		}

		public static void SwitchTool()
		{
			loggerAnimator.SetTrigger("SwitchTool");
			actionState = AnimState.NONE;
		}

		public static void SetSwitchToolAsAction()
		{
			actionState = AnimState.SWITCH_TOOL;
		}
	#endregion
}
