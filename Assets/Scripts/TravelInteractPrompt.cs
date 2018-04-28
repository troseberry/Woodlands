using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TravelInteractPrompt : MonoBehaviour 
{
	private bool canInteract;
	private string triggerName;
	
	void Update () 
	{
		if (Input.GetButtonDown("Interact") && canInteract)
		{
			if (triggerName.Contains("Trigger"))
			{
				
				PlayerManager.currentSceneSaveHandler.SaveSceneData();
				StartCoroutine(SaveSceneAndTravel());
			}
			else
			{
				CallTravelMethod();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = true;
			triggerName = gameObject.name;

			PlayerHud.SetInteractText(GetComponent<DisplayText>().displayText);
			PlayerHud.ToggleInteractPrompt(true);
			
		}
	}

	public void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			canInteract = false;
			triggerName = "none";

			PlayerHud.ToggleInteractPrompt(false);
		}
	}

	IEnumerator SaveSceneAndTravel()
	{
		LoadingScreen.ToggleIsLoading(true);
		LoadingScreen.Instance.ToggleLoadingCanvas(true);

		yield return new WaitUntil( () => PlayerManager.currentSceneSaveHandler.HasFinishedSaving());
		yield return new WaitForSeconds(0.5f);

		CharacterInputController.ToggleCharacterInput(false);
		CharacterInputController.ToggleCameraInput(false);

		CallTravelMethod();
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