using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

namespace TreeFelling 
{	
	public class PlayerBehavior : MonoBehaviour 
	{
		public static PlayerBehavior PlayerBehaviorReference;

		private ThirdPersonUserControl userControl;

		private RigidbodyConstraints startingConstraints;

		private bool playerIsLocked;
		private bool canSnapPlayer;

		private TreeBehavior treeToCut;
		private Transform snapLocation;
		private int sideToCut;

		private bool inForwardPosition = false;
		private bool inBackwardPosition = true;


		void Start () 
		{
			PlayerBehaviorReference = this;

			userControl = GetComponent<ThirdPersonUserControl>();
			startingConstraints = RigidbodyConstraints.FreezeRotation;
		}
		
		void Update () 
		{
			DebugPanel.Log("Forward: ", inForwardPosition);
			DebugPanel.Log("Backward: ", inBackwardPosition);
			// DebugPanel.Log("Tree: ", treeToCut);
			// DebugPanel.Log("Side: ", sideToCut);


			if (Input.GetButtonDown("Interact") && canSnapPlayer && !treeToCut.HasFallen())
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
					RotateAroundTree();
				}

				if (Input.GetAxis("Left Trigger") == 1)
				{
					SwingForward();
				}
				else if (Input.GetAxis("Right Trigger") == 1)
				{
					SwingBackward();
				}
			}
		}

		public void SetSnapInfo(bool canSnap) { canSnapPlayer = canSnap; }

		public void SetSnapInfo(TreeBehavior tree, Transform location, bool canSnap, int side)
		{
			treeToCut = tree;
			snapLocation = location;
			canSnapPlayer = canSnap;
			sideToCut = side;
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

		void RotateAroundTree()
		{
			if (transform.eulerAngles.y == 0) 
			{
				transform.position = new Vector3(transform.position.x - 2, 0 , transform.position.z);transform.eulerAngles = new Vector3(0, 180, 0);
			}
			else if (transform.eulerAngles.y == 90)
			{
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z + 2);
				transform.eulerAngles = new Vector3(0, 270, 0);
			}
			else if (transform.eulerAngles.y == 180)
			{
				transform.position = new Vector3(transform.position.x + 2, 0 , transform.position.z);
				transform.eulerAngles = new Vector3(0, 0, 0);
			}
			else if (transform.eulerAngles.y == 270)
			{
				transform.position = new Vector3(transform.position.x, 0 , transform.position.z - 2);
				transform.eulerAngles = new Vector3(0, 90, 0);
			}

			inForwardPosition = false;
			inBackwardPosition = true;
		}

		
		void SwingForward()
		{
			if (inBackwardPosition)
			{
				Debug.Log("Swing Forward");
				treeToCut.cutSide(sideToCut);
				inForwardPosition = true;
				inBackwardPosition = false;
			}
		}

		void SwingBackward()
		{
			if (inForwardPosition)
			{
				Debug.Log("Swing Backward");
				inBackwardPosition = true;
				inForwardPosition = false;
			}
		}
	}
}