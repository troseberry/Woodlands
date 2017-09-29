﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace LogBucking
{
	public class LogBuckingPlayerBehavior : MonoBehaviour 
	{	
		public static LogBuckingPlayerBehavior LogBuckingPBRef;

		private ThirdPersonUserControl userControl;

		private RigidbodyConstraints startingConstraints;

		private bool playerIsLocked = false;
		private bool canSnapPlayer = false;

		private LogBuckingTreeBehavior logToSaw;
		private Transform snapLocation;
		private int locationToSaw;

		private bool inForwardPosition = false;
		private bool inBackwardPosition = true;

		void Start () 
		{
			LogBuckingPBRef = this;

			userControl = GetComponent<ThirdPersonUserControl>();
			startingConstraints = RigidbodyConstraints.FreezeRotation;
		}
		
		void Update () 
		{
			if (Input.GetButtonDown("Interact") && canSnapPlayer && !logToSaw.IsLocationFullyCut(locationToSaw))
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

		public void SetSnapInfo(LogBuckingTreeBehavior log, Transform location, bool canSnap, int loc)
		{
			logToSaw = log;
			snapLocation = location;
			canSnapPlayer = canSnap;
			locationToSaw = loc;
		}

		void SnapPlayer()
		{
			transform.position = snapLocation.position;
			transform.rotation = snapLocation.rotation;

			userControl.enabled = false;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

			inForwardPosition = false;
			inBackwardPosition = true;

			playerIsLocked = true;
		}

		public void UnsnapPlayer()
		{
			userControl.enabled = true;
			GetComponent<Rigidbody>().constraints = startingConstraints;
			
			inForwardPosition = false;
			inBackwardPosition = true;

			playerIsLocked = false;
		}

		void PushForward()
		{
			if (inBackwardPosition)
			{
				// Debug.Log("Push Forward");
				logToSaw.SawLocation(locationToSaw);
				inForwardPosition = true;
				inBackwardPosition = false;
			}
		}

		void PullBackward()
		{
			if (inForwardPosition)
			{
				// Debug.Log("Pull Backward");
				inBackwardPosition = true;
				inForwardPosition = false;
			}
		}
	}
}