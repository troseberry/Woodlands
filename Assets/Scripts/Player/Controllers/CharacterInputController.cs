﻿// Input Controller: Handles input from player to character. Calls methods in
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
	public static CharacterInputController Instance;

	private static CinemachineFreeLook characterCameraController;

	float vertInput;
	float horzInput;

	private float rotationOffset;

	private static bool canTurn = true;
	private static bool canRun = true;

	private static bool doChangeTool = false;
	private static int startingToolLocation;
	private static int endingToolLocation;
	
	private static bool toolsDisabled = false;
	private int tempToolIndex = 0;

	private static bool characterInputEnabled = true;
	private static bool freeLookInputEnabled = true;

	private string lastScene = "";

	void Start () 
	{
		Instance = this;

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
		toolsDisabled = scene.name.Equals("MainCabin");

		if (toolsDisabled)
		{
			// Debug.Log("Entered Cabin");
			freeLookInputEnabled = false;
			tempToolIndex = PlayerTools.GetCurrentlyEquippedToolIndex();
			HandleToolInput(0);
			ChangeTool();

		}
		else
		{
			if (lastScene.Equals("MainCabin"))
			{
				freeLookInputEnabled = true;
				HandleToolInput(tempToolIndex);
				ChangeTool();
			}
		}
		
		lastScene = scene.name;
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
			if (Input.GetButton("Run") && canRun)
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

		CharacterMotor.DetermineCharacterRotation(vertInput, horzInput);

		if (!toolsDisabled)
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

	public static void SetCanRun(bool run) { canRun = run; }

	public static void ToggleCameraInput(bool canInput) { if (freeLookInputEnabled) characterCameraController.enabled = canInput; }

	public static void ToggleCameraTurn(bool canTurn)
	{
		if (freeLookInputEnabled)
		{
			// characterCameraController.enabled = false;

			characterCameraController.m_YAxis.m_InputAxisName = canTurn ? "Mouse Y" : "";
			characterCameraController.m_XAxis.m_InputAxisName = canTurn ? "Mouse X" : "";
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

		// if (doChangeTool) ChangeTool();
	}

	public static void HandleToolInput(int inputToolIndex)
	{
		if (ToolManager.GetToolToEquipIndex() != inputToolIndex)
		{
			ToolManager.SetToolToEquipIndex(inputToolIndex);
			doChangeTool = true;

			Instance.ChangeTool();
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

			// Debug.Log("Start Loc: " + startLoc);
			// Debug.Log("End Loc: " + endLoc);

			doChangeTool = false;
		}
	}

		public static void ToggleToolsInput(bool state) { toolsDisabled = !state; }

	public static void InitiateUpgrade(AnimState upgradeAction) { CharacterAnimator.SetUpgradingAsAction(upgradeAction); }
}
