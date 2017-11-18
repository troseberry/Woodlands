using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	private bool menuOpen = false;
	private Canvas menuCanvas;

	void Start () 
	{
		menuCanvas = GetComponent<Canvas>();
		menuCanvas.enabled = false;
	}
	
	void Update () 
	{
		if (Input.GetButtonDown("Pause Menu"))
		{
			if (!menuOpen)
			{
				OpenMenu();
			}
			else
			{
				CloseMenu();
			}
		}
	}

	public void OpenMenu()
	{
		menuCanvas.enabled = true;
		menuOpen = true;
		TimeManager.PauseGame();
	}

	public void CloseMenu()
	{
		menuCanvas.enabled = false;
		menuOpen = false;
		TimeManager.UnpauseGame();
	}

	public void SaveGame()
	{
		SaveLoad.Save();
	}

	public void ReturnToMainMenu()
	{
		SaveLoad.Save();
		SceneManager.LoadScene("MainMenu");
	}

	public void QuitGame()
	{
		SaveLoad.Save();
		Application.Quit();
	}
}