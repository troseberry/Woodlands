using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace LogBucking
{
	public class LogBuckingPlayerBehavior : MonoBehaviour 
	{	
		public static LogBuckingPlayerBehavior LogBuckingPBRef;

		// private ThirdPersonUserControl userControl;

		private RigidbodyConstraints startingConstraints;

		private bool playerIsLocked = false;
		private bool canSnapPlayer = false;

		private FelledTreeBehavior felledTreeToSaw;
		private Transform snapLocation;
		private int locationToSaw;

		private bool inForwardPosition = false;
		private bool inBackwardPosition = true;

		void Start () 
		{
			LogBuckingPBRef = this;

			// userControl = GetComponent<ThirdPersonUserControl>();
			startingConstraints = RigidbodyConstraints.FreezeRotation;
		}
		
		void Update () 
		{
			if (Input.GetButtonDown("Interact") && canSnapPlayer && !felledTreeToSaw.IsLocationFullyCut(locationToSaw))
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
				//Controller Input
				if (Input.GetAxis("Left Trigger") == 1)
				{
					PushForward();
				}
				else if (Input.GetAxis("Right Trigger") == 1)
				{
					PullBackward();
				}

				//Mouse & Keyboard Input
				if (Input.GetMouseButtonDown(0))
				{
					PushForward();
				}
				else if (Input.GetMouseButtonDown(1))
				{
					PullBackward();
				}
			}
		}

		public void SetSnapInfo(bool canSnap) { canSnapPlayer = canSnap; }

		public void SetSnapInfo(FelledTreeBehavior tree, Transform location, bool canSnap, int loc)
		{
			felledTreeToSaw = tree;
			snapLocation = location;
			canSnapPlayer = canSnap;
			locationToSaw = loc;
		}

		void SnapPlayer()
		{
			CharacterMotor.SetCanMove(false);
			CharacterInputController.SetCanTurn(false);
			CharacterInputController.InitiateLoggingState(AnimState.IDLE_BUCKING);

			transform.position = snapLocation.position;
			transform.rotation = snapLocation.rotation;

			// userControl.enabled = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

			inForwardPosition = false;
			inBackwardPosition = true;

			playerIsLocked = true;
		}

		public void UnsnapPlayer()
		{
			CharacterMotor.SetCanMove(true);
			CharacterInputController.SetCanTurn(true);
			CharacterInputController.InitiateLoggingState(AnimState.NONE);

			// userControl.enabled = true;
			GetComponent<Rigidbody>().constraints = startingConstraints;
			
			inForwardPosition = false;
			inBackwardPosition = true;

			playerIsLocked = false;
		}

		void PushForward()
		{
			if (inBackwardPosition)
			{
				CharacterAnimator.SawForward();
				felledTreeToSaw.SawLocation(locationToSaw);
				inForwardPosition = true;
				inBackwardPosition = false;
			}
		}

		void PullBackward()
		{
			if (inForwardPosition)
			{
				CharacterAnimator.SawBackward();
				inBackwardPosition = true;
				inForwardPosition = false;
			}
		}
	}
}