﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class KeyItemInteract : MonoBehaviour 
{
	private FreeLookCam cameraControl;

	public GameObject popupMenu;
	public GameObject[] generalElements;
	private bool isMenuOpen = false;
	private bool canInteract = false;

	void Start () 
	{
		popupMenu.SetActive(false);
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
		if (other.tag == "Player") canInteract = true;
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			canInteract = false;
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
		popupMenu.SetActive(true);
		cameraControl.enabled = false;
		isMenuOpen = true;
	}

	void CloseMenu()
	{
		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(false);
		}
		popupMenu.SetActive(false);
		cameraControl.enabled = true;
		isMenuOpen = false;
	}
}
