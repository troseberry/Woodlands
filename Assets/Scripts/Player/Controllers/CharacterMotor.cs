using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour 
{
	private static CharacterMotor Instance;

	private static CapsuleCollider characterCollider;
	private static Rigidbody characterRigidbody;

	private static bool isGrounded = true;
	private static bool canMove = true;

	public float walkSpeed;
	public float runSpeed;

	private static Vector3 moveVector;


	void Start () 
	{
		Instance = this;

		characterCollider = GetComponent<CapsuleCollider>();
		characterRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		DetermineGroundedStatus();
	}

	public static bool DetermineGroundedStatus()
	{
		Vector3 capsuleStart = characterCollider.bounds.center;
		Vector3 capsuleEnd = new Vector3(capsuleStart.x, capsuleStart.y - 1.5f, capsuleStart.z);

		isGrounded = Physics.CheckCapsule(capsuleStart, capsuleEnd, 0.501f);

		return isGrounded;
	}

	public static bool IsGrounded() { return isGrounded; }

	public static void SetCanMove(bool move)
	{
		canMove = move;
	}

	public static void ProcessLocomotionInput(float vertInput, float horzInput)
	{
		if (canMove)
		{
			Transform cameraReference = Camera.main.transform;
			Vector3 cameraForward = Vector3.Scale(cameraReference.forward, new Vector3(1, 0, 1)).normalized;

			moveVector =  Vector3.zero;
			moveVector = (vertInput * cameraForward) + (horzInput * cameraReference.right);

			if (moveVector.magnitude > 1) moveVector = Vector3.Normalize(moveVector);

			moveVector *= GetMoveSpeed();		//for new vector magnitude after being normalized

			characterRigidbody.AddForce(moveVector * GetMoveSpeed());
		}
	}

	static float GetMoveSpeed()
	{
		switch(CharacterAnimator.GetMovementState())
		{
			case AnimState.IDLE:
				return 0f;
			case AnimState.WALK:
				return Instance.walkSpeed;
			case AnimState.RUN:
				return Instance.runSpeed;
		}
		return 0f;
	}
}