using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour 
{
	private bool menuOpen = false;
	private Canvas menuCanvas;
	public GameObject optionsMenu;

	public GameObject mainMenuConfirm;
	public GameObject quitGameConfirm;

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
		MenuManager.currentMenuManager.CloseAllCanvases(false);
		menuCanvas.enabled = true;
		menuOpen = true;

		optionsMenu.SetActive(false);
		CloseMainMenuConfirm();
		CloseQuitGameConfirm();

		TimeManager.PauseGame();
	}

	public void CloseMenu()
	{
		menuCanvas.enabled = false;
		menuOpen = false;

		optionsMenu.SetActive(false);
		CloseMainMenuConfirm();
		CloseQuitGameConfirm();

		TimeManager.UnpauseGame();
	}

	public void SaveGame()
	{
		SaveLoad.Save();
	}

	public void OpenOptionsMenu()
	{
		optionsMenu.SetActive(true);
	}

	public void BackFromOptionsMenu()
	{
		optionsMenu.SetActive(false);
	}

	public void ReturnToMainMenu()
	{
		SaveLoad.Save();
		CloseMenu();		
		SceneManager.LoadScene("MainMenu");
	}

	public void OpenMainMenuConfirm()
	{
		mainMenuConfirm.SetActive(true);
		transform.GetChild(1).gameObject.SetActive(false);
	}

	public void CloseMainMenuConfirm()
	{
		mainMenuConfirm.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(true);
	}

	public void QuitGame()
	{
		SaveLoad.Save();
		CloseMenu();		
		Application.Quit();
	}

	public void OpenQuitGameConfirm()
	{
		quitGameConfirm.SetActive(true);
		transform.GetChild(1).gameObject.SetActive(false);
	}

	public void CloseQuitGameConfirm()
	{
		quitGameConfirm.SetActive(false);
		transform.GetChild(1).gameObject.SetActive(true);
	}
}