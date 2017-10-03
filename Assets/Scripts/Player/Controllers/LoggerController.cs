using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerController : MonoBehaviour 
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

		// LoggerAnimator.SetWalkDirection(vertInput, horzInput);
		if (vertInput != 0 || horzInput != 0)
		{
			LoggerAnimator.SetMovementState(AnimState.WALK);
		}
		else if (vertInput == 0 && horzInput == 0)
		{
			LoggerAnimator.SetMovementState(AnimState.IDLE);
		}

		DetermineCharacterRotation();
	}



	public void DetermineCharacterRotation()
    {
        //player rotation follows camera direction when moving. if stationary, player can rotate camera 360 around character
        if (LoggerAnimator.GetMovementState() != AnimState.IDLE)
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
