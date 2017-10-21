using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelInteractPrompt : MonoBehaviour 
{
	public Canvas uiPrompt;
	private bool isPromptVisible;
	private bool canInteract;

	private string triggerName;
	
	void Update () 
	{
		if (Input.GetButtonDown("Interact") && canInteract)
		{
			CallTravelMethod();
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = true;
			uiPrompt.enabled = true;
			triggerName = gameObject.name;
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = false;
			uiPrompt.enabled = false;
			triggerName = "none";
		}
	}

	void CallTravelMethod()
	{
		switch (triggerName)
		{
			case "ToHomesteadTrigger":
				SceneNavigation.ToHomestead();
				break;
			case "ToMainCabinTrigger":
				SceneNavigation.ToMainCabin();
				break;
			case "ToWorkshopTrigger":
				SceneNavigation.ToWorkshop();
				break;
			case "ToForestTrigger":
				SceneNavigation.ToForest();
				break;
			default:
				Debug.Log("No Valid Travel Scene");
				break;
		}
	}
}