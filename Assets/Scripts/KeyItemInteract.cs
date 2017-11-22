using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class KeyItemInteract : MonoBehaviour 
{
	private FreeLookCam cameraControl;

	public Canvas popupMenu;
	public Canvas interactPrompt;
	public GameObject[] generalElements;
	public GameObject[] elementsToDisable;
	private bool isMenuOpen = false;
	private bool canInteract = false;

	void Start () 
	{
		popupMenu.enabled = false;
		cameraControl = GameObject.Find("FreeLookCameraRig").GetComponent<FreeLookCam>();
	}
	
	void Update () 
	{
		if (canInteract && Input.GetButtonDown("Interact"))
		{
			if (!isMenuOpen) 
			{
				OpenMenu();
			}
			else 
			{
				CloseMenu();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			canInteract = true;
			interactPrompt.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			canInteract = false;
			interactPrompt.enabled = false;
			isMenuOpen = false;
			CloseMenu();
		}
	}

	void OpenMenu()
	{
		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(true);
		}

		for (int i = 0; i < elementsToDisable.Length; i++)
		{
			elementsToDisable[i].SetActive(false);
		}

	
		popupMenu.enabled = true;
		cameraControl.enabled = false;
		isMenuOpen = true;

		// Debug.Log("Camera Script: " + cameraControl.enabled);
	}

	public void CloseMenu()
	{
		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(false);
		}
		popupMenu.enabled = false;
		cameraControl.enabled = true;
		isMenuOpen = false;

		// Debug.Log("Camera Script: " + cameraControl.enabled);
	}
}
