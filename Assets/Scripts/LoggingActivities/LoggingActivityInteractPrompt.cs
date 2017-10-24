using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoggingActivityInteractPrompt : MonoBehaviour 
{
	public Canvas interactPrompt;
	private string grade;
	bool permenantlyDisabled = false;

	void Start () 
	{
		interactPrompt.enabled = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && !permenantlyDisabled) 
		{
			interactPrompt.enabled = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && !permenantlyDisabled) 
		{
			interactPrompt.enabled = false;
		}
	}

	public void HideUI()
	{
		permenantlyDisabled = true;
		interactPrompt.enabled = false;
	}
}