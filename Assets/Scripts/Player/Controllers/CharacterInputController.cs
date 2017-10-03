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

	void Start () 
	{
		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");
	}
	
	void Update () 
	{
		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");

		DebugPanel.Log("Vertical: ", "Controller", vertInput);
		DebugPanel.Log("Horizontal: ", "Controller", horzInput);

		// CharacterAnimator.SetWalkDirection(vertInput, horzInput);



		/* MOVEMENT INPUT */
		if (vertInput != 0 || horzInput != 0)
		{
			CharacterAnimator.SetMovementState(AnimState.WALK);
		}
		else if (vertInput == 0 && horzInput == 0)
		{
			CharacterAnimator.SetMovementState(AnimState.IDLE);
		}

		DetermineCharacterRotation();

		if (Input.GetButtonDown("Jump"))
		{
			CharacterAnimator.SetJumpAsAction();
		}
	}

	void FixedUpdate()
	{
		if (vertInput != 0 || horzInput != 0)
		{
			//apply movement force
		}
		else if (vertInput == 0 && horzInput == 0)
		{
			//set velocity back to 0
		}
	}



	public void DetermineCharacterRotation()
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
