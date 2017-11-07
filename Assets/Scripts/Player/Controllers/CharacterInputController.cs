// Input Controller: Handles input from player to character. Calls methods in
// 			         character Animator and Motor scripts. 
// 			         Should not be applying any forces or using FixedUpdate here

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInputController : MonoBehaviour 
{

	float vertInput;
	float horzInput;

	private float rotationOffset;

	private static bool canTurn = true;

	void Start () 
	{
		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");
	}
	
	void Update () 
	{
		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");

		DebugPanel.Log("Vertical Input: ", "Controller", vertInput);
		DebugPanel.Log("Horizontal Input: ", "Controller", horzInput);

		// CharacterAnimator.SetWalkDirection(vertInput, horzInput);



		/* MOVEMENT INPUT */
		if (vertInput != 0 || horzInput != 0)
		{
			if (Input.GetButton("Move Speed"))
			{
				CharacterAnimator.SetMovementState(AnimState.RUN);
			}
			else
			{
				CharacterAnimator.SetMovementState(AnimState.WALK);
			}
			
		}
		else if (vertInput == 0 && horzInput == 0)
		{
			CharacterAnimator.SetMovementState(AnimState.IDLE);
		}

		DetermineCharacterRotation();

		if (Input.GetButtonDown("Jump"))
		{
			CharacterMotor.ExecuteJump();
			CharacterAnimator.SetJumpAsAction();
		}

		
	}

	void FixedUpdate()
	{
		CharacterMotor.ProcessLocomotionInput(vertInput, horzInput);
	}


	public static void SetCanTurn(bool turn) { canTurn = turn; }

	public void DetermineCharacterRotation()
    {
		if (canTurn)
		{
			//player rotation follows camera direction when moving. if stationary, player can rotate camera 360 around character
			if (CharacterAnimator.GetMovementState() != AnimState.IDLE)
			{
				if (vertInput == 1f)
				{
					rotationOffset = (horzInput == 0)
					? 0f
					: (horzInput > 0) ? 45f : -45f;
				}
				else if (vertInput == -1f)
				{
					rotationOffset = (horzInput == 0)
					? 180f
					: (horzInput > 0) ? -225f : 225f;
				}
				else if (vertInput == 0f)
				{
					rotationOffset = (horzInput == 0)
					? 0f
					: (horzInput > 0) ? 90f : -90f;
				}

				transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y + rotationOffset, transform.eulerAngles.z);
			}
		}
    }

	public static void InitiateLoggingState(AnimState activity)
	{
		CharacterAnimator.SetLoggingAsAction(activity);
	}

	// public static void ProcessToolSwitchLogic()
	// {
	// 	if (Input.GetButtonDown("Tool_01") || Input.GetButtonDown("Tool_02") || Input.GetButtonDown("Tool_03") || Input.GetButtonDown("Tool_04"))
	// 	{
	// 		CharacterAnimator.SetEquipLocations();
	// 		CharacterAnimator.SetSwitchToolAsAction();
	// 	}
	// }
}
