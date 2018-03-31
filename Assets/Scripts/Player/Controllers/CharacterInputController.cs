// Input Controller: Handles input from player to character. Calls methods in
// 			         character Animator and Motor scripts. 
// 			         Should not be applying any forces or using FixedUpdate here

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Cameras;
using Cinemachine;

public class CharacterInputController : MonoBehaviour 
{
	// private static FreeLookCam characterCameraController;
	private static CinemachineFreeLook characterCameraController;

	float vertInput;
	float horzInput;

	private float rotationOffset;

	private static bool canTurn = true;

	private static bool doChangeTool = false;
	private static int startingToolLocation;
	private static int endingToolLocation;
	
	private bool toolsDisabledInside = false;
	private int tempToolIndex = 0;

	private static bool characterInputEnabled = true;
	private static bool freeLookInputEnabled = true;

	void Start () 
	{
		characterCameraController = GameObject.Find("CM_FreeLookCam").GetComponent<CinemachineFreeLook>();

		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");
	}

	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		toolsDisabledInside = scene.name.Equals("MainCabin");

		if (toolsDisabledInside)
		{
			// Debug.Log("Entered Cabin");
			freeLookInputEnabled = false;
			tempToolIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
			HandleToolInput(0);
			ChangeTool();
		}
		else
		{
			freeLookInputEnabled = true;
			HandleToolInput(tempToolIndex);
			ChangeTool();
		}
	}

	void OnDisable()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}
	

	void Update () 
	{
		if (!characterInputEnabled) return;

		vertInput = Input.GetAxisRaw("Vertical");
		horzInput = Input.GetAxisRaw("Horizontal");


		#region MOVEMENT INPUT
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
		#endregion

		DetermineCharacterRotation();

		if (!toolsDisabledInside)
		{
			HandleToolInput();		
			if (doChangeTool) ChangeTool();
		}
	}

	void FixedUpdate()
	{
		if (!characterInputEnabled) return;
		CharacterMotor.ProcessLocomotionInput(vertInput, horzInput);
	}

	public static void ToggleCharacterInput(bool canInput) { if (freeLookInputEnabled) characterInputEnabled = canInput; }

	public static void SetCanTurn(bool turn) { if (freeLookInputEnabled) canTurn = turn; }

	public static void ToggleCameraInput(bool canInput) { if (freeLookInputEnabled) characterCameraController.enabled = canInput; }

	public static void ToggleCameraTurn(bool canTurn)
	{
		if (freeLookInputEnabled)
		{
			characterCameraController.m_YAxis.m_InputAxisName = canTurn ? "Mouse Y" : "";
			characterCameraController.m_XAxis.m_InputAxisName = canTurn ? "Mouse X" : "";
		}
	}

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

	void HandleToolInput()
	{
		if (Input.GetButtonDown("Tool_01") && ToolManager.GetToolToEquipIndex() != 0)
		{
			ToolManager.SetToolToEquipIndex(0);
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_02") && ToolManager.GetToolToEquipIndex() != 1)
		{
			ToolManager.SetToolToEquipIndex(1);
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_03") && ToolManager.GetToolToEquipIndex() != 2)
		{
			ToolManager.SetToolToEquipIndex(2);
			doChangeTool = true;
		}
		else if (Input.GetButtonDown("Tool_04") && ToolManager.GetToolToEquipIndex() != 3)
		{
			ToolManager.SetToolToEquipIndex(3);
			doChangeTool = true;
		}

		if (!ToolManager.GetScrollSwitch() && !MenuManager.currentMenuManager.IsInMenu())
		{
			// Debug.Log("Scroll: " + Input.GetAxis("Mouse ScrollWheel"));
			if (Input.GetAxis("Mouse ScrollWheel") >= 0.1f)
			{
				// Debug.Log("Scoll Check Forward");
				ToolManager.SetToolToEquipIndex((PlayerTools.GetCurrentlyEquippedToolIndex() + 1) % 4);
				doChangeTool = true;
				ToolManager.SetScrollSwitch(true);
			}
			else if (Input.GetAxis("Mouse ScrollWheel") <= -0.1f)
			{
				// Debug.Log("Scoll Check Backward");
				ToolManager.SetToolToEquipIndex((PlayerTools.GetCurrentlyEquippedToolIndex() + 3) % 4);
				doChangeTool = true;
				ToolManager.SetScrollSwitch(true);
			}
		}
	}

	public static void HandleToolInput(int inputToolIndex)
	{
		if (ToolManager.GetToolToEquipIndex() != inputToolIndex)
		{
			ToolManager.SetToolToEquipIndex(inputToolIndex);
			doChangeTool = true;
		}
	}

	void ChangeTool()
	{
		if (doChangeTool)
		{
			// Debug.Log("Current Tool: " + PlayerTools.GetCurrentlyEquippedToolIndex());
			// Debug.Log("To Equip Tool: " + ToolManager.GetToolToEquipIndex());
			
			int startLoc = 0;
			if (PlayerTools.GetCurrentlyEquippedToolIndex() > 0) startLoc = (PlayerTools.GetCurrentlyEquippedToolIndex() == 2) ? 2 : 1;

			int endLoc = 0;
			if (ToolManager.GetToolToEquipIndex() > 0) endLoc = (ToolManager.GetToolToEquipIndex() == 2) ? 2 : 1;

			CharacterAnimator.SetEquipLocations( (float) startLoc, (float) endLoc);
			CharacterAnimator.SetSwitchToolAsAction();

			PlayerHud.PlayerHudReference.ChangeToolIcon();

			doChangeTool = false;
		}
	}
}
