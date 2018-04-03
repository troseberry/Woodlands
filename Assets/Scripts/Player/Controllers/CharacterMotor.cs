using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class CharacterMotor : MonoBehaviour 
{
	public static CharacterMotor Instance;

	private static CapsuleCollider characterCollider;
	private static Rigidbody characterRigidbody;

	private static bool isGrounded = true;
	private static bool canMove = true;
	private static bool canTurn = true;

	public float walkSpeed;
	public float runSpeed;
	private static float rotationOffset;

	private static Vector3 moveVector;

	private Transform cameraTransformReference;
	private Transform activeClearShotCamera;
	private CinemachineClearShot CM_ClearShot;


	void Start () 
	{
		Instance = this;

		characterCollider = GetComponent<CapsuleCollider>();
		characterRigidbody = GetComponent<Rigidbody>();
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		cameraTransformReference = Camera.main.transform;
		if (scene.name.Equals("MainCabin"))
		{
			CM_ClearShot = GameObject.Find("CM_ClearShotCamera_MainCabin").GetComponent<CinemachineClearShot>();

			StartCoroutine(SetActiveClearShot());
		}
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	IEnumerator SetActiveClearShot()
	{
		yield return new WaitUntil( () => CM_ClearShot.LiveChild != null);
		activeClearShotCamera = CM_ClearShot.LiveChild.VirtualCameraGameObject.transform;
		cameraTransformReference = activeClearShotCamera;
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
		if (Instance.CM_ClearShot != null) SwitchCameraRefernce(vertInput, horzInput);

		if (canMove)
		{
			Vector3 cameraForward = Vector3.Scale(Instance.cameraTransformReference.forward, new Vector3(1, 0, 1)).normalized;

			moveVector =  Vector3.zero;
			moveVector = (vertInput * cameraForward) + (horzInput * Instance.cameraTransformReference.right);

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

	public static void DetermineCharacterRotation(float vertInput, float horzInput)
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

				Instance.transform.rotation = Quaternion.Euler(Instance.transform.eulerAngles.x, Instance.cameraTransformReference.eulerAngles.y + rotationOffset, Instance.transform.eulerAngles.z);
			}
		}
    }


	static void SwitchCameraRefernce(float vertInput, float horzInput)
	{
		if (Instance.activeClearShotCamera != Instance.CM_ClearShot.LiveChild.VirtualCameraGameObject.transform)
		{
			if (vertInput == 0 && horzInput == 0)
			{
				Instance.activeClearShotCamera = Instance.CM_ClearShot.LiveChild.VirtualCameraGameObject.transform;
				Instance.cameraTransformReference = Instance.activeClearShotCamera;
			}
		}
	}
}