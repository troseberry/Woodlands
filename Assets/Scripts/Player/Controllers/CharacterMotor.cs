using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour 
{
	private static CharacterMotor Instance;

	private static CapsuleCollider characterCollider;
	private static Rigidbody characterRigidbody;

	private static bool isGrounded = true;
	private static bool doJump = false;

	public float walkSpeed;
	public float runSpeed;

	void Start () 
	{
		Instance = this;
		characterCollider = GetComponent<CapsuleCollider>();
		characterRigidbody = GetComponent<Rigidbody>();
	}
	
	void Update () 
	{
		DebugPanel.Log("Grounded Status: ", "Motor", isGrounded);
	}

	void FixedUpdate()
	{
		DetermineGroundedStatus();
		ApplyJumpForce();
	}

	public static bool DetermineGroundedStatus()
	{
		Vector3 capsuleStart = characterCollider.bounds.center;
		Vector3 capsuleEnd = new Vector3(capsuleStart.x, capsuleStart.y - 1.5f, capsuleStart.z);

		isGrounded = Physics.CheckCapsule(capsuleStart, capsuleEnd, 0.501f);

		return isGrounded;
	}

	public static bool IsGrounded() { return isGrounded; }

	public static void ExecuteJump() { doJump = true; }
	
	void ApplyJumpForce()
	{
		if (doJump)
		{
			if (CharacterAnimator.GetActionState() == AnimState.JUMP_STATIONARY)
			{
				characterRigidbody.AddForce(new Vector3(0, 3.5f, 0), ForceMode.Impulse);	
			}
			doJump = false;
		}
	}

	
}