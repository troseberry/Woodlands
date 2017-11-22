using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour 
{
	public GameObject controlsGroup;
	public GameObject keyMapsGroup;
	public GameObject videoGroup;
	public GameObject audioGroup;
	public GameObject saveGroup;
	
	void CloseAllTabs()
	{
		controlsGroup.SetActive(false);
		keyMapsGroup.SetActive(false);
		videoGroup.SetActive(false);
		audioGroup.SetActive(false);
		saveGroup.SetActive(false);
	}

	public void OpenControlsOptions()
	{
		CloseAllTabs();
		controlsGroup.SetActive(true);
	}

	public void OpenKeyMapsOptions()
	{
		CloseAllTabs();
		keyMapsGroup.SetActive(true);
	}

	public void OpenVideoOptions()
	{
		CloseAllTabs();
		videoGroup.SetActive(true);
	}

	public void OpenAudioOptions()
	{
		CloseAllTabs();
		audioGroup.SetActive(true);
	}

	public void OpenSaveOptions()
	{
		CloseAllTabs();
		saveGroup.SetActive(true);
	}
}