using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class TreeBehavior : MonoBehaviour 
{
	
	private Transform snapLocation;
	private bool playerIsLocked;
	private bool canSnapPlayer;

	GameObject playerObj;
	private Transform playerTransform;
	private ThirdPersonUserControl userControl;

	private RigidbodyConstraints startingConstraints;

	void Start () 
	{
		
		playerObj = GameObject.FindGameObjectWithTag("Player");

		playerTransform = playerObj.transform;
		userControl = playerObj.GetComponent<ThirdPersonUserControl>();

		startingConstraints = RigidbodyConstraints.FreezeRotation;
	}
	
	void Update () 
	{
		if (canSnapPlayer && Input.GetButtonDown("Interact"))
		{
			if (!playerIsLocked)
			{
				SnapPlayer();
			}
			else
			{
				UnlockPlayer();
			}
		}

		if (playerIsLocked && (Input.GetKeyDown(KeyCode.R)) || Input.GetButtonDown("Right Bumper") || Input.GetButtonDown("Left Bumper"))
		{
			RotateAroundTree();
		}
		
		
	}

	public void SetSnapInfo(bool canSnap) { canSnapPlayer = canSnap; }

	public void SetSnapInfo(Transform location, bool canSnap)
	{
		snapLocation = location;
		canSnapPlayer = canSnap;
	}

	void SnapPlayer()
	{
		playerTransform.position = snapLocation.position;
		playerTransform.rotation = snapLocation.rotation;

		userControl.enabled = false;
		playerObj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

		playerIsLocked = true;
	}

	void RotateAroundTree()
	{
		if (playerTransform.eulerAngles.y == 0) 
		{
			playerTransform.position = new Vector3(playerTransform.position.x - 2, 0 , playerTransform.position.z);playerTransform.eulerAngles = new Vector3(0, 180, 0);
		}
		else if (playerTransform.eulerAngles.y == 90)
		{
			playerTransform.position = new Vector3(playerTransform.position.x, 0 , playerTransform.position.z + 2);
			playerTransform.eulerAngles = new Vector3(0, 270, 0);
		}
		else if (playerTransform.eulerAngles.y == 180)
		{
			playerTransform.position = new Vector3(playerTransform.position.x + 2, 0 , playerTransform.position.z);
			playerTransform.eulerAngles = new Vector3(0, 0, 0);
		}
		else if (playerTransform.eulerAngles.y == 270)
		{
			playerTransform.position = new Vector3(playerTransform.position.x, 0 , playerTransform.position.z - 2);
			playerTransform.eulerAngles = new Vector3(0, 90, 0);
		}

		
		Debug.Log("World + Local:" + (playerTransform.position + snapLocation.localPosition));
		Debug.Log("World - Local:" + (playerTransform.position - snapLocation.localPosition));
	}

	void UnlockPlayer()
	{
		userControl.enabled = true;
		playerObj.GetComponent<Rigidbody>().constraints = startingConstraints;

		playerIsLocked = false;
	}
}
