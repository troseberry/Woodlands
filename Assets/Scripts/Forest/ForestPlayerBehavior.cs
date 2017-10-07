﻿//try and make this work for all logging activities
//so you don't need a separate one for tree felling, log bucking, and log splitting

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace Forest 
{	
	public class ForestPlayerBehavior : MonoBehaviour 
	{
		public static ForestPlayerBehavior PlayerBehaviorReference;

		// private ThirdPersonUserControl userControl;

		private RigidbodyConstraints startingConstraints;

		private bool playerIsLocked;
		private bool canSnapPlayer;

		private ForestTreeBehavior forestTreeToCut;
		private Transform snapLocation;
		private int sideToCut;

		private bool inForwardPosition = true;
		private bool inBackwardPosition = false;

		private int animRotOffset = 30;
		

		void Start () 
		{
			PlayerBehaviorReference = this;

			// userControl = GetComponent<ThirdPersonUserControl>();
			startingConstraints = RigidbodyConstraints.FreezeRotation;
		}
		
		void Update () 
		{
			DebugPanel.Log("Euler Y: ", transform.eulerAngles.y);

			if (Input.GetButtonDown("Interact") && canSnapPlayer && !forestTreeToCut.HasFallen())
			{
				if (!playerIsLocked)
				{
					SnapPlayer();
				}
				else
				{
					UnsnapPlayer();
				}
			}

			if (playerIsLocked)
			{
				if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Right Bumper") || Input.GetButtonDown("Left Bumper"))
				{
					Debug.Log("Rotate Call");
					RotateAroundTree();
				}

				//Controller Input
				if (Input.GetAxis("Left Trigger") == 1)
				{
					SwingForward();
				}
				else if (Input.GetAxis("Right Trigger") == 1)
				{
					SwingBackward();
				}

				//Mouse & Keyboard Input
				if (Input.GetMouseButtonDown(0))
				{
					SwingForward();
				}
				else if (Input.GetMouseButtonDown(1))
				{
					SwingBackward();
				}
			}
		}

		public void SetSnapInfo(bool canSnap) { canSnapPlayer = canSnap; }

		public void SetSnapInfo(ForestTreeBehavior tree, Transform location, bool canSnap, int side)
		{
			forestTreeToCut = tree;
			snapLocation = location;
			canSnapPlayer = canSnap;
			sideToCut = side;
		}


		void SnapPlayer()
		{
			CharacterMotor.SetCanMove(false);
			CharacterInputController.SetCanTurn(false);
			CharacterInputController.InitiateLoggingState(AnimState.IDLE_FELLING);

			transform.position = snapLocation.position;
			transform.rotation = snapLocation.rotation;

			// userControl.enabled = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

			inForwardPosition = true;
			inBackwardPosition = false;

			playerIsLocked = true;
		}

		public void UnsnapPlayer()
		{
			CharacterMotor.SetCanMove(true);
			CharacterInputController.SetCanTurn(true);
			CharacterInputController.InitiateLoggingState(AnimState.NONE);

			// userControl.enabled = true;
			GetComponent<Rigidbody>().constraints = startingConstraints;
			
			inForwardPosition = true;
			inBackwardPosition = false;

			playerIsLocked = false;
		}

		void RotateAroundTree()
		{
			Debug.Log("Euler: " + transform.eulerAngles.y);
			float eulerValY = transform.eulerAngles.y;

			if (Mathf.Approximately(transform.eulerAngles.y, 30f)) 
			{
				Debug.Log("30");
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z + 2);
				transform.eulerAngles = new Vector3(0, 210, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 120f)) 
			{
				Debug.Log("120");
				transform.position = new Vector3(transform.position.x + 2, 0 , transform.position.z);
				transform.eulerAngles = new Vector3(0, 300, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 210f)) 
			{
				Debug.Log("210");
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z - 2);
				transform.eulerAngles = new Vector3(0, 30, 0);
			}
			else if (Mathf.Approximately(transform.eulerAngles.y, 300f)) 
			{
				Debug.Log("300");
				transform.position = new Vector3(transform.position.x - 2, 0 , transform.position.z);
				transform.eulerAngles = new Vector3(0, 120, 0);
			}

			inForwardPosition = true;
			inBackwardPosition = false;
		}

		
		void SwingForward()
		{
			if (inBackwardPosition)
			{
				CharacterAnimator.ChopForward();
				forestTreeToCut.CutSide(sideToCut);
				inForwardPosition = true;
				inBackwardPosition = false;
			}
		}

		void SwingBackward()
		{
			if (inForwardPosition)
			{
				CharacterAnimator.ChopBackward();
				inBackwardPosition = true;
				inForwardPosition = false;
			}
		}
	}
}