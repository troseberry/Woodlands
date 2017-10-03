using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimState {NONE, IDLE, IDLE_FELLING, IDLE_BUCKING, IDLE_SPLITTING, WALK, RUN, JUMP_STATIONARY, JUMP_WALK, JUMP_RUN, CHOP_FORWARD, CHOP_BACKWARD, SAW_FORWARD, SAW_BACWARD, UPGRADE_TOOL, UPGRADE_SKILL, UPGRADE_ROOM, INTERACT_NEWSPAPER, INTERACT_BED, INTERACT_SHOP, INTERACT_WORKBENCH, INTERACT_BOOKSHELF};


public class LoggerAnimator : MonoBehaviour 
{

	private static AnimState movementState;
	private static AnimState actionState;

	private static Animator loggerAnimator;

	private static float walkDirectionValue = 0f;

	void Start () 
	{
		movementState = AnimState.IDLE;
		actionState = AnimState.NONE;
		loggerAnimator = GetComponent<Animator>();

		walkDirectionValue = 0f;
	}

	void Update()
	{
		DebugPanel.Log("Movement Speed: ", "Animation", loggerAnimator.GetFloat("MovementSpeed"));
		DebugPanel.Log("Movement State: ", "Animation", movementState);
		DebugPanel.Log("Action State: ", "Animation", actionState);
		ProcessMovementState();
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

		// public static void SetWalkDirection(float vertDir, float horzDir)
		// {	
		// 	//0 - no dir
		// 	//1 - pos dir (forward or right)
		// 	//-1 - neg dir (backward or left)
		// 	if (vertDir == -1f)
		// 	{
		// 		walkDirectionValue = (horzDir == 0)
		// 			? 0 //4 - use 4 if don't want character to face camera and walk forward when pressing 'S'
		// 			: (horzDir > 0f) ? 5f : 3f;
		// 	}
		// 	else if (vertDir == 0f)
		// 	{
		// 		walkDirectionValue = (horzDir == 0)
		// 		? 0
		// 		: (horzDir > 0f) ? 6f : 2f;
		// 	}
		// 	else if (vertDir == 1f)
		// 	{
		// 		walkDirectionValue = (horzDir == 0)
		// 		? 0
		// 		: (horzDir > 0f) ? 7f : 1f;
		// 	}
		// 	loggerAnimator.SetFloat("WalkDirection", walkDirectionValue);
		// }
	#endregion
}
