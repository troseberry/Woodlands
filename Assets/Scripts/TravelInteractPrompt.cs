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
				GameSceneNavigation.ToHomestead();
				break;
			case "ToMainCabinTrigger":
				GameSceneNavigation.ToMainCabin();
				break;
			case "ToWorkshopTrigger":
				GameSceneNavigation.ToWorkshop();
				break;
			case "ToForestTrigger":
				GameSceneNavigation.ToForest();
				break;
			case "ToLumberYardTrigger":
				GameSceneNavigation.ToLumberYard();
				break;
			case "ToTopFloor":
				GameSceneNavigation.ToTopFloor();
				break;
			case "ToBottomFloor":
				GameSceneNavigation.ToBottomFloor();
				break;
			default:
				Debug.Log("No Valid Travel Scene");
				break;
		}
	}
}