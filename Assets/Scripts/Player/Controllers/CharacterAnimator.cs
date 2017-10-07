using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimState {NONE, IDLE, IDLE_FELLING, IDLE_BUCKING, IDLE_SPLITTING, WALK, RUN, JUMP_STATIONARY, JUMP_WALK, JUMP_RUN, CHOP_FORWARD, CHOP_BACKWARD, SAW_FORWARD, SAW_BACWARD, UPGRADE_TOOL, UPGRADE_SKILL, UPGRADE_ROOM, INTERACT_NEWSPAPER, INTERACT_BED, INTERACT_SHOP, INTERACT_WORKBENCH, INTERACT_BOOKSHELF};


public class CharacterAnimator : MonoBehaviour 
{
	private static CharacterAnimator Instance;

	private static AnimState movementState;
	private static AnimState actionState;

	private static Animator loggerAnimator;

	private static bool isGrounded = true;

	void Start () 
	{
		Instance = this;

		movementState = AnimState.IDLE;
		actionState = AnimState.NONE;
		loggerAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		DebugPanel.Log("Movement Speed: ", "Animation", loggerAnimator.GetInteger("MovementSpeed"));
		DebugPanel.Log("Movement State: ", "Animation", movementState);
		DebugPanel.Log("Action State: ", "Animation", actionState);

		ProcessMovementState();
		ProcessActionState();
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
			case AnimState.JUMP_STATIONARY:
				Jump();
				break;
			case AnimState.JUMP_WALK:
				Jump();
				break;
			case AnimState.JUMP_RUN:
				Jump();
				break;
			case AnimState.IDLE_FELLING:
				IdleTreeFelling();
				break;
			case AnimState.IDLE_BUCKING:
				IdleLogBucking();
				break;
			case AnimState.IDLE_SPLITTING:
				IdleFirewoodSplitting();
				break;
		}
	}


	#region JUMP METHODS
		public static void Jump() 
		{ 
			if (CharacterMotor.IsGrounded())
			{	
				//change this to be a trigger? with transition with exit time
				loggerAnimator.SetBool("JumpBool", true);
				Instance.Invoke("ResetJump", 0.9f);		//delay time should be jump anim length
			}
		}

		public static void SetJumpAsAction()
		{
			if (movementState == AnimState.IDLE)
			{
				actionState = AnimState.JUMP_STATIONARY; 
			}
			else if (movementState == AnimState.WALK)
			{
				actionState = AnimState.JUMP_WALK;
			}
			else if (movementState == AnimState.RUN)
			{
				actionState = AnimState.JUMP_RUN;
			}
			else
			{
				actionState = AnimState.NONE;
			}
		}

		void ResetJump()
		{
			actionState = AnimState.NONE;
			loggerAnimator.SetBool("JumpBool", false);
		}
	#endregion

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

		public static void ChopFull()  { loggerAnimator.SetTrigger("ChopFull"); }

		public static void ChopForward() { loggerAnimator.SetTrigger("SwingForward"); }

		public static void ChopBackward()  { loggerAnimator.SetTrigger("SwingBackward"); }

		public static void SawForward() { loggerAnimator.SetTrigger("PushForward"); }

		public static void SawBackward() { loggerAnimator.SetTrigger("PullBackward"); }

	#endregion
}
