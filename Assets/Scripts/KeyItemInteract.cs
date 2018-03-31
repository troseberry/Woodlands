using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Cameras;

public class KeyItemInteract : MonoBehaviour 
{
	public Canvas popupMenu;
	public GameObject[] generalElements;
	public GameObject[] elementsToDisable;
	private bool isMenuOpen = false;
	private bool canInteract = false;

	void Start () 
	{
		popupMenu.enabled = false;
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

	public bool IsMenuOpen() { return isMenuOpen; }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (name.Equals("Bed") && !TimeManager.IsInSleepTimeFrame()) return;

			canInteract = true;
			
			PlayerHud.SetInteractText(GetComponent<DisplayText>().displayText);
			PlayerHud.ToggleInteractPrompt();
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (name.Equals("Bed") && !TimeManager.IsInSleepTimeFrame()) return;

			canInteract = false;
			isMenuOpen = false;

			PlayerHud.ToggleInteractPrompt();
			CloseMenu();
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && !canInteract) 
		{
			if (name.Equals("Bed") && !TimeManager.IsInSleepTimeFrame()) return;

			canInteract = true;
			
			PlayerHud.SetInteractText(GetComponent<DisplayText>().displayText);
			PlayerHud.ToggleInteractPrompt();
		}
	}

	void OpenMenu()
	{	
		MenuManager.currentMenuManager.CloseAllCanvases();
		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(true);
		}

		for (int i = 0; i < elementsToDisable.Length; i++)
		{
			elementsToDisable[i].SetActive(false);
		}

	
		popupMenu.enabled = true;
		CharacterInputController.ToggleCameraInput(false);
		isMenuOpen = true;
	}

	public void CloseMenu()
	{
		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(false);
		}
		popupMenu.enabled = false;
		CharacterInputController.ToggleCameraInput(true);
		isMenuOpen = false;
	}
}
