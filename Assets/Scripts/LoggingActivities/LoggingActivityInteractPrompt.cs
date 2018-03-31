 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoggingActivityInteractPrompt : MonoBehaviour 
{
	private string grade;
	bool permenantlyDisabled = false;

	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !permenantlyDisabled) 
		{
			PlayerHud.SetInteractText(GetComponent<DisplayText>().displayText);
			PlayerHud.SetInteractPrompt(true);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && !permenantlyDisabled) 
		{
			PlayerHud.SetInteractPrompt(false);
		}
	}

	public void HideUI()
	{
		permenantlyDisabled = true;
		PlayerHud.SetInteractPrompt(false);
	}
}