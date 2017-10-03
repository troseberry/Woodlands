using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoggerController : MonoBehaviour 
{

	float vertInput;
	float horzInput;

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

		LoggerAnimator.SetWalkDirection(vertInput, horzInput);
		if (vertInput != 0 || horzInput != 0)
		{
			LoggerAnimator.SetMovementState(AnimState.WALK);
		}
		else if (vertInput == 0 && horzInput == 0)
		{
			LoggerAnimator.SetMovementState(AnimState.IDLE);
		}
	}
}
