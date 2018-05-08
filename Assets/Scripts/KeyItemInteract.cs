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

	public GenericSnapSpot itemSnapSpot;

	void Start () 
	{
		popupMenu.enabled = false;
	}
	
	void Update () 
	{
		DebugPanel.Log("Bed - Can Interact: ", canInteract);
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
			PlayerHud.ToggleInteractPrompt(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player") 
		{
			canInteract = false;
			isMenuOpen = false;

			PlayerHud.ToggleInteractPrompt(false);
			CloseMenu();
		}
	}

	// Only used for the bed/sleep trigger
	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" && name.Equals("Bed"))
		{
			PlayerHud.SetInteractText(GetComponent<DisplayText>().displayText);
			PlayerHud.ToggleInteractPrompt(TimeManager.IsInSleepTimeFrame());
			canInteract = TimeManager.IsInSleepTimeFrame();
		}
	}

	void OpenMenu()
	{	
		if (itemSnapSpot) itemSnapSpot.SnapPlayer();

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
		if (itemSnapSpot) itemSnapSpot.UnsnapPlayer();

		for (int i = 0; i < generalElements.Length; i++)
		{
			generalElements[i].SetActive(false);
		}
		popupMenu.enabled = false;
		CharacterInputController.ToggleCameraInput(true);
		isMenuOpen = false;
	}
}
